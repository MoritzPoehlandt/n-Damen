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
        new Question(rand,"Welche Komplexität besitzt der Backtracking Algorithmus zum Lösen des Damenproblems?",new Answer("O(1)",false),new Answer("O(n)",false),new Answer("O(k^n)",true),new Answer("O(n^2)",false)),
        new Question(rand,"Wofür eignet sich ein Backtracking Algorithmus nicht?",new Answer("Damenproblem",false),new Answer("Lösen eines Sudoku",false),new Answer("Wegsuche in einem Graphen",false),new Answer("Invertieren einer Liste",true)),
        new Question(rand,"Wie viele eindeutige Lösungen gibt es für das Damenproblem auf einem 3x3 Feld?",new Answer("0",true),new Answer("1",false),new Answer("2",false),new Answer("3",false)),
        new Question(rand,"Das Backtracking nutzt das Prinzip der ...",new Answer("Tiefensuche",true),new Answer("Breitensuche",false),new Answer("Warteschlange",false),new Answer("Listensuche",false)),
        new Question(rand,"Welche der folgenden Aussagen stimmt für den Algorithmus zum Lösen des Damenproblems für Spielfelder der Größe n > 1?",
            new Answer("Es gibt immer genau eine Lösung",false), new Answer("Es gibt gar keine Lösung für das Problem",false),
            new Answer("Nicht alle Feldgrößen haben eine Lösung",true), new Answer("Die Anzahl der Lösungen ist gleich der Feldgröße n",false)),
        new Question(rand,"Wann wird in dem Algorithmus eine Dame zurückgesetzt?",
            new Answer("Wenn eine Dame am Spielfeldrand platziert wurde",false), new Answer("Wenn in der nächsten Reihe ein genau ein freies Feld ist",false),
            new Answer("Wenn mehr als zwei Damen platziert wurden",false), new Answer("Wenn keine weitere Dame platziert werden kann oder eine Lösung gefunden wurde",true)),
        new Question(rand,"Die Laufzeit des Algorithmus im bei steigender Spielfeldgröße n verhält sich...",
            new Answer("konstant",false), new Answer("linear",false),
            new Answer("exponentiell",true), new Answer("logarithmisch",false)),
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
