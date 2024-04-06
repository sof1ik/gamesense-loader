using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gamesense
{
    public partial class Form2 : Form
    {
        string HWID;
        string dll_link = "https://test.com/hack/gamesense.dll"; // download dll url;
        string hwid_link = "https://test.com/hack/hwids/hwid.txt"; // check hwid url;
        string dll_name = "svhost"; // rename dll;

        int time_to_wait = 35000; // wait time for dll inject;
        bool setted_up = true; // loader setting's;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public Form2()
        {
            InitializeComponent();
        }

        private async void load_Click(object sender, EventArgs e)
        {
            WebClient wb = new WebClient();
            string access_list = wb.DownloadString(hwid_link);
            if (access_list.Contains(HWID))
            {
                this.Hide();
                string mainpath = "C:\\Windows\\" + dll_name + ".dll";
                wb.DownloadFile(dll_link, mainpath);

                Process.Start("steam://rungameid/730");
                await Task.Delay(time_to_wait);
                Process csgo = Process.GetProcessesByName("cs2").FirstOrDefault();
                Process[] csgo_array = Process.GetProcessesByName("cs2");

                if (csgo_array.Length != 0)
                {
                    // inject dll
                    injector.BasicInject.Inject(mainpath, "cs2");
                    Console.Read();
                    csgo.WaitForExit();

                    // deleted dll file
                    if (File.Exists(mainpath))
                    	File.Delete(mainpath);
       
                    await Task.Delay(10000);
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("Error: 'cs2' process not found", "gamesense", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            else MessageBox.Show("Incorrect HWID", "gamesense");
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Start();
            HWID = System.Security.Principal.WindowsIdentity.GetCurrent().User.Value;

            if (!setted_up)
                setup.Show();
            else setup.Hide();

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        }

        private void setup_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form3 = new Form3();
            form3.Closed += (s, args) => this.Close();
            form3.Show();
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void load_MouseDown(object sender, MouseEventArgs e)
        {
            load.ForeColor = Color.FromArgb(146, 189, 68);
        }

        private void load_MouseUp(object sender, MouseEventArgs e)
        {
            load.ForeColor = SystemColors.ControlLight;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Process[] ida64 = Process.GetProcessesByName("ida64");
            Process[] ida32 = Process.GetProcessesByName("ida32");
            Process[] ollydbg = Process.GetProcessesByName("ollydbg");
            Process[] ollydbg64 = Process.GetProcessesByName("ollydbg64");
            Process[] loaddll = Process.GetProcessesByName("loaddll");
            Process[] httpdebugger = Process.GetProcessesByName("httpdebugger");
            Process[] windowrenamer = Process.GetProcessesByName("windowrenamer");
            Process[] processhacker = Process.GetProcessesByName("processhacker");
            Process[] processhacker2 = Process.GetProcessesByName("Process Hacker");
            Process[] processhacker3 = Process.GetProcessesByName("ProcessHacker");
            Process[] HxD = Process.GetProcessesByName("HxD");
            Process[] parsecd = Process.GetProcessesByName("parsecd");
            Process[] ida = Process.GetProcessesByName("ida");
            Process[] dnSpy = Process.GetProcessesByName("dnSpy");

            if (ida64.Length != 0 || ida32.Length != 0 || ollydbg.Length != 0 || ollydbg64.Length != 0 || loaddll.Length != 0 || httpdebugger.Length != 0 || windowrenamer.Length != 0 || processhacker.Length != 0 || processhacker2.Length != 0 || processhacker3.Length != 0 || HxD.Length != 0 || ida.Length != 0 || parsecd.Length != 0 || dnSpy.Length != 0)
            {
                Application.Exit();
            }
        }
    }
}
