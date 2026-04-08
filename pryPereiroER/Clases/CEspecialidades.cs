using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryPereiroER
{
    internal class CEspecialidades
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public override string ToString()
        {
            return this.Nombre;
        }
    }


    internal class CMedico
    {
        public int Matricula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public CEspecialidades Especialidad { get; set; } // Relación con la otra clase

        public CMedico()
        { 
        }
    }
}
