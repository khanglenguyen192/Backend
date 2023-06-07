using Backend.Common;
using Backend.Common.Models.Common;
using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DBContext
{
    public class SpecialDayRepository : BaseRepository<SpecialDay>, ISpecialDayRepository
    {
        public SpecialDayRepository(IDbContextFactory contextFactory) : base(contextFactory)
        {
        }

        public PagingResponseModel<SpecialDayResponseModel> SearchSpecialDay(SearchSpecialDayModel searchModel)
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                var query = from s in context.Set<SpecialDay>()
                            join u in context.Set<User>() on s.UserId equals u.Id
                            select new SpecialDayResponseModel { 
                                Id = s.Id,
                                Created = s.Created,
                                DateTime = s.DateTime,
                                Option = s.Option,
                                Reason = s.Reason,
                                IsUrgent = s.IsUrgent,
                                DayOffStatus = s.DayOffStatus,
                                Type = s.Type,
                                HolidayType = s.HolidayType,
                                UserId = s.UserId,
                                UserName = u.FullName,
                                UserAvatar = u.Avatar,
                            };

                if (searchModel.DepartmentId != null)
                {
                    var departmentUserQuery = from b in context.Set<DepartmentUserMap>() select b;
                    IList<int> userIds = new List<int>();

                    if (searchModel.IgnoreDepartmentManager.GetValueOrDefault())
                    {
                        userIds = departmentUserQuery.Where(d => d.DepartmentId == searchModel.DepartmentId 
                        && !d.IsDeactivate && d.RoleId != EnumUtil.DepartmentRole.Manager)
                        .Select(u => u.UserId).ToList();
                    }
                    else
                    {
                        userIds = departmentUserQuery.Where(d => d.DepartmentId == searchModel.DepartmentId && !d.IsDeactivate)
                        .Select(u => u.UserId).ToList();
                    }

                    if (userIds.Any())
                    {
                        query = query.Where(p => userIds.Contains(p.UserId.GetValueOrDefault()));
                    }
                }

                if (searchModel.DateTime != null)
                {
                    DateTime searchDate = searchModel.DateTime.GetValueOrDefault().Date;
                    query = query.Where(p => p.DateTime == searchDate);
                }
                if (searchModel.Option != null)
                {
                    query = query.Where(p => p.Option == searchModel.Option);
                }
                if (searchModel.IsUrgent != null)
                {
                    query = query.Where(p => p.IsUrgent == searchModel.IsUrgent);
                }
                if (searchModel.DayOffStatus != null)
                {
                    query = query.Where(p => p.DayOffStatus == searchModel.DayOffStatus);
                }
                if (searchModel.HolidayType != null)
                {
                    query = query.Where(p => p.HolidayType == searchModel.HolidayType);
                }
                if (searchModel.Type != null)
                {
                    query = query.Where(p => p.Type == searchModel.Type);
                }
                if (searchModel.UserId != null)
                {
                    query = query.Where(p => p.UserId == searchModel.UserId);
                }

                int totalCount = query.Count();

                query = query.OrderByDescending(p => p.Created).Skip(searchModel.PageIndex).Take(searchModel.PageSize);

                var result = query.ToList();

                return new PagingResponseModel<SpecialDayResponseModel>
                {
                    Data = result,
                    TotalSize = totalCount,
                    PageIndex = searchModel.PageIndex,
                    PageSize = searchModel.PageSize
                };
            }
        }
    }
}
