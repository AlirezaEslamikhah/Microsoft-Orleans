using orleans.grains.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orleans.grains.Grains
{
    public class HumanGrain : Grain, IHumanGrain
    {

        public async Task<string> CheckCrime( string nationalCode , int age)
        {
            var policeGrain = GrainFactory.GetGrain<IPoliceGrain> (nationalCode);  
            string result =  await policeGrain.GetCrimeStatus(age);
            return result;
        }

     
    }
}
