using Restaurant_Common.Models.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Common.Extensions
{
    public static class QueryableFoodTypeExtension
    {
        /// <summary>
        /// Get T objects by parameters and use pagination
        /// </summary>
        /// <param name="queryable"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static IEnumerable<FoodType> GetByQueryParameters(this IQueryable<FoodType> queryable, QueryParameters parameters)
        {
            return queryable.Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToList();
        }
    }
}
