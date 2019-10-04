using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateSQLiteTables.Util
{
    public static class SQLiteExecutter
    {
        /// <summary>
        /// Método que cria os comandos
        /// </summary>
        /// <param name="caminho_bd"></param>
        /// <returns>true - Comandos criados com sucesso; False - erro ao criar</returns>
        public static bool CreateCommands(string caminho_bd)
        {
            Util.CL_Files.WriteOnTheLog("SQLiteExecutter.CreateCommands", Global.TipoLog.DETALHADO);

            try
            {
                if (!AbrirConexao(caminho_bd))
                {
                    return false;
                }

                StringBuilder result = new StringBuilder();
                result.Append(string.Empty);

                List<string> tables = new List<string>();
                CreatesTables(ref result, ref tables);

                foreach (string table in tables)
                {
                    GenerateInserts(table, ref result);
                }

                EscreveSaida(result);
            }
            catch(Exception e)
            {
                Util.CL_Files.WriteOnTheLog("Error: " + e.Message, Global.TipoLog.SIMPLES);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Método que abre a conexão com o banco de dados 
        /// </summary>
        /// <param name="caminho_bd">Caminho do banco de dados</param>
        /// <returns>True - A conexão foi aberta com sucesso; False - Houve erro para abrir a conexão</returns>
        private static bool AbrirConexao(string caminho_bd)
        {
            Util.CL_Files.WriteOnTheLog("SQLiteExecutter.AbrirConexao", Global.TipoLog.DETALHADO);

            try
            {
                return Util.DataBase.OpenConnection(caminho_bd);
            }
            catch (Exception e)
            {
                Util.CL_Files.WriteOnTheLog("Error: " + e.Message, Global.TipoLog.SIMPLES);
                return false;
            }
        }

        /// <summary>
        /// Método que preenche os inserts das tabelas do banco de dados
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private static bool CreatesTables( ref StringBuilder result, ref List<string> tabelas)
        {
            Util.CL_Files.WriteOnTheLog("SQLiteExecutter.CreatesTables", Global.TipoLog.DETALHADO);

            try
            {
                result.Append(string.Empty);
                tabelas = new List<string>();

                string sentenca = "SELECT TYPE, NAME, TBL_NAME, ROOTPAGE, SQL FROM sqlite_master WHERE TYPE='table'";
                SQLiteDataReader reader = Util.DataBase.Select(sentenca);

                while (reader.Read())
                {
                    result.Append(reader["SQL"].ToString() + ";\n");

                    tabelas.Add(reader["TBL_NAME"].ToString());
                }
            }
            catch (Exception e)
            {
                Util.CL_Files.WriteOnTheLog("Error: " + e.Message, Global.TipoLog.SIMPLES);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Método que gera os inserts da tabela
        /// </summary>
        /// <param name="tabela">Tabela a ser gerada o insert</param>
        /// <param name="result"></param>
        /// <returns></returns>
        private static bool GenerateInserts(string tabela, ref StringBuilder result)
        {
            Util.CL_Files.WriteOnTheLog("SQLiteExecutter.GenerateInserts", Global.TipoLog.DETALHADO);

            try
            {
                result.Append(string.Empty);
                SQLiteDataReader reader = Util.DataBase.Select("PRAGMA table_info(" + tabela + ")");
                string sentenca = "INSERT INTO " + tabela + " (";
                string colunas = "";
                bool first = true;

                while (reader.Read())
                {
                    colunas += first ? reader["NAME"].ToString() : ", " + reader["NAME"].ToString();
                    first = false;
                }
                reader.Close();
                sentenca += colunas + ") VALUES (";

                reader = Util.DataBase.Select("SELECT " + colunas + " FROM " + tabela);

                string linha = "", _base = sentenca;
                sentenca = "";
                while (reader.Read())
                {
                    first = true;
                    linha = "";
                    string[] valores = colunas.Split(',');
                    foreach (string col in valores)
                    {
                        linha += first ? "'" + reader[col.Trim()].ToString() + "'" : ", '" + reader[col.Trim()].ToString() + "'";
                        first = false;
                    }
                    sentenca += _base + linha + ");\n";
                }
                result.Append(sentenca);
            }
            catch (Exception e)
            {
                Util.CL_Files.WriteOnTheLog("Error: " + e.Message, Global.TipoLog.SIMPLES);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Método que escreve em arquivo a saída do sistema
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private static bool EscreveSaida(StringBuilder result)
        {
            Util.CL_Files.WriteOnTheLog("SQLiteExecutter.EscreveSaida", Global.TipoLog.DETALHADO);

            try
            {
                CL_Files arquivo = new CL_Files(Global.app_out_directory + "comandos_sql.sql");
                arquivo.WriteOnTheEnd(result.ToString());
            }
            catch (Exception e)
            {
                Util.CL_Files.WriteOnTheLog("Error: " + e.Message, Global.TipoLog.SIMPLES);
                return false;
            }

            return true;
        }

    }
}
