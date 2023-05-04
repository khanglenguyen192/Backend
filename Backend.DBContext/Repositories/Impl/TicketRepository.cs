using Backend.Common;
using Backend.Common.Models.Common;
using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DBContext
{
    public class TicketRepository : BaseRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(IDbContextFactory contextFactory) : base(contextFactory)
        {
            
        }

        public PagingResponseModel<Ticket> SearchTicket(SearchTicketModel searchModel)
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                var query = from b in context.Set<Ticket>()
                            select b;

                if (searchModel.AssignorId != null)
                {
                    query = query.Where(p => p.AssignorId == searchModel.AssignorId);
                }
                if (searchModel.AssigneeId != null)
                {
                    query = query.Where(p => p.AssigneeId == searchModel.AssigneeId);
                }
                if (searchModel.TicketStatus != null)
                {
                    query = query.Where(p => p.TicketStatus == searchModel.TicketStatus);
                }
                if (searchModel.ProjectId != null)
                {
                    query = query.Where(p => p.ProjectId == searchModel.ProjectId);
                }
                if (searchModel.DepartmentId != null)
                {
                    query = query.Where(p => p.DepartmentId == searchModel.DepartmentId);
                }

                int totalCount = query.Count();

                query = query.OrderByDescending(p => p.Created).Skip(searchModel.PageIndex).Take(searchModel.PageSize);

                var result = query.ToList();

                return new PagingResponseModel<Ticket> { 
                    Data = result,
                    TotalSize = totalCount,
                    PageIndex= searchModel.PageIndex,
                    PageSize = searchModel.PageSize
                };
            }
        }
    }
}
