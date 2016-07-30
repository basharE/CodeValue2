using System;
using System.Xml.Linq;

namespace DynamicXml
{
    class Program
    {
        static void Main()
        {
            dynamic planets = DynamicXElement.Create(XElement.Load("planets.xml"));
            var mercury = planets.Planet;
            Console.WriteLine(mercury);
            var venus = planets["Planet", 1];     
            Console.WriteLine(venus);
            var ourMoon = planets["Planet", 2].Moons.Moon;
            Console.WriteLine(ourMoon);
            var marsMoon = planets["Planet", 3]["Moons", 1].Moon;  
            Console.WriteLine(marsMoon);
        }
    }
}
