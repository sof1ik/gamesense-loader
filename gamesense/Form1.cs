﻿using System;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;

namespace gamesense
{
    public partial class Form1 : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public Form1()
        {
            InitializeComponent();
        }

        private void load_Click(object sender, EventArgs e)
        {
            if (login.Text == "skeetcrack" && password.Text == "skeetcrack")
            {
                this.Hide();
                var form1 = new Form2();
                form1.Closed += (s, args) => this.Close();
                form1.Show();
            }
            else this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            password.PasswordChar = '*';

            // check for steam launch
            Process[] steam = Process.GetProcessesByName("steam");
            if (steam.Length != 0)
            {
                foreach (var process in Process.GetProcessesByName("steam"))
                {
                    process.Kill();
                }
                MessageBox.Show("Steam has been closed for security reasons!", "gamesense");
            }
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
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
