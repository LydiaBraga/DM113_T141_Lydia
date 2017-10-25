using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using EstoqueClient.EstoqueService;

namespace EstoqueClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CLIENT 1");
            Console.WriteLine("Press ENTER when the service has started");
            Console.ReadLine();

            ServicoEstoqueClient proxy = new ServicoEstoqueClient("BasicHttpBinding_IServicoEstoque");

            // Teste para inclusão de produto
            Console.WriteLine("Test 1: Add Product 11");
            ProdutoEstoqueData produto = new ProdutoEstoqueData(){
                NumeroProduto = "11000",
                NomeProduto = "Produto 11",
                DescricaoProduto = "Este é o produto 11",
                EstoqueProduto = 200
            };

            if (proxy.IncluirProduto(produto))
            {
                Console.WriteLine("Product 11 was added");
            }
            else
            {
                Console.WriteLine("Couldn't add Product 11");
            }
            Console.WriteLine();

            // Teste para remoção de produto
            Console.WriteLine("Test 2: Remove Product 10");
           
            if (proxy.RemoverProduto("10000"))
            {
                Console.WriteLine("Product 10 was removed");
            }
            else
            {
                Console.WriteLine("Couldn't remove Product 10");
            }
            Console.WriteLine();

            // Teste para listar todos os produtos
            Console.WriteLine("Test 3: List all products");

            List<string> produtos = proxy.ListarProdutos().ToList();
            produtos.ForEach(p => Console.WriteLine(p));
            Console.WriteLine();

            // Teste para verificar as informações de um produto
            Console.WriteLine("Test 4: Verify product 2 information");

            ProdutoEstoqueData produto2 = proxy.VerProduto("2000");
            Console.WriteLine("Product Number: " + produto2.NumeroProduto);
            Console.WriteLine("Product Name: " + produto2.NomeProduto);
            Console.WriteLine("Product Description: " + produto2.DescricaoProduto);
            Console.WriteLine("Product Stock: " + produto2.EstoqueProduto);
            Console.WriteLine();

            // Teste para adicionar estoque para um produto
            Console.WriteLine("Test 5: Add Stock for product 2");

            if (proxy.AdicionarEstoque("2000", 10))
            {
                Console.WriteLine("Stock increased 10 units.");
            }
            else
            {
                Console.WriteLine("Couldn't add 10 units to Stock");
            }
            Console.WriteLine();

            // Teste para ver estoque de um produto
            Console.WriteLine("Test 6: Verify Stock of product 2");
            Console.WriteLine("Product 2 Stock: " + proxy.ConsultarEstoque("2000"));
            Console.WriteLine();

            // Teste para ver estoque de um produto
            Console.WriteLine("Test 7: Verify Stock of product 1");
            Console.WriteLine("Product 1 Stock: " + proxy.ConsultarEstoque("1000"));
            Console.WriteLine();

            // Teste para remover estoque de um produto
            Console.WriteLine("Test 8: Remove Stock of product 1");

            if (proxy.RemoverEstoque("1000", 20))
            {
                Console.WriteLine("Stock decreased 20 units.");
            }
            else
            {
                Console.WriteLine("Couldn't remove 20 units of Stock");
            }
            Console.WriteLine();

            // Teste para ver estoque de um produto
            Console.WriteLine("Test 9: Verify Stock of product 1");
            Console.WriteLine("Product 1 Stock: " + proxy.ConsultarEstoque("1000"));
            Console.WriteLine();

            // Teste para ver estoque de um produto
            Console.WriteLine("Test 10: Verify product 1 information");
            ProdutoEstoqueData produto1 = proxy.VerProduto("1000");
            Console.WriteLine("Product Number: " + produto1.NumeroProduto);
            Console.WriteLine("Product Name: " + produto1.NomeProduto);
            Console.WriteLine("Product Description: " + produto1.DescricaoProduto);
            Console.WriteLine("Product Stock: " + produto1.EstoqueProduto);

            Console.WriteLine();

            // Desconectar do serviço
            proxy.Close();
            Console.WriteLine("Press ENTER to finish"); Console.ReadLine();
        }
    }
}
