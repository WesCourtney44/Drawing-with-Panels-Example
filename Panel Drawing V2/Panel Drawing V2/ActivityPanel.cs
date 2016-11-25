using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Panel_Drawing_V2
{
    class ActivityPanel : Panel
    {
        private List<DataLine> dataLines;

        //A constant to control horizontal spacing between lines
        private const int HOR_SPACER = 4;
        public ActivityPanel()
        {
            dataLines = new List<DataLine>();
        }

        //Adds a new dataline, and moves previous lines to the right.
        public void addDataLine(int activityValue)
        {
            foreach(DataLine dataLine in dataLines)
            {

                //Move low point to the right
                Point currentPoint1 = dataLine.getPoint1();
                dataLine.setPoint1(new Point(currentPoint1.X + HOR_SPACER, currentPoint1.Y));

                //Move high point to the right
                Point currentPoint2 = dataLine.getPoint2();
                dataLine.setPoint2(new Point(currentPoint2.X + HOR_SPACER, currentPoint2.Y));
            }

            //Create the new line
            Point point1 = new Point(HOR_SPACER, this.Height);
            Point point2 = new Point(HOR_SPACER, this.Height - activityValue);
            dataLines.Add(new DataLine(point1, point2));

            //Delete Old DataLines (clean up memory)
            for(int i = 0; i < dataLines.Count; i++)
            {
                if (dataLines[i].getPoint1().X > this.Width)
                {
                    dataLines.Remove(dataLines[i]);
                    i = 0;
                }
            }
            this.Refresh();
        }
        public List<DataLine> getDataLines() { return dataLines; }
    }

    class DataLine
    {
        private Point point1, point2;
        public DataLine(Point point1, Point point2)
        {
            this.point1 = point1;
            this.point2 = point2;
        }
        public Point getPoint1() { return this.point1; }
        public void setPoint1(Point point1) { this.point1 = point1; }
        public Point getPoint2() { return this.point2; }
        public void setPoint2(Point point2) { this.point2 = point2; }
    }

}
