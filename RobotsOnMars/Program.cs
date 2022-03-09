using RobotsOnMars.Engines;
using RobotsOnMars.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace RobotsOnMars
{
    public class Program
    {
        static void Main(string[] args)
        {
            var validValues = false;
            Mars mars = null;
            List<Robot> robots = null;
            MarsEngine _marsEngine = new MarsEngine();
            RobotsEngine _robotsEngine = new RobotsEngine();

            while (!validValues)
            {
                try
                {
                    Console.WriteLine("Enter Mars Dimensions: ");
                    var marsInput = Console.ReadLine();
                    mars = _marsEngine.GenerateMars(marsInput);
                    int cnt = 0;
                    string position;
                    List<string> input = new List<string>();
                    do
                    {
                        Console.WriteLine($"Robot #{++cnt}");
                        Console.WriteLine("Enter initial position: ");
                        position = Console.ReadLine();
                        if(!string.IsNullOrEmpty(position))
                        {
                            Console.WriteLine("Enter instructions: ");
                            var robotInput = $"{position};{Console.ReadLine()}";
                            input.Add(robotInput);
                        }
                    }
                    while (!string.IsNullOrEmpty(position));
                    if (!input.Any())
                    {
                        throw new InvalidOperationException();
                    }
                    Console.WriteLine("Generating robots...");
                    robots = _robotsEngine.GenerateRobotsList(input);
                    if (!robots.Any())
                    {
                        throw new InvalidOperationException();
                    }
                    validValues = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Please, check your values and try again!");
                }
            }

            //Console.ReadLine();



        }
    }
}
