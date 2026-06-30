using Search.Api.Data;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Search.Api.Models;

namespace Search.Api.Services
{
    public class ImportService
    {
        private readonly AppDbContext _context;

        public ImportService(AppDbContext context)
        {
            _context = context;
        }

        public string Ping()
        {
            return "Import Service Ready";
        }

        public async Task<object> ReadExcelAsync(IFormFile file)
        {
            using var stream = new MemoryStream();

            await file.CopyToAsync(stream);

            stream.Position = 0;

            using var workbook = new XLWorkbook(stream);

            var worksheet = workbook.Worksheet(1);

            var rowCount = worksheet.LastRowUsed()?.RowNumber() ?? 0;
            var columnCount = worksheet.LastColumnUsed()?.ColumnNumber() ?? 0;

            return new
            {
                SheetName = worksheet.Name,
                TotalRows = rowCount,
                TotalColumns = columnCount
            };
        }

        public async Task<int> ImportExcelAsync(IFormFile file)
        {
            using var stream = new MemoryStream();
            await file.CopyToAsync(stream);

            stream.Position = 0;

            using var workbook = new XLWorkbook(stream);
            var worksheet = workbook.Worksheet(1);

            var lastRow = worksheet.LastRowUsed().RowNumber();

            int imported = 0;

            for (int row = 2; row <= lastRow; row++)
            {
                // រំលង Row ទទេ
                if (string.IsNullOrWhiteSpace(worksheet.Cell(row, 1).GetString()))
                    continue;

                var land = new LandInformation
                {
                    LandNo = GetString(worksheet.Cell(row, 1)),
                    HusbandName = GetString(worksheet.Cell(row, 2)),
                    HusbandOwnerStatus = GetString(worksheet.Cell(row, 3)),
                    WifeName = GetString(worksheet.Cell(row, 4)),
                    WifeOwnerStatus = GetString(worksheet.Cell(row, 5)),
                    PropertyType = GetString(worksheet.Cell(row, 6)),
                    AreaSqm = GetDecimal(worksheet.Cell(row, 7)),

                    HusbandDob = GetDate(worksheet.Cell(row, 8)),
                    HusbandNationality = GetString(worksheet.Cell(row, 9)),
                    HusbandIdCard = GetString(worksheet.Cell(row, 10)),
                    HusbandBirthPlace = GetString(worksheet.Cell(row, 11)),
                    HusbandFatherName = GetString(worksheet.Cell(row, 12)),
                    HusbandMotherName = GetString(worksheet.Cell(row, 13)),
                    HusbandAddress = GetString(worksheet.Cell(row, 14)),

                    WifeDob = GetDate(worksheet.Cell(row, 15)),
                    WifeNationality = GetString(worksheet.Cell(row, 16)),
                    WifeIdCard = GetString(worksheet.Cell(row, 17)),
                    WifeBirthPlace = GetString(worksheet.Cell(row, 18)),
                    WifeFatherName = GetString(worksheet.Cell(row, 19)),
                    WifeMotherName = GetString(worksheet.Cell(row, 20)),
                    WifeAddress = GetString(worksheet.Cell(row, 21)),

                    LegalStatus = GetString(worksheet.Cell(row, 22)),
                    CertificateNo = GetString(worksheet.Cell(row, 23)),
                    LandUseImage = GetString(worksheet.Cell(row, 24)),
                    LandUseType = GetString(worksheet.Cell(row, 25)),
                    DisputedLand = GetString(worksheet.Cell(row, 26)),
                    OwnershipSource = GetString(worksheet.Cell(row, 27)),
                    RecordDate = GetDate(worksheet.Cell(row, 28)),

                    LegalEntityType = GetString(worksheet.Cell(row, 29)),
                    OrganizationName = GetString(worksheet.Cell(row, 30)),
                    OrganizationAddress = GetString(worksheet.Cell(row, 31)),
                    RepresentativeName = GetString(worksheet.Cell(row, 32)),
                    RepresentativeIdCard = GetString(worksheet.Cell(row, 33)),
                    RepresentativePosition = GetString(worksheet.Cell(row, 34)),

                    CreatedAt = DateTime.UtcNow
                };

                _context.LandInformations.Add(land);
                imported++;
            }

            await _context.SaveChangesAsync();

            return imported;
        }

        private string? GetString(IXLCell cell)
        {
            var value = cell.GetString().Trim();
            return string.IsNullOrWhiteSpace(value) ? null : value;
        }

        private decimal? GetDecimal(IXLCell cell)
        {
            var value = cell.GetString().Trim();

            if (string.IsNullOrWhiteSpace(value))
                return null;

            if (decimal.TryParse(value, out var result))
                return result;

            return null;
        }

        private DateTime? GetDate(IXLCell cell)
        {
            var value = cell.GetString().Trim();

            if (string.IsNullOrWhiteSpace(value))
                return null;

            DateTime date;

            if (cell.DataType == XLDataType.DateTime)
            {
                date = cell.GetDateTime();
            }
            else if (DateTime.TryParse(value, out date))
            {
            }
            else if (int.TryParse(value, out var year))
            {
                date = new DateTime(year, 1, 1);
            }
            else
            {
                return null;
            }

            // បម្លែងទៅ UTC
            return DateTime.SpecifyKind(date, DateTimeKind.Utc);
        }
    }
}