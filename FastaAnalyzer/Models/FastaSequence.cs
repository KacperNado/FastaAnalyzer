namespace FastaAnalyzer.Models;

public class FastaSequence
{
    public string Name { get; set; } = "";
    public string Sequence { get; set; } = "";

    public int Length => Sequence.Length;
}