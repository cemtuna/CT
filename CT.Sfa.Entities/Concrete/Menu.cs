using CT.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CT.Sfa.Entities.Concrete
{
    public class Menu:IEntity
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public int ParentMenu { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public int RowNumber { get; set; }


    }
}
