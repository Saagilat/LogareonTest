namespace Task3
{
    public static class MainClass
    {
        public static void Main(string[] args)
        {
            List<char> chars = new List<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9'};
            List<string> result = SequencesHelper.GetAllSequences(chars).ToList();
        }
    }
}



