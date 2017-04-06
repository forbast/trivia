using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    class QuestionStack
    {
        LinkedList<string> questions = new LinkedList<string>();
        public string Categorie { get; private set; }


        public QuestionStack(string categorie)
        {
            this.Categorie = categorie;
        }

        public void AddLast(string s)
        {
            questions.AddLast(s);
        }

        public void ReadFirstQuestion()
        {
            Console.WriteLine(questions.First());
            questions.RemoveFirst();
        }
    }
}
