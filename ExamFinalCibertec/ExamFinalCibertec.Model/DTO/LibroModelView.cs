using System;

namespace ExamFinalCibertec.Model.DTO
{
    public class LibroModelView
    {
        public int libroId { get; set; }
        public string titulo { get; set; }
        
        public string tipo { get; set; }
        
        public double precio { get; set; }
        
        public string notas { get; set; }
        
        public DateTime fecPublicacion { get; set; }
    }
}
