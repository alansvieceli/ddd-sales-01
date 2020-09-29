using System.Collections;
using System.Collections.Generic;
using DDD.Sales.Application.Models;
using DDD.Sales.Application.Services.Interfaces;
using DDD.Sales.Domain.Entities;
using DDD.Sales.Domain.Interfaces;

namespace DDD.Sales.Application.Services
{
    public class ClienteAppService: IClienteAppService
    {
        private readonly IClienteService _service;
        
        public ClienteAppService(IClienteService service)
        {
            this._service = service;
        }
        
        public IEnumerable<ClienteViewModel> Listagem()
        {
            var lista = this._service.Listagem();
            List<ClienteViewModel> listaModel = new List<ClienteViewModel>();
            foreach (var item in lista)
            {
                ClienteViewModel cliente = new ClienteViewModel()
                {
                    Codigo = item.Codigo,
                    Nome = item.Nome,
                    CNPJ_CPF = item.CNPJ_CPF,
                    Telefone = item.Telefone,
                    Email = item.Email
                };
                listaModel.Add(cliente);
            }
            return listaModel;
        }

        public ClienteViewModel Carregar(int? id)
        {
            ClienteViewModel categorialModel = new ClienteViewModel();
            if (id != null)
            {
                var cliente = this._service.CarregarRegistro((int) id);
                if (cliente != null)
                {
                    categorialModel.Codigo = cliente.Codigo;
                    categorialModel.Nome = cliente.Nome;
                    categorialModel.CNPJ_CPF = cliente.CNPJ_CPF;
                    categorialModel.Telefone = cliente.Telefone;
                    categorialModel.Email = cliente.Email;
                }
            }
            return categorialModel;
        }

        public void Cadastrar(ClienteViewModel entidade)
        {
            var cliente = new Cliente()
            {
                Codigo = entidade.Codigo,
                Nome = entidade.Nome,
                CNPJ_CPF = entidade.CNPJ_CPF,
                Telefone = entidade.Telefone,
                Email = entidade.Email
            };
            
            this._service.Cadastrar(cliente);
        }

        public void Excluir(int id)
        {
            this._service.Excluir(id);
        }
    }
}