public readonly struct Antwort
{
    public string Text { get; }
    public bool Richtig { get; }

    public Antwort(string text, bool richtig)
    {
        Text = text;
        Richtig = richtig;
    }

}