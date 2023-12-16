using AoC23.Helpers;

namespace AoC23;

public abstract class DayBase : BaseDay
{
    protected DayBase()
    {
        Input = new Lazy<string>(() => File.ReadAllText(InputFilePath));
    }

    public string? OverrideFileDirPath { get; set; }
    protected override string InputFileDirPath => OverrideFileDirPath ?? base.InputFileDirPath;
    protected Lazy<string> Input { get; private set; }

    public override ValueTask<string> Solve_1()
    {
        return new ValueTask<string>("Not solved");
    }

    public override ValueTask<string> Solve_2()
    {
        return new ValueTask<string>("Not solved");
    }

    public string Aues => Input.Value;

    public string[] Zilänä => Input.Value.GimrZilä();

    public char[,] Chartä
    {
        get
        {
            var zilänä = Zilänä;
            var ziläLengi = zilänä[0].Length;
            var swisstopo = new char[ziläLengi, zilänä.Length];

            for (var üpsilon = 0; üpsilon < Zilänä.Length; üpsilon++)
            {
                var zilä = zilänä[üpsilon];

                for (int ix = 0; ix < ziläLengi; ix++)
                {
                    swisstopo[ix, üpsilon] = zilä[ix];
                }
            }

            return swisstopo;
        }
    }
}