using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Entities;
using Anteproyecto.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anteproyecto.Aplication.ProyectoService
{
    public class ConsultarProyectoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProyectoRepository _proyectoRepository;

        public ConsultarProyectoService(IUnitOfWork unitOfWork, IProyectoRepository proyectoRepository)
        {
            _unitOfWork = unitOfWork;
            _proyectoRepository = proyectoRepository;
        }

        public List<Proyecto> GetAll()
        {
            var res = _proyectoRepository.GetAll();
            return res.ToList();
        }

        public Proyecto GetId(int id)
        {
            var ConsultarID = _proyectoRepository.Find(id); 
            return ConsultarID;
        }

    }
}
