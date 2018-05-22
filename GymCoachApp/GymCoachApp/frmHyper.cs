using GymCoach.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace GymCoachApp
{
    public partial class frmHyper : Form
    {
        public frmHyper()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
        private System.Windows.Forms.Timer timer1;
        int counter = TrainingType.REST_SECONDS_NORMAL_HYPERTROPHY;
        private void timer1_Tick(object sender, EventArgs e)
        {
            counter--;
            if (counter == 0)
                timer1.Stop();
            txtRest.Text = counter.ToString();
        }

        private void btnSet1_Click(object sender, EventArgs e)
        {
            counter = TrainingType.REST_SECONDS_NORMAL_HYPERTROPHY;
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000; // 1 second
            timer1.Start();
            txtRest.Text = counter.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int max = TrainingType.REST_SECONDS_EXTENDED_HYPERTROPHY - TrainingType.REST_SECONDS_NORMAL_HYPERTROPHY;
            counter = counter + max;
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000; // 1 second
            timer1.Start();
            txtRest.Text = counter.ToString();
        }
    }
}
