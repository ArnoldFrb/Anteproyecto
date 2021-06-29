﻿using Anteproyecto.Domain.Contracts;
using Anteproyecto.Domain.Entities;
using Anteproyecto.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anteproyecto.Aplication.ProyectoService
{
    public class ListProyectosService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProyectoRepository _proyectoRepository;

        public ListProyectosService(IUnitOfWork unitOfWork, IProyectoRepository proyectoRepository)
        {
            _unitOfWork = unitOfWork;
            _proyectoRepository = proyectoRepository;
        }

        public ListProyectosResponse List()
        {
            var proyecto = _proyectoRepository.GetAll();
            if (proyecto.Count() != 0)
            {
                return new ListProyectosResponse(proyecto, "No existen Proyectos registrados");
            }
            else
            {
                return new ListProyectosResponse(null, "No existen Proyectos registrados");
            }
        }

        public record ListProyectosResponse(IEnumerable<Proyecto> Proyectos, string Mensaje);
    }
}