using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DayMinTempSpread
{
    internal class TemperatureData
    {
        public int Day { get; private set; }
        public int MaxTemp { get; private set; }
        public int MinTemp { get; private set; }

        private TemperatureData(int day, int maxTemp, int minTemp)
        {
            Day = day;
            MaxTemp = maxTemp;
            MinTemp = minTemp;
        }

        public static IEnumerable<TemperatureData> ExtractFromRawData(string rawData)
        {
            var pattern = @"^\s*(\d+)\s+(\d+)\**\s+(\d+)\**";
            var regex = new Regex(pattern, RegexOptions.Multiline);
            var matches = regex.Matches(rawData);

            foreach (Match match in matches)
            {
                var day = int.Parse(match.Groups[1].Value);
                var maxTemp = int.Parse(match.Groups[2].Value);
                var minTemp = int.Parse(match.Groups[3].Value);

                yield return new TemperatureData(day, maxTemp, minTemp);
            }
        }
    }
}
