using FamilyLINQTraining.DataAccess;
using System;
using System.Linq;

namespace FamilyEx
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(">>>LINQ Exercises ****");

            using (var famCtx = new FamilyContext())
            {
                P(famCtx);
            }
        }

        //Result = 47
        static void HowManyFamiliesLiveInNumberOne(FamilyContext ctx)
        {
            var result = ctx.Families.Count(f => f.HouseNumber == 1);

            Console.WriteLine(result);
        }

        //Write a method, which prints out all families, who live on “Abby Park Street”.
        //Expected = 5
        //Got      = 5
        static void A(FamilyContext ctx)
        {
            var familiesOnAPS = ctx.Families.Where(f => f.StreetName == "Abby Park Street");
            Console.WriteLine(familiesOnAPS.Count());
            Console.WriteLine(familiesOnAPS.ToList());
        }

        //Write a method, which prints out how many families live at an adress with the house number 5.
        //Expected = 46
        //Got      = 46
        static void B(FamilyContext ctx)
        {
            var result = ctx.Families.Count(f => f.HouseNumber == 5);
            Console.WriteLine(result);
        }

        //Write a method, which prints out how many families have only one Adult.
        //Expected = 154
        //Got      = 154
        static void C(FamilyContext ctx)
        {
            var result = ctx.Families
                .Where(f => f.Adults.Count == 1)
                .Count();
            Console.WriteLine(result);
        }

        //Write a method, which prints out how many families live at an address with the house number 3 or 5.
        //Expected = 92
        //Got      = 92
        static void D(FamilyContext ctx)
        {
            var result = ctx.Families
                .Count(f => f.HouseNumber == 5 || f.HouseNumber == 3);
            Console.WriteLine(result);
        }

        //Write a method, which prints out how many families have one or more dogs.
        //Expected = 83
        //Got      = 83
        static void E(FamilyContext ctx)
        {
            var result = ctx.Families
                .Where(f => f.Pets.Any(p => p.Species == "Dog"))
                .Count();
            Console.WriteLine(result);
        }

        //Write a method, which prints out how many families have a dog and a cat (one or more of each).
        //Expected = 10
        //Got      = 10
        static void F(FamilyContext ctx)
        {
            var result = ctx.Families
                .Where(f => f.Pets.Any(p => p.Species == "Dog") && f.Pets.Any(p => p.Species == "Cat"))
                .Count();
            Console.WriteLine(result);
        }

        //Write a method, which prints out how many families have 3 children.
        //Expected = 112
        //Got      = 112
        static void G(FamilyContext ctx)
        {
            var result = ctx.Families
                .Where(f => f.Children.Count == 3)
                .Count();
            Console.WriteLine(result);
        }

        //Write a method, which prints out how many families have gay parents, i.e. two Adults of the same sex.
        //Expected = 187
        //Got      = 187
        static void H(FamilyContext ctx)
        {
            var result = ctx.Families
                .Where(f => f.Adults.Count == 2)
                .Where(f => f.Adults.Count(a => a.Sex == f.Adults.FirstOrDefault().Sex) == 2)
                .Count();
            Console.WriteLine(result);
        }

        //Write a method, which prints out how many families have an Adult with red hair (one or more).
        //Expected = 12
        //Got      = 12
        static void I(FamilyContext ctx)
        {
            var result = ctx.Families
                .Where(f => f.Adults.Any(a => a.HairColor == "Red"))
                .Count();
            Console.WriteLine(result);
        }

        //Write a method, which prints out how many families have exactly 2 pets (not including children’s pets).
        //Expected = 20
        //Got      = 20
        static void J(FamilyContext ctx)
        {
            var result = ctx.Families
                .Where(f => f.Pets.Count == 2)
                .Count();
            Console.WriteLine(result);
        }

        //Write a method, which prints out how many families have a child, which plays Soccer.
        //Expected = 67
        //Got      = 67
        static void K(FamilyContext ctx)
        {
            var result = ctx.Families
                .Where(f => f.Children
                    .Any(c => c.ChildInterests
                        .Any(c => c.Interest.Type == "Soccer")))
                .Count();
            Console.WriteLine(result);
        }

        //Write a method, which prints out how many families have an adult with black hair and a child with black hair.
        //Expected = 350
        //Got      = 350
        static void L(FamilyContext ctx)
        {
            var result = ctx.Families
                .Where(f => f.Adults.Any(a => a.HairColor == "Black") && f.Children.Any(c => c.HairColor == "Black"))
                .Count();
            Console.WriteLine(result);
        }

        //Write a method, which prints out how many families have a child with black hair, who plays Ultimate.
        //Expected = 54
        //Got      = 54
        static void M(FamilyContext ctx)
        {
            var result = ctx.Families
                .Where(f => f.Children
                    .Any(c => c.HairColor == "Black" && c.ChildInterests
                        .Any(c => c.Interest.Type == "Ultimate")))
                .Count();
            Console.WriteLine(result);
        }

        //Write a method, which prints out how many families have two aduls with the same hair color.
        //Expected = 192
        //Got      = 192
        static void N(FamilyContext ctx)
        {
            var result = ctx.Families
                .Where(f => f.Adults.Count(a => a.HairColor == f.Adults.FirstOrDefault().HairColor) == 2)
                .Count();
            Console.WriteLine(result);
        }

        //Write a method, which prints out how many families have child, which has a hamster.
        //Expected = 67
        //Got      = 67
        static void O(FamilyContext ctx)
        {
            var result = ctx.Families
                .Where(f => f.Children.Any(c => c.Pets.Any(p => p.Species == "Hamster")))
                .Count();
            Console.WriteLine(result);
        }

        //Write a method, which prints out the number of children, who is interested in “Soccer” and “Barbie”.
        //Expected = 5
        //Got      = 5
        static void P(FamilyContext ctx)
        {
            var result = ctx.Families
                .Where(f => f.Children
                    .Any(c => c.ChildInterests.Any(c => c.Interest.Type == "Soccer")
                             && c.ChildInterests.Any(c => c.Interest.Type == "Barbie")))
                .Count();
            Console.WriteLine(result);
        }
    }
}
