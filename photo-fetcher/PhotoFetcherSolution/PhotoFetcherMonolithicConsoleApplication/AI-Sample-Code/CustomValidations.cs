using System.ComponentModel.DataAnnotations;

namespace PhotoFetcherMonolithicConsoleApplication.AI_Sample_Code.CustomValidations;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public class StartsWithAttribute : ValidationAttribute
{
    private readonly string _prefix;

    public StartsWithAttribute(string prefix)
    {
        _prefix = prefix ?? throw new ArgumentNullException(nameof(prefix));
        ErrorMessage = "The {0} field must start with the prefix: " + _prefix;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value != null)
        {
            var stringValue = value.ToString();
            if (!stringValue.StartsWith(_prefix))
            {
                var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                return new ValidationResult(errorMessage);
            }
        }

        return ValidationResult.Success;
    }
}


public class MyModel
{
    [StartsWith("ABC", ErrorMessage = "The code must start with ABC.")]
    public string Code { get; set; }
}