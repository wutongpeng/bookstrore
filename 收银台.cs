using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;




namespace 书店零售管理系统
{
    public partial class 收银台 : Form
    {

        private bool havebook = false;
        private string uname = "";
        public 收银台(string uname)
        {
            InitializeComponent();
            this.uname = uname;
            this.textBox9.Text = uname;
        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }



        private void button1_Click(object sender, EventArgs e)
        {
            //selExecuteSQL();
            string bookId = this.textBox1.Text.ToString().Trim();
            if (bookId == "")
            {
                MessageBox.Show("请先输入图书编号！");
                return;
            }
            string slStr = this.textBox7.Text.ToString().Trim();
            if (slStr == "")
            {
                MessageBox.Show("请先输入图书数量！");
                return;
            }
            int sl = Convert.ToInt32(slStr);
            if (sl < 1)
            {
                MessageBox.Show("请先输入图书数量！");
                return;
            }

            //string cmdText = "SELECT F_BNAME,F_BAUTHOR,F_BHOUSE,F_BPRICE,F_BDISCOUNT,F_BNUMBER,F_BDISCOUNT*F_BPRICE/10 "
            //实际价格需要计算，因为不打折就是0，你也可以改成100，但是实际价格还得乘以数量，总的来说不能在sql中计算
            string cmdText = "SELECT F_BNAME,F_BAUTHOR,F_BHOUSE,F_BPRICE,F_BDISCOUNT,F_BNUMBER"
                + " FROM BOOK WHERE F_BID = '" + bookId + "'";
            MysqlHelper helper = new MysqlHelper();
            CommandType cmdType = CommandType.Text;
            MySqlDataReader reader = helper.ExecuteReader(cmdType, cmdText, null);
            while (reader.Read())
            {
                //数量
                if (Convert.ToInt32(reader[5]) == 0)
                {
                    MessageBox.Show("此图书已售完，请选择其他图书！");
                    return;
                }
                else if (Convert.ToInt32(reader[5]) < sl)
                {
                    MessageBox.Show("此图书库存不足，请修改购买数量！");
                    return;
                }
                //书名
                this.textBox2.Text = reader[0].ToString();
                //作者
                this.textBox3.Text = reader[1].ToString();
                //出版社
                this.textBox4.Text = reader[2].ToString();
                //定价
                this.textBox5.Text = reader[3].ToString();
                //折扣

                int count = Convert.ToInt32(reader[4]);
                if (count == 0)
                {
                    this.textBox6.Text = "无";
                    double realprice = Convert.ToDouble(reader[3].ToString().Trim()) * Convert.ToInt32(sl);
                    this.textBox11.Text = realprice.ToString();
                }
                else
                {
                    this.textBox6.Text = reader[4] + "折";
                    double p = (Convert.ToDouble(reader[3]) * (count / 100) * sl);
                    this.textBox11.Text = p.ToString();

                    //this.textBox7.Text = reader[6].ToString();

                }
                this.textBox10.Text = System.DateTime.Now.ToString();
                this.havebook = true;
            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void 报警信息_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string bookId = this.textBox1.Text.ToString().Trim();
            if (bookId == "")
            {
                MessageBox.Show("请先输入图书编号！");
                return;
            }
            if (!havebook)
            {
                MessageBox.Show("请先查询图书！");
                return;
            }
            string uId = this.textBox8.Text.ToString().Trim();
            if (uId == "")
            {
                MessageBox.Show("请先输入会员编号！");
                return;
            }
            double realprice = Convert.ToDouble(this.textBox5.Text.ToString().Trim()) * Convert.ToDouble(this.textBox7.Text.ToString().Trim());
            string sId = this.textBox9.Text.ToString().Trim();
            string time = this.textBox10.Text.ToString().Trim();

            int sl = Convert.ToInt32(this.textBox7.Text.ToString().Trim());
            if (sl > 0)
            {
                string cmdText = "insert into sell (F_BID,F_UID,F_PRICE,F_DATA,F_SID) values('" + bookId + "','" + uId + "','" + realprice + "','" + time + "','" + sId + "')";
                CommandType cmdType = CommandType.Text;
                MysqlHelper helper = new MysqlHelper();
                try
                {
                    for (int i = 0; i < sl; i++)
                    {
                        helper.ExecuteNonQuery(cmdType, cmdText, null);
                    }
                    //改变库存
                    cmdText = "select F_BNUMBER FROM BOOK WHERE F_BID = '" + bookId + "'";
                    int n = helper.getNumber(cmdText);
                    int n2 = n - sl;
                    cmdText = "UPDATE BOOK SET F_BNUMBER =  " + n2 + "   WHERE F_BID = '" + bookId + "'";
                    helper.ExecuteNonQuery(cmdType, cmdText, null);

                    MessageBox.Show("交易成功！");

                    havebook = false;

                    this.textBox1.Text = "";
                    this.textBox2.Text = "";
                    this.textBox3.Text = "";
                    this.textBox4.Text = "";
                    this.textBox5.Text = "";
                    this.textBox6.Text = "";
                    this.textBox7.Text = "";
                    this.textBox8.Text = "";
                    this.textBox10.Text = "";
                    this.textBox11.Text = "";
                }
                catch
                {
                    throw;
                }
            }
            else
            {
                MessageBox.Show("数量必须大于零！");
            }

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

