using Anteproyecto.Domain;
using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Entities;
using Anteproyecto.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Anteproyecto.Aplication.Test.Dobles
{
    class CuentaRepositoryFake : IUsuarioRepository
    {

        List<Usuario> usuarios = new List<Usuario>();
        
        public void Add(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(List<Usuario> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(List<Usuario> entities)
        {
            throw new NotImplementedException();
        }

        public void Edit(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public Usuario Find(object id)
        {
            return new Estudiante("Jose Carlo", "Santander Pimienta", "0123456789", "hola@gmail.com", "123344444",0,32,true);
        }

        public IEnumerable<Usuario> FindBy(Expression<Func<Usuario, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> FindBy(Expression<Func<Usuario, bool>> filter = null, Func<IQueryable<Usuario>, IOrderedQueryable<Usuario>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

 
        public Usuario FindFirstOrDefault(Expression<Func<Usuario, bool>> predicate)
        {
            return new Estudiante("Jose Carlo", "Santander Pimienta", "0123456789", "hola@gmail.com", "123344444",9,24,true);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return new List<Usuario>();   
        }
    }
}
