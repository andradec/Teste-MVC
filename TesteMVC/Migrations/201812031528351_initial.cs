namespace TesteMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Amigo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Celular = c.String(nullable: false),
                        SexoId = c.Int(nullable: false),
                        Rua = c.String(nullable: false),
                        Numero = c.Int(nullable: false),
                        Bairro = c.String(nullable: false),
                        Cep = c.String(nullable: false),
                        Cidade = c.String(nullable: false),
                        Cpf = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sexo", t => t.SexoId, cascadeDelete: true)
                .Index(t => t.SexoId);
            
            CreateTable(
                "dbo.Emprestimo",
                c => new
                    {
                        EmprestimoID = c.Int(nullable: false, identity: true),
                        AmigoID = c.Int(nullable: false),
                        JogoID = c.Int(nullable: false),
                        Data = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EmprestimoID)
                .ForeignKey("dbo.Amigo", t => t.AmigoID, cascadeDelete: true)
                .ForeignKey("dbo.Jogo", t => t.JogoID, cascadeDelete: true)
                .Index(t => t.AmigoID)
                .Index(t => t.JogoID);
            
            CreateTable(
                "dbo.Jogo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false),
                        EstiloId = c.Int(nullable: false),
                        Lancamento = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Estilo", t => t.EstiloId, cascadeDelete: true)
                .Index(t => t.EstiloId);
            
            CreateTable(
                "dbo.Estilo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sexo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeUsuario = c.String(nullable: false),
                        Senha = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Amigo", "SexoId", "dbo.Sexo");
            DropForeignKey("dbo.Jogo", "EstiloId", "dbo.Estilo");
            DropForeignKey("dbo.Emprestimo", "JogoID", "dbo.Jogo");
            DropForeignKey("dbo.Emprestimo", "AmigoID", "dbo.Amigo");
            DropIndex("dbo.Jogo", new[] { "EstiloId" });
            DropIndex("dbo.Emprestimo", new[] { "JogoID" });
            DropIndex("dbo.Emprestimo", new[] { "AmigoID" });
            DropIndex("dbo.Amigo", new[] { "SexoId" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Sexo");
            DropTable("dbo.Estilo");
            DropTable("dbo.Jogo");
            DropTable("dbo.Emprestimo");
            DropTable("dbo.Amigo");
        }
    }
}
