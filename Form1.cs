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
using System.Security;
namespace WindowsFormsApplication7
{
    public partial class Form1 : Form
    {
        private string aa;
        public Form1()
        {
            InitializeComponent();
        }
    

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

 
        //button login
        private void btLogin_Click(object sender, EventArgs e)
        {
            aa = RunScript();
            if (aa.Equals("OK")== true)
            {
                MessageBox.Show("Đăng nhập thành công");
            }
            else
            {
                Form2 fr2 = new Form2();
                fr2.Show();
            }

        }
        //button exit
        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //chay lenh powershell
        private string RunScript()
        {
            /*//đọc code  powershell vào biến code
            FileStream fs = new FileStream (@"C:\Users\Thanh\Desktop\aaaa\WindowsFormsApplication7\codePWS.txt",FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8);
            String code = sr.ReadToEnd();
            fs.Close();*/
            //chạy lệnh pws
            PowerShell pws = PowerShell.Create();
            pws.AddCommand("set-executionpolicy");
            pws.AddParameter("ExecutionPolicy","Unrestricted");
            pws.Invoke();
            
            pws.AddScript(@"C:\Users\Thanh\Desktop\aaaa\WindowsFormsApplication7\codePWS.ps1");
            //tạo credential
            /*var password = new SecureString();
            Array.ForEach(tbPassword.Text.ToCharArray(), password.AppendChar);
            PSCredential Credential = new PSCredential(tbUsername.Text, password);
            //tạo đối tượng powershell
            PowerShell pws = PowerShell.Create();
            pws.AddScript("gwmi win32_operatingsystem -comp"+ cbDSIP.Items +"-credential"+ Credential);*/
            Collection<PSObject> results = pws.Invoke();
            //Nếu không có kết quả trả về return về KO
            /*if (results == null)
            {
                return "KO";
                MessageBox.Show("aaaaaa");
            }
            else
            {
                return "OK";
                MessageBox.Show(results.ToString());
            }*/
            StringBuilder stringBuilder = new StringBuilder();
            foreach (PSObject obj in results )
            {
                stringBuilder.AppendLine(obj.ToString());
            }

            return stringBuilder.ToString();
        }

        private void tbUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            FileStream fs = new FileStream(@"C:\Users\Thanh\Desktop\aaaa\WindowsFormsApplication7\dsIP.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                cbDSIP.Items.Add(line);
            }

        }
        //Thiếu chọn IP từ combobox gán vào biến $IP của powershell
       

    }
}
