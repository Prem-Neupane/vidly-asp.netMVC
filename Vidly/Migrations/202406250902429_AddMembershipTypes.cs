namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddMembershipTpes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "DurationInMonths", c => c.Byte(nullable: false));
            DropColumn("dbo.MembershipTypes", "DurationIMonths");
        }

        public override void Down()
        {
            AddColumn("dbo.MembershipTypes", "DurationIMonths", c => c.Byte(nullable: false));
            DropColumn("dbo.MembershipTypes", "DurationInMonths");
        }
    }
}
