using System;
using System.Linq;
using System.Security.Cryptography;

public class Fragen
{

    private int AktuelleFrage = 0;
    private Frage[] FragenListe { get; } = new Frage[]
    {
        new Frage("Frage1",new Antwort("a1",true),new Antwort("b2",false),new Antwort("c3",false),new Antwort("d4",false)),
        new Frage("Frage2",new Antwort("a1",true),new Antwort("b2",false),new Antwort("c3",false),new Antwort("d4",false)),
        new Frage("Frage3",new Antwort("a1",true),new Antwort("b2",false),new Antwort("c3",false),new Antwort("d4",false)),
    };


    public Fragen()
    {
        // randomisiere the reihenfolge der liste
        Random rand = new Random();
        FragenListe = FragenListe.OrderBy(x => rand.Next()).ToArray();
    }

    public Frage naechsteFrage()
    {
        if (FragenListe.Length <= AktuelleFrage)
        {
            return null;
        }
        Frage f = FragenListe[AktuelleFrage];
        AktuelleFrage++;
        return f;
    }
}