using System.Text.RegularExpressions;

namespace AdventOfCode;

public class Day02 : BaseDay
{
    private readonly string[] _input;

    public Day02()
    {
        _input = File.ReadAllLines(InputFilePath);
    }

    public override ValueTask<string> Solve_1()
    {
        File.ReadAllLines(InputFilePath);
        var r = _input
            .Select(t => t.Split(" ").Select(int.Parse).ToList())
            .Count(IsSafe);
        return new ValueTask<string>($"{r}");
    }
    
    public override ValueTask<string> Solve_2()
    {
        File.ReadAllLines(InputFilePath);
        var r = _input
            .Select(t => t.Split(" ").Select(int.Parse).ToList())
            .Count(ints => IsSafe(ints) || Enumerable.Range(0, ints.Count).Any(ii => IsSafe(Skip(ints, ii))));
        return new ValueTask<string>($"{r}");
    }

    private static List<int> Skip(List<int> p, int ii)
    {
        return p.Where((_, i) => i != ii).ToList();
    }

    private static bool IsSafe(List<int> p)
    {
        return Enumerable.Range(1, p.Count - 1)
                   .Select(i => i)
                   .All(i =>
                   {
                       double d = p[i] - p[i - 1];
                       return d is >= 1 and <= 3;
                   })
               ||
               Enumerable.Range(1, p.Count - 1)
                   .Select(i => i)
                   .All(i =>
                   {
                       double d = p[i - 1] - p[i];
                       return d is >= 1 and <= 3;
                   })
            ;
    }
}