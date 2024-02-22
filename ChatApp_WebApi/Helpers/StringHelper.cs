namespace Helpers
{
    public class StringHelper
    {
        public static string GetRandomValue(int length)
        {
            const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890abcdefghijklmnopqrstuvwxyz_!@#$%^&*()_-+=";

            Random random = new();

            return new(
                value: Enumerable
                    .Repeat(element: Chars, count: length)
                    .Select(selector: s => s[random.Next(maxValue: s.Length)])
                    .ToArray());
        }
    }
}
