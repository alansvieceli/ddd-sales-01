using System.Collections.Generic;
using DDD.Sales.Application.Models;
using DDD.Sales.Application.Services.Interfaces;
using DDD.Sales.Domain.Entities;
using DDD.Sales.Domain.Interfaces;

namespace DDD.Sales.Application.Services
{
    public class CategoriaAppService: ICategoriaAppService
    {
        private readonly ICategoriaService _service;
        
        public CategoriaAppService(ICategoriaService service)
        {
            this._service = service;
        }
        
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

        public CategoriaViewModel Carregar(int? id)
        {
            CategoriaViewModel categorialModel = new CategoriaViewModel();
            if (id != null)
            {
                var categoria = this._service.CarregarRegistro((int) id);
                if (categoria != null)
                {
                    categorialModel.Codigo = categoria.Codigo;
                    categorialModel.Descricao = categoria.Descricao;
                }
            }
            return categorialModel;
        }

        public void Cadastrar(CategoriaViewModel entidade)
        {
            var categoria = new Categoria()
            {
                Codigo = entidade.Codigo,
                Descricao = entidade.Descricao
            };
            
            this._service.Cadastrar(categoria);
        }

        public void Excluir(int id)
        {
            this._service.Excluir(id);
        }
        
    }
}