using System;

namespace Trivia
{
    internal class QuestionStacks
    {

        QuestionStack popQuestions = new QuestionStack("Pop");
        QuestionStack scienceQuestions = new QuestionStack("Science");
        QuestionStack sportsQuestions = new QuestionStack("Sports");
        QuestionStack rockQuestions = new QuestionStack("Rock");

        public void AskQuestion(String currentCategory)
        {
            if (currentCategory == popQuestions.Categorie)
            {
                popQuestions.ReadFirstQuestion();
            }
            if (currentCategory == scienceQuestions.Categorie)
            {
                scienceQuestions.ReadFirstQuestion();
            }
            if (currentCategory == sportsQuestions.Categorie)
            {
                sportsQuestions.ReadFirstQuestion();
            }
            if (currentCategory == rockQuestions.Categorie)
            {
                rockQuestions.ReadFirstQuestion();
            }
        }
        public void GenerateStacksQuestions()
        {
            for (var i = 0; i < 50; i++)
            {
                popQuestions.AddLast("Pop Question " + i);
                scienceQuestions.AddLast(("Science Question " + i));
                sportsQuestions.AddLast(("Sports Question " + i));
                rockQuestions.AddLast("Rock Question " + i);
            }
        }

    }
}