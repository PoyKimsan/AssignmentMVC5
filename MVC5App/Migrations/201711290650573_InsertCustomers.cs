namespace MVC5App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertCustomers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Customers(ID,Name) VALUES(1,'Customer1')");
            Sql("INSERT INTO Customers(ID,Name) VALUES(2,'Customer2')");
        }
        
        public override void Down()
        {
        }
    }
}
