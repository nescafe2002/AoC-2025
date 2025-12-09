<Query Kind="Statements">
  <Reference Relative="09 input.txt">&lt;UserProfile&gt;/Documents/GitHub/AoC-2025/09 input.txt</Reference>
  <Namespace>System.Drawing</Namespace>
</Query>

var input = @"7,1
11,1
11,7
9,7
9,5
2,5
2,3
7,3".Split("\r\n");

//input = File.ReadAllLines("09 input.txt");

var tiles = input.Select(x => x.Split(",").Select(int.Parse).ToArray()).Select(x => new Point(x[0], x[1])).ToHashSet();

var result =
  from a in tiles
  from b in tiles
  where a.X < b.X || (a.X == b.X && a.Y < b.Y)
  let c = (long)(1 + Math.Abs(a.X - b.X)) * (long)(1 + Math.Abs(a.Y - b.Y ))
  orderby c descending
  select c;

result.First().Dump();

Rectangle GetRectangle(Point p1, Point p2, int shift = 0)
{
  var left = Math.Min(p1.X, p2.X);
  var right = Math.Max(p1.X, p2.X);
  var top = Math.Min(p1.Y, p2.Y);
  var bottom = Math.Max(p1.Y, p2.Y);
  return new Rectangle(left + shift, top + shift, right - left - 2 * shift, bottom - top - 2 * shift );
}

var result2 =
  from a in tiles
  from b in tiles
  where a.X < b.X || (a.X == b.X && a.Y < b.Y)
  //let rec = GetRectangle(a, b, 1)
  let rec0 = GetRectangle(a, b)
  //where !tiles.Any(t => rec1.Contains(t))
  where tiles.Count(t => t.X < rec0.Right && rec0.Left < t.X && rec0.Top < t.Y && t.Y < rec0.Bottom) == 0
  where tiles.Count(t => t.X <= rec0.Right && rec0.Left <= t.X && rec0.Top <= t.Y && t.Y <= rec0.Bottom) >= 4
  //where tiles.Count(t => rec0.Contains(t)) >= 4
  let c = (long)(1 + Math.Abs(a.X - b.X)) * (long)(1 + Math.Abs(a.Y - b.Y))
  orderby c descending
  select (a, b, c);

result2.First().Dump();