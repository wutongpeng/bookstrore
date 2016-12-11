using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Diagnostics;



namespace 书店零售管理系统
{
    public partial class 图书查询 : Form
    {
        public 图书查询()
        {
            InitializeComponent();
        }
      
        private void 图书查询_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void button1_Click_1(object sender, System.EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cmdText = " SELECT * FROM book WHERE 1 = 1 ";               
            string bid = textBox1.Text.Trim();
            string name = textBox2.Text.Trim();
            if (bid != "")
            {
                cmdText += " AND F_BID = '" + bid + "'";
            }
            if (name != "")
            {
                cmdText += "AND F_BNAME  LIKE  '" + name + "%'";
            }           
            MysqlHelper helper = new MysqlHelper();
            CommandType cmdType = CommandType.Text;
            DataSet ds = helper.GetDataSet(cmdType, cmdText, null);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }







}
