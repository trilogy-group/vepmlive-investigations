namespace EPMLiveCore.Helpers
{
    public static class StringHelper
    {
        public static string GetSafeString(string input)
        {
            var result = string.Empty;
            if (!string.IsNullOrWhiteSpace(input))
            {
                result = input.Replace("\"", "")
                              .Replace("/", "")
                              .Replace("\\", "")
                              .Replace("[", "")
                              .Replace("]", "")
                              .Replace(":", "")
                              .Replace("|", "")
                              .Replace("<", "")
                              .Replace(">", "")
                              .Replace("+", "")
                              .Replace("=", "")
                              .Replace(";", "")
                              .Replace(",", "")
                              .Replace("?", "")
                              .Replace("*", "")
                              .Replace("'", "")
                              .Replace("@", "");
            }

            return result;
        }
    }
}