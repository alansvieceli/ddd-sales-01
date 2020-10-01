using System;
using System.Collections.Generic;
using DDD.Sales.Application.Models;
using DDD.Sales.Application.Services.Interfaces;
using DDD.Sales.Domain.DTO;
using DDD.Sales.Domain.Entities;
using DDD.Sales.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace DDD.Sales.Application.Services
{
    public class VendaAppService: IVendaAppService
    {
        private readonly IVendaService _service;
        private readonly IProdutoService _serviceProduto;
        private readonly IClienteService _serviceCliente;
        
        public VendaAppService(IVendaService service, IProdutoService serviceProduto, IClienteService serviceCliente)
        {
            this._service = service;
            this._serviceProduto = serviceProduto;
            this._serviceCliente = serviceCliente;
        }
        
        public IEnumerable<VendaViewModel> Listagem()
        {
            var lista = this._service.Listagem();
            List<VendaViewModel> listaModel = new List<VendaViewModel>();
            foreach (var item in lista)
            {
                VendaViewModel venda = new VendaViewModel()
                {
                    Codigo = item.Codigo,
                    Data = item.Data,
                    Total = item.Total,
                    CodigoCliente = item.CodigoCliente,
                    DescricaoCliente = item.Cliente.Nome,
                };
                listaModel.Add(venda);
            }
            return listaModel;
        }

        public VendaViewModel Carregar(int? id)
        {
            VendaViewModel vendaViewModel = new VendaViewModel();
            if (id != null)
            {
                var venda = this._service.CarregarRegistro((int) id);
                if (venda != null)
                {
                    vendaViewModel.Codigo = venda.Codigo;
                    vendaViewModel.Data = venda.Data;
                    vendaViewModel.Total = venda.Total;
                    vendaViewModel.CodigoCliente = venda.CodigoCliente;
                }
            }
            return vendaViewModel;
        }

        public void Cadastrar(VendaViewModel entidade)
        {
            var venda = new Venda()
            {
                Codigo = entidade.Codigo,
                Data = (DateTime) entidade.Data,
                Total = entidade.Total,
                CodigoCliente = (int) entidade.CodigoCliente,
                Produtos = JsonConvert.DeserializeObject<ICollection<VendaProdutos>>(entidade.JsonProdutos)
            };
            
            this._service.Cadastrar(venda);
        }

        public void Excluir(int id)
        {
            this._service.Excluir(id);
        }
        
        public IEnumerable<SelectListItem> GetListaProdutos()
        {
            List<SelectListItem> lista = new List<SelectListItem>();
            lista.Add(new SelectListItem()
            {
                Value = String.Empty,
                Text = String.Empty
            });

            foreach (var item in this._serviceProduto.Listagem())
            {
                lista.Add(new SelectListItem()
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Descricao
                });
            }

            return lista;
        }
        
        public IEnumerable<SelectListItem> GetListaClientes()
        {
            List<SelectListItem> lista = new List<SelectListItem>();
            lista.Add(new SelectListItem()
            {
                Value = String.Empty,
                Text = String.Empty
            });

            foreach (var item in this._serviceCliente.Listagem())
            {
                lista.Add(new SelectListItem()
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Nome
                });
            }

            return lista;
        }

        public IEnumerable<VendaProdutosDto> ListaGrafico()
        {
            return this._service.ListaGrafico();
        }
    }
}