using System;
using System.Data.Entity.Migrations;

public partial class EnableCascadeDelete : DbMigration
{
    public override void Up()
    {
        CreateTable(
            "dbo.Customers",
            c => new
                {
                    CustomerID = c.Int(nullable: false, identity: true),
                    FirstName = c.String(nullable: false, maxLength: 50),
                    LastName = c.String(nullable: false, maxLength: 50),
                    Email = c.String(maxLength: 100),
                    Phone = c.String(maxLength: 15),
                })
            .PrimaryKey(t => t.CustomerID);
        
        CreateTable(
            "dbo.MenuItems",
            c => new
                {
                    MenuItemID = c.Int(nullable: false, identity: true),
                    RestaurantID = c.Int(nullable: false),
                    Name = c.String(nullable: false, maxLength: 100),
                    Description = c.String(maxLength: 255),
                    Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                })
            .PrimaryKey(t => t.MenuItemID)
            .ForeignKey("dbo.Restaurants", t => t.RestaurantID, cascadeDelete: true)
            .Index(t => t.RestaurantID);
        
        CreateTable(
            "dbo.Restaurants",
            c => new
                {
                    RestaurantID = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 100),
                    Address = c.String(nullable: false, maxLength: 200),
                    Phone = c.String(maxLength: 15),
                })
            .PrimaryKey(t => t.RestaurantID);
        
        CreateTable(
            "dbo.OrderItems",
            c => new
                {
                    OrderItemID = c.Int(nullable: false, identity: true),
                    OrderID = c.Int(nullable: false),
                    MenuItemID = c.Int(nullable: false),
                    Quantity = c.Int(nullable: false),
                    Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                })
            .PrimaryKey(t => t.OrderItemID)
            .ForeignKey("dbo.MenuItems", t => t.MenuItemID, cascadeDelete: true)
            .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
            .Index(t => t.OrderID)
            .Index(t => t.MenuItemID);
        
        CreateTable(
            "dbo.Orders",
            c => new
                {
                    OrderID = c.Int(nullable: false, identity: true),
                    CustomerID = c.Int(nullable: false),
                    RestaurantID = c.Int(nullable: false),
                    OrderDate = c.DateTime(nullable: false),
                    Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                })
            .PrimaryKey(t => t.OrderID)
            .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
            .ForeignKey("dbo.Restaurants", t => t.RestaurantID, cascadeDelete: true)
            .Index(t => t.CustomerID)
            .Index(t => t.RestaurantID);
        
    }
    
    public override void Down()
    {
        DropForeignKey("dbo.OrderItems", "OrderID", "dbo.Orders");
        DropForeignKey("dbo.Orders", "RestaurantID", "dbo.Restaurants");
        DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customers");
        DropForeignKey("dbo.OrderItems", "MenuItemID", "dbo.MenuItems");
        DropForeignKey("dbo.MenuItems", "RestaurantID", "dbo.Restaurants");
        DropIndex("dbo.Orders", new[] { "RestaurantID" });
        DropIndex("dbo.Orders", new[] { "CustomerID" });
        DropIndex("dbo.OrderItems", new[] { "MenuItemID" });
        DropIndex("dbo.OrderItems", new[] { "OrderID" });
        DropIndex("dbo.MenuItems", new[] { "RestaurantID" });
        DropTable("dbo.Orders");
        DropTable("dbo.OrderItems");
        DropTable("dbo.Restaurants");
        DropTable("dbo.MenuItems");
        DropTable("dbo.Customers");
    }
}
