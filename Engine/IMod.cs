using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public interface IMod
    {

        string Name { get; }

        string Version { get; }

        void Initialize();

    }
}
