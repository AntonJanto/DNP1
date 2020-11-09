using System.Text.Json;
using System.Text.Json.Serialization;

namespace FamilyAPI.Models.Families
{
    public class Adult : Person
    {
        public string JobTitle { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

        public void Update(Adult toUpdate)
        {
            JobTitle = toUpdate.JobTitle;
            base.Update(toUpdate);
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Adult a = (Adult)obj;
                return base.Equals(a);
            }
        }
    }
}