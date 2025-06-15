namespace Task3.Tests
{
    //ћожно 1 цикл
    //Ќапишите метод, использу€ Linq и рекурсию.
    //ћетод принимает на вход коллекцию не повтор€ющихс€ букв и возвращает все возможные их комбинации.
    //Ћюба€ из комбинаций не должна содержать повтор€ющихс€ букв.
    public class UnitTest1
    {
        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { new List<char> { 'a', 'b' }, new HashSet<string> { "ab", "ba" } };
            yield return new object[] { new List<char> { '0', '1' }, new HashSet<string> { "10", "01" } };
            yield return new object[] { new List<char> { 'a', 'b', 'c' }, new HashSet<string> { "abc", "acb", "bac", "bca", "cab", "cba" } };
            yield return new object[] { new List<char> { 'a', 'b', 'c', 'd' }, new HashSet<string> { 
                                                                                                "abcd", "abdc", "acbd", "acdb", "adbc", "adcb", 
                                                                                                "bacd", "badc", "bcad", "bcda", "bdac", "bdca",
                                                                                                "cabd", "cadb", "cbad", "cbda", "cdab", "cdba",
                                                                                                "dabc", "dacb", "dbac", "dbca", "dcab", "dcba"} };
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Theory1(List<char> chars, HashSet<string> expected)
        {
            HashSet<string> actual = SequencesHelper.GetAllSequences(chars).ToHashSet();

            Assert.True(expected.SetEquals(actual));
        }
    }
}