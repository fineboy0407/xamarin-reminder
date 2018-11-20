namespace Reminder.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhotoImageTypeChanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Photos", "Image", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Photos", "Image", c => c.Binary());
        }
    }
}
