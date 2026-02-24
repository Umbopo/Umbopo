using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IAMNOTGONE
{
    public partial class MainForm : Form
    {
        private Thread workerThread; private bool running = false; [DllImport("user32.dll")] static extern bool SetCursorPos(int X, int Y); public MainForm()
        {
            InitializeComponent(); this.Text = "Mouse Mover"; this.Width = 300; this.Height = 100;

            // Create label
            Label infoLabel = new Label() { Text = "HIT ESCAPE TO STOP ;)", Dock = DockStyle.Top, TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 10, FontStyle.Bold), ForeColor = Color.DarkRed, Height = 30 };

            Button startButton = new Button() { Text = "Start", Dock = DockStyle.Top }; Button stopButton = new Button() { Text = "Stop", Dock = DockStyle.Top }; startButton.Click += (s, e) => StartMoving(); stopButton.Click += (s, e) => StopMoving(); this.Controls.Add(stopButton); this.Controls.Add(startButton); this.KeyPreview = true; this.KeyDown += MainForm_KeyDown;
        }
        private void MainForm_KeyDown(object sender, KeyEventArgs e) { if (e.KeyCode == Keys.Escape) { StopMoving(); } }
        private void StartMoving() { if (running) return; running = true; workerThread = new Thread(MoveMouseRandomly); workerThread.IsBackground = true; workerThread.Start(); }
        private void StopMoving() { running = false; workerThread?.Join(); }
        private void MoveMouseRandomly()
        {
            Random rand = new Random(); while (running)
            {
                int x = rand.Next(Screen.PrimaryScreen.Bounds.Width); int y = rand.Next(Screen.PrimaryScreen.Bounds.Height); SetCursorPos(x, y); Thread.Sleep(1000); // move every second } } }
            }
        }
    }
}
