<Query Kind="Statements">
  <Reference Relative="05 input.txt">&lt;UserProfile&gt;/Documents/GitHub/AoC-2025/05 input.txt</Reference>
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

var input = @"3-5
10-14
16-20
12-18

1
5
8
11
17
32".Split("\r\n");

input = File.ReadAllLines("05 input.txt");

var parts = MoreEnumerable.Split(input, "").ToArray();
var ranges = parts[0].Select(x => x.Split("-").Select(long.Parse).ToArray()).Select(x => (x[0], x[1])).ToHashSet();
var ids = parts[1].Select(long.Parse);

ids.Count(x => ranges.Any(y => x >= y.Item1 && x <= y.Item2)).Dump("Answer 1");

var dupes =
  from a in ranges
  from b in ranges
  where a != b && a.Item1 <= b.Item2 && b.Item1 <= a.Item2
  select (a, b, c: (Math.Min(a.Item1, b.Item1), Math.Max(a.Item2, b.Item2)));

while (dupes.FirstOrDefault() is var item && item != default)
{
  ranges.Remove(item.a);
  ranges.Remove(item.b);
  ranges.Add(item.c);
}

ranges.Sum(x => x.Item2 - x.Item1 + 1).Dump("Answer 2");