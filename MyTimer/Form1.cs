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

namespace MyTimer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int countdown;
        MyTimer _countdownTimer;
       

        private void timer1_Tick(object sender, EventArgs e)
        {
            countdown--;
            labelCountdown.Text = countdown.ToString();
            if (countdown <= 0)
                timer1.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //timer1.Start();
            //countdown = 10;
            //Thread thread = new Thread(() =>
            //{
            //    for (int i = countdown; i >= 0; i--)
            //    {
            //        Thread.Sleep(1000);
            //        this.Invoke(new Action(() => { labelCountdown.Text = i.ToString(); }));

            //    }
            //});

            //thread.IsBackground = true;
            //thread.Start();
            
            countdown = 10;
            labelCountdown.Text = countdown.ToString();
            _countdownTimer = new MyTimer(1000, () => {
                countdown--;
                this.Invoke(new Action(() => { labelCountdown.Text = countdown.ToString(); }));
                if (countdown <= 0)
                    _countdownTimer.Stop();
            },0,false);
            _countdownTimer.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _countdownTimer.Pause();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _countdownTimer.Resume();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _countdownTimer.Stop();
            labelCountdown.Text = "cancelled...";
        }
    }
}
