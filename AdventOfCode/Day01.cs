using System.Text.RegularExpressions;

namespace AdventOfCode;

public class Day01 : BaseDay
{
    private readonly string _input;

    public Day01()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public override ValueTask<string> Solve_1()
    {
        var l = getLAndR(out var r);

        l.Sort();
        r.Sort();

        var res = l
            .Select((t, i) => int.Abs(t - r[i]))
            .Sum();

        return new ValueTask<string>($"{res}");
    }

    private List<int> getLAndR(out List<int> r)
    {
        List<int> l = [];
        r = [];
        
        
        foreach (var line in _input.Split("\n"))
        {
            var ll = Regex.Split(line, @"\s+");
            l.Add(int.Parse(ll[0]));
            r.Add(int.Parse(ll[1]));
        }

        return l;
    }

    public override ValueTask<string> Solve_2()
    {
        var l = getLAndR(out var r);
        var rFreq = new Dictionary<int, int>();
        
        foreach (var i in r)
        {
            if (!rFreq.TryGetValue(i, out var e))
            {
                rFreq[i] = 1;
            }
            else
            {
                rFreq[i] = e + 1;
            }
        }

        var res = l.Select(t => rFreq.GetValueOrDefault(t, 0) * t).Sum();
            
        return new ValueTask<string>($"{res}");
    }
}
