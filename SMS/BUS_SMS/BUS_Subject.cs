using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_SMS;
using System.Data;

namespace BUS_SMS
{
    public class BUS_Subject
    {
        DAL_Subject daSubject = new DAL_Subject();
        public DataTable getSubject(string id)
        {
            return daSubject.getSubject(id);
        }
        public bool insertSubject(string id, string SubjectName, string SubjectMark)
        {
            return daSubject.insertSubject(id, SubjectName, SubjectMark);
        }
    }
}