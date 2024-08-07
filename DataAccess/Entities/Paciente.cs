using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Paciente
    {
        public string CIPaciente { get; set; }
        public string nombresPaciente { get; set; }
        public string apellidosPaciente { get; set; }
        public string telefonoPaciente { get; set; }
        public string correoPaciente { get; set; }
        public string direccionPaciente { get; set; }
        public string fechaNacPaciente { get; set; }

        public Paciente() { }

        public Paciente(string cedula, string nombres, string apellidos, string telefono, string correo, string direccion, string fechaNac)
        {
            CIPaciente= cedula;
            nombresPaciente= nombres;
            apellidosPaciente=apellidos;
            telefonoPaciente = telefono;
            correoPaciente=correo;
            direccionPaciente=direccion;
            fechaNacPaciente=fechaNac;
        }
    }
}
