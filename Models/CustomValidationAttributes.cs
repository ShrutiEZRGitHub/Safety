namespace Models;

public sealed class RequiredIfAttribute : ValidationAttribute
{
    public string PropertyName { get; set; }
    public object Value { get; set; }
    public int MinLength { get; set; }
    public int MaxLength { get; set; }

    public RequiredIfAttribute(string propertyName, object value, string errorMessage = "", int minLength = 0, int maxLength = 0)
    {
        PropertyName = propertyName; ErrorMessage = errorMessage; Value = value;
        MinLength = minLength; MaxLength = maxLength;
    }

    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        string strValue = Convert.ToString(value) ?? string.Empty;

        if (!string.IsNullOrEmpty(strValue))
        {
            int len = strValue.Length;
            if ((MinLength == 0 || len >= MinLength) &&
                (MaxLength == 0 || len <= MaxLength))
                return ValidationResult.Success!;
            else
                return new ValidationResult(ErrorMessage);
        }
        else
        {
            var instance = validationContext.ObjectInstance;
            var type = instance.GetType();
            string propertyvalue = Convert.ToString(type.GetProperty(PropertyName)?.GetValue(instance, null)) ?? string.Empty;
            if (propertyvalue == Value.ToString())
                return new ValidationResult(ErrorMessage);
            else
                return ValidationResult.Success!;
        }
    }
}

public sealed class CurrentDateNotAllowedAttribute : ValidationAttribute
{
    public CurrentDateNotAllowedAttribute()
    {
    }

    public override bool IsValid(object? value)
    {
        var dt = (DateTime?)value;
        return (dt?.Date > DateTime.Now.Date);
    }
}
