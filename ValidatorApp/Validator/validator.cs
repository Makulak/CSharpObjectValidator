using System.Collections.Generic;
using System.Linq;

namespace Validator
{
    public class Validator<T>
    {
        private IEnumerable<ValidationRule<T>> _rules;
        public Validator(IEnumerable<ValidationRule<T>> rules)
        {
            _rules = rules;
        }

        /// <summary>
        /// Checks if object is correct
        /// </summary>
        /// <param name="obj">Object to check</param>
        /// <returns>true if object is valid, false otherwise</returns>
        public bool IsValid(T obj)
        {
            return _rules.All(rule => rule.IsValid(obj));
        }

        /// <summary>
        /// Checks if object is correct
        /// </summary>
        /// <param name="obj">Object to check</param>
        /// <returns>ValidationMessage from first incomplete rule</returns>
        public string Validate(T obj)
        {
            return _rules.FirstOrDefault(rule => !rule.IsValid(obj))?.ValidationMessage;
        }

        /// <summary>
        /// Checks if object is correct
        /// </summary>
        /// <param name="obj">Object to check</param>
        /// <returns>ValidationMessages from incomplete rules</returns>
        public IEnumerable<string> ValidateA(T obj)
        {
            return _rules.Where(rule => !rule.IsValid(obj)).Select(rule => rule.ValidationMessage);
        }
    }
}
