using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_SMS;
using System.Data;

namespace GUI_SMS
{
    public partial class GUI_Subject : Form
    {
        BUS_Student busStudent = new BUS_Student();
        BUS_Subject busSubject = new BUS_Subject();
        bool tf, tf1;
        DataTable dtbStudent;
        public GUI_Subject()
        {
            InitializeComponent();
            tf = tf1 = true;
            Lock_Unlock(tf);
            Lock_Unlock1(tf1);
            dtbStudent = busStudent.getStudent();
        }
        void Lock_Unlock(bool tf)
        {
            btnNew.Enabled = tf;
            btnAdd.Enabled = txtSubjectMark.Enabled = txtSubjectName.Enabled = !tf;
        }
        void Lock_Unlock1(bool tf1)
        {
            dgvSubject.Enabled = tf1;
            btnDelete.Enabled = btnUpdate.Enabled = txtSubjectMark.Enabled = txtSubjectName.Enabled = !tf1;
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            if (tf1)
            {
                tf = !tf;
                Lock_Unlock(tf);
                txtSubjectName.Text = txtSubjectMark.Text = "";
                txtSubjectName.Focus();
            }
            else MessageBox.Show("Updating or Deleting!\nClick Reset to do another thing.", "Information");

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (txtSubjectName.Text != "" && txtSubjectMark.Text != "")
            {
                string id = dtbStudent.Rows[int.Parse(cmbStudentName.SelectedIndex.ToString())]["id"].ToString();

                if (busSubject.insertSubject(id, txtSubjectName.Text, txtSubjectMark.Text))
                {
                    MessageBox.Show("Insert successful.", "Information");
                    tf = !tf;
                    Lock_Unlock(tf);
                    txtSubjectName.Text = txtSubjectMark.Text = "";
                    dgvSubject.DataSource = busSubject.getSubject(id);
                }
                else
                {
                    MessageBox.Show("Insert fail!", "Information");
                }
            }
            else
            {
                MessageBox.Show("Subject Name or Mark is empty!\nInput data again.", "Information");
                txtSubjectName.Focus();
            }
        }
        


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            /*if (txtName.Text != "" && txtEmail.Text != "")
            {
                if (busStudent.updateStudent(id, txtName.Text, txtEmail.Text))
                {
                    MessageBox.Show("Update successful.", "Information");
                    tf1 = !tf1;
                    Lock_Unlock1(tf1);
                    dgvStudent.DataSource = busStudent.getStudent();
                }
                else
                {
                    MessageBox.Show("Update fail!", "Information");
                }
            }
            else
            {
                MessageBox.Show("Student name or Email is empty!\nInput data again.", "Information");
                txtName.Focus();
            }*/

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            /*if (busStudent.deleteStudent(id))
            {
                MessageBox.Show("Delete successful.", "Information");
                tf1 = !tf1;
                Lock_Unlock1(tf1);
                dgvStudent.DataSource = busStudent.getStudent();
            }
            else
            {
                MessageBox.Show("Delete fail!", "Information");
            }*/

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GUI_Subject_Load(object sender, EventArgs e)
        {

            for(int i=0; i < dtbStudent.Rows.Count; i++)
            {
                cmbStudentName.Items.Add(dtbStudent.Rows[i]["name"].ToString());
                cmbStudentName.Text = dtbStudent.Rows[0]["name"].ToString();
            }
            string id = dtbStudent.Rows[int.Parse(cmbStudentName.SelectedIndex.ToString())]["id"].ToString();
            dgvSubject.DataSource = busSubject.getSubject(id);
        }

        private void cmbStudentName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dtbStudent.Rows[int.Parse(cmbStudentName.SelectedIndex.ToString())]["id"].ToString();
            dgvSubject.DataSource = busSubject.getSubject(id);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            tf = tf1 = true;
            Lock_Unlock(tf);
            Lock_Unlock1(tf1);
        }
    }
}
