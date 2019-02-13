using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr_calculator.models
{
    class Result
    {
        public DateTime eventDate;
        public SwimStyle swimStyle;
        public int time;

        public Result(DateTime eventDate, SwimStyle swimStyle, int time)
        {
            this.eventDate = eventDate;
            this.swimStyle = swimStyle;
            this.time = time;
        }

        public override string ToString()
        {
            return swimStyle.stroke + " " + swimStyle.distance + "m " + time.ToString() + " " + eventDate.ToShortDateString();
        }
    }
}
