using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Validator
{
    public class ValidatorBuilder<T>
    {
        private List<ValidationRule<T>> _rules;

        public ValidatorBuilder()
        {
            _rules = new List<ValidationRule<T>>();
        }

        public ValidatorBuilder<T> AddCheck(Expression<Func<T, bool>> expr, string validationMessage = null)
        {
            ValidationRule<T> rule = new ValidationRule<T>(expr.Compile(), validationMessage);

            _rules.Add(rule);

            return this;
        }

        public Validator<T> Create()
        {
            return new Validator<T>(_rules);
        }
    }
}
