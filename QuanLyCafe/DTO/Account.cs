using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCafe.DTO
{
    public class Account
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public int Type { get; set; }
        public Account()
        {
            
        }

        public Account(DataRow data)
        {
            int.TryParse(data["id"].ToString(), out int intValue);
            Id = intValue;

            int.TryParse(data["type"].ToString(), out intValue);
            Type = intValue;

            UserName = data["user_name"].ToString();
            Password = data["password"].ToString();
            DisplayName = data["display_name"].ToString();
        }
    }
}
