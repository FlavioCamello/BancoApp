using BancoApp.Models.ExportStrategy.Interfaces;

namespace BancoApp.Models.ExportStrategy
{
    public class ExportContext
    {
        private readonly IExportStrategy _exportStrategy;

        public ExportContext(IExportStrategy exportStrategy)
        {
            _exportStrategy = exportStrategy;
        }

        public byte[] Export(List<Transaction> transactions)
        {
            return _exportStrategy.Export(transactions);
        }

        public string GetContentType()
        {
            return _exportStrategy.GetContentType();
        }

        public string GetFileExtension()
        {
            return _exportStrategy.GetFileExtension();
        }
    }

}
