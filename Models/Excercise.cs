using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Excercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Day { get; set; }
        public BodyType BodyType { get; set; }
        public byte[] Picture { get; set; }
        public string PictureType { get; set; }
        public string Reps { get; set; }
        public string FoodPLan { get; set; }
        public string FoodDescription { get; set; }
    }
}
