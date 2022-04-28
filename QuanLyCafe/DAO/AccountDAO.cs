using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using QuanLyCafe.DTO;

namespace QuanLyCafe.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new AccountDAO();
                return instance;
            }
            private set { instance = value; }
        }
        private AccountDAO(){}

        public bool Login(string userName, string password)
        {
            string pw = Encrypt(password);
            string query = " EXEC USP_User_Login @user_name , @password ";

            var result = DataProvider.Instance.ExecuteReader(query, new object[] {userName, pw});

            return result;               
        }

        public Account GetAccountByUserName(string userName)
        {
            string query = $"SELECT * FROM Account WHERE user_name = '{userName}'";

            var result = DataProvider.Instance.FillData(query, new object[] {userName});

            return new Account(result.Rows[0]);
        }

        public string Encrypt(string value)
        {
            using(MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                //Hash data 
                byte[] data = md5.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        }

        public bool UpdateInfo(int idUser, string displayName)
        {
            string query = $"UPDATE Account SET display_name = N'{displayName}' WHERE id = {idUser} ";
            return DataProvider.Instance.ExecuteNonQuery(query);
        }
        public bool ChangePass(int idUser, string password)
        {
            string pw = Encrypt(password);
            string query = $"UPDATE Account SET password = '{pw}' WHERE id = {idUser} ";
            return DataProvider.Instance.ExecuteNonQuery(query);
        }

        public DataTable GetTable()
        {
            string query = @"SELECT id, user_name, display_name, type ,
                                    CASE 
                                      WHEN type = 1 THEN 'Admin'
                                      ELSE 'User'
                                    END AS name_type    
                             FROM Account 
                             ORDER BY user_name ";
            return DataProvider.Instance.FillData(query);
        }

        public int Insert(string userName, string displayName, int type)
        {
            string pass = Encrypt("1");
            string query = $@"INSERT INTO Account(user_name, display_name, password, type)
                              VALUES ('{userName}', N'{displayName}', '{pass}', {type})
                              SELECT SCOPE_IDENTITY() AS Id ";
            return Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query));
        }

        public bool Update(int id, string displayName, int type)
        {
            string query = $@"UPDATE Account 
                              SET display_name = N'{displayName}', type = {type} 
                              WHERE id = {id}";
            return DataProvider.Instance.ExecuteNonQuery(query);
        }

        public bool Delete(int id)
        {
            string query = $"DELETE FROM Account WHERE id = {id} ";
            return DataProvider.Instance.ExecuteNonQuery(query);
        }

        public bool ResetPass(int id)
        {
            string pass = Encrypt("1");
            string query = $@"UPDATE Account 
                              SET password = '{pass}'
                              WHERE id = {id}";
            return DataProvider.Instance.ExecuteNonQuery(query);
        }

        public bool Used(int id)
        {
            string query = $"SELECT TOP 1 id FROM Bill WHERE id_user = {id}";
            string id_bill = Convert.ToString(DataProvider.Instance.ExecuteScalar(query));
            return !string.IsNullOrEmpty(id_bill);
        }
    }
}
