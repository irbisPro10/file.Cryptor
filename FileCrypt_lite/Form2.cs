using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace FileCrypt_lite
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
        }


        public bool list;

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        
            
                AES aesCrypt = new AES();
                string password = aesCrypt.DecryptPassword(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "FileCrypt_lite.loc"));
                if (textBox2.Text.Length < 4) { MessageBox.Show("Password lenth should have a lenngh more then 3", "Error"); textBox2.Text = null; }
                if (password != textBox1.Text)
                {
                    
                    MessageBox.Show("Password wasn't changed. Current password incorrect", "Error");
                    textBox1.Text = null;
                    textBox2.Text = null;
                }
                else
                {
                    string newPas = textBox2.Text;
                    DirectoryInfo dis = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\Storage\\");
                    FileInfo[] Files = dis.GetFiles("*");

                    foreach (FileInfo di in Files)
                    {
                        aesCrypt.DecryptFile(di.FullName, File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "FileCrypt_lite.loc"));
                    }
                    File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "FileCrypt_lite.loc", aesCrypt.EncryptPassword(newPas));
                    foreach (FileInfo di in Files)
                    {
                        aesCrypt.EncryptFile(di.FullName, File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "FileCrypt_lite.loc"));
                    }

                    MessageBox.Show("Your password successfully changed", "Success!");
                }

            

                     
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }


    }
}
