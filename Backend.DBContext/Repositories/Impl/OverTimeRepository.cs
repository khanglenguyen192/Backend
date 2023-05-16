using Backend.Common.Models.Common;
using Backend.Common;
using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DBContext
{
    public class OverTimeRepository : BaseRepository<OverTime>, IOverTimeRepository
    {
        public OverTimeRepository(IDbContextFactory contextFactory) : base(contextFactory)
        {
        }

        public PagingResponseModel<OverTimeResponeModel> SearchOverTime(SearchOverTimeModel searchModel)
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                var query = from o in context.Set<OverTime>()
                            join u in context.Set<User>() on o.UserId equals u.Id
                            select new
                            {
                                OverTime = o,
                                User = u
                            };

                if (searchModel.DepartmentId != null)
                {
                   query = from o in context.Set<OverTime>()
                                join u in context.Set<User>() on o.UserId equals u.Id
                                join du in context.Set<DepartmentUserMap>() on o.UserId equals du.UserId
                                select new
                                {
                                    OverTime = o,
                                    User = u
                                };                    
                }

                if (searchModel.UserId != null)
                {
                    query = query.Where(o => o.User.Id == searchModel.UserId);
                }
                if (searchModel.Month != null)
                {
                    DateTime month = (DateTime)searchModel.Month;
                    query = query.Where(o => o.OverTime.Month == month);
                }

                int totalCount = query.Count();
                query = query.OrderByDescending(p => p.OverTime.Created).Skip(searchModel.PageIndex).Take(searchModel.PageSize);

                var queryResult = query.Select(o => new OverTimeResponeModel
                {
                    Id = o.OverTime.Id,
                    Created = o.OverTime.Created,
                    TimeStart = o.OverTime.TimeStart,
                    TimeFinish = o.OverTime.TimeFinish,
                    WorkTime = o.OverTime.WorkTime,
                    Description = o.OverTime.Description,
                    UserId = o.User.Id,
                    UserName = o.User.FullName,
                    UserAvatar = o.User.Avatar,
                }).ToList();

                var result = new PagingResponseModel<OverTimeResponeModel>
                {
                    Data = queryResult,
                    TotalSize = totalCount,
                    PageIndex = searchModel.PageIndex,
                    PageSize = searchModel.PageSize
                };

                return result;
            }
        }
    }
}
