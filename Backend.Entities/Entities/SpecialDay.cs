﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Backend.Entities.EnumUtil;

namespace Backend.Entities
{
    public class SpecialDay : BaseEntity
    {
        public DateTime DateTime { get; set; }
        public string? Reason { get; set; }
        public DayOffOption Option { get; set; }
        public bool IsUrgent { get; set; }
        public DayOffStatus DayOffStatus { get; set; }
        public SpecialDayType Type { get; set; }
        public HolidayType? HolidayType { get; set; }
        public bool IsPaidOff { get; set; }

        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
