using CT.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CT.Sfa.Entities.Concrete
{
    //[Table("LU_MAMUL")]
    public class Product:IEntity
    {
        //[Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductNo { get; set; }

    }
}
