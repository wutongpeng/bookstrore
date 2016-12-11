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
    public partial class 主界面 : Form
    {
        public string username = "";
        public string power = "";
        public 主界面(string username, string power)
        {
            InitializeComponent();
            welcome( username,  power);
        }
        private void welcome(string username ,string power)
        {
            this.username = username;
            this.power = power;
            this.label1.Text = "欢迎您 " + username + "! 你的权限是:" + power;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void 即时信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            图书查询 图书 = new 图书查询();
            图书.Show();
        }

        private void 历史信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            销售统计 lishi = new 销售统计();
            lishi.Show();
        }

        private void 报警信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            收银台 报警 = new 收银台(username);
            报警.Show();
        }

        private void 货物管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            用户管理 货物 = new 用户管理();
            货物.Show();
        }

        private void 网关设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            图书管理 阈值 = new 图书管理();
            阈值.Show();
        }
       
        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要退出本系统？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Application.Exit();

            } 
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void 主界面_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
