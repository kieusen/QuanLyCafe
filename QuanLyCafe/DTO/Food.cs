using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCafe.DTO
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdCategory { get; set; }
        public decimal Price { get; set; }

        public string NameCate { get; private set; }

        public Food()
        {
        }

        public Food(DataRow data)
        {             
            int.TryParse(data["id"].ToString(), out int intValue);
            Id = intValue;

            int.TryParse(data["id_category"].ToString(), out intValue);
            IdCategory = intValue;
            
            decimal.TryParse(data["price"].ToString(), out decimal price);
            Price = price;

            Name = data["name"].ToString();
            NameCate = data["name_cate"].ToString();    
        }
    }
}
