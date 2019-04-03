using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace ToDoListClientApp
{

    //this whole class is for check if I can create and connect a client to a server and do a HTTP Get
    public partial class Form1 : Form
    {
        //private DataSet ds = new DataSet();
        //private DataTable dt = new DataTable();

        static HttpClient client = new HttpClient();
        private static HttpResponseMessage response;


        static async Task<MyValue> GetValueAsync(string path)
        {
            MyValue _value = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                _value = await response.Content.ReadAsAsync<MyValue>();
            }
            return _value;
        }

        static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:5000");
            client.DefaultRequestHeaders.Accept.Clear();

            // HTTP Get
            response = await client.GetAsync("api/values/5");
            if (response.IsSuccessStatusCode)
            {
                // Get the URI of the created resource.
                Uri gizmoUrl = response.Headers.Location;
                
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            RunAsync();

        }
    }
}
