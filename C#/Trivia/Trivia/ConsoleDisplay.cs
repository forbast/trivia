using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia
{
    class ConsoleDisplay : IDisplay
    {
        public void Display(String text)
        {
            Console.WriteLine(text);
        }

    }
}
