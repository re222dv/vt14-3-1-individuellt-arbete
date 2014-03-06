using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IV.Model {
    public interface Validatable {
    }

    public static class ValidateMethods {

        /// <summary>
        /// Validate the data annotations
        /// </summary>
        public static bool Validate(this Validatable obj) {
            return obj.Validate(new List<ValidationResult>());
        }

        /// <summary>
        /// Validate the data annotations
        /// </summary>
        /// <param name="validationResults">out parameter for the result of the validation</param>
        public static bool Validate(this Validatable obj, ICollection<ValidationResult> validationResults) {
            var validationContext = new ValidationContext(obj);
            return Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}
