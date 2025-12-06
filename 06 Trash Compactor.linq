<Query Kind="Statements">
  <Reference Relative="06 input.txt">&lt;UserProfile&gt;/Documents/GitHub/AoC-2025/06 input.txt</Reference>
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

var input = @"123 328  51 64 
 45 64  387 23 
  6 98  215 314
*   +   *   +  ".Split("\r\n");

input = File.ReadAllLines("06 input.txt");

var grid = input.Select(x => x.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(y => y.Trim())).ToArray();
var values = grid[..^1].Select(x => x.Select(long.Parse).ToArray());

grid[^1].Select((x, i) => (x, i)).Sum(x => values.Aggregate(x.x == "*" ? 1L : 0L, (j, k) => x.x == "*" ? j * k[x.i] : j + k[x.i])).Dump("Answer 1");

var cells = MoreEnumerable.Split(Enumerable.Range(0, input[0].Length).Select(j => string.Join("", Enumerable.Range(0, input.Length - 1).Select(x => input[x][j])).Trim()), "").ToArray();

grid[^1].Select((x, i) => (x, i)).Sum(x => cells[x.i].Aggregate(x.x == "*" ? 1L : 0L, (j, k) => x.x == "*" ? j * long.Parse(k) : j + long.Parse(k))).Dump("Answer 2");