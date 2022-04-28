using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCafe.DTO;

namespace QuanLyCafe.DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;
        public static BillInfoDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new BillInfoDAO();
                return instance;
            }
            set
            {
                instance = value;
            }
        }

        private BillInfoDAO() { }
        public bool Delete(string idBill, int idFood)
        {
            string query = $"EXEC USP_Bill_Info_Delete @id_bill , @id_food";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] {idBill, idFood});
        }

        public bool UpdateQty(string idBill, int idFood, int qty)
        {
            string query = $"UPDATE BillInfo SET quantity = {qty} WHERE id_bill = '{idBill}' AND id_food = {idFood}";
            return DataProvider.Instance.ExecuteNonQuery(query);
        }

        public DataTable GetByBill(string idBill)
        {
            string query = @"EXEC USP_Bill_Info @id_bill ";
            return DataProvider.Instance.FillData(query, new object[] {idBill});
        }
    }
}
