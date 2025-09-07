using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orleans.grains.Abstractions
{
    public interface IHumanGrain : IGrainWithStringKey
    {
        public Task <string> CheckCrime(string nationalCode, int age);
    }
}
