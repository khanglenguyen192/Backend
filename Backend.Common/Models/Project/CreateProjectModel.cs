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
    public class CreateProjectModel
    {
        [Required]
        [JsonProperty(PropertyName = "projectname")]
        public string? ProjectName { get; set; }
        [JsonProperty(PropertyName = "status")]
        public ProjectStatus? Status { get; set; }
        [JsonProperty(PropertyName = "customerName")]
        public string? CustomerName { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string? Description { get; set; }

        [JsonProperty(PropertyName = "projectlogo")]
        public string? ProjectLogo { get; set; }
    }
}
