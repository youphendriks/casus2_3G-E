using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Summ2.Models
{
    public class tblCategoryTotals
    {
        [Key]
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public string CategoryBeschrijving { get; set; }

        public string Status { get; set; }

        public string StatusBeschrijving { get; set; }

        public int? TotalBuyPrice { get; set; }

        public int? TotalCurrentPrice { get; set; }

        public int? TotalPriceDiffrence { get; set; }
    }
}