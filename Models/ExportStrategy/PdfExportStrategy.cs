using BancoApp.Models.ExportStrategy.Interfaces;
using DinkToPdf;
using System.Text;

namespace BancoApp.Models.ExportStrategy
{
    public class PdfExportStrategy : IExportStrategy
    {
        public byte[] Export(List<Transaction> transactions)
        {
            var converter = new SynchronizedConverter(new PdfTools());
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = { },
                Objects = {
                new ObjectSettings()
                {
                    HtmlContent = GenerateHtmlStatement(transactions),
                    WebSettings = { DefaultEncoding = "utf-8" },
                }
            }
            };
            return converter.Convert(doc);
        }

        public string GetContentType() => "application/pdf";

        public string GetFileExtension() => ".pdf";

        private string GenerateHtmlStatement(List<Transaction> transactions)
        {
            var sb = new StringBuilder();
            sb.Append("<h1>Statement</h1>");
            sb.Append("<table>");
            sb.Append("<tr><th>Date</th><th>Type</th><th>Amount</th></tr>");
            foreach (var transaction in transactions)
            {
                sb.Append($"<tr><td>{transaction.TransactionDate:dd/MM}</td><td>{transaction.TransactionType}</td><td>{transaction.Amount:C}</td></tr>");
            }
            sb.Append("</table>");
            return sb.ToString();
        }
    }

}
