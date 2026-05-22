using FastaAnalyzer.Models;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace FastaAnalyzer.Services;

public static class FastaParser
{
    public static List<FastaSequence> Parse(string path)
    {
        var sequences = new List<FastaSequence>();

        string[] lines = File.ReadAllLines(path);

        FastaSequence? current = null;
        StringBuilder sb = new();

        foreach (string line in lines)
        {
            if (line.StartsWith(">"))
            {
                if (current != null)
                {
                    current.Sequence = sb.ToString();
                    sequences.Add(current);
                    sb.Clear();
                }

                current = new FastaSequence
                {
                    Name = line.Substring(1)
                };
            }
            else
            {
                sb.Append(line.Trim());
            }
        }

        if (current != null)
        {
            current.Sequence = sb.ToString();
            sequences.Add(current);
        }

        return sequences;
    }
}