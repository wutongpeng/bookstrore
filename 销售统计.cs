using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace 书店零售管理系统
{
    public partial class 销售统计 : Form
    {      

        public 销售统计()
        {
            InitializeComponent();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void zedGraphControl1_Load(object sender, EventArgs e)
        {

        }

    

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
            string cmdText = " SELECT s.F_BID,(SELECT F_BNAME FROM BOOK b WHERE b.F_BID = s.F_BID) F_NAME, "
                + " (SELECT F_BHOUSE FROM BOOK b WHERE b.F_BID = s.F_BID) F_BHOUSE,"
                + " s.F_UID ,(SELECT F_NAME FROM USER U WHERE U.F_UID = s.F_UID) F_UNAME,"
                + " s.F_PRICE ,s.F_DATA,"
                + " s.F_SID ,(SELECT F_NAME FROM USER U WHERE U.F_UID = s.F_SID) F_SNAME"
                + " FROM sell s WHERE 1 = 1 ";
            string bid = textBox1.Text.Trim();
            string house = textBox2.Text.Trim();
            string sid = textBox3.Text.Trim();
            if (bid != "")
            {
                cmdText += " AND s.F_BID = '" + bid + "'";
            }
            if (house != "")
            {
                cmdText += "AND s.F_BID IN (SELECT F_BID FROM book WHERE book.F_BHOUSE LIKE  '" + house + "%')";
            }
            if (sid != "")
            {
                cmdText += " AND s.F_UID = '" + sid + "'";
            }
            MysqlHelper helper = new MysqlHelper();
            CommandType cmdType = CommandType.Text;
            DataSet ds = helper.GetDataSet(cmdType, cmdText , null);      
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.label5.Text = ds.Tables[0].Rows.Count.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void 销售统计_Load_1(object sender, EventArgs e)
        {

        }



    }

}
