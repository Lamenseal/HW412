using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HW412
{
    public partial class Form1 : Form
    {
        SqlConnection cnn = null;
        public Form1()
        {
            InitializeComponent();
            SqlConnection conn = new SqlConnection("Data Source =.; Initial Catalog = Northwind; Integrated Security = True");
            SqlDataAdapter adapter = new SqlDataAdapter("select*from Products", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            this.dataGridView1.DataSource = ds.Tables[0];

            this.productsTableAdapter1.Fill(this.dataSet11.Products);
            this.bindingSource1.DataSource = this.dataSet11.Products;
            this.dataGridView1.DataSource = this.bindingSource1;
            this.label4.Text = $"{this.bindingSource1.Position + 1} / {this.bindingSource1.Count}";
            this.bindingNavigator1.BindingSource = this.bindingSource1;
            label5.Text = "共" + this.bindingSource1.Count + "筆資料";


        }

        private void button1_Click(object sender, EventArgs e)
        {
            int UP1 = Convert.ToInt32(textBox1.Text);
            int UP2 = Convert.ToInt32(textBox2.Text);
            
            //SqlConnection conn = new SqlConnection("Data Source =.; Initial Catalog = Northwind; Integrated Security = True");
            //SqlDataAdapter adapter = new SqlDataAdapter("select*from Products where UnitPrice between "+UP1+" and "+UP2, conn);
            //DataSet ds = new DataSet();
            //adapter.Fill(ds);
            //this.dataGridView1.DataSource = ds.Tables[0];
            this.productsTableAdapter1.FillUP(this.dataSet11.Products,UP1,UP2);
            this.bindingSource1.DataSource = this.dataSet11.Products;
            this.dataGridView1.DataSource = this.bindingSource1;
            this.label4.Text = $"{this.bindingSource1.Position + 1} / {this.bindingSource1.Count}";
            label5.Text = "共" + this.bindingSource1.Count + "筆資料";
        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            this.bindingSource1.Position = 0;
            this.label4.Text = $"{this.bindingSource1.Position + 1} / {this.bindingSource1.Count}";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.bindingSource1.Position -= 1;
            this.label4.Text = $"{this.bindingSource1.Position + 1} / {this.bindingSource1.Count}";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.bindingSource1.Position += 1;
            this.label4.Text = $"{this.bindingSource1.Position + 1} / {this.bindingSource1.Count}";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.bindingSource1.Position = this.dataSet11.Products.Count - 1;
            this.label4.Text = $"{this.bindingSource1.Position + 1} / {this.bindingSource1.Count}";
        }
        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            this.label4.Text = $"{this.bindingSource1.Position + 1} / {this.bindingSource1.Count}";

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'dataSet11.Categories' 資料表。您可以視需要進行移動或移除。
            this.categoriesTableAdapter.Fill(this.dataSet11.Categories);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string PN = textBox3.Text;
            this.productsTableAdapter1.FillPN(this.dataSet11.Products, PN);
            this.bindingSource1.DataSource = this.dataSet11.Products;
            this.dataGridView1.DataSource = this.bindingSource1;
            this.label4.Text = $"{this.bindingSource1.Position + 1} / {this.bindingSource1.Count}";
            label5.Text = "共" + this.bindingSource1.Count + "筆資料";
        }
    }
}
