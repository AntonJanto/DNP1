using System.Buffers.Text;
using System.Text.Json;

namespace DNP_FamilyOverview1.Models.Families
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
                return base.Equals(a) && JobTitle == a.JobTitle;
            }
        }
    }
}