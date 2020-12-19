using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EMPRESA.Models
{
    public class Producto
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Producto")]
        public string NomProducto { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [DataType(DataType.Currency)]
        [Display(Name = "Precio (€)")]
        public decimal Precio { get; set; }

        [Display(Name = "Categoría")]
        public string Categoria { get; set; }

        [Display(Name = "Imagen")]
        public string UrlImagen { get; set; }
    }
}
