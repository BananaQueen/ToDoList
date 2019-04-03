using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace ToDoListClientApp
{
    public partial class Form1 : Form
    {
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "User ID=postgres;Password=1234Qwer;Host=localhost;Port=5432;Database=ToDoList";
                NpgsqlConnection conn = new NpgsqlConnection(connectionString);
                conn.Open();

                //NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM ToDo", conn);
                //NpgsqlDataReader dataReader = command.ExecuteReader();

                string sql = "SELECT Id FROM ToDo";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);

                ds.Reset();

                da.Fill(ds, "ToDo");

                dt = ds.Tables[0];

                dataGridView1.DataSource = dt;

                conn.Close();
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString());
                throw;
            }
        }
    }
}
