using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunsetSunrise
{
    public class SunModel
    {
        public DateTime Sunrise { get; set; }
        public DateTime Sunset { get; set; }
        public DateTime solar_noon { get; set; }
        public TimeSpan day_length { get; set; }
        public DateTime civil_twilight_begin { get; set; }
        public DateTime civil_twilight_end { get; set; }
        public DateTime nautical_twilight_begin { get; set; }
        public DateTime nautical_twilight_end { get; set; }
        public DateTime astronomical_twilight_begin { get; set; }
        public DateTime astronomical_twilight_end { get; set; }

        public override string ToString()
        {
            StringBuilder retval = new StringBuilder("Sunrise: ").Append('\t').Append('\t').Append('\t').Append(this.Sunrise.ToShortTimeString());
            retval.Append(Environment.NewLine);
            retval.Append("Sunset: ").Append("\t").Append('\t').Append('\t').Append(this.Sunset.ToShortTimeString());
            retval.Append(Environment.NewLine);
            retval.Append("Solar Noon: ").Append("\t").Append('\t').Append(this.solar_noon.ToShortTimeString());
            retval.Append(Environment.NewLine);
            retval.Append("Day Length: ").Append("\t").Append('\t').Append(this.day_length);
            retval.Append(Environment.NewLine);
            retval.Append("Civil Twilight Begin: ").Append("\t").Append('\t').Append(this.civil_twilight_begin.ToShortTimeString());
            retval.Append(Environment.NewLine);
            retval.Append("Civil Twilight End: ").Append("\t").Append('\t').Append(this.civil_twilight_end.ToShortTimeString());
            retval.Append(Environment.NewLine);
            retval.Append("Nautical Twilight Begin: ").Append("\t").Append(this.nautical_twilight_begin.ToShortTimeString());
            retval.Append(Environment.NewLine);
            retval.Append("Nautical Twilight End: ").Append("\t").Append(this.nautical_twilight_end.ToShortTimeString());
            retval.Append(Environment.NewLine);
            retval.Append("Astronomica Twilight Begin: ").Append("\t").Append(this.astronomical_twilight_begin.ToShortTimeString());
            retval.Append(Environment.NewLine);
            retval.Append("Astronomica Twilight End: ").Append("\t").Append(this.astronomical_twilight_end.ToShortTimeString());

            return retval.ToString();
        }
    }

    

}
