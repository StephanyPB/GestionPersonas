using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPersonas.Entidades
{
    public class Aportes
    {
        [Key]
        public int AporteId { get; set; }
        public DateTime Fecha { get; set; }
        public int PersonaId { get; set; }
        public string Concepto { get; set; }
        public double MontoTotal { get; set; }
  
        [ForeignKey("AporteId")] 
        public List<AportesDetalle> Detalle { get; set; } = new List<AportesDetalle>();

        public Aportes()
        {
            AporteId = 0;
            Fecha = DateTime.Now;
            PersonaId = 0;
            Concepto = string.Empty;
            MontoTotal = 0;
        }

        public Aportes(int aporteId, DateTime fecha, int personaId, string concepto, double monto)
        {
            AporteId = aporteId;
            Fecha = fecha;
            PersonaId = personaId;
            Concepto = concepto;
            MontoTotal = monto;
        }
        
    }
}
