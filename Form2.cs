using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management.Automation;
using System.Collections.ObjectModel;
using System.IO;

namespace WindowsFormsApplication7
{
    public partial class Form2 : Form
    {
        private int count = 0;
        private string aa = "";
        public Form2()
        {
            InitializeComponent();
        }
        //button exit
        private void btThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //button Nhập lại
        private void btNhaplai_Click(object sender, EventArgs e)
        {
            do
            {
                aa=RunScript();
                if (aa.Equals("OK")==true)
                {
                    MessageBox.Show("Đăng nhập thành công");
                }
                else
                {
                    count = count + 1;
                    Form2 fr2 = new Form2();
                }
             

            } while (count < 3);
        }
        //chay lenh powerhsell
        private string RunScript()
        {
            do
            {
                // đọc code powershell vào biến code
                FileStream fs = new FileStream(@"C:\Users\Thanh\Desktop\aaaa\WindowsFormsApplication7\codePWS.txt", FileMode.Open);
                StreamReader sr = new StreamReader(fs, Encoding.UTF8);
                String code = sr.ReadToEnd();
                fs.Close();
                PowerShell pws = PowerShell.Create();
                pws.AddCommand(code);
                Collection<PSObject> results = pws.Invoke();
                if (results == null)
                {
                    return "KO";
                }
                else
                    return "OK";
            } while (count < 3);
        }
    }
}
