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
        new Question(rand,"Welche Komplexität besitzt der Backtracking Algorithmus zum Lösen des Damenproblems?",new Answer("O(1)",false),new Answer("O(n)",false),new Answer("O(n!)",true),new Answer("O(n^2)",false)),
        new Question(rand,"Wofür eignet sich ein Backtracking Algorithmus nicht?",new Answer("Damenproblem",false),new Answer("Lösen eines Sudoku",false),new Answer("Wegsuche in einem Graphen",false),new Answer("Invertieren einer Liste",true)),
        new Question(rand,"Wie viele eindeutige Lösungen gibt es für das Damenproblem auf einem 3x3 Feld?",new Answer("0",true),new Answer("1",false),new Answer("2",false),new Answer("3",false)),
        new Question(rand,"Wie viele Lösungen gibt es für das Damenproblem auf einem klassische 8x8 Schachbrett insgesamt?",new Answer("1",false),new Answer("12",false),new Answer("92",true),new Answer("40320 (8!)",false)),
        new Question(rand,"Das Backtracking nutzt das Prinzip der ...",new Answer("Tiefensuche",true),new Answer("Breitensuche",false),new Answer("Warteschlange",false),new Answer("Listensuche",false)),
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
