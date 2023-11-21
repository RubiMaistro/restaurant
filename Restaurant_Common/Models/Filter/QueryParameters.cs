using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Common.Models.Filter
{
    public class QueryParameters
    {
        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public int PageSize { 
            get { return _pageSize;} 
            set { _pageSize = (value > maxPageSize) ? maxPageSize : value; }
        }

        public QueryParameters()
        {
            
        }

        public QueryParameters(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public string FoodName { get; set; } = string.Empty;
    }
}
