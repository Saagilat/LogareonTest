namespace Task3
{
    public static class SequencesHelper
    {
        public static IEnumerable<string> GetAllSequences(IEnumerable<char> chars)
        {
            return chars.SelectMany(x =>
            {
                if (chars.Count() <= 1)
                {
                    return new List<string>() { x.ToString() }; // По хорошему при конкатенации большого количества строк лучше использовать StringBuilder, но я не придумал как его здесь использовать.
                }
                return GetAllSequences(chars.Where(y => y != x)).Select(y => x + y).ToList(); // n! коллекций. Очень легко переполняет память.
            });
        }
    }

}
