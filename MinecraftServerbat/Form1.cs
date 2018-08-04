using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace MinecraftServerbat
{
    public partial class Form1 : Form
    {
        string filename;
        string add;
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "所有文件(*.jar)|*.jar";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;
                MessageBox.Show("已选择文件:" + file, "选择文件提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Text = file;
                filename = file;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(textBox2.Text);
                Convert.ToInt32(textBox3.Text);
            }
            catch
            {
                MessageBox.Show("Error 请输入正确的内存值");
                goto Fail;
                                  
            }
            if (checkBox1.Checked==true)
            {
                add += " -d64";
            }
            if (checkBox2.Checked == true)
            {
                add += " -Xss"+textBox4.Text+"k";
            }
            if (checkBox3.Checked == true)
            {
                add += " -Xmn"+textBox5.Text+"G";
            }
            if (checkBox4.Checked == true)
            {
                add += " -XX:NewSize="+textBox6.Text+"m";
            }
            if (checkBox5.Checked == true)
            {
                add += " -XX:MaxNewSize="+textBox7.Text+"m";
            }
            if (checkBox6.Checked == true)
            {
                add += " -XX:PermSize="+textBox8.Text+"m";
            }
            if (checkBox7.Checked == true)
            {
                add += " -XX:MaxPermSize="+textBox9.Text+"m";
            }
            if (checkBox8.Checked == true)
            {
                add += " -XX:NewRatio="+textBox10.Text;
            }
            if (checkBox9.Checked == true)
            {
                add += " -XX:SurvivorRatio="+textBox11.Text;
            }
            if (checkBox10.Checked == true)
            {
                add += " -XX:MaxTenuringThreshold="+textBox12.Text;
            }
            if (checkBox11.Checked == true)
            {
                add += " -XX:+UseParNewGC";
            }
            if (checkBox12.Checked == true)
            {
                add += " -XX:+UseConcMarkSweepGC";
            }
            if (checkBox13.Checked == true)
            {
                add += " -XX:+UseParallelGC";
            }
            if (filename==null)
            {
                MessageBox.Show("请选择一个文件");
                goto Fail;
            }
            string bat = "@echo off\r\n echo 本启动脚本由MinecraftServerbat软件生成\r\necho 作者 Small_Miao\r\njava -Xms"+textBox3.Text+"G -Xmx"+textBox2.Text+"G"+add+" -jar "+filename+"\r\npause>nul\r\n";
            try
            {
                File.WriteAllText("StartServer.bat", bat, Encoding.GetEncoding(936));
                MessageBox.Show("生成成功 文件在软件目录");
            }
            catch 
            {

                
            }
           
            Fail: Console.WriteLine("Hello");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Say say = new Say();
            say.Show();
        }
    }
}
