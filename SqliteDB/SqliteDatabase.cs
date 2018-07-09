using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace SqliteDB
{
    public class SqliteDatabase
    {
        private readonly string _file;

        public SqliteDatabase(string fullFileName)
        {
            _file = fullFileName;
        }

        public string CreateNewDataBase()
        {
            SQLiteConnection.CreateFile(Path.GetFullPath(_file));
            using (var dataBaseConnection = new SQLiteConnection("Data Source=" + Path.GetFullPath(_file)))
            {
                using (var sqlCommand = new SQLiteCommand())

                {
                    dataBaseConnection.Open();
                    sqlCommand.Connection = dataBaseConnection;

                    sqlCommand.CommandText = "CREATE TABLE  [Alias]  (id INTEGER PRIMARY KEY AUTOINCREMENT, aliases TEXT UNIQUE, paths TEXT)";
                    sqlCommand.ExecuteNonQuery();

                    sqlCommand.CommandText = "CREATE TABLE  [IP]  (id INTEGER PRIMARY KEY AUTOINCREMENT, ips TEXT  UNIQUE)";
                    sqlCommand.ExecuteNonQuery();
                }
                return "Status:  Database creted " + Path.GetFileName(_file) + "\n\r" + " Connection open!";
            }
        }


        public string AddNewItems(string aliasItem, string pathItem)
        {
            using (var dataBaseConnection = new SQLiteConnection("Data Source=" + Path.GetFullPath(_file)))
            {
                using (var sqlCommand = new SQLiteCommand())
                {
                    dataBaseConnection.Open();
                    if (dataBaseConnection.State == ConnectionState.Open)
                    {
                        sqlCommand.Connection = dataBaseConnection;
                        sqlCommand.Parameters.AddWithValue("@aliases", aliasItem);
                        sqlCommand.Parameters.AddWithValue("@paths", pathItem);
                        sqlCommand.CommandText = "INSERT INTO  [Alias]   (aliases, paths)" + "VALUES (@aliases, @paths);";
                        sqlCommand.ExecuteNonQuery();
                    }
                }
                return "Status: Item " + "\n\r" + " " + aliasItem + " was saved.";
            }
        }

        public string AddNewItems(string ipItem)
        {
            using (var dataBaseConnection = new SQLiteConnection("Data Source=" + Path.GetFullPath(_file)))
            {
                using (var sqlCommand = new SQLiteCommand())
                {
                    dataBaseConnection.Open();
                    sqlCommand.Connection = dataBaseConnection;
                    sqlCommand.Parameters.AddWithValue("@ips", ipItem);
                    sqlCommand.CommandText = "INSERT INTO  [IP]  (ips)" + "VALUES (@ips);";
                    sqlCommand.ExecuteNonQuery();
                }
                return "Status: Item " + "\n\r" + " " + ipItem + " was saved.";
            }
        }

        public string DeleteIp(string ipItem)
        {
            using (var dataBaseConnection = new SQLiteConnection("Data Source=" + Path.GetFullPath(_file)))
            {
                using (var sqlCommand = new SQLiteCommand())
                {
                    dataBaseConnection.Open();
                    sqlCommand.Connection = dataBaseConnection;
                    sqlCommand.Parameters.AddWithValue("@ips", ipItem);

                    sqlCommand.CommandText = "DELETE FROM  [IP]  WHERE [ips] = @ips";
                    sqlCommand.ExecuteNonQuery();
                }
                return "Status: Item " + "\n\r" + " " + ipItem + " was deleted.";
            }
        }

        public string DeleteAlias(string aliasItem)
        {
            using (var dataBaseConnection = new SQLiteConnection("Data Source=" + Path.GetFullPath(_file)))
            {
                using (var sqlCommand = new SQLiteCommand())
                {
                    dataBaseConnection.Open();
                    sqlCommand.Connection = dataBaseConnection;
                    sqlCommand.Parameters.AddWithValue("@aliases", aliasItem);
                    sqlCommand.CommandText = "DELETE FROM  [Alias]  WHERE [aliases] = @aliases";
                    sqlCommand.ExecuteNonQuery();
                }

                return "Status: Item " + "\n\r" + " " + aliasItem + " was deleted.";
            }
        }

        public string RenameAlias(string aliasOld, string aliasNew, string pathItem)
        {
            using (var dataBaseConnection = new SQLiteConnection("Data Source=" + Path.GetFullPath(_file)))
            {
                using (var sqlCommand = new SQLiteCommand())
                {
                    dataBaseConnection.Open();
                    sqlCommand.Connection = dataBaseConnection;
                    sqlCommand.Parameters.AddWithValue("@aliases", aliasOld);
                    sqlCommand.CommandText = "DELETE FROM [Alias] WHERE [aliases] = @aliases";
                    sqlCommand.ExecuteNonQuery();


                    sqlCommand.Parameters.AddWithValue("@aliases", aliasNew);
                    sqlCommand.Parameters.AddWithValue("@paths", pathItem);
                    sqlCommand.CommandText = "INSERT INTO [Alias] (aliases, paths) VALUES (@aliases, @paths);";
                    
                    sqlCommand.ExecuteNonQuery();
                }
                return "Status: Item " + "\n\r" + " " + aliasOld + " was remaned." + "\n\r" + " by " + aliasNew;
            }
        }

        public object LoadIp()
        {
            using (var dataBaseConnection = new SQLiteConnection("Data Source=" + Path.GetFullPath(_file)))
            {
                using (var sqlCommand = new SQLiteCommand())
                {
                    dataBaseConnection.Open();
                    sqlCommand.Connection = dataBaseConnection;
                    sqlCommand.CommandText = "SELECT * FROM [IP];";
                    var collectionIp = new List<string>();
                    using (SQLiteDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            collectionIp.Add(Convert.ToString(reader["ips"]));
                        }
                    }

                    return collectionIp;
                }
            }
        }


        public object LoadAlias()
        {
            using (var dataBaseConnection = new SQLiteConnection("Data Source=" + Path.GetFullPath(_file)))
            {
                using (var sqlCommand = new SQLiteCommand())
                {
                    dataBaseConnection.Open();
                    sqlCommand.Connection = dataBaseConnection;
                    sqlCommand.CommandText = "SELECT * FROM [Alias];";
                    var collectionAlias = new Dictionary<string, string>();

                    using (SQLiteDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            collectionAlias.Add(Convert.ToString(reader["aliases"]), Convert.ToString(reader["paths"]));
                        }
                    }
                    return collectionAlias;
                }
            }
        }

        public object AliasList()
        {
            using (var dataBaseConnection = new SQLiteConnection("Data Source=" + Path.GetFullPath(_file)))
            {
                using (var sqlCommand = new SQLiteCommand())
                {
                    dataBaseConnection.Open();
                    sqlCommand.Connection = dataBaseConnection;
                    sqlCommand.CommandText = "SELECT * FROM [Alias];";
                    var aliasList = new List<string>();

                    using (SQLiteDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            aliasList.Add(Convert.ToString(reader["aliases"]));
                        }
                    }

                    return aliasList;
                }
            }
        }

        public string GetAliasPath(string aliasName)
        {
            using (var dataBaseConnection = new SQLiteConnection("Data Source=" + Path.GetFullPath(_file)))
            {
                using (var sqlCommand = new SQLiteCommand())
                {
                    dataBaseConnection.Open();
                    sqlCommand.Connection = dataBaseConnection;
                    sqlCommand.Parameters.AddWithValue("@aliases", aliasName);
                    sqlCommand.CommandText = "SELECT paths FROM [Alias] WHERE aliases = @aliases;";

                    using (SQLiteDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return Convert.ToString(reader[0]);
                        }
                        throw new AliasNotExistExeption("Alias not exist already. ");
                    }
                }
            }
        }
    }
}