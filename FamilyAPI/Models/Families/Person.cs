using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text.Json.Serialization;

namespace FamilyAPI.Models.Families
{
    public class Person
    {
        public int Id { get; set; }

        [NotNull]
        [NotEmptyString]
        public string FirstName { get; set; }
        
        [NotNull]
        [NotEmptyString]
        public string LastName { get; set; }

        [ValidHairColor]
        public string HairColor { get; set; }

        [NotNull]
        [ValidEyeColor]
        public string EyeColor { get; set; }

        [NotNull, Range(0, 125)]
        public int Age { get; set; }

        [NotNull, Range(20, 250)]
        public float Weight { get; set; }

        [NotNull, Range(30, 250)]
        public int Height { get; set; }

        [NotNull]
        [NotEmptyString]
        public string Sex { get; set; }

        public void Update(Person toUpdate)
        {
            Age = toUpdate.Age;
            Height = toUpdate.Height;
            HairColor = toUpdate.HairColor;
            Sex = toUpdate.Sex;
            Weight = toUpdate.Weight;
            EyeColor = toUpdate.EyeColor;
            FirstName = toUpdate.FirstName;
            LastName = toUpdate.LastName;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Person p = (Person)obj;
                return (FirstName == p.FirstName && LastName == p.LastName && Age == p.Age && Weight == p.Weight && Height == p.Height &&Sex == p.Sex) || (Id == p.Id);
            }
            }


    }

    public class NotEmptyString : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null && value.ToString() != "")
                return ValidationResult.Success;
            return new ValidationResult($"{validationContext.DisplayName} is empty");
        }
    }
    public class ValidHairColor : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            List<string> valid = new[] {"blonde", "red", "brown", "black",
            "white", "grey", "blue", "green", "leverpostej"}.ToList();
            if (value != null && (valid == null || valid.Contains(value.ToString().ToLower())))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Valid hair colors are: Blonde, Red, Brown, Black, White, Grey, Blue, Green, Leverpostej");
        }
    }

    public class ValidEyeColor : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            List<string> valid = new[] {"brown", "grey", "green", "blue",
            "amber", "hazel"}.ToList();
            if (value != null && (valid != null && valid.Contains(value.ToString().ToLower())))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Valid hair colors are: Brown, Grey, Green, Blue, Amber, Hazel");
        }
    }
}