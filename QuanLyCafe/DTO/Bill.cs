using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCafe.DTO
{
    public class Bill
    {
        public string Id { get; set; }
        public DateTime DateCheckIn { get; set; }
        public DateTime DateCheckOut { get; set; }
        public int Status { get; set; }
        public int Discount { get; set; }
        public int IdTable { get; set; }
        public int IdUser { get; set; }

        public Bill()
        {
        }

        public Bill(DataRow data)
        {
            Id = data["id"].ToString();

            DateTime.TryParse(data["date_check_in"].ToString(), out DateTime dateValue);
            DateCheckIn = dateValue;

            DateTime.TryParse(data["date_check_out"].ToString(), out dateValue);
            DateCheckOut = dateValue;

            int.TryParse(data["status"].ToString(), out int intValue);
            Status = intValue;

            int.TryParse(data["discount"].ToString(), out intValue);
            Discount = intValue;

            int.TryParse(data["id_table"].ToString(), out intValue);
            IdTable = intValue;

            int.TryParse(data["id_user"].ToString(), out intValue);
            IdUser = intValue;
        }
    }
}
