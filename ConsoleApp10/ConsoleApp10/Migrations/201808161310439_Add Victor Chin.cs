namespace ConsoleApp10.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVictorChin : DbMigration
    {
        public override void Up()
        {
            
            CreateTable(
                "dbo.VictorChins",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        DoB = c.DateTime(nullable: false),
                        Grade = c.Int(),
                    })
                .PrimaryKey(t => t.StudentID);
            
        }
        
        public override void Down()
        {   DropTable("dbo.VictorChins");
         
        }
    }
}
