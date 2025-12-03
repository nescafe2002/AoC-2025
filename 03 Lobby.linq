<Query Kind="Statements">
  <Reference Relative="03 input.txt">&lt;UserProfile&gt;/Documents/GitHub/AoC-2025/03 input.txt</Reference>
</Query>

var input = @"987654321111111
811111111111119
234234234234278
818181911112111".Split("\r\n");

input = File.ReadAllLines("03 input.txt");

input.Select(x => Enumerable.Range(0, x.Length - 1).Select(i => Enumerable.Range(1, x.Length - i - 1).Select(j => (x[i] - '0') * 10 + (x[i + j] - '0')).Max()).Max()).Sum().Dump("Answer 1");

IEnumerable<int> FindMax(IEnumerable<int> list, string line)
{
  var c = list.ToArray();
  var m = c.Max(x => line[x]);
  return c.Where(x => line[x] == m);
}

var answer =
  from line in input
  let l = line.Length
  let pos =
    from p0 in FindMax(Enumerable.Range(0, l - 11), line)
    from p1 in FindMax(Enumerable.Range(p0 + 1, l - p0 - 11), line)
    from p2 in FindMax(Enumerable.Range(p1 + 1, l - p1 - 10), line)
    from p3 in FindMax(Enumerable.Range(p2 + 1, l - p2 - 9), line)
    from p4 in FindMax(Enumerable.Range(p3 + 1, l - p3 - 8), line)
    from p5 in FindMax(Enumerable.Range(p4 + 1, l - p4 - 7), line)
    from p6 in FindMax(Enumerable.Range(p5 + 1, l - p5 - 6), line)
    from p7 in FindMax(Enumerable.Range(p6 + 1, l - p6 - 5), line)
    from p8 in FindMax(Enumerable.Range(p7 + 1, l - p7 - 4), line)
    from p9 in FindMax(Enumerable.Range(p8 + 1, l - p8 - 3), line)
    from pa in FindMax(Enumerable.Range(p9 + 1, l - p9 - 2), line)
    from pb in FindMax(Enumerable.Range(pa + 1, l - pa - 1), line)
    select (line[p0] - '0') * 100000000000L
         + (line[p1] - '0') * 10000000000L
         + (line[p2] - '0') * 1000000000L
         + (line[p3] - '0') * 100000000L
         + (line[p4] - '0') * 10000000L
         + (line[p5] - '0') * 1000000L
         + (line[p6] - '0') * 100000L
         + (line[p7] - '0') * 10000L
         + (line[p8] - '0') * 1000L
         + (line[p9] - '0') * 100L
         + (line[pa] - '0') * 10L
         + (line[pb] - '0') * 1L
  select pos.Max();
  
answer.Sum().Dump("Answer 2");