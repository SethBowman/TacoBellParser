using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacoBellParser
{
    public class TacoBell : ITrackable
    {
        public string Name { get; set; }
        public Point Location { get; set; }

        public TacoBell()
        {
            
        }

        public TacoBell(string name, Point location)
        {
            Name = name;
            Location = location;
        }
    }
}
