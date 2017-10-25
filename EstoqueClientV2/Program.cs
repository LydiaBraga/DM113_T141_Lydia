using EstoqueClient.EstoqueService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueClientV2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CLIENT 2");
            Console.WriteLine("Press ENTER when the service has started");
            Console.ReadLine();

            ServicoEstoqueClient proxy = new ServicoEstoqueClient("WS2007HttpBinding_IServicoEstoque");

            // Teste para ver estoque de um produto
            Console.WriteLine("Test 1: Verify Stock of product 1");
            Console.WriteLine("Product 1 Stock: " + proxy.ConsultarEstoque("1000"));
            Console.WriteLine();

            // Teste para adicionar estoque para um produto
            Console.WriteLine("Test 2: Add Stock for product 1");

            if (proxy.AdicionarEstoque("1000", 20))
            {
                Console.WriteLine("Stock increased 20 units.");
            }
            else
            {
                Console.WriteLine("Couldn't add 20 units to Stock");
            }
            Console.WriteLine();

            // Teste para ver estoque de um produto
            Console.WriteLine("Test 3: Verify Stock of product 1");
            Console.WriteLine("Product 1 Stock: " + proxy.ConsultarEstoque("1000"));
            Console.WriteLine();

            // Teste para ver estoque de um produto
            Console.WriteLine("Test 4: Verify Stock of product 5");
            Console.WriteLine("Product 1 Stock: " + proxy.ConsultarEstoque("5000"));
            Console.WriteLine();

            // Teste para remover estoque de um produto
            Console.WriteLine("Test 5: Remove Stock for product 5");

            if (proxy.RemoverEstoque("5000", 10))
            {
                Console.WriteLine("Stock decreased 10 units.");
            }
            else
            {
                Console.WriteLine("Couldn't remove 10 units of Stock");
            }
            Console.WriteLine();

            // Teste para ver estoque de um produto
            Console.WriteLine("Test 6: Verify Stock of product 5");
            Console.WriteLine("Product 5 Stock: " + proxy.ConsultarEstoque("5000"));
            Console.WriteLine();

            // Desconectar do serviço
            proxy.Close();
            Console.WriteLine("Press ENTER to finish"); Console.ReadLine();

        }
    }
}
