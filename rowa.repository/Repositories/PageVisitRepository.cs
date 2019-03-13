using Microsoft.EntityFrameworkCore;
using rowa.repository.Entites;
using rowa.repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rowa.repository.Repositories
{
    public class PageVisitRepository : BaseRepository<PageVisit>, IPageVisitRepository
    {
        public async Task<int> AddPageVisit(PageVisit pageVisit)
        {
            return await Add(pageVisit);
        }

        public async Task<PageVisit> GetPage(string url)
        {
            var page = await DatabaseContext.PageVisit.Where(x => string.Equals(url, x.Url)).FirstOrDefaultAsync();

            return page;
        }
    }
}
