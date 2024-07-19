using BancoApp.Data;
using BancoApp.Models.ExportStrategy;
using BancoApp.Models.ExportStrategy.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BancoApp.Controllers
{
    public class StatementController : Controller
    {
        private readonly BankContext _context;

        public StatementController(BankContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int accountId, int days = 5)
        {
            ViewBag.AccountId = accountId;
            ViewBag.Days = days;

            var endDate = DateTime.Now;
            var startDate = endDate.AddDays(-days);
            var transactions = await _context.Transactions
                                             .Where(t => t.AccountId == accountId && t.TransactionDate >= startDate)
                                             .OrderByDescending(t => t.TransactionDate)
                                             .ToListAsync();

            return View(transactions);
        }

        public IActionResult Export(int accountId, int days = 5, string format = "pdf")
        {
            var endDate = DateTime.Now;
            var startDate = endDate.AddDays(-days);
            var transactions = _context.Transactions
                                       .Where(t => t.AccountId == accountId && t.TransactionDate >= startDate)
                                       .OrderByDescending(t => t.TransactionDate)
                                       .ToList();

            IExportStrategy exportStrategy = format.ToLower() switch
            {
                "pdf" => new PdfExportStrategy(),
                _ => throw new NotSupportedException("The specified format is not supported.")
            };

            var exportContext = new ExportContext(exportStrategy);
            var fileContent = exportContext.Export(transactions);
            var contentType = exportContext.GetContentType();
            var fileExtension = exportContext.GetFileExtension();

            return File(fileContent, contentType, $"Statement{fileExtension}");
        }
    }
}
