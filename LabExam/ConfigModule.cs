using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace LabExam
{
    public class ConfigModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            this.Bind<IStorage>().To<ListStorage>();
        }
    }
}
