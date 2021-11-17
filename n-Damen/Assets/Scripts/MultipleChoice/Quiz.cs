using System;
using System.Linq;
using System.Security.Cryptography;

public class Quiz
{

    private int currentQuestionIndex = 0;

    private int correctAnswers = 0;

    private static Random rand = new Random();
    private Question[] questionList { get; } = new Question[]
    {
        new Question(rand,"Frage1",new Answer("a1",true),new Answer("b2",false),new Answer("c3",false),new Answer("d4",false)),
        new Question(rand,"Frage2",new Answer("a1",true),new Answer("b2",false),new Answer("c3",false),new Answer("d4",false)),
        new Question(rand,"Frage3",new Answer("a1",true),new Answer("b2",false),new Answer("c3",false),new Answer("d4",false)),
    };


    public Quiz()
    {
        // randomsie order of questions
        questionList = questionList.OrderBy(x => rand.Next()).ToArray();
    }

    public Question nextQuestion()
    {
        if (questionList.Length <= currentQuestionIndex)
        {
            return null;
        }
        Question f = questionList[currentQuestionIndex];
        currentQuestionIndex++;
        return f;
    }

    public void incrementCorrect()
    {
        correctAnswers++;
    }

    // return the score as string
    public string getScore()
    {
        return correctAnswers.ToString() + "/" + currentQuestionIndex;
    }

    public string getFinishMessage()
    {
        double percent = correctAnswers * 100.0 / questionList.Length;

        string text = "Du hast " + percent.ToString("0.##") + "% der Fragen richtig beantwortet.\n";

        if (percent >= 90)
        {
            return "Glückwunsch. " + text + "Du hast das Damenproblem und den Backtracking Algorithmus verstanden.";
        }
        else if (percent >= 75)
        {
            return "Gut. " + text + "Du hast das Damenproblem und den Backtracking Algorithmus größtenteils verstanden.";
        }
        else if (percent >= 50)
        {
            return "Schade. " + text + "Du hast das Damenproblem und den Backtracking Algorithmus teilweise verstanden aber das geht doch noch besser.";
        }

        return "Das war wohl nix. " + text + "Du must dich nochmal ausführlich mit dem Backtracking Algorithmus und dem Damenproblem auseinandersetzten.";
    }
}
