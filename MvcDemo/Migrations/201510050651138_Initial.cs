namespace MvcDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "EmailID", c => c.String(nullable: false));
            AddColumn("dbo.Students", "Pswd", c => c.String(nullable: false));
        }
        
        //public override void Down()
        //{
        //    DropColumn("dbo.Students", "Pswd");
        //    DropColumn("dbo.Students", "EmailID");
        //}
    }
}
