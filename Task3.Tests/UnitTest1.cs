namespace Task3.Tests
{
    //����� 1 ����
    //�������� �����, ��������� Linq � ��������.
    //����� ��������� �� ���� ��������� �� ������������� ���� � ���������� ��� ��������� �� ����������.
    //����� �� ���������� �� ������ ��������� ������������� ����.
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