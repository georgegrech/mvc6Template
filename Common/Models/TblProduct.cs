using System;
using System.Collections.Generic;

namespace Common.Models
{
    public partial class TblProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public int? SubCategoryId { get; set; }

        public virtual TblSubCategory SubCategory { get; set; }
    }
}
