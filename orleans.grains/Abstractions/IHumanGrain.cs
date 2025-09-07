using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orleans.grains.Abstractions
{
    public interface IHumanGrain : IGrainWithStringKey
    {
        public Task Initialise(string name , string lastname , string nationalcode);
        public Task <string> CheckCrime();
    }
}
