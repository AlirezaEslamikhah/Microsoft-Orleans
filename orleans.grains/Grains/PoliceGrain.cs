using orleans.grains.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orleans.grains.Grains
{
    public class PoliceGrain : Grain, IPoliceGrain
    {
        private string _nationalcode; 
        public async Task<string> GetCrimeStatus()
        {
            var randomnum = new Random().Next(0,1);
            if (randomnum == 0)
            {
                return "VALID";
            }
            else 
            {
                return "CRIMINAL"; 
            }
        }

        public async Task Initialise(string nationalcode)
        {
            this._nationalcode = nationalcode;
        }
    }
}
