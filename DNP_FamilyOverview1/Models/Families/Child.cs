using System.Collections.Generic;

namespace DNP_FamilyOverview1.Models.Families
{
    public class Child : Person
    {

        public List<ChildInterest> ChildInterests { get; set; }
        public List<Pet> Pets { get; set; }

        public void Update(Child toUpdate)
        {
            base.Update(toUpdate);
            ChildInterests = toUpdate.ChildInterests;
            Pets = toUpdate.Pets;
        }

    }
}