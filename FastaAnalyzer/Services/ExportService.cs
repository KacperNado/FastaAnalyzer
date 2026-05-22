using CsvHelper;
using FastaAnalyzer.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace FastaAnalyzer.Services;

public static class ExportService
{
    public static void ExportCsv(List<FastaSequence> seqs, string path)
    {
        using var writer = new StreamWriter(path);
        using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

        csv.WriteRecords(seqs);
    }

    public static void ExportJson(List<FastaSequence> seqs, string path)
    {
        string json = JsonConvert.SerializeObject(seqs, Formatting.Indented);

        File.WriteAllText(path, json);
    }
}