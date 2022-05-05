using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Management_App
{
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
        }

        private void formToggle()
        {
            var formSearch = new formSearch();
            formSearch.Show();
            this.Hide();
        }

        private bool validLogin()
        {

            // Check empty fill information
            if (textUsername.Text == "" || textPassword.Text == "")
            {
                MessageBox.Show
                    (
                        "Please complete information for login!",
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                return false;
            }

            // DB connection open
            dbConfig.connection.Open();

            // Fields
            var empAdapter = new SqlDataAdapter();
            var empTable = new DataTable();
            DataRow[] empDR;

            // SQL command
            string sql = "SELECT * FROM employees ";

            dbOperation.createCmdSelect(sql);

            empAdapter.SelectCommand = dbOperation.commandSelect;
            empAdapter.Fill(empTable);

            // SELECT FROM DATATABLE
            sql =
                $"empUsername='{textUsername.Text}' " +
                $"and empPassword='{textPassword.Text}'";

            try
            {
                empDR = empTable.Select(sql);

                // FetchData and Storage
                emp.id = empDR[0]["empID"].ToString();
                emp.title = empDR[0]["empTitle"].ToString();
                emp.fname = empDR[0]["empFname"].ToString();
                emp.lname = empDR[0]["empLname"].ToString();
                emp.position = empDR[0]["positionID"].ToString();

                // Check
                //Console.WriteLine(emp.id + " " + emp.title + " " + emp.fname + " " + emp.lname + " " + emp.position);

                // Login success
                // Open new form
                formToggle();

            }
            catch (Exception ex)
            {
                // Login fail
                MessageBox.Show
                    (
                        "Username or Password is wrong!",
                        "Login fail",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                //MessageBox.Show(ex.Message);
                dbConfig.connection.Close();
                dbOperation.disposeCmdSelect();
                return false;
            }

            dbConfig.connection.Close();

            dbOperation.disposeCmdSelect();

            return true;
        }
      
        private void buttonLogin_Click_1(object sender, EventArgs e)
        {
            validLogin();
        }
    }
}