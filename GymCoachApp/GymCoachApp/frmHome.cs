using GymCoach.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymCoachApp
{
    public partial class frmHome : Form
    {
        frmEnduro enduro = new frmEnduro();
        frmHyper hyper = new frmHyper();
        frmStrength strength = new frmStrength();

        public frmHome()
        {
            InitializeComponent();
        }



        private void btnSettings_Click(object sender, EventArgs e)
        {
            
            if (cbxGoal.SelectedItem != null && cbxGoal.SelectedItem.ToString().Equals("Strength - Maximise strength"))
            {
                TrainingType.setTrainingName(TrainingType.NAME_STRENGTH);
            }
            else if (cbxGoal.SelectedItem != null && cbxGoal.SelectedItem.ToString().Equals("Hypertrophy - Look better aesthetically"))
            {
                TrainingType.setTrainingName(TrainingType.NAME_HYPERTROPHY);
            }
            else if (cbxGoal.SelectedItem != null && cbxGoal.SelectedItem.ToString().Equals("Endurance - Maintain peak performance for longer periods of time"))
            {
                TrainingType.setTrainingName(TrainingType.NAME_ENDURANCE);
            }
            Console.WriteLine(TrainingType.getTrainingName());
            String sVal = cbxDays.SelectedItem.ToString();
            TrainingType.setDays((int)Char.GetNumericValue(sVal[0]));
            Console.WriteLine(TrainingType.getDays());

            this.Controls.Clear();
            this.InitializeComponent();
            setButtons();
            setMessage();
        }

        List<Button> buttons = new List<Button>();
        private void setButtons()
        {
            buttons = new List<Button>();
            if (TrainingType.getDays() == 1)
            {
                Button newButton = new Button();
                newButton.Size = new Size(103, 23);
                newButton.Left = 15;
                newButton.Top = 432;
                newButton.Name = "btnFullBody";
                newButton.Text = "Full-Body";

                buttons.Add(newButton);
                this.Controls.Add(newButton);
                newButton.Click += new EventHandler(this.btnFullBody_Click);

            }
            else if (TrainingType.getDays() == 2)
            {
                Button newButton = new Button();
                newButton.Size = new Size(103, 23);
                newButton.Left = 15;
                newButton.Top = 432;
                newButton.Name = "btnUpperBody";
                newButton.Text = "Upper-Body";

                buttons.Add(newButton);
                this.Controls.Add(newButton);
                newButton.Click += new EventHandler(this.btnUpperBody_Click);

                Button newButton2 = new Button();
                newButton2.Size = new Size(103, 23);
                newButton2.Left = 124;
                newButton2.Top = 432;
                newButton2.Name = "btnLowerBody";
                newButton2.Text = "Lower-Body";

                buttons.Add(newButton2);
                this.Controls.Add(newButton2);
                newButton2.Click += new EventHandler(this.btnLowerBody_Click);
            }
            else
            {
                Button newButton = new Button();
                newButton.Size = new Size(103, 23);
                newButton.Left = 15;
                newButton.Top = 432;
                newButton.Name = "btnPush";
                newButton.Text = "Push";

                buttons.Add(newButton);
                this.Controls.Add(newButton);
                newButton.Click += new EventHandler(this.btnPush_Click);

                Button newButton2 = new Button();
                newButton2.Size = new Size(103, 23);
                newButton2.Left = 124;
                newButton2.Top = 432;
                newButton2.Name = "btnPull";
                newButton2.Text = "Pull";

                buttons.Add(newButton2);
                this.Controls.Add(newButton2);
                newButton2.Click += new EventHandler(this.btnPull_Click);

                Button newButton3 = new Button();
                newButton3.Size = new Size(103, 23);
                newButton3.Left = 233;
                newButton3.Top = 432;
                newButton3.Name = "btnLowerBody";
                newButton3.Text = "Legs";

                buttons.Add(newButton3);
                this.Controls.Add(newButton3);
                newButton3.Click += new EventHandler(this.btnLowerBody_Click);
            }
        }

        private void setMessage()
        {
            String message = "";
            switch (TrainingType.getDays())
            {
                case 1:
                    message = "Fullbody workout program once a week\r\n\r\n"
                                                + "Full-Body:\r\n"
                                                    + "Chest\r\n"
                                                    + "Shoulders\r\n"
                                                    + "Triceps\r\n"
                                                    + "Back\r\n"
                                                    + "Biceps\r\n"
                                                    + "Quads\r\n"
                                                    + "Glutes\r\n"
                                                    + "Hamstrings\r\n"
                                                    + "Calves\r\n";

                    break;
                case 2:
                    message = "Upper and Lower Body split workout program 2 times a week\r\n\r\n"
                                                + "Upper-Body:\r\n"
                                                    + "Chest\r\n"
                                                    + "Shoulders\r\n"
                                                    + "Triceps\r\n"
                                                    + "Back\r\n"
                                                    + "Biceps\r\n\r\n"
                                                 + "Lower-Body:\r\n"
                                                    + "Biceps\r\n"
                                                    + "Quads\r\n"
                                                    + "Glutes\r\n"
                                                    + "Hamstrings\r\n"
                                                    + "Calves\r\n";
                    break;
                case 3:
                    message = "Push, Pull, Legs workout program 3 times a week\r\n\r\n"
                                                + "Push:\r\n"
                                                    + "Chest\r\n"
                                                    + "Shoulders\r\n"
                                                    + "Triceps\r\n\r\n"
                                                    + "Pull:\r\n"
                                                    + "Back\r\n"
                                                    + "Biceps\r\n\r\n"
                                                    + "Legs:\r\n"
                                                    + "Quads\r\n"
                                                    + "Glutes\r\n"
                                                    + "Hamstrings\r\n"
                                                    + "Calves\r\n";
                    break;
            }

            if (TrainingType.getTrainingName().Equals(TrainingType.NAME_ENDURANCE))
            {
                txtText.Text = TrainingType.getTrainingName() + " Training Routine\r\n\r\n"
                    + "The training routine is a " + TrainingType.NAME_ENDURANCE + " routine using a " + message;
            }
            if (TrainingType.getTrainingName().Equals(TrainingType.NAME_HYPERTROPHY))
            {
                txtText.Text = TrainingType.getTrainingName() + " Training Routine\r\n\r\n"
                    + "The training routine is a " + TrainingType.NAME_HYPERTROPHY + " routine using a " + message;
            }
            if (TrainingType.getTrainingName().Equals(TrainingType.NAME_STRENGTH))
            {
                txtText.Text = TrainingType.getTrainingName() + " Training Routine\r\n\r\n"
                    + "The training routine is a " + TrainingType.NAME_STRENGTH + " routine using a " + message;
            }
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            setButtons();
            setMessage();
        }

        private void btnPush_Click(object sender, EventArgs e)
        {
            if (TrainingType.getTrainingName().Equals(TrainingType.NAME_ENDURANCE))
            {
                enduro = new frmEnduro();
                enduro.Show();
            }
            if (TrainingType.getTrainingName().Equals(TrainingType.NAME_HYPERTROPHY))
            {
                hyper = new frmHyper();
                hyper.Show();
            }
            if (TrainingType.getTrainingName().Equals(TrainingType.NAME_STRENGTH))
            {
                strength = new frmStrength();
                strength.Show();
            }
        }

        private void btnPull_Click(object sender, EventArgs e)
        {
            if (TrainingType.getTrainingName().Equals(TrainingType.NAME_ENDURANCE))
            {
                enduro = new frmEnduro();
                enduro.Show();
            }
            if (TrainingType.getTrainingName().Equals(TrainingType.NAME_HYPERTROPHY))
            {
                hyper = new frmHyper();
                hyper.Show();
            }
            if (TrainingType.getTrainingName().Equals(TrainingType.NAME_STRENGTH))
            {
                strength = new frmStrength();
                strength.Show();
            }
        }

        private void btnUpperBody_Click(object sender, EventArgs e)
        {
            if (TrainingType.getTrainingName().Equals(TrainingType.NAME_ENDURANCE))
            {
                enduro = new frmEnduro(); enduro.Show();
            }
            if (TrainingType.getTrainingName().Equals(TrainingType.NAME_HYPERTROPHY))
            {
                hyper = new frmHyper();
                hyper.Show();
            }
            if (TrainingType.getTrainingName().Equals(TrainingType.NAME_STRENGTH))
            {
                strength = new frmStrength();
                strength.Show();
            }
        }

        private void btnLowerBody_Click(object sender, EventArgs e)
        {
            if (TrainingType.getTrainingName().Equals(TrainingType.NAME_ENDURANCE))
            {
                enduro = new frmEnduro(); enduro.Show();
            }
            if (TrainingType.getTrainingName().Equals(TrainingType.NAME_HYPERTROPHY))
            {
                hyper = new frmHyper();
                hyper.Show();
            }
            if (TrainingType.getTrainingName().Equals(TrainingType.NAME_STRENGTH))
            {
                strength = new frmStrength();
                strength.Show();
            }
        }

        private void btnFullBody_Click(object sender, EventArgs e)
        {
            if (TrainingType.getTrainingName().Equals(TrainingType.NAME_ENDURANCE))
            {
                enduro = new frmEnduro();
            }
            if (TrainingType.getTrainingName().Equals(TrainingType.NAME_HYPERTROPHY))
            {
                hyper = new frmHyper();
                hyper.Show();
            }
            if (TrainingType.getTrainingName().Equals(TrainingType.NAME_STRENGTH))
            {
                strength = new frmStrength();
                strength.Show();
            }
        }
    }
}
