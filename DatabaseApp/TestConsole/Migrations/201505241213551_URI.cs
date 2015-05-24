namespace TestConsole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class URI : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DepartmentsBase", "URI", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DepartmentsBase", "URI");
        }
    }
}
