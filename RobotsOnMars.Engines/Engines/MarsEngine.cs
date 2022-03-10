using RobotsOnMars.Abstractions;
using RobotsOnMars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsOnMars.Engines
{
    public class MarsEngine : IMarsEngine
    {
        private readonly IInputEngine _inputEngine;
        public MarsEngine(IInputEngine inputEngine)
        {
            _inputEngine = inputEngine;
        }
        public Mars GenerateMars(string input)
        {
            try
            {
                if (string.IsNullOrEmpty(input))
                {
                    throw new ArgumentNullException("Input for Mars cannot be null");
                }
                var mars = new Mars
                {
                    MaxExtension = _inputEngine.GetMaxExtension(input),
                    RobotsOnMars = new List<Robot>()
                };

                return mars;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
