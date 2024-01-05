using System;

namespace TacoBellParser
{
    public class TacoParser
    {
        public ITrackable Parse(string line)
        {
            var cells = line.Split(',');

            if (cells.Length < 3)
            {

                Console.WriteLine("There was an error.");
                return null;
            }

            var latitude = double.Parse(cells[0]);
            var longitude = double.Parse(cells[1]);
            var storeName = cells[2];

            var location = new Point(latitude, longitude);
            var tacoBell = new TacoBell(storeName, location);

            return tacoBell;
        }
    }
}
