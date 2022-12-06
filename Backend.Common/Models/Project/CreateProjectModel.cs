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
        public int Id { get; set; }
        [Required]
        [JsonProperty(PropertyName = "projectname")]
        public string ProjectName { get; set; }
        [Required]
        [JsonProperty(PropertyName = "status")]
        public ProjectStatus Status { get; set; }
        [Required]
        [JsonProperty(PropertyName = "customerName")]
        public string CustomerName { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "projectlogo")]
        public string ProjectLogo { get; set; }

        [JsonProperty(PropertyName = "member")]
        public string Member { get; set; }

        [JsonProperty(PropertyName = "islogodelete")]
        public bool IsLogoDelete { get; set; }
    }
}
