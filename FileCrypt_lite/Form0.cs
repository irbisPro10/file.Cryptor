using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace FileCrypt_lite
{
    public partial class Form0 : Form
    {
        public Form0()
        {
            InitializeComponent();
            AcceptButton = button1;
        }

        Form1 MF = new Form1();
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private Int16 check = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            AES aesCrypt = new AES();
                string pas = aesCrypt.DecryptPassword(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "FileCrypt_lite.loc"));
                if (pas == textBox1.Text)
                {
                    MF.Show();
                    this.Hide();
                }

                else
                {
                    if (check == 2)
                    {
                        MessageBox.Show("You enter incorrect password for 3 time. \nWait a minute and try again");
                        Thread.Sleep(60000);
                    }
                    else
                    {
                        MessageBox.Show("incorrect password", "The password error");
                        textBox1.Text = null;
                        check++;
                    }
                }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form0_Load(object sender, EventArgs e)
        {
            AES aesCrypt = new AES();
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "FileCrypt_lite.loc"))
            {
                MessageBox.Show("Programm was start in first time. \n Password: 0000");
          
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "FileCrypt_lite.loc", aesCrypt.EncryptPassword("0000"));
            }
        }
    }
}
