using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace difzach_ravkin
{
    public partial class Form1 : Form
    { int i = 1;
        public Form1()
        {
            InitializeComponent();
        }
        List<Product> products = new List<Product>();
        List<Group> groups = new List<Group>();
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                if (radioButton1.Checked == true)
                {
               
                products.Add(new Product { Id = i, Name = textBox1.Text });               
                groups.Add(new Group { InventoryNumber = i, ProductId = i, GroupName = "Кулинария", Price = Convert.ToInt32(textBox2.Text) });

                }
                if (radioButton2.Checked == true)
                {

                    
                    products.Add(new Product { Id = i, Name = textBox1.Text });

                   
                    groups.Add(new Group { InventoryNumber = i, ProductId = i, GroupName = "Масло", Price = Convert.ToInt32(textBox2.Text) });


                }
            
           
            i++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
           
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AutoSize = true;
           



            DataGridViewTextBoxColumn columnId = new DataGridViewTextBoxColumn();
            columnId.HeaderText = "Идентификатор товара";
            columnId.DataPropertyName = "Id";
            dataGridView1.Columns.Add(columnId);


            DataGridViewTextBoxColumn columnName = new DataGridViewTextBoxColumn();
            columnName.HeaderText = "Название товара";
            columnName.DataPropertyName = "Name";
            dataGridView1.Columns.Add(columnName);


            DataGridViewTextBoxColumn columnPrice = new DataGridViewTextBoxColumn();
            columnPrice.HeaderText = "Цена товара";
            columnPrice.DataPropertyName = "Price";
            dataGridView1.Columns.Add(columnPrice);
            var mergedData = products.Select(p => new { p.Name, p.Id })
                      .Zip(groups, (p, pr) => new { pr.GroupName, p.Id, p.Name, pr.Price });

            
            dataGridView1.DataSource = mergedData.ToList();
            
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true) 
            {
               
                List<DataGridViewRow> rowsToRemove = new List<DataGridViewRow>();

               
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                   
                    string groupName = row.Cells["GroupName"].Value.ToString(); 

                   
                    if (groupName == "Масло")
                    {
                        rowsToRemove.Add(row);
                    }
                }

                
                foreach (DataGridViewRow rowToRemove in rowsToRemove)
                {
                    dataGridView1.Rows.Remove(rowToRemove);
                }
            }
            if (radioButton4.Checked == true)
            {

            }
        }
    }
}
