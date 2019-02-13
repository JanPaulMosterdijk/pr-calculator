using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr_calculator.models
{
    class Record
    {
        public DateTime eventDate;
        public SwimStyle swimStyle;
        public int time;
        public string timeAsString;
        public string difference;
        public TimeSpan differenceAsTimeSpan;
        public TimeSpan timeAsTimeSpan;
        public TimeSpan oldRecord;

        public Record(DateTime eventDate, SwimStyle swimStyle, int time, TimeSpan oldRecord)
        {
            this.eventDate = eventDate;
            this.swimStyle = swimStyle;
            this.time = time;
            this.oldRecord = oldRecord;

            this.timeAsString = time.ToString();
            string formattedTime = timeAsString.Remove(timeAsString.Length - 3);
            String milliseconds = timeAsString.Remove(0, timeAsString.Length - 3);

            timeAsTimeSpan = TimeSpan.FromSeconds(Convert.ToDouble(formattedTime));
            timeAsTimeSpan = timeAsTimeSpan.Add(TimeSpan.FromMilliseconds(Convert.ToDouble(milliseconds)));

            differenceAsTimeSpan = oldRecord.Add(-timeAsTimeSpan);

            this.timeAsString = timeAsTimeSpan.ToString(@"hh\:mm\:ss\:ff").Replace("00:0", "0").Replace("00", "0");

            this.difference = differenceAsTimeSpan.ToString(@"hh\:mm\:ss\:ff").Replace("00:0", "0").Replace("00", "0");
        }

        public Record(DateTime eventDate, SwimStyle swimStyle, int time)
        {
            this.eventDate = eventDate;
            this.swimStyle = swimStyle;
            this.time = time;

            this.timeAsString = time.ToString();
            string formattedTime = timeAsString.Remove(timeAsString.Length - 3);
            String milliseconds = timeAsString.Remove(0, timeAsString.Length - 3);

            timeAsTimeSpan = TimeSpan.FromSeconds(Convert.ToDouble(formattedTime));
            timeAsTimeSpan = timeAsTimeSpan.Add(TimeSpan.FromMilliseconds(Convert.ToDouble(milliseconds)));

            differenceAsTimeSpan = oldRecord.Add(-timeAsTimeSpan);

            this.timeAsString = timeAsTimeSpan.ToString(@"hh\:mm\:ss\:fff").Replace("00:0", "0").Replace("00", "0");
            this.timeAsString = timeAsString.Remove(timeAsString.Length - 1);

            this.difference = differenceAsTimeSpan.ToString(@"hh\:mm\:ss\:fff").Replace("00:0", "0").Replace("00", "0");
            this.difference = difference.Remove(timeAsString.Length - 1);
        }

        public override string ToString()
        {
            return swimStyle.stroke + " " + swimStyle.distance + "m " + timeAsString.ToString() + " difference: -" + difference + " " + eventDate.ToShortDateString();
        }
    }
}
