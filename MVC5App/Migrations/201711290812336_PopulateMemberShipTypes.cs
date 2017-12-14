namespace MVC5App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMemberShipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MemberShipTypes (Id,SingUpFee,DuratiionInMonth,DiscountRate) VALUES (1,0,0,0)");
            Sql("INSERT INTO MemberShipTypes (Id,SingUpFee,DuratiionInMonth,DiscountRate) VALUES (2,30,1,10)");
            Sql("INSERT INTO MemberShipTypes (Id,SingUpFee,DuratiionInMonth,DiscountRate) VALUES (3,90,3,15)");
            Sql("INSERT INTO MemberShipTypes (Id,SingUpFee,DuratiionInMonth,DiscountRate) VALUES (4,300,12,15)");
        }
        
        public override void Down()
        {
        }
    }
}
