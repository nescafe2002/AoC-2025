<Query Kind="Statements">
  <Reference Relative="08 input.txt">C:\Drive\Challenges\AoC 2025\08 input.txt</Reference>
</Query>

var input = @"162,817,812
57,618,57
906,360,560
592,479,940
352,342,300
466,668,158
542,29,236
431,825,988
739,650,466
52,470,668
216,146,977
819,987,18
117,168,530
805,96,715
346,949,466
970,615,88
941,993,340
862,61,35
984,92,344
425,690,689".Split("\r\n");

input = File.ReadAllLines("08 input.txt");

var points = input.Select(x => x.Split(",").Select(int.Parse).ToArray()).ToList();

var pairs =
  from left in points
  from right in points
  where left[0] < right[0] || (left[0] == right[0] && (left[1] < right[1] || (left[1] == right[1] && left[2] < right[2])))
  orderby Math.Sqrt(Enumerable.Range(0, left.Length).Sum(i => Math.Pow(Math.Abs(left[i] - right[i]), 2)))
  select (left, right);

var sets = new List<HashSet<int[]>>();

foreach (var (pair, i) in pairs.Select((x, i) => (x, i + 1)))
{
  if (sets.FirstOrDefault(x => x.Contains(pair.left)) is var set1 && set1 == null)
  {
    sets.Add(set1 = new HashSet<int[]>());
  }

  if (sets.FirstOrDefault(x => x != set1 && x.Contains(pair.right)) is var set2 && set2 != null)
  {
    set1.UnionWith(set2);
    sets.Remove(set2);
  }

  set1.UnionWith(new[] { pair.left, pair.right });

  if (set1.Count == input.Length)
  {
    (pair.left[0] * pair.right[0]).Dump("Answer 2");
    return;
  }
  else if (i == input.Length switch { 20 => 10, _ => 1000 })
  {
    sets.OrderByDescending(x => x.Count).Take(3).Aggregate(1, (x, y) => x * y.Count).Dump("Answer 1");
  }
}