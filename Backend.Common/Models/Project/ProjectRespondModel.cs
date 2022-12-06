using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Backend.Entities.EnumUtil;

namespace Backend.Common
{
    public class ProjectRespondModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "projectname")]
        public string ProjectName { get; set; }

        [JsonProperty(PropertyName = "status")]
        public ProjectStatus Status { get; set; }

        [JsonProperty(PropertyName = "statusmodel")]
        public HardcodeModel StatusModel { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "projectlogo")]
        public string ProjectLogo { get; set; }

        [JsonProperty(PropertyName = "customerName")]
        public string CustomerName { get; set; }

        [JsonProperty(PropertyName = "owner")]
        public UserInfoModel Owner { get; set; }

        [JsonProperty(PropertyName = "userinfos")]
        public IList<UserMapProjectModel> UserInfos { get; set; }

        public ProjectRespondModel()
        {
            UserInfos = new List<UserMapProjectModel>();
            Owner = new UserInfoModel();
            StatusModel = new HardcodeModel();
        }
    }
}
