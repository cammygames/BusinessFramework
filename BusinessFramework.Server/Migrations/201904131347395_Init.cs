// <auto-generated />
// ReSharper disable all

using System;
using System.Data.Entity.Migrations;
using System.CodeDom.Compiler;
using System.Data.Entity.Migrations.Infrastructure;

namespace MercuryWorks.BusinessFramework.Server.Migrations
{
    [GeneratedCode("NFive.Migration", "0.3 Alpha Build 169")]
    public class Init : DbMigration, IMigrationMetadata
    {
        string IMigrationMetadata.Id => "201904131347395_Init";
        
        string IMigrationMetadata.Source => null;
        
        string IMigrationMetadata.Target => "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";
        
        public override void Up()
        {
            CreateTable(
                "dbo.Businesses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                        CharacterId = c.Guid(nullable: false),
                        MarkerPosition_X = c.Single(nullable: false),
                        MarkerPosition_Y = c.Single(nullable: false),
                        MarkerPosition_Z = c.Single(nullable: false),
                        MarkerColorId = c.Int(nullable: false),
                        MarkerSpriteId = c.Int(nullable: false),
                        Default = c.Boolean(nullable: false, storeType: "bit"),
                        Created = c.DateTime(nullable: false, precision: 0),
                        Deleted = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BusinessPositions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        BusinessId = c.Guid(nullable: false),
                        Position_X = c.Single(nullable: false),
                        Position_Y = c.Single(nullable: false),
                        Position_Z = c.Single(nullable: false),
                        PositionType = c.Int(nullable: false),
                        MarkerTypeId = c.Int(nullable: false),
                        MarkerRotation_X = c.Single(nullable: false),
                        MarkerRotation_Y = c.Single(nullable: false),
                        MarkerRotation_Z = c.Single(nullable: false),
                        MarkerScale_X = c.Single(nullable: false),
                        MarkerScale_Y = c.Single(nullable: false),
                        MarkerScale_Z = c.Single(nullable: false),
                        MarkerColor_A = c.Byte(),
                        MarkerColor_R = c.Byte(),
                        MarkerColor_G = c.Byte(),
                        MarkerColor_B = c.Byte(),
                        Created = c.DateTime(nullable: false, precision: 0),
                        Deleted = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        BusinessId = c.Guid(nullable: false),
                        CharacterId = c.Guid(nullable: false),
                        Created = c.DateTime(nullable: false, precision: 0),
                        Deleted = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100, unicode: false),
                        Description = c.String(maxLength: 1000, unicode: false),
                        BusinessId = c.Guid(nullable: false),
                        CompensationType = c.Int(nullable: false),
                        AccessLevel = c.Int(nullable: false),
                        CompensationValue = c.Single(nullable: false),
                        Created = c.DateTime(nullable: false, precision: 0),
                        Deleted = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id);   
        }
        
        public override void Down()
        {
            DropTable("dbo.Jobs");
            DropTable("dbo.Employees");
            DropTable("dbo.BusinessPositions");
            DropTable("dbo.Businesses");
        }
    }
}