using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class UserStatdModel
    {
        public int Weight { get; set; }
        public int Height { get; set; }
        public BodyType BodyTypes { get; set; }
        public string UserId { get; set; }
        public int GoalWeight { get; set; }
        public string UserName { get; set; }
        public string UserGoal { get; set; }
        public byte[] UserPicture { get; set; }
        public int StartWeight { get; set; }

    }
}
