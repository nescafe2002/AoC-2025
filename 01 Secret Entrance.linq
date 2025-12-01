<Query Kind="Statements">
  <Reference Relative="01 input.txt">&lt;UserProfile&gt;/LINQPad/Scripts/AoC-2025/01 input.txt</Reference>
</Query>

var input = @"L68
L30
R48
L5
R60
L55
L1
L99
R14
L82".Split("\r\n");

input = File.ReadAllLines("01 input.txt");

var start = 50;
var result1 = 0;
var result2 = 0;

foreach (var line in input)
{
  start += line[0] switch { 'L' => -1, 'R' => 1 } * int.Parse(line[1..]);
  if ((start %= 100) == 0)
  {
    result1++;
  }
}

result1.Dump("Answer 1");

start = 50;
foreach (var item in input.SelectMany(line => Enumerable.Repeat(line[0] switch { 'L' => -1, 'R' => 1 }, int.Parse(line[1..]))))
{
  if ((start += item) % 100 == 0) result2++;
}

result2.Dump("Answer 2");