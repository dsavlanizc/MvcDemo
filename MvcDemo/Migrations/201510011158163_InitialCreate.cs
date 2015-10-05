namespace MvcDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RollNo = c.Int(nullable: false),
                        FName = c.String(nullable: false),
                        LName = c.String(nullable: false),
                        EmailID = c.String(nullable: false),
                        Pswd = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }

        //public override void Down()
        //{
        //    DropTable("dbo.Students");
        //}
    }
}
