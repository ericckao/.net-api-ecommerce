using eCommerce.API.Database;
using eCommerce.Models;

namespace eCommerce.API.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly eCommerceContext _db;

        public UsuarioRepository(eCommerceContext db)
        {
            _db = db;
        }
        public List<Usuario> Get()
        {
            return _db.Usuarios.OrderBy(x => x.Id).ToList(); //Primeiro o SGBD ordena e depois é convertido pra lista no c#
            //var lista = _db.Usuarios.ToList().OrderBy(x => x.Id); | Primeiro converte na lista e depois o Csharp ordena.

        }

        public Usuario Get(int id)
        {
            return _db.Usuarios.Find(id)!;
        }

        public void Add(Usuario usuario)
        {
            /*
             * Unit of Works
             * Memory - EF Core
             */
            _db.Usuarios.Add(usuario); 

            //Memory --> SGBD
            _db.SaveChanges();
        }
        public void Update(Usuario usuario)
        {
            _db.Usuarios.Update(usuario);
            _db.SaveChanges();
            
            /* Outra forma de atualizar usuario
             * _db.Remove(Get(usuario.Id));
             * _db.Add(usuario);
             */
        }
        public void Delete(int id)
        {
            _db.Usuarios.Remove(Get(id));
            _db.SaveChanges();
            //_db.Remove(Get(id));
        }
    }
}
