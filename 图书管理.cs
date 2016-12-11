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
using MySql.Data;
using MySql.Data.MySqlClient;

namespace 书店零售管理系统
{




    public partial class 图书管理 : Form
    {
        public 图书管理()
        {
            InitializeComponent();
        }

        private void 阈值设置_Load(object sender, EventArgs e)
        {

        }
        //添加
        private void button1_Click(object sender, EventArgs e)
        {
            //Islive();
            bool b = checkIfNull();
            if (!b)
            {
                return;
            }
            string id = this.id.Text.Trim();
            string name = this.name.Text.Trim();
            string author = this.author.Text.Trim();
            string house = this.house.Text.Trim();           
            string type = this.type.Text.Trim();
            double price = Convert.ToDouble(this.price.Text.Trim());
            string time = this.time.Text.Trim();
            int discount = Convert.ToInt32(this.discount.Text.Trim());
            int number = Convert.ToInt32(this.number.Text.Trim());
                      
            string cmdText = "insert into book  values ( '" + id + "','"+name+"','"+author+"','"+house+"','"
                +type+"','"+price+"','"+time+"','"+discount+"','"+number +"')";
            CommandType cmdType = CommandType.Text;
            MysqlHelper helper = new MysqlHelper();
            int result = helper.ExecuteNonQuery(cmdType, cmdText, null);
            if (result == 1)
            {
                MessageBox.Show("添加成功！");
                this.richTextBox1.AppendText("添加成功 ！\n");
                clearInfo();
            }
            else
            {
                MessageBox.Show("添加失败，请先查看是否有此信息！");
            }

        }
        //删除
        private void button2_Click(object sender, EventArgs e)
        {
           
            string id = textBox1.Text.Trim();
            if (id == "")
            {
                MessageBox.Show("请先在图书管理区输入图书编号！");
                return;
            }
            string cmdText = "delete  from book where F_BID = '" + id +"'";
            CommandType cmdType = CommandType.Text;
            MysqlHelper helper = new MysqlHelper();
            int result = helper.ExecuteNonQuery(cmdType, cmdText,null);
            if (result == 1)
            {
                MessageBox.Show("删除成功！");
                this.richTextBox1.AppendText("删除成功 ！\n");
                clearInfo();
            }
            else
            {
                MessageBox.Show("删除失败，请先查看是否有此信息！");
            }

        }
        //修改
        private void button4_Click(object sender, EventArgs e)
        {
            //Islive();
            bool b = checkIfNull();
            if (!b)
            {
                return;
            }
            string id = this.id.Text.Trim();
            string name = this.name.Text.Trim();
            string author = this.author.Text.Trim();
            string house = this.house.Text.Trim();
            string type = this.type.Text.Trim();
            double price = Convert.ToDouble(this.price.Text.Trim());
            string time = this.time.Text.Trim();
            int discount = Convert.ToInt32(this.discount.Text.Trim());
            int number = Convert.ToInt32(this.number.Text.Trim());

            string cmdText = "update  book  set F_BNAME = '" + name + "',F_BAUTHOR='" + author + "',F_BHOUSE='" + house
                + "',F_BTYPE='" + type + "',F_BPRICE='" + price + "',F_BDISCOUNT='" + discount + "',F_BNUMBER='" + number
                + "' where F_BID = '" + id + "' ";
            CommandType cmdType = CommandType.Text;
            MysqlHelper helper = new MysqlHelper();
            int result = helper.ExecuteNonQuery(cmdType, cmdText, null);
            if (result == 1)
            {
                MessageBox.Show("修改成功！");
                this.richTextBox1.AppendText("修改成功 ！\n");
                clearInfo();
            }
            else
            {
                MessageBox.Show("修改失败，请先查看是否有此信息！");
            }          
           
        }
        //查询
        private void button3_Click(object sender, EventArgs e)
        {
            //selExecuteSQL();
            string id = textBox1.Text.Trim();
            if (id == "")
            {
                MessageBox.Show("请先在图书管理区输入图书编号！");
                return;
            }
            string cmdText = "select *  from book where F_BID = '" + id + "'";
            CommandType cmdType = CommandType.Text;
            MysqlHelper helper = new MysqlHelper();
            try
            {
                MySqlDataReader reader = helper.ExecuteReader(cmdType, cmdText, null);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        this.id.Text = reader[0].ToString();
                        this.name.Text = reader[1].ToString();
                        this.author.Text = reader[2].ToString();
                        this.house.Text = reader[3].ToString();
                        this.type.Text = reader[4].ToString();
                        this.price.Text = reader[5].ToString();
                        this.time.Text = reader[6].ToString();
                        this.discount.Text = reader[7].ToString();
                        this.number.Text = reader[8].ToString();

                        this.richTextBox1.AppendText("查询成功 ！\n");
                    }
                }else
                {
                    MessageBox.Show("数据库没有此信息!");
                    clearInfo();
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库错误信息："+ex.Message);
                return;
                
            } 
           

        }

        private void id_TextChanged(object sender, EventArgs e)
        {

        }

        private bool checkIfNull()
        {
            bool result = true;
            try
            {
                string id = this.id.Text.Trim();
                if (id == "")
                {
                    MessageBox.Show("图书编号不能为空！");
                    return false;
                }
                string name = this.name.Text.Trim();
                if (name == "")
                {
                    MessageBox.Show("图书名称不能为空！");
                    return false;
                }
                string author = this.author.Text.Trim();
                if (author == "")
                {
                    MessageBox.Show("图书作者不能为空！");
                    return false;
                }
                string house = this.house.Text.Trim();
                if (house == "")
                {
                    MessageBox.Show("图书出版社不能为空！");
                    return false;
                }
                string type = this.type.Text.Trim();
                if (type == "")
                {
                    MessageBox.Show("图书类型不能为空！");
                    return false;
                }
                string price = this.price.Text.Trim();
                if (price == "")
                {
                    MessageBox.Show("图书定价不能为空！");
                    return false;
                }
                string time = this.time.Text.Trim();
                if (time == "")
                {
                    MessageBox.Show("图书出版时间不能为空！");
                    return false;
                }
                int discount = Convert.ToInt32(this.discount.Text.Trim());
                if (id == "")
                {
                    MessageBox.Show("图书折扣不能为空！");
                    return false;
                }
                int number = Convert.ToInt32(this.number.Text.Trim());
                if (id == "")
                {
                    MessageBox.Show("图书数量不能为空！");
                    return false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("错误提示："+ex.Message);
            }
           
            return result;
        }

        private void clearInfo()
        {
            this.id.Text = "";
            this.name.Text = "";
            this.author.Text = "";
            this.house.Text = "";
            this.type.Text = "";
            this.price.Text = "";
            this.time.Text = "";
            this.discount.Text = "";
            this.number.Text = "";
        }

    }
}
