using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

public class RequiredIfNonZeroAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var propertyInfo = validationContext.ObjectType.GetProperty(validationContext.MemberName);
        if (propertyInfo == null)
        {
            return new ValidationResult($"La propiedad {validationContext.MemberName} no fue encontrada.");
        }

        var idValue = Convert.ToInt32(value);
        if (idValue == 0)
        {
            return new ValidationResult(ErrorMessage);
        }

        return ValidationResult.Success;
    }
}
