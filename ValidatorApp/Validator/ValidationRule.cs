using System;

namespace Validator
{
    public class ValidationRule<T>
    {
        private Func<T, bool> _condition;
        public string ValidationMessage { get; }
        public bool IsValid(T obj) => _condition(obj);

        public ValidationRule(Func<T, bool> condition, string validationMessage = null)
        {
            _condition = condition;
            ValidationMessage = validationMessage;
        }
    }
}
