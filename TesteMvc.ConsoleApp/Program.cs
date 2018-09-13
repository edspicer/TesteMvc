using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteMvc.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Adicionar();

        }

        private static void Adicionar()
        {
            using(var repUsr = new DAL.Repository.UsuarioRepository())
            {

                EF.Usuario user = new EF.Usuario()
                {
                    Nome = "Testes",
                    Sobrenome = "Sbretestes",
                    Email = "teste@teste.com",

                };


                repUsr.Add(user);
                repUsr.Commit();


            }
        }
    }
}
