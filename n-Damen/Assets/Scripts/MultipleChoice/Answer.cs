public readonly struct Answer
{
    public string Text { get; }
    public bool Correct { get; }

    public Answer(string text, bool correct)
    {
        Text = text;
        Correct = correct;
    }

}
