// <auto-generated />
// ReSharper disable all

using System;
using System.Data.Entity.Migrations;
using System.CodeDom.Compiler;
using System.Data.Entity.Migrations.Infrastructure;

namespace MercuryWorks.BusinessFramework.Server.Migrations
{
    [GeneratedCode("NFive.Migration", "0.3 Alpha Build 169")]
    public class AddBtype : DbMigration, IMigrationMetadata
    {
        string IMigrationMetadata.Id => "201904181019163_AddBtype";
        
        string IMigrationMetadata.Source => null;
        
        string IMigrationMetadata.Target => "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";
        
        public override void Up()
        {
            AddColumn("dbo.Businesses", "BusinessType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Businesses", "BusinessType");
        }
    }
}
