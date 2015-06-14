namespace Pingo.FluentCommandLineParser.Contrib.Help
{
    public static class HelpStringHelpers
    {
        private const int IndentSize = 4;
        public static string GetIndentString(int indentLevel)
        {
            var indent = new string(' ', indentLevel * IndentSize);
            return indent;
        }
    }
}