  using System;
  using System.ComponentModel.DataAnnotations;

  namespace SecretSanta.Application.Validation
  {
    public class GreaterThanValidationAttribute : ValidationAttribute
    {
      private readonly string _comparisonProperty;

      public GreaterThanValidationAttribute(string comparisonProperty)
      {
        _comparisonProperty = comparisonProperty;
      }

      protected override ValidationResult IsValid(object value, ValidationContext validationContext)
      {
        var currentValue = (decimal)value;
        var comparisonProperty = validationContext.ObjectType.GetProperty(_comparisonProperty);
        if (comparisonProperty == null)
          return new ValidationResult($"Unknown property: {_comparisonProperty}");

        var comparisonValue = (decimal)comparisonProperty.GetValue(validationContext.ObjectInstance);

        if (currentValue <= comparisonValue)
          return new ValidationResult(ErrorMessage ?? $"{validationContext.DisplayName} должно быть больше, чем {_comparisonProperty}");

        return ValidationResult.Success;
      }
    }
  }