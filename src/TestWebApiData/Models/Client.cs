using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestWebApiData.Models
{
    [Serializable]

    public class Client
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Required name.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Required lastname.")]
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        [Required(ErrorMessage = "Required Cuit.")]
        public string Cuit { get; set; }
        public string domicilio { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }

        public Client() { }
    }
}