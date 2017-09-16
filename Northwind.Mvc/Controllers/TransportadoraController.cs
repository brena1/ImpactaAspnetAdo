using Nothwind.Repositorios.SqlServer.Ado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Northwind.Modelo;
using Northwind.Mvc.Models;

namespace Northwind.Mvc.Controllers
{
    public class TransportadoraController : Controller
    {
        TransportadoraRepositorio _repositorio = new TransportadoraRepositorio();
        // GET: Transportadora
        public ActionResult Index()
        {           
            //ToDo: AutoMapper ou TinyMapper ou FastMapper
            return View(Mapear(_repositorio.Selecionar()));
        }

        private List<TransportadoraViewModel> Mapear(List<Transportadora> transportadoras)
        {
            var transportadorasViewModel = new List<TransportadoraViewModel>();

            foreach (var transportadora in transportadoras)
            {
                transportadorasViewModel.Add(Mapear(transportadora));
            }


            return transportadorasViewModel;
        }

        private TransportadoraViewModel Mapear(Transportadora transportadora)
        {
            var viewModel = new TransportadoraViewModel();
            viewModel.Id = transportadora.Id;
            viewModel.Nome = transportadora.Nome;
            viewModel.Telefone = transportadora.Telefone;
            return viewModel;
        }

        // GET: Transportadora/Details/5
        public ActionResult Details(int id)
        {
            return View(Mapear(_repositorio.Selecionar(id)));

        }

        // GET: Transportadora/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transportadora/Create
        [HttpPost]
        //public ActionResult Create(FormCollection collection)
        public ActionResult Create(TransportadoraViewModel viewModel)
        {
            try
            {
               
                 //var nome = collection["Nome"];

                _repositorio.Inserir(Mapear(viewModel));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private Transportadora Mapear(TransportadoraViewModel viewModel)
        {
            return new Transportadora { Nome = viewModel.Nome,
                                        Id = viewModel.Id,
                                        Telefone = viewModel.Telefone
            };
        }

        // GET: Transportadora/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Mapear(_repositorio.Selecionar(id)));
        }

        // POST: Transportadora/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TransportadoraViewModel viewModel)
        {
            try
            {
                _repositorio.Atualizar(Mapear(viewModel));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Transportadora/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Mapear(_repositorio.Selecionar(id)));
        }

        // POST: Transportadora/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, TransportadoraViewModel viewModel)
        {
            try
            {
                _repositorio.Excluir(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
