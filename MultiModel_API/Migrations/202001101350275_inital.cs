namespace MultiModel_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inital : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuestionsAnswer_Tb",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionDescription = c.String(),
                        Answer = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.QuestionsAnswer_Tb");
        }
    }
}
