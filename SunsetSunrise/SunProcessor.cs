using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SunsetSunrise
{
    public class SunProcessor
    {
        public async Task<SunModel> GetRiseInfo(String latitude, string longitude, DateTime date)
        {
            SunModel retval = null;

            string month = date.Month < 10 ? $"0{date.Month}" : date.Month.ToString();
            
            string dateform = $"{date.Year}-{month}-{date.Day}";  

            HttpClient client = new HttpClient();

            HttpResponseMessage responseMessage = await client.GetAsync($"https://api.sunrise-sunset.org/json?lat={latitude}&lng={longitude}&date={dateform}");

            string requestContent = await responseMessage.Content.ReadAsStringAsync();
            SunResultModel restResult = JsonConvert.DeserializeObject<SunResultModel>(requestContent);

            retval = restResult.Results;

            //convert to system time
            retval = ConvertToSystemTime(retval);

            return retval;
        }

        private SunModel ConvertToSystemTime(SunModel preconversionResults)
        {
            SunModel retval = new SunModel();

            retval.Sunrise = preconversionResults.Sunrise.ToLocalTime();
            retval.Sunset = preconversionResults.Sunset.ToLocalTime();
            retval.solar_noon = preconversionResults.solar_noon.ToLocalTime();
            retval.day_length = preconversionResults.day_length;
            retval.civil_twilight_begin = preconversionResults.civil_twilight_begin.ToLocalTime();
            retval.civil_twilight_end = preconversionResults.civil_twilight_end.ToLocalTime();
            retval.nautical_twilight_begin = preconversionResults.nautical_twilight_begin.ToLocalTime();
            retval.nautical_twilight_end = preconversionResults.nautical_twilight_end.ToLocalTime();
            retval.astronomical_twilight_begin = preconversionResults.astronomical_twilight_begin.ToLocalTime();
            retval.astronomical_twilight_end = preconversionResults.astronomical_twilight_end.ToLocalTime();

            return retval;
        }
    }
}
