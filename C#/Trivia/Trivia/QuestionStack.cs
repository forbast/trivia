using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    class QuestionStack
    {
        LinkedList<string> popQuestions = new LinkedList<string>();
        public string Type { get; private set; }


        public QuestionStack(string type)
        {
            this.Type = type;
        }

        public void AddLast(string s)
        {
            popQuestions.AddLast(s);
        }

        public void ReadFirstQuestion()
        {
            Console.WriteLine(popQuestions.First());
            popQuestions.RemoveFirst();
        }
    }
}
