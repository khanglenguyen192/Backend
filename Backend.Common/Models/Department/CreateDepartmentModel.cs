using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Backend.Entities.EnumUtil;

namespace Backend.Common
{
    public class CreateDepartmentModel
    {
        public int? ParentId { get; set; }
        [Required]
        [JsonProperty(PropertyName = "departmentName")]
        public string DepartmentName { get; set; }
        [Required]
        [JsonProperty(PropertyName = "status")]
        public DepartmentStatus Status { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string? Description { get; set; }

        [JsonProperty(PropertyName = "departmentLogo")]
        public string? DepartmentLogo { get; set; }

        [JsonProperty(PropertyName = "usersInfo")]
        public IList<UserMapDepartmentModel>? UsersInfo { get; set; }

        [JsonProperty(PropertyName = "isLogoDelete")]
        public bool IsLogoDelete { get; set; }
    }
}
