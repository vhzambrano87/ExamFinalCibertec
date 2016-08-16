using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamFinalCibertec.Model
{
    [Table("dbo.Autor")]
    public partial class Libro
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int libroId { get; set; }
        [Display(Name = "Título: ")]
        [StringLength(80)]
        [Required]
        public string titulo { get; set; }
        [Display(Name = "Tipo/Categoría: ")]
        [StringLength(50)]
        public string tipo { get; set; }
        [Display(Name = "Precio: ")]
        [DataType(DataType.Currency)]
        public double precio { get; set; }
        [Display(Name = "Tipo/Categoría: ")]
        [StringLength(200)]
        public string notas { get; set; }[Display(Name ="Nombre: ")]
        [DataType(DataType.Date)]
        public DateTime fecPublicacion { get; set; }
        public virtual Autor Autor { get; set; }

    }
}
