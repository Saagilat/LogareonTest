namespace Task1.Services.Interfaces
{
    public interface IReporter
    {
        void ReportSuccess(byte[] data, int id);
        void ReportError(int id);
        void ReportTimeout(int id);
    }
}
