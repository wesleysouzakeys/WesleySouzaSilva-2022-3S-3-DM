using Patrimonio.Contexts;
using Patrimonio.Domains;
using Patrimonio.Interfaces;
using Patrimonio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Patrimonio.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly PatrimonioContext ctx;

        public UsuarioRepository(PatrimonioContext appContext)
        {
            ctx = appContext;
        }

        public Usuario Login(string email, string senha)
        {
            var usuario = ctx.Usuarios.FirstOrDefault(u => u.Email == email);
            var rgx = new Regex(@"^\$\d[a-z]\$\d\d\$.{53}");

            if (rgx.IsMatch(usuario.Senha))
            {
                bool comparado = Criptografia.Comparar(senha, usuario.Senha);
                if (comparado)
                    return usuario;
            }
            else
            {
                AtualizarCripto(usuario, usuario.Id);
                Login(usuario.Email, usuario.Senha);
            }

            return null;
        }

        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuarios.Find(id);
        }

        public void AtualizarCripto(Usuario usuarioBuscado, int id)
        {
            Usuario usuarioNoBanco = BuscarPorId(id);

            string senhaAtualizada = Criptografia.GerarHash(usuarioBuscado.Senha);

            usuarioNoBanco.IdPerfils = usuarioBuscado.IdPerfils;
            usuarioNoBanco.Senha = senhaAtualizada;
            usuarioNoBanco.Email = usuarioBuscado.Email;

            ctx.Usuarios.Update(usuarioNoBanco);

            ctx.SaveChanges();
        }
    }
}
