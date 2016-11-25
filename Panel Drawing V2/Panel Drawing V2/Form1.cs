using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Panel_Drawing_V2
{
    public partial class Form1 : Form
    {

        public static Random random = new Random();

        private List<Student> students;
        private List<Workstation> workstations;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            students = new List<Student>();
            workstations = new List<Workstation>();

            //Add students
            students.Add(new Student("Timmy", "Thomas"));
            students.Add(new Student("Henry", "Adams"));
            students.Add(new Student("Stephen", "Miller"));

            //Add workstations for each student
            foreach (Student student in students)
            {
                workstations.Add(new Workstation(student));
            }

            //Add Activity Panels for each workstation
            const int MARGIN = 10;
            int x = MARGIN;
            foreach (Workstation workstation in workstations)
            {
                ActivityPanel activityPanel = workstation.getActivityPanel();
                activityPanel.Paint += new PaintEventHandler(activityPanelPaint);
                activityPanel.BorderStyle = BorderStyle.FixedSingle;
                activityPanel.Width = 150;
                activityPanel.BackColor = Color.LimeGreen;
                activityPanel.SetBounds(x, MARGIN, activityPanel.Width, activityPanel.Height);
                this.Controls.Add(activityPanel);
                x += activityPanel.Width + MARGIN;
            }

            //Probe all workstations for network activity
            //a given number of times
            foreach (Workstation workstation in workstations)
            {
                int probeCount = 54;
                for (int i = 0; i < probeCount; i++)
                {
                    workstation.probeNetActivity();
                }
            }
        }

        //The paint event for all activity panels
        public void activityPanelPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            var p = new Pen(Color.Black, 1);
            ActivityPanel activityPanel = sender as ActivityPanel;
            foreach (DataLine dataLine in activityPanel.getDataLines())
            {
                Point point1 = dataLine.getPoint1();
                Point point2 = dataLine.getPoint2();
                g.DrawLine(p, point1, point2);
            }

            
        }

        //A button added to simulate net activity probing
        private void ProbeWorkstations_Click(object sender, EventArgs e)
        {
            foreach (Workstation workstation in workstations)
            {
                workstation.probeNetActivity();
            }
        }
    }
}
