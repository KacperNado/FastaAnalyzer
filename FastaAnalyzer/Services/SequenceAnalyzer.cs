using System.Linq;

namespace FastaAnalyzer.Services;

public static class SequenceAnalyzer
{
    public static double CalculateGC(string seq)
    {
        seq = seq.ToUpper();

        int gc = seq.Count(c => c == 'G' || c == 'C');

        return seq.Length == 0 ? 0 : (double)gc / seq.Length * 100;
    }

    public static int CountCodons(string seq)
    {
        return seq.Length / 3;
    }

    public static int CountBase(string seq, char b)
    {
        return seq.ToUpper().Count(c => c == char.ToUpper(b));
    }
}