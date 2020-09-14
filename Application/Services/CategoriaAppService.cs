using System.Collections;
using System.Collections.Generic;
using DDD.Sales.Application.Models;
using DDD.Sales.Application.Services.Interfaces;
using DDD.Sales.Domain.Interfaces;


namespace DDD.Sales.Application.Services
{
    public class CategoriaAppService: ICategoriaAppService
    {
        public CategoriaAppService(ICategoriaService service)
        {
            this._service = service;
        }

        private readonly ICategoriaService _service;
        
        public IEnumerable<CategoriaViewModel> Listagem()
        {
            var lista = this._service.Listagem();
            List<CategoriaViewModel> listaModel = new List<CategoriaViewModel>();
            foreach (var item in lista)
            {
                CategoriaViewModel categoria = new CategoriaViewModel()
                {
                    Codigo = item.Codigo,
                    Descricao = item.Descricao
                };
                listaModel.Add(categoria);
            }
            return listaModel;
        }
    }
}