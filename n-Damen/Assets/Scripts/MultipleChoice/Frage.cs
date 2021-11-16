using System;
using System.Linq;
using System.Security.Cryptography;

public class Frage
{
    public string Text { get; }
    public Antwort[] Antworten { get; } = new Antwort[4];

    public Frage(string text, Antwort a, Antwort b, Antwort c, Antwort d)
    {
        Text = text;
        Antworten[0] = a;
        Antworten[1] = b;
        Antworten[2] = c;
        Antworten[3] = d;

        // randomisiere the reihenfolge der antworten
        Random rand = new Random();
        Antworten = Antworten.OrderBy(x => rand.Next()).ToArray();
    }
}