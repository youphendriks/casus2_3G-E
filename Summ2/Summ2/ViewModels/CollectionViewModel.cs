using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Summ2.Models;

namespace Summ2.ViewModels
{
    public class CollectionViewModel
    {
        public IEnumerable<tblCollection> tblCollection { get; set; }

        public IEnumerable<tblCategory> tblCategory { get; set; }

        public IEnumerable<tblItem> tblItem { get; set; }

        public IEnumerable<tblItemCategory> tblItemCategory { get; set; }
    }
}