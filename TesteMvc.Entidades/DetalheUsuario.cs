using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteMvc.Entidades
{
   public class DetalheUsuario
    {
        public int DetalheId { get; set; }
        public int UsuarioId { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
    }
}
