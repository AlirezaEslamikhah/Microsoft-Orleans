using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orleans.grains.Abstractions
{
    public interface IPoliceGrain :  IGrainWithStringKey
    {
        public  Task<string> GetCrimeStatus(int age);
    }
}
