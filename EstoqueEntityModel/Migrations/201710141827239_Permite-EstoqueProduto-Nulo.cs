namespace EstoqueEntityModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PermiteEstoqueProdutoNulo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProdutoEstoques", "EstoqueProduto", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProdutoEstoques", "EstoqueProduto", c => c.Int(nullable: false));
        }
    }
}
