namespace Task1.Services.Interfaces
{
    public interface IReportBuilder
    {
        byte[] Build(CancellationToken cancellationToken);
    }
}
