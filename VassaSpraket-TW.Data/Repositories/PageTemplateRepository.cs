using VassaSpraket_TW.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace VassaSpraket_TW.Data.Repositories
{
    public interface IPageTemplateRepository
    {
        Task<PageTemplate> GetById(int id);
       
    }


    public class PageTemplateRepository : IPageTemplateRepository
    {
        private readonly VassaSpraket_TWDbContext _ctx;

        public PageTemplateRepository(VassaSpraket_TWDbContext ctx)
        {
            _ctx = ctx;
        }       


        public async Task<PageTemplate> GetById(int id)
        {
            try
            {
                return await _ctx.PageTemplates
                   
                    .Where(x => x.ChapterId == id)
                     .Include(r => r.Rows)
                     
                    .FirstOrDefaultAsync();
            }
            catch (Exception)
            {               
                throw;
            }
        }      


    }
}
