namespace EstoqueEntityModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Criacao_do_Banco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProdutoEstoques",
                c => new
                    {
                        NumeroProduto = c.String(nullable: false, maxLength: 10),
                        NomeProduto = c.String(maxLength: 20),
                        DescricaoProduto = c.String(maxLength: 50),
                        EstoqueProduto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NumeroProduto);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProdutoEstoques");
        }
    }
}
