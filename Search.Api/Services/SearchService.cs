using Microsoft.EntityFrameworkCore;
using Search.Api.Data;
using Search.Api.Models;

namespace Search.Api.Services
{
    public class SearchService
    {
        private readonly AppDbContext _context;

        public SearchService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<LandInformation>> SearchAsync(string keyword)
        {
            keyword = keyword.Trim();

            return await _context.LandInformations
                .Where(x =>
                    x.LandNo!.Contains(keyword) ||
                    x.HusbandName!.Contains(keyword) ||
                    x.WifeName!.Contains(keyword) ||
                    x.HusbandIdCard!.Contains(keyword) ||
                    x.CertificateNo!.Contains(keyword))
                .Take(100)
                .ToListAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _context.LandInformations.CountAsync();
        }

        public async Task<List<LandInformation>> SearchByLandNoAsync(string keyword)
        {
            return await _context.LandInformations
                .Where(x => x.LandNo != null &&
                            x.LandNo.Contains(keyword))
                .ToListAsync();
        }

    }
}