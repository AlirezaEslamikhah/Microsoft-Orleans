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
        private  string? _name;
        private  string? _lastname;
        private  string? _nationalcode; 


        public async Task<string> CheckCrime()
        {
            var policeGrain = GrainFactory.GetGrain<IPoliceGrain> (_nationalcode);  
            string result =  await policeGrain.GetCrimeStatus();
            return result;
        }

        public async Task Initialise(string name, string lastname, string nationalcode)
        {
            this._name = name;
            this._lastname = lastname;
            this._nationalcode = nationalcode;
            var policeGrain = GrainFactory.GetGrain<IPoliceGrain> (nationalcode);
            await policeGrain.Initialise(nationalcode);
        }
    }
}
