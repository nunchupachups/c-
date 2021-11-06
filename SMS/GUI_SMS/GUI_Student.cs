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

namespace GUI_SMS
{
    public partial class GUI_Student : Form
    {
        BUS_Student busStudent = new BUS_Student();
        bool tf, tf1;
        int id;
        public GUI_Student()
        {
            InitializeComponent();
            tf = tf1 = true;
            Lock_Unlock(tf);
            Lock_Unlock1(tf1);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (tf1)
            {
                tf = !tf;
                Lock_Unlock(tf);
                txtName.Text = txtEmail.Text = "";
                txtName.Focus();
            }
            else MessageBox.Show("Updating or Deleting!\nClick Reset to do another thing.", "Information");
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtName.Text!="" && txtEmail.Text != "")
            {
                if(busStudent.insertStudent(txtName.Text, txtEmail.Text))
                {
                    MessageBox.Show("Insert successful.", "Information");
                    tf = !tf;
                    Lock_Unlock(tf);
                    dgvStudent.DataSource = busStudent.getStudent();
                }
                else
                {
                    MessageBox.Show("Insert fail!", "Information");
                }
            }
            else
            {
                MessageBox.Show("Student name or Email is empty!\nInput data again.", "Information");
                txtName.Focus();
            }
        }
        void Lock_Unlock(bool tf)
        {
            btnNew.Enabled = tf;
            btnAdd.Enabled = txtEmail.Enabled = txtName.Enabled = !tf;
        }
        void Lock_Unlock1(bool tf1)
        {
            dgvStudent.Enabled = tf1;
            btnDelete.Enabled = btnUpdate.Enabled =txtEmail.Enabled = txtName.Enabled = !tf1;
        }

        private void dgvStudent_Click(object sender, EventArgs e)
        {
            if (tf)
            {
                int i = dgvStudent.CurrentRow.Index; 
                id = int.Parse(dgvStudent[0, i].Value.ToString());
                txtName.Text = dgvStudent[1, i].Value.ToString();
                txtEmail.Text = dgvStudent[2, i].Value.ToString();
                txtName.Focus();
                tf1 = !tf1;
                Lock_Unlock1(tf1);
            }
            else MessageBox.Show("Inserting!\nClick Reset to do another thing.", "Information");
           
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtEmail.Text != "")
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
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (busStudent.deleteStudent(id))
            {
                MessageBox.Show("Delete successful.", "Information");
                tf1 = !tf1;
                Lock_Unlock1(tf1);
                dgvStudent.DataSource = busStudent.getStudent();
            }
            else
            {
                MessageBox.Show("Delete fail!", "Information");
            }
   
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            tf = tf1 = true;
            Lock_Unlock(tf);
            Lock_Unlock1(tf1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GUI_Subject x = new GUI_Subject();
            x.Show();
        }

        private void GUI_Student_Load(object sender, EventArgs e)
        {
            dgvStudent.DataSource = busStudent.getStudent();
        }
    }
}
