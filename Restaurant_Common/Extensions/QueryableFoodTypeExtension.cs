using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Common.Extensions
{
    public static class QueryableExtensionForQueryParameters
    {
        /// <summary>
        /// Get Food objects by parameters and use pagination
        /// </summary>
        /// <param name="queryable"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static IEnumerable<Food> GetByQueryParameters(this IQueryable<Food> queryable, QueryParameters parameters)
        {
            return GetByQueryParametersGenericsMethod(queryable, parameters);
        }
        /// <summary>
        /// Get FoodType objects by parameters and use pagination
        /// </summary>
        /// <param name="queryable"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static IEnumerable<FoodType> GetByQueryParameters(this IQueryable<FoodType> queryable, QueryParameters parameters)
        {
            return GetByQueryParametersGenericsMethod(queryable, parameters);
        }
        /// <summary>
        /// Get Order objects by parameters and use pagination
        /// </summary>
        /// <param name="queryable"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static IEnumerable<Order> GetByQueryParameters(this IQueryable<Order> queryable, QueryParameters parameters)
        {
            return GetByQueryParametersGenericsMethod(queryable, parameters);
        }
        /// <summary>
        /// Get OrderItem objects by parameters and use pagination
        /// </summary>
        /// <param name="queryable"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static IEnumerable<OrderItem> GetByQueryParameters(this IQueryable<OrderItem> queryable, QueryParameters parameters)
        {
            return GetByQueryParametersGenericsMethod(queryable, parameters);
        }

        private static IEnumerable<T> GetByQueryParametersGenericsMethod<T>(IQueryable<T> queryable, QueryParameters parameters) where T : class
        {
            return queryable.Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToList<T>();
        }
    }
}
