using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL_SMS
{
    public class DAL_Subject:DBConnection
    {
        public DataTable getSubject(string id)
        {
            string str = string.Format("select * from Subject where id='{0}'", id);
            SqlDataAdapter da = new SqlDataAdapter(str, con);
            DataTable daSubject = new DataTable();
            da.Fill(daSubject);
            daSubject.Columns.Add("Ord");
            for (int i = 1; i <= daSubject.Rows.Count; i++)
                daSubject.Rows[i - 1]["Ord"] = i.ToString();
            return daSubject;

        }
        public bool insertSubject(string id, string SubjectName, string SubjectMark)
        {
            string str = string.Format("insert into Subject(id, Subject_name, Subject_mark) values('{0}','{1}','{2}')", id, SubjectName, SubjectMark);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            con.Close();
            return true;
        }
    }
}
