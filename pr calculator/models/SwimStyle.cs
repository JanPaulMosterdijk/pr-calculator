using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr_calculator.models
{
    class SwimStyle
    {
        public int id;
        public int distance;
        public string stroke;

        public SwimStyle(int id, int distance, int stroke) {
            this.id = id;
            this.distance = distance;
            switch (stroke) {
                case 1:
                    this.stroke = "freestyle";
                    break;
                case 2:
                    this.stroke = "backstroke";
                    break;
                case 3:
                    this.stroke = "breaststroke";
                    break;
                case 4:
                    this.stroke = "butterfly";
                    break;
                case 5:
                    this.stroke = "medley";
                    break;
            }
        }

        public override string ToString()
        {
            return stroke + " " + distance;
        }
    }
}
