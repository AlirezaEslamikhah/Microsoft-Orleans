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


        public async Task<string> GetCrimeStatus(int age)
        {
            var randomNum = new Random().Next(0,1);
            if (randomNum == 0)
            { 
                return "VALID"; 
            } 
            else 
            {
                return "CRIMINAL"; 
            }
        }

    }
}
