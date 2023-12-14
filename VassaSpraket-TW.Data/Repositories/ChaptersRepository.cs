using VassaSpraket_TW.Data.Models;
using Microsoft.EntityFrameworkCore;


namespace VassaSpraket_TW.Data.Repositories
{
    public interface IChaptersRepository
    {       
        Task<IEnumerable<Chapters>> GetAllChapters();
       
    }


    public class ChaptersRepository : IChaptersRepository
    {
        private readonly VassaSpraket_TWDbContext _ctx;

        public ChaptersRepository(VassaSpraket_TWDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<Chapters>> GetAllChapters()
        {
            return await _ctx.Chapter.ToListAsync();
        }     


    }
}
