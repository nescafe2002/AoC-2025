<Query Kind="Statements">
  <Reference Relative="03 input.txt">&lt;UserProfile&gt;/Documents/GitHub/AoC-2025/03 input.txt</Reference>
</Query>

var input = @"987654321111111
811111111111119
234234234234278
818181911112111".Split("\r\n");

input = File.ReadAllLines("03 input.txt");

input.Select(x => Enumerable.Range(0, x.Length - 1).Select(i => Enumerable.Range(1, x.Length - i - 1).Select(j => (x[i] - '0') * 10 + (x[i + j] - '0')).Max()).Max()).Sum().Dump("Answer 1");

var answer =
  from line in input
  let len = line.Length
  let dic = Enumerable.Range(0, len).ToLookup(x => line[x])
  let keys = dic.Select(x => x.Key).OrderDescending().SelectMany(x => dic[x]).ToList()
  select Enumerable.Range(0, 12).Aggregate(Array.Empty<int>(), (x, i) => x.Append(keys.First(y => (x.Length == 0 || y > x.Last()) && y < len - 11 + i)).ToArray()).Aggregate(0L, (x, y) => x * 10L + line[y] - '0');

answer.Sum().Dump("Answer 2");