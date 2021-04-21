using Anteproyecto.Domain;
using Anteproyecto.Domain.Contracts;
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

        List<Estudiante> estudiantes = new List<Estudiante>();

        
        public void Add(Estudiante entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(List<Estudiante> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(Estudiante entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(List<Estudiante> entities)
        {
            throw new NotImplementedException();
        }

        public void Edit(Estudiante entity)
        {
            throw new NotImplementedException();
        }

        public Estudiante Find(object id)
        {
            return new Estudiante("Jose Carlo", "Santander Pimienta", "0123456789", "hola@gmail.com", "123344444");
        }

        public IEnumerable<Estudiante> FindBy(Expression<Func<Estudiante, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Estudiante> FindBy(Expression<Func<Estudiante, bool>> filter = null, Func<IQueryable<Estudiante>, IOrderedQueryable<Estudiante>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

 
        public Estudiante FindFirstOrDefault(Expression<Func<Estudiante, bool>> predicate)
        {
            return new Estudiante("Jose Carlo", "Santander Pimienta", "0123456789", "hola@gmail.com", "123344444");
        }

        public IEnumerable<Estudiante> GetAll()
        {
          
            return new List<Estudiante>();   
        }
    }
}
