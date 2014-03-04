using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IV.Model {
    interface Validatable {
    }

    public static class ValidateMethods {

        public static bool Validate(this Validatable obj) {
            return obj.Validate(new List<ValidationResult>());
        }

        public static bool Validate(this Validatable obj, ICollection<ValidationResult> validationResults) {
            var validationContext = new ValidationContext(obj);
            return Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}
