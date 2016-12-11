using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace 书店零售管理系统
{




    public partial class 用户管理 : Form
    {
        public 用户管理()
        {
            InitializeComponent();
        }

        /// </summary>
        private MySqlDataAdapter adapter;
        private DataTable table;
        /// <summary>
        /// 


        //处理删除按钮
        private void button2_Click(object sender, EventArgs e)
        {           
            // '删除选中行
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);
            // '数据库中进行删除
            MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);
            adapter.Update(table);
            MessageBox.Show("删除成功");
        }

        //处理修改按钮
        private void button4_Click(object sender, EventArgs e)
        {          
            MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);
            adapter.Update(table);
            adapter = null;
            MessageBox.Show("更新成功");
        }
        //处理查询按钮
        public void button3_Click(object sender, EventArgs e)
        {
          
            string cmdText = "select * from user ";
            string id = textBox1.Text.Trim();
            string name = textBox2.Text.Trim();
            if (id != "")
            {
                cmdText = "select * from user where F_UID = '"+id+"'";
            }
            else if (id == "" && name != "")
            {
                cmdText = "select * from user where F_NAME like '"+ name +"%'";
            }
           
            MysqlHelper helper = new MysqlHelper();
            MySqlConnection conn = helper.getMySqlConnection();
            adapter = new MySqlDataAdapter(cmdText, conn);
            table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            conn.Close();
        }



        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void 货物管理_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
