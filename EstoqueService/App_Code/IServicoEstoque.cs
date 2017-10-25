using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ProdutoEstoqueService
{
    [ServiceContract(Namespace = "http://projetoavaliativo.dm113/01", Name = "IServicoEstoque")]
    public interface IServicoEstoque
    {
        [OperationContract]
        List<string> ListarProdutos();

        [OperationContract]
        bool IncluirProduto(ProdutoEstoqueData produtoEstoque);

        [OperationContract]
        bool RemoverProduto(string numeroProduto);

        [OperationContract]
        int ConsultarEstoque(string numeroProduto);

        [OperationContract]
        bool AdicionarEstoque(string numeroProduto, int quantidade);

        [OperationContract]
        bool RemoverEstoque(string numeroProduto, int quantidade);

        [OperationContract]
        ProdutoEstoqueData VerProduto(string numeroProduto);
    }

    [ServiceContract(Namespace = "http://projetoavaliativo.dm113/02", Name = "IServicoEstoque")]
    public interface IServicoEstoqueV2
    {
        [OperationContract]
        bool AdicionarEstoque(string numeroProduto, int quantidade);

        [OperationContract]
        bool RemoverEstoque(string numeroProduto, int quantidade);

        [OperationContract]
        int ConsultarEstoque(string numeroProduto);

        // TODO: Adicione suas operações de serviço aqui

    }

    // Use um contrato de dados como ilustrado no exemplo abaixo para adicionar tipos compostos a operações de serviço.
    [DataContract]
    public class ProdutoEstoqueData
    {
        [DataMember]
        public string NumeroProduto;

        [DataMember]
        public string NomeProduto;

        [DataMember]
        public string DescricaoProduto;

        [DataMember]
        public int? EstoqueProduto;
    }
}
