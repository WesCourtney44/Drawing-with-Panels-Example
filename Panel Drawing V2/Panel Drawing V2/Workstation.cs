using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Panel_Drawing_V2
{
    class Workstation
    {
        private Student student;
        private ActivityPanel activityPanel;
        Random random = new Random();
        public Workstation(Student student)
        {
            this.student = student;
            this.activityPanel = new ActivityPanel();
        }

        //This method is a placeholder which represents when
        //the switch probes the workstation for net activity
        //---------------------------------------------------
        //In this case, the "random" is a filler for net
        //activity in the form of an integer.
        public void probeNetActivity()
        {
            activityPanel.addDataLine(Form1.random.Next(0, 100));
        }
        public ActivityPanel getActivityPanel() { return activityPanel; }
    }
}
