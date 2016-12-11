using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 书店零售管理系统
{
    public partial class 登陆 : Form
    {
        public 登陆()
        {
            InitializeComponent();
        }
        private void 登陆_Load(object sender, EventArgs e)
        {
 

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //字符串赋值:用户名 密码
            string username = textBox1.Text.Trim();
            string userpwd = textBox2.Text.Trim();
            MysqlHelper helper = new MysqlHelper();
            string power = helper.checkLogin(username, userpwd);
            if (power != "")
            {
                MessageBox.Show("登录成功");
                this.Hide();
                主界面 主界面 = new 主界面(username, power);       
                主界面.Show();
            }
            else
            {
                MessageBox.Show("请输入正确的用户名和密码");
            }
        }

     }
}
