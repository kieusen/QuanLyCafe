using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCafe.DTO
{
    public class BillInfo
    {
        public string IdBill { get; set; }
        public int IdFood { get; set; }                
        public int Quantity { get; set; }       

        public decimal Price { get; set; }

        public string NameFood { get; private set; }
        public decimal Amount { get; private set; }

        public BillInfo()
        {
        }

        public BillInfo(DataRow data)
        {
            IdBill = data["id_bill"].ToString();
            NameFood = data["name_food"].ToString();

            int.TryParse(data["id_food"].ToString(), out int intValue);
            IdFood = intValue;
            int.TryParse(data["quantity"].ToString(), out intValue);
            Quantity = intValue;
         
            decimal.TryParse(data["price"].ToString(), out decimal price);
            Price = price;

            Amount = Quantity * Price;
        }
    }
}
