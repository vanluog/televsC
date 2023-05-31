using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace televsC
{
    public class ketnoisql
    {
        static string strCon = @"Data Source=ALONE\SQLEXPRESS;Initial Catalog=quanliktx;Integrated Security=True";
        public static string timSV(string tenSv)
        {
            string kq = "";
            try
            {
                using (SqlConnection cn = new SqlConnection(strCon))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandText = "TIM_SV";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.Add("@tenSV", SqlDbType.NVarChar, 50).Value = tenSv;
                        object obj = cm.ExecuteScalar(); //lấy col1 of row1
                        if (obj != null)
                            kq = (string)obj;
                        else
                            kq = $"không có sv nào tên: {tenSv}";
                    }
                }
            }
            catch (Exception ex)
            {
                kq += $"Error: {ex.Message}";
            }
            return kq;
        }
    }

}