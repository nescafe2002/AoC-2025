<Query Kind="Statements">
  <Reference Relative="02 input.txt">&lt;UserProfile&gt;/Documents/GitHub/AoC-2025/02 input.txt</Reference>
</Query>

var input = @"1-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124";

input = File.ReadAllText("02 input.txt");

var result = 0L;
var result2 = 0L;

foreach (var item in input.Split(',').Select(x => x.Split('-').Select(long.Parse).ToArray()))
{
  for (var num = item[0]; num <= item[1]; num++)
  {
    if (num.ToString() is var s && s.Length % 2 == 0 && num % (1 + Math.Pow(10, (s.Length / 2))) == 0)
    {
      result += num;
    }
    if (Enumerable.Range(1, s.Length / 2).Any(i => s.Length % i == 0 && Enumerable.Range(0, s.Length / i).All(j => Enumerable.Range(0, i).All(k => s[k] == s[i*j+k]))))
    {
      result2 += num;
    }
  }
}

result.Dump("Answer 1");
result2.Dump("Answer 2");