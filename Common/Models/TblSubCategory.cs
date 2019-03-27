using System;
using System.Collections.Generic;

namespace Common.Models
{
    public partial class TblSubCategory
    {
        public TblSubCategory()
        {
            TblProduct = new HashSet<TblProduct>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }

        public virtual TblCategory Category { get; set; }
        public virtual ICollection<TblProduct> TblProduct { get; set; }
    }
}
