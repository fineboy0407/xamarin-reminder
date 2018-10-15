namespace Reminder.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableNamesFix : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AchievementModels", newName: "Achievements");
            RenameTable(name: "dbo.BirthdayModels", newName: "Birthdays");
            RenameTable(name: "dbo.PhotoModels", newName: "Photos");
            RenameTable(name: "dbo.VideoModels", newName: "Videos");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Videos", newName: "VideoModels");
            RenameTable(name: "dbo.Photos", newName: "PhotoModels");
            RenameTable(name: "dbo.Birthdays", newName: "BirthdayModels");
            RenameTable(name: "dbo.Achievements", newName: "AchievementModels");
        }
    }
}
