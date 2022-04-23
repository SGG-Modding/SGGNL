using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Mod : IMod
    {
        public virtual string Name => "Undefined";

        public virtual string Version => "Undefined";

        public virtual void Initialize() { }
    }
}
