using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCafe.DTO
{
    public class TableFood
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }

        public TableFood()
        {
        }

        public TableFood(DataRow data)
        {
            int.TryParse(data["id"].ToString(), out int intValue);
            Id = intValue;

            int.TryParse(data["status"].ToString(), out intValue);
            Status = intValue;

            Name = data["name"].ToString();
        }
    }
}
