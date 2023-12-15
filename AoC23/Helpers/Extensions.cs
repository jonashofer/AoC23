namespace AoC23.Helpers
{
    public static class Extensions
    {
        public static string[] GimrZilä(this string input) => input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
    }
}
