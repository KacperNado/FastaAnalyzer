using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using FastaAnalyzer.Models;
using FastaAnalyzer.Services;



using System.Collections.ObjectModel;
using System.Linq;

namespace FastaAnalyzer.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    public ObservableCollection<FastaSequence> Sequences { get; set; }
        = new();

    private FastaSequence? _selectedSequence;

    public FastaSequence? SelectedSequence
    {
        get => _selectedSequence;

        set
        {
            SetProperty(ref _selectedSequence, value);

            if (value != null)
            {
                GCContent = SequenceAnalyzer.CalculateGC(value.Sequence);

                Codons = SequenceAnalyzer.CountCodons(value.Sequence);

                CountA = SequenceAnalyzer.CountBase(value.Sequence, 'A');
                CountT = SequenceAnalyzer.CountBase(value.Sequence, 'T');
                CountG = SequenceAnalyzer.CountBase(value.Sequence, 'G');
                CountC = SequenceAnalyzer.CountBase(value.Sequence, 'C');
            }
        }
    }

    private double _gcContent;

    public double GCContent
    {
        get => _gcContent;
        set => SetProperty(ref _gcContent, value);
    }

    private int _codons;

    public int Codons
    {
        get => _codons;
        set => SetProperty(ref _codons, value);
    }

    private int _countA;

    public int CountA
    {
        get => _countA;
        set => SetProperty(ref _countA, value);
    }

    private int _countT;

    public int CountT
    {
        get => _countT;
        set => SetProperty(ref _countT, value);
    }

    private int _countG;

    public int CountG
    {
        get => _countG;
        set => SetProperty(ref _countG, value);
    }

    private int _countC;

    public int CountC
    {
        get => _countC;
        set => SetProperty(ref _countC, value);
    }

   

    [RelayCommand]
    public void LoadFasta()
    {
        string path = "sample.fasta";

        var loaded = FastaParser.Parse(path);

        Sequences.Clear();

        foreach (var s in loaded)
            Sequences.Add(s);

        
    }

    [RelayCommand]
    public void ExportCsv()
    {
        ExportService.ExportCsv(Sequences.ToList(), "export.csv");
    }

    [RelayCommand]
    public void ExportJson()
    {
        ExportService.ExportJson(Sequences.ToList(), "export.json");
    }

    
}