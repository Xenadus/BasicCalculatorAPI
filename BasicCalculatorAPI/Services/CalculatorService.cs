using System;
using System.Globalization;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using Sprache;

namespace BasicCalculatorAPI.Services
{
    public class CalculatorService : ICalculator
    {
        private static readonly Parser<Expression> Constant =
            Parse.DecimalInvariant
                .Select(n => double.Parse(n, CultureInfo.InvariantCulture))
                .Select(n => Expression.Constant(n, typeof(double)))
                .Token();

        private static readonly Parser<ExpressionType> Operator =
            Parse.Char('+').Return(ExpressionType.Add)
                .Or(Parse.Char('-').Return(ExpressionType.Subtract))
                .Or(Parse.Char('*').Return(ExpressionType.Multiply))
                .Or(Parse.Char('/').Return(ExpressionType.Divide));

        private static readonly Parser<Expression> Operation =
            Parse.ChainOperator(Operator, Constant, Expression.MakeBinary);

        private static readonly Parser<Expression> FullExpression =
            Operation.Or(Constant).End();

        public string OperationType(string expression)
        {
            var combineOperations = new Regex(@"[+*/-]");
            var matches = combineOperations.Matches(expression);

            if (matches.Count > 1)
            {
                return "Combine";
            }

            if (expression.Contains('+'))
            {
                return "Addition";
            }
            if (expression.Contains('-'))
            {
                return "Subtract";
            }
            if (expression.Contains('-'))
            {
                return "Multiply";
            }
            if (expression.Contains('/'))
            {
                return "Divide";
            }

            return "Other";
        }

        public double Calculate(string expression)
        {
            var operation = FullExpression.Parse(expression);
            var func = Expression.Lambda<Func<double>>(operation).Compile();

            return func();
        }
    }
}