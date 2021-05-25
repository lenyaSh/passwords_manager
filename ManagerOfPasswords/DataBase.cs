using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace ManagerOfPasswords {
    /// <summary>
    /// class for easy working with database
    /// </summary>
    public class DataBase {
        private string connectionString;
        private NpgsqlConnection connection;
        private readonly string usernameDB, passwordDB;

        public DataBase(string usernameDB, string passwordDB) {
            this.usernameDB = usernameDB;
            this.passwordDB = passwordDB;
            connectionString = $"Host=localhost;Username={usernameDB};Password={passwordDB}";
        }

        /// <summary>
        /// Try to add new account for user
        /// </summary>
        /// <param name="user_id">id user from db</param>
        /// <param name="name_site">url entered from user</param>
        /// <param name="login">login on entered web site</param>
        /// <returns></returns>
        public UInt16 AddNewAccount(int user_id, string name_site, string login) {
            UInt16 account_exists = CheckExistsAccount(name_site, login);
            if (account_exists == 0) {
                try {
                    int site_id = CheckExistsSite(name_site);

                    if(site_id == -1) {
                        throw new Exception("Ошибка с проверкой сайтов");
                    }




                }
                catch (Exception ex) {
                    
                }
            }
            else return 1;
        }

        private int CheckExistsSite(string url) {
            try {
                using var check_account_cmd = new NpgsqlCommand(
                                           @"select id from sites where url = @url;", connection);
                check_account_cmd.Parameters.AddWithValue("url", url);

                using (NpgsqlDataReader result = check_account_cmd.ExecuteReader()) {
                    if (result.HasRows)
                        return result.GetInt32(0);
                }

                return AddNewSite(url);
            }
            catch (Exception ex) {
                return -1;
            }
        }

        private int AddNewSite(string url) {
            try {
                using var new_site_cmd = new NpgsqlCommand(
                                           @"insert into sites (url) values (@url) returning id;", connection);
                new_site_cmd.Parameters.AddWithValue("login", url);

                using (NpgsqlDataReader result = new_site_cmd.ExecuteReader()) {
                    if (result.HasRows)
                        return result.GetInt32(0);

                    else
                        throw new Exception();
                }
            }
            catch(Exception ex) {
                return -1;
            }
        }

        /// <summary>
        /// Check existing user with entered values
        /// </summary>
        /// <param name="name_site">url entered user</param>
        /// <param name="login">login in entered sites</param>
        /// <returns>0 - not exists
        /// 1 - exists
        /// 2 - error</returns>
        private UInt16 CheckExistsAccount(string name_site, string login) {
            try {
                using var check_account_cmd = new NpgsqlCommand(
                                           @"select login from accounts
                                             join sites on id_site = sites.id and sites.url = @name_site and login = @login;", connection);
                check_account_cmd.Parameters.AddWithValue("login", login);
                check_account_cmd.Parameters.AddWithValue("name_site", name_site);

                using NpgsqlDataReader result = check_account_cmd.ExecuteReader(); if (result.HasRows)
                    return 1;

                return 0;
            }
            catch (Exception ex) {
                return 2;
            }
        }

        /// <summary>
        /// Gets accounts list
        /// </summary>
        /// <param name="accounts">List of objects class Account, storage all field</param>
        /// <param name="user_id">Need for sql request</param>
        /// <returns></returns>
        public bool GetAccountsList(List<Account> accounts, int user_id) {
            try {
                using var get_accounts_cmd = new NpgsqlCommand(
                @"select url, login, password, create_date, change_date from accounts
                  join sites on sites.id = accounts.id_site
                  join user_account on user_account.id_account = accounts.id and user_account.id_user = @user_id;", connection);
                get_accounts_cmd.Parameters.AddWithValue("user_id", user_id);

                using (var reader = get_accounts_cmd.ExecuteReader()) {
                    if (reader.HasRows) {
                        while (reader.Read()) {
                            accounts.Add(new Account(reader.GetString(0), reader.GetString(1), reader.GetString(2),
                                reader.GetDateTime(3), reader.GetDateTime(4)));
                        }
                        return true;
                    }
                }
                return false;

            }
            catch (Exception ex) {
                // TODO: ошибка при получении списка сайтов
                return false;
            }
        }

        public bool RegisterNewUser(string login, string password) {
            try {
                using (NpgsqlDataReader result = CheckExistsUser(login, password)) {
                    result.Read();

                    if (result.HasRows) {
                        // TODO: придумать, что делать с исключениями
                        throw new Exception("Вы ввели существующие логин и пароль.");
                    }
                }

                using var new_user_cmd = new NpgsqlCommand(
                                            @"insert into users (login, password) values (@login,  @password)", connection);
                new_user_cmd.Parameters.AddWithValue("login", login);
                new_user_cmd.Parameters.AddWithValue("password", password);

                new_user_cmd.ExecuteNonQuery();

                return true;

            }
            catch (Exception ex) {
                return false;
            }
        }

        public NpgsqlDataReader CheckExistsUser(string login, string password) {
            using var check_user_cmd = new NpgsqlCommand(
               @"select id from users where login=@login and password=@password;", connection);
            check_user_cmd.Parameters.AddWithValue("login", login);
            check_user_cmd.Parameters.AddWithValue("password", password);
            return check_user_cmd.ExecuteReader();
        }

        /// <summary>
        /// Make request for search user with login and password
        /// </summary>
        /// <param name="login">login entered by the user</param>
        /// <param name="password">password entered by the user</param>
        /// <returns></returns>
        public int Login(string login, string password) {
            try {
                using NpgsqlDataReader result = CheckExistsUser(login, password); result.Read();
                if (result.HasRows) {
                    return result.GetInt32(0);
                }
                else {
                    throw new Exception("Неверный логин или пароль");
                }
            }
            catch (Exception ex) {
                // TODO: обработать ошибку во время входа
                return -1;
            }
        }

        private void ConnectToPostgres() {
            connection = new NpgsqlConnection(connectionString);
            connection.Open();
        }

        /// <summary>
        /// trying connecting with DB and creating all tables
        /// </summary>
        /// <returns>true if succesfully connected</returns>
        public bool ConnectToDB() {
            try {
                ConnectToPostgres();

                using var createdb_cmd = new NpgsqlCommand("select datname from pg_database", connection);
                bool db_is_created = false;

                using (NpgsqlDataReader database_names = createdb_cmd.ExecuteReader()) {
                    while (database_names.Read()) {
                        if (database_names.GetString(0) == "pswd_manager") {
                            db_is_created = true;
                            break;
                        }
                    }
                }


                if (!db_is_created) {
                    using var sql_cmd = new NpgsqlCommand("create database pswd_manager", connection);
                    sql_cmd.ExecuteNonQuery();
                }

                connection.Close();
                connectionString = $"Host=localhost;Username={usernameDB};Password={passwordDB};Database=pswd_manager";
                connection = new NpgsqlConnection(connectionString);
                connection.Open();
                CreateAllTables();

                return true;
            }
            catch (Exception ex) {
                // TODO: обработка неподключения к бд (вернуть в гуи сообщение и вывести его на экран)
                CloseConnection();
                return false;
            }
        }

        /// <summary>
        /// Create 3 tables: users, sites and accounts
        /// </summary>
        private void CreateAllTables() {
            var sql_create_table = new NpgsqlCommand(@"CREATE table if not exists users(
                                    	id serial UNIQUE  primary key,
	                                    login varchar(50) not null,
	                                    password varchar(50) not null
                                        )",
                                        connection);

            sql_create_table.ExecuteNonQuery();

            sql_create_table = new NpgsqlCommand(@"CREATE table if not exists sites(
                                    	id serial UNIQUE  primary key,
                                        url varchar(100) not null unique
                                        )",
                                        connection);

            sql_create_table.ExecuteNonQuery();

            sql_create_table = new NpgsqlCommand(@"create table if not exists accounts(
                                                   id_user integer not null,
                                                   id_site integer not null,
                                                   login varchar(50) not null,
                                                   password varchar(100) not null
                                                )",
                                        connection);

            sql_create_table.ExecuteNonQuery();
        }

        private void CloseConnection() {
            connection.Close();
            connection.Dispose();
        }

    }
}
