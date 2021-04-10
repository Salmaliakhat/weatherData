using System;
using System.IO;
using System.Linq;

namespace DayMinTempSpread
{
    class Program
    {
        static void Main(string[] args)
        {
            var enviroment = System.Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(enviroment).Parent.FullName;

            string rawData = File.ReadAllText(projectDirectory+"/App_Data/weather.dat");

            var temperatureData = TemperatureData.ExtractFromRawData(rawData);
            Console.WriteLine($"Read {temperatureData.Count()} lines of weather data.");

            Func<TemperatureData, int> temperatureSpread = data => data.MaxTemp - data.MinTemp;
            var smallestSpread = temperatureData.OrderBy(temperatureSpread).First();

            Console.WriteLine("Day with the smallest temperature spread:");
            Console.WriteLine($"{smallestSpread.Day} (with a temperature spread of {temperatureSpread(smallestSpread)}°F)");

            Console.ReadLine();
        }
    }
}
