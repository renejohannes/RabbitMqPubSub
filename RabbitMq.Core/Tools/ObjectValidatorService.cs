using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RabbitMq.Core.Tools
{
    public static class ObjectValidatorService    
    {
        public static bool TryValidate(object obj, out ICollection<ValidationResult> results)
        {
            var context = new ValidationContext(obj, serviceProvider: null, items: null);

            results = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, context, results, true);
        }
    }
}
