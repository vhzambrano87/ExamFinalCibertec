using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamFinalCibertec.Model
{
    [Table("dbo.Autor")]
    public partial class Autor
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int autorId { get; set; }

        [Display(Name ="Nombre: ")]
        [StringLength(50)]
        [Required]
        public string nombre { get; set; }
        [Display(Name = "Apellido: ")]
        [StringLength(50)]
        [Required]
        public string apellido { get; set; }
        [Display(Name = "Número telefónico: ")]
        [StringLength(10)]
        public string telefono { get; set; }
        [Display(Name = "Ciudad: ")]
        [StringLength(15)]
        public string ciudad { get; set; }
        [Display(Name = "Estado: ")]
        [StringLength(10)]
        public string estado { get; set; }
        [Display(Name = "Código postal: ")]
        [StringLength(10)]
        public string zip { get; set; }
        [Display(Name = "Genero: ")]
        public int genero { get; set; }
        [Display(Name = "Suedo: ")]
        [DataType(DataType.Currency)]
        public double sueldo { get; set; }
        [Display(Name = "Tema: ")]
        [StringLength(50)]
        public string tema { get; set; }

        public virtual ICollection<Libro> Libro { get; set; }

    }
}
