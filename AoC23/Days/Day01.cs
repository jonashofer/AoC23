using AoC23.Helpers;

namespace AoC23.Days;

public class Day01 : DayBase
{
    public override ValueTask<string> Solve_1() => ZahläGspürä(Zilänä);

    public override ValueTask<string> Solve_2() => ZahläGspürä(BitteMitRichtigäZahlä(Aues).GimrZilä());

    private static ValueTask<string> ZahläGspürä(IEnumerable<string> zilänä) => new(zilänä.Sum(l => 10 * int.Parse($"{l.First(char.IsDigit)}") + int.Parse($"{l.Last(char.IsDigit)}")).ToString());

    private static string BitteMitRichtigäZahlä(string aues) => aues
        .Replace("one", "o1e")
        .Replace("two", "t2o")
        .Replace("three", "t3e")
        .Replace("four", "f4r")
        .Replace("five", "f5e")
        .Replace("six", "s6x")
        .Replace("seven", "s7n")
        .Replace("eight", "e8t")
        .Replace("nine", "n9e");
}