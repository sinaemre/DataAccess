using DataAccess.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.Concrete
{
    public class Category : BaseItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
