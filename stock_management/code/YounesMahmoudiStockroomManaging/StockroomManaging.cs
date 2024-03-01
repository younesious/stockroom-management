using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;

namespace YounesMahmoudiStockroomManaging
{
    
    class StockroomManaging
    {
        SqlConnection cnct = new SqlConnection();
      
        public  StockroomManaging(string con)
        {
            cnct.ConnectionString = con;
        }
        public DataTable ReturnInformation(string srchstr, string typesrch)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            
            if (typesrch == "Code")
                cmd.CommandText = "Select * from TableStockroom where Code like '%" + srchstr + "%'";
            else
                cmd.CommandText = "Select * from TableStockroom where Name like '%" + srchstr + "%'";
            cmd.Connection = cnct;
            cnct.Open();
            da.SelectCommand = cmd;
            da.Fill(dt);
            cnct.Close();

            return dt;
        }
        public void Add_New_Part(string code, string name, string count,string price)
        {
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = "Insert into TableStockroom (Code, Name, Count, Price) values ( @p1, @p2, @p3, @p4)";
            cmd1.Parameters.AddWithValue("p1", code);
            cmd1.Parameters.AddWithValue("p2", name);
            cmd1.Parameters.AddWithValue("p3", count);
            cmd1.Parameters.AddWithValue("p4", price);
            cmd1.Connection = cnct;
            cnct.Open();
            cmd1.ExecuteNonQuery();
            cnct.Close();
        }
        public void Edit_Part(string count,string code,string price)
        {
            SqlCommand cmd2 = new SqlCommand();
            cmd2.CommandText = "Update TableStockroom set Count = @p1,Price = @p2 where Code = @p4";
            cmd2.Parameters.AddWithValue("p1", count);
            cmd2.Parameters.AddWithValue("p2", price);
            cmd2.Parameters.AddWithValue("p4", code);
            cmd2.Connection = cnct;
            cnct.Open();
            cmd2.ExecuteNonQuery();
            cnct.Close();
        }
        public void Delete_Part(string code)
        {
            SqlCommand cmd3 = new SqlCommand();
            cmd3.CommandText = "Delete from TableStockroom where Code = @p1";
            cmd3.Parameters.AddWithValue("p1", code);
            cmd3.Connection = cnct;
            cnct.Open();
            cmd3.ExecuteNonQuery();
            cnct.Close();
        }
        public bool Check_Code(string code)
        {
            SqlCommand cmd4 = new SqlCommand();
            bool b = false;
            cmd4.CommandText = "Select * from TableStockroom";
            cmd4.Connection = cnct;
            cnct.Open();
            SqlDataReader rd = cmd4.ExecuteReader();
            while(rd.Read())
            { 
                int i = 0;
                if(rd[i].ToString() == code)
                {
                    b = true;
                    break;
                }
                i++;
            }
            cnct.Close();
            return b;
        }
    }
}
