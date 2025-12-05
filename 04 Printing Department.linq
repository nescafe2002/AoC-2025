<Query Kind="Statements">
  <Reference Relative="04 input.txt">&lt;UserProfile&gt;/Documents/GitHub/AoC-2025/04 input.txt</Reference>
</Query>

var input = @"..@@.@@@@.
@@@.@.@.@@
@@@@@.@.@@
@.@@@@..@.
@@.@@@@.@@
.@@@@@@@.@
.@.@.@.@@@
@.@@@.@@@@
.@@@@@@@@.
@.@.@@@.@.".Split("\r\n");;

input = File.ReadAllLines("04 input.txt");

var grid = (from i in Enumerable.Range(0, input.Length) from j in Enumerable.Range(0, input[0].Length) where input[i][j] == '@' select (i, j)).ToHashSet();

IEnumerable<(int, int)> Result() => grid.Where(x => new[] { (x.i - 1, x.j - 1), (x.i - 1, x.j), (x.i - 1, x.j + 1), (x.i, x.j - 1), (x.i, x.j + 1), (x.i + 1, x.j - 1), (x.i + 1, x.j), (x.i + 1, x.j + 1) }.Count(y => grid.Contains(y)) < 4);

Result().Count().Dump("Answer 1");

Enumerable.Range(0, int.MaxValue).Select(_ => Result().ToList().Count(x => grid.Remove(x))).TakeWhile(x => x > 0).Sum().Dump("Answer 2");