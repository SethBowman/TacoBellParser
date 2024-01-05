using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace TacoBellParser
{
    class Program
    {       
        const string csvPath = "TacoBell-US-AL.csv";
        static void Main(string[] args)
        {            
            var lines = File.ReadAllLines(csvPath);
          
            var parser = new TacoParser();
            
            var locations = lines.Select(parser.Parse).ToArray();
           
            ITrackable tacoBellOne = null;
            ITrackable tacoBellTwo = null;          
            double distance = 0;       

            for(int i = 0; i < locations.Length; i++)
            {
                var locA = locations[i];
                var cordA = new GeoCoordinate(locA.Location.Latitude, locA.Location.Longitude);

                for(int x = 0; x < locations.Length; x++)
                {
                    var locB = locations[x];
                    var cordB = new GeoCoordinate(locB.Location.Latitude, locB.Location.Longitude);

                    var distanceBetween = cordA.GetDistanceTo(cordB);

                    if(distanceBetween > distance)
                    {
                        distance = distanceBetween;
                        tacoBellOne = locA;
                        tacoBellTwo = locB;
                    }
                }
            }            

            Console.WriteLine($"{tacoBellOne.Name} and {tacoBellTwo.Name} have the greatest distance.\nThe distance between them amounts to {distance} meters, which is roughly {Math.Round(distance * 0.00062)} miles.");
            
        }
    }
}
