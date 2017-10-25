using EstoqueEntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.Web;

namespace ProdutoEstoqueService
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ServicoEstoque : IServicoEstoque, IServicoEstoqueV2
    {
        public bool AdicionarEstoque(string numeroProduto, int quantidade)
        {
            bool wasAdded = false;
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    ProdutoEstoque produtoEstoque = database.ProdutosEstoque.Find(numeroProduto);

                    if (produtoEstoque != null)
                    {
                        produtoEstoque.EstoqueProduto = produtoEstoque.EstoqueProduto + quantidade;
                        database.SaveChanges();

                        wasAdded = true;
                    }
                }
            }
            catch
            {
                // Ignore exceptions in this implementation
            }

            return wasAdded;
        }

        public int ConsultarEstoque(string numeroProduto)
        {
            int quantidade = 0;
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    quantidade = database.ProdutosEstoque.Find(numeroProduto).EstoqueProduto.Value;
                }
            }
            catch
            {
                // Ignore exceptions in this implementation
            }

            return quantidade;
        }

        public bool IncluirProduto(ProdutoEstoqueData produtoEstoque)
        {
            bool wasAdded = false;
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    ProdutoEstoque produtoEstoqueToAdd = new ProdutoEstoque()
                    {
                        NumeroProduto = produtoEstoque.NumeroProduto,
                        NomeProduto = produtoEstoque.NomeProduto,
                        DescricaoProduto = produtoEstoque.DescricaoProduto,
                        EstoqueProduto = produtoEstoque.EstoqueProduto
                    };

                    database.ProdutosEstoque.Add(produtoEstoqueToAdd);
                    database.SaveChanges();

                    wasAdded = true;
                }
            }
            catch
            {
                // Ignore exceptions in this implementation
            }

            return wasAdded;
        }

        public List<string> ListarProdutos()
        {
            List<string> produtoEstoqueNomes = new List<string>();

            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    produtoEstoqueNomes = (from produtoEstoque in database.ProdutosEstoque
                                           select produtoEstoque.NomeProduto).ToList();
                }
            }
            catch
            {
                // Ignore exceptions in this implementation
            }

            return produtoEstoqueNomes;
        }

        public bool RemoverEstoque(string numeroProduto, int quantidade)
        {
            bool wasRemoved = false;
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    ProdutoEstoque produtoEstoque = database.ProdutosEstoque.Find(numeroProduto);

                    if (produtoEstoque != null)
                    {
                        int novaQuantidade = produtoEstoque.EstoqueProduto.Value - quantidade;

                        if (novaQuantidade > 0)
                        {
                            produtoEstoque.EstoqueProduto = novaQuantidade;
                        }
                        else
                        {
                            produtoEstoque.EstoqueProduto = 0;
                        }

                        database.SaveChanges();

                        wasRemoved = true;
                    }
                }
            }
            catch
            {
                // Ignore exceptions in this implementation
            }

            return wasRemoved;
        }

        public bool RemoverProduto(string numeroProduto)
        {
            bool wasRemoved = false;
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    ProdutoEstoque produtoEstoque = database.ProdutosEstoque.Find(numeroProduto);

                    if (produtoEstoque != null)
                    {
                        database.ProdutosEstoque.Remove(produtoEstoque);
                        database.SaveChanges();

                        wasRemoved = true;
                    }
                }
            }
            catch
            {
                // Ignore exceptions in this implementation
            }

            return wasRemoved;
        }

        public ProdutoEstoqueData VerProduto(string numeroProduto)
        {
            ProdutoEstoqueData produtoEstoque = null;
            try
            {
                // Connect to the ProductsModel database
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    // Find the first product that matches the specified product code
                    ProdutoEstoque produto = database.ProdutosEstoque.Find(numeroProduto);

                    if (produto != null)
                    {
                        produtoEstoque = new ProdutoEstoqueData()
                        {
                            NumeroProduto = produto.NumeroProduto,
                            NomeProduto = produto.NomeProduto,
                            DescricaoProduto = produto.DescricaoProduto,
                            EstoqueProduto = produto.EstoqueProduto
                        };
                    }
                }
            }
            catch
            {
                // Ignore exceptions in this implementation
            }
            // Return the product
            return produtoEstoque;
        }
    }
}