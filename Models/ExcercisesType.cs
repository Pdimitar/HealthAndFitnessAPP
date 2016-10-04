using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ExcercisesType
    {
        public int Id { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public BodyType BodyTypes { get; set; }
        public string UserId { get; set; }
        public int GoalWeight { get; set; }
        public string UserGoal { get; set; }
        public byte[] UserPicture { get; set; }
        public int StartWeight { get; set; }
    }

    }
    public enum BodyType
    {
        GainWeight = 1,
        LoseWeight = 0
    }

