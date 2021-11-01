using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPersonas.Entidades
{
    public class AportesDetalle
    {
        [Key]
        public int Id { get; set; }
        public int AporteId { get; set; }
        public int TipoAporteId { get; set; } // RECUERDA QUE LAS FOREIGN KEY DEBEN LLAMARSE IGUALES AQUI TENIAS UNA "S" DE MAS
        public double Monto { get; set; }
        //public double Total { get; set; }
        //public double MontoDeseado { get; set; } //ESTOS CAMPOS NO SON NECESARIOS

        public AportesDetalle()
        {
            Id = 0;
            AporteId = 0;
            TipoAporteId = 0;
            Monto = 0;
            //MontoDeseado = 0;
            //Total = 0;


        }

        public AportesDetalle(int id, int aporteId, int tipoAportesId, double monto)
        {
            Id = id;
            AporteId = aporteId;
            TipoAporteId = tipoAportesId;
            Monto = monto;
        }
    }
}
