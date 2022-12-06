using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Common
{
    public class CreateMeetingModel
    {
        [Required]
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Required]
        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }

        [Required]
        [JsonProperty(PropertyName = "userids")]
        public IList<int> UserIds { get; set; }

        [Required]
        [JsonProperty(PropertyName = "timeStart")]
        public string TimeStart { get; set; }

        [JsonIgnore]
        public DateTime TimeStartDateTime { get; set; }
    }
}
