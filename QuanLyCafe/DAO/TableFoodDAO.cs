using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCafe.DTO;

namespace QuanLyCafe.DAO
{
    public class TableFoodDAO
    {
        private static TableFoodDAO instance;
        public static TableFoodDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new TableFoodDAO();
                return instance;
            }
            set
            {
                instance = value;
            }
        }

        private TableFoodDAO() { }

        public List<TableFood> GetList()
        {
            string query = "SELECT * FROM TableFood ORDER BY name ";

            var result = DataProvider.Instance.FillData(query);

            List<TableFood> list = new List<TableFood>();

            foreach (DataRow item in result.Rows)
            {
                list.Add(new TableFood(item));
            }

            return list;
        }

        public DataTable GetTable()
        {
            string query = "SELECT * FROM TableFood ORDER BY name ";
            
            return DataProvider.Instance.FillData(query);
        }

        public List<TableFood> GetList(int idTable)
        {
            // Lay danh sach cac table khac idTable
            string query = $"SELECT * FROM TableFood WHERE id <> {idTable} ORDER BY name ";

            var result = DataProvider.Instance.FillData(query);

            List<TableFood> list = new List<TableFood>();

            foreach (DataRow item in result.Rows)
            {
                list.Add(new TableFood(item));
            }

            return list;
        }

        public TableFood GetById(int idTable)
        {            
            string query = $"SELECT TOP 1 * FROM TableFood WHERE id = {idTable}";

            var result = DataProvider.Instance.FillData(query);

            if (result.Rows.Count > 0)
                return new TableFood(result.Rows[0]);

            return new TableFood();
        }
       
        // Lay bill chua thanh toan cua ban
        public Bill GetBill(int idTable)
        {
            string query = $"SELECT TOP 1 * FROM Bill WHERE id_table = {idTable} and status = 0 ";

            DataTable result = DataProvider.Instance.FillData(query, new object[] { idTable });    

            if (result.Rows.Count > 0)
                return new Bill(result?.Rows[0]);

            return new Bill();
        }

        public List<BillInfo> GetBillInfo(int idTable)
        {
            List<BillInfo> list = new List<BillInfo>();

            string query = $"EXEC USP_Table_Get_Bill_Info @id_table ";

            DataTable result = DataProvider.Instance.FillData(query, new object[] { idTable });
            foreach (DataRow item in result.Rows)
            {
                list.Add(new BillInfo(item));
            }

            return list;
        }

        public bool AddBillInfo(int idTable, int idFood, int quantity, int idUser)
        {
            string query = $" EXEC USP_Table_Add_Bill_Info @id_table , @id_food , @quantity , @id_user ";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idTable, idFood, quantity, idUser });
        }

        public bool Cancel(int idTable)
        {
            string query = $" EXEC USP_Table_Cancel_Bill @id_table ";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] {idTable});
        }

        public bool Change(int idTableFrom, int idTableTo)
        {
            string query = "EXEC USP_Table_Change_Bill @id_table_from , @id_table_to ";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idTableFrom, idTableTo });
        }

        public bool Merge(int idTableFrom, int idTableTo, int idUser)
        {
            string query = "EXEC USP_Table_Merge_Bill @id_table_from , @id_table_to , @id_user ";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idTableFrom, idTableTo, idUser });
        }

        public bool Payment(int idTable)
        {            
            string query = "EXEC USP_Table_Payment_Bill @id_table ";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idTable });
        }

        public int InsertOrUpdate(int idTable, string nameTable)
        {
            string query = "EXEC USP_Table_InsertOrUpdate @id , @name ";
            return (int) DataProvider.Instance.ExecuteScalar(query, new object[] {idTable, nameTable});
        }
        public int Delete(int idTable)
        {
            string query = "EXEC USP_Table_Delete @id ";
            return (int) DataProvider.Instance.ExecuteScalar(query, new object[] { idTable });
        }
    }
}
