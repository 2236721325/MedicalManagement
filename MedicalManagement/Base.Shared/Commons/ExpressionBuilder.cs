using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Base.Shared.Commons
{
    public class ExpressionBuilder<TEntity, TSearchDto>
    {
        // 其实这里也可以通过传入 params Expression<Func<TRelateEntity, object>>[] selectFields 来构建
        public Expression<Func<TEntity, bool>> Build(string[] excludeFields, TSearchDto dto)
        {
            var parameters = GenerateParametersDictionary(excludeFields, dto);

            StringBuilder sb = new StringBuilder();
            var fieldNames = parameters.Keys.ToList();

            // 动态拼接
            for (int i = 0; i < fieldNames.Count; i++)
            {
                sb.Append(fieldNames[i]).Append($" == @{i}").Append(" && ");
            }

            var lambdaStr = sb.ToString();
            lambdaStr = lambdaStr.Substring(0, lambdaStr.Length - " && ".Length);

            // 构建表达式
            return DynamicExpressionParser.ParseLambda<TEntity, bool>(new ParsingConfig(), false, lambdaStr, parameters.Values.ToArray());
        }

        // 构建参数/值键值对，如果参数值为 NULL 则不进行构建
        private Dictionary<string, object> GenerateParametersDictionary(string[] excludeFields, TSearchDto dto)
        {
            var typeInfo = typeof(TSearchDto);
            var properties = typeInfo.GetProperties();
            var parameters = new Dictionary<string, object>();

            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(dto);

                if (propertyValue == null) continue;
                if (excludeFields == null) continue;
                if (excludeFields.Contains(property.Name)) continue;
                if (parameters.ContainsKey(property.Name)) continue;

                parameters.Add(property.Name, propertyValue);
            }

            return parameters;
        }
    }
}

