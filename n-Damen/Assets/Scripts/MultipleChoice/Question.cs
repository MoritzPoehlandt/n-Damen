using System;
using System.Linq;
using System.Security.Cryptography;

public class Question
{
    public string Text { get; }
    public Answer[] Answers { get; } = new Answer[4];

    public Question(string text, Answer a, Answer b, Answer c, Answer d)
    {
        Text = text;
        Answers[0] = a;
        Answers[1] = b;
        Answers[2] = c;
        Answers[3] = d;

        // randomsie order of answers
        Random rand = new Random();
        Answers = Answers.OrderBy(x => rand.Next()).ToArray();
    }
}
