using System;
using System.Collections;
using System.Collections.Generic;
using DDD.Sales.Application.Models;
using DDD.Sales.Application.Services.Interfaces;
using DDD.Sales.Domain.Entities;
using DDD.Sales.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Storage;

namespace DDD.Sales.Application.Services
{
    public class ProdutoAppService: IProdutoAppService
    {
        private readonly IProdutoService _service;
        private readonly ICategoriaService _serviceCategoria;
        
        public ProdutoAppService(IProdutoService service, ICategoriaService serviceCategoria)
        {
            this._service = service;
            this._serviceCategoria = serviceCategoria;
        }
        
        public IEnumerable<ProdutoViewModel> Listagem()
        {
            var lista = this._service.Listagem();
            List<ProdutoViewModel> listaModel = new List<ProdutoViewModel>();
            foreach (var item in lista)
            {
                ProdutoViewModel produto = new ProdutoViewModel()
                {
                    Codigo = item.Codigo,
                    Descricao = item.Descricao,
                    Quantidade = item.Quantidade,
                    Valor = item.Valor,
                    CodigoCategoria = item.CodigoCategoria,
                    DescricaoCategoria = item.Categoria.Descricao
                };
                listaModel.Add(produto);
            }
            return listaModel;
        }

        public ProdutoViewModel Carregar(int? id)
        {
            ProdutoViewModel produtoModel = new ProdutoViewModel()
            {
                ListaCategorias = GetListaCategorias()
            };
            if (id != null)
            {
                var produto = this._service.CarregarRegistro((int) id);
                if (produto != null)
                {
                    produtoModel.Codigo = produto.Codigo;
                    produtoModel.Descricao = produto.Descricao;
                    produtoModel.Quantidade = produto.Quantidade;
                    produtoModel.Valor = produto.Valor;
                    produtoModel.CodigoCategoria = produto.CodigoCategoria;
                }
            }
            return produtoModel;
        }

        public void Cadastrar(ProdutoViewModel view)
        {
            var produto = new Produto()
            {
                Codigo = view.Codigo,
                Descricao = view.Descricao,
                Quantidade = view.Quantidade,
                Valor = view.Valor,
                CodigoCategoria = (int) view.CodigoCategoria
            };
            
            this._service.Cadastrar(produto);
        }

        public void Excluir(int id)
        {
            this._service.Excluir(id);
        }

        public decimal GetPrice(int id)
        {
            return this._service.GetPrice(id);
        }

        private IEnumerable<SelectListItem> GetListaCategorias()
        {
            
            List<SelectListItem> lista = new List<SelectListItem>();
            lista.Add(new SelectListItem()
            {
                Value = String.Empty,
                Text = String.Empty
            });

            foreach (var item in this._serviceCategoria.Listagem())
            {
                lista.Add(new SelectListItem()
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Descricao
                });
            }

            return lista;
            
        }
    }
}