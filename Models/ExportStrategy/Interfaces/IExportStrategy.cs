namespace BancoApp.Models.ExportStrategy.Interfaces
{
    public interface IExportStrategy
    {
        byte[] Export(List<Transaction> transactions);
        string GetContentType();
        string GetFileExtension();
    }
}
