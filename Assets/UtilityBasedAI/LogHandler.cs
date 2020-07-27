using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityAI
{
    public interface ILogHandler
    {
        void WriteText(string text);

        void Initialise();

    }
}
