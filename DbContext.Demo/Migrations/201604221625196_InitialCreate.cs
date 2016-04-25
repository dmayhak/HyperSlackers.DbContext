namespace HyperSlackers.DbContext.Demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetAuditItems",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ClusteredKey = c.Long(nullable: false, identity: true),
                        AuditId = c.Guid(nullable: false),
                        Entity1Id = c.Guid(nullable: false),
                        Entity2Id = c.Guid(nullable: false),
                        AuditPropertyId = c.Guid(nullable: false),
                        OperationType = c.String(nullable: false, maxLength: 1),
                        OldValue = c.String(),
                        NewValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetAudits", t => t.AuditId)
                .ForeignKey("dbo.AspNetAuditProperties", t => t.AuditPropertyId)
                .Index(t => t.ClusteredKey, clustered: true)
                .Index(t => t.AuditId, name: "IX_Audit")
                .Index(t => t.Entity1Id, name: "IX_Entity1")
                .Index(t => t.Entity2Id, name: "IX_Entity2")
                .Index(t => t.AuditPropertyId, name: "IX_Property");
            
            CreateTable(
                "dbo.AspNetAudits",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ClusteredKey = c.Long(nullable: false, identity: true),
                        HostId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        HostName = c.String(maxLength: 255),
                        UserName = c.String(maxLength: 255),
                        AuditDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Id, name: "IX_Date_Id")
                .Index(t => t.ClusteredKey, clustered: true)
                .Index(t => new { t.HostId, t.AuditDate }, name: "IX_Host_Date")
                .Index(t => new { t.UserId, t.AuditDate }, name: "IX_User_Date")
                .Index(t => t.AuditDate, name: "IX_Date");
            
            CreateTable(
                "dbo.AspNetAuditProperties",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ClusteredKey = c.Long(nullable: false, identity: true),
                        EntityName = c.String(nullable: false, maxLength: 255),
                        PropertyName = c.String(maxLength: 255),
                        PropertyType = c.String(),
                        IsRelation = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.ClusteredKey, clustered: true)
                .Index(t => new { t.EntityName, t.PropertyName }, name: "IX_Entity_Property");
            
            CreateTable(
                "dbo.AspNetHostDomains",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ClusteredKey = c.Long(nullable: false, identity: true),
                        HostId = c.Guid(nullable: false),
                        DomainName = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetHosts", t => t.HostId, cascadeDelete: true)
                .Index(t => t.ClusteredKey, clustered: true)
                .Index(t => new { t.DomainName, t.HostId }, unique: true, name: "IX_Domain_Host")
                .Index(t => new { t.HostId, t.DomainName }, unique: true, name: "IX_Host_Domain");
            
            CreateTable(
                "dbo.AspNetHosts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ClusteredKey = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        IsSystemHost = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.ClusteredKey, clustered: true)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.InvoiceItems",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        HostId = c.Guid(nullable: false),
                        InvoiceId = c.Guid(nullable: false),
                        ProductId = c.Guid(nullable: false),
                        Code = c.String(),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Invoices", t => t.InvoiceId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.InvoiceId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        HostId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        Number = c.String(),
                        Date = c.DateTime(nullable: false),
                        SubTotal = c.Double(nullable: false),
                        Tax = c.Double(nullable: false),
                        Shipping = c.Double(nullable: false),
                        Total = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        HostId = c.Guid(nullable: false),
                        Code = c.String(),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetGroupRoles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ClusteredKey = c.Long(nullable: false, identity: true),
                        RoleGroupId = c.Guid(nullable: false),
                        RoleId = c.Guid(nullable: false),
                        HyperRoleGroupGuid_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetGroups", t => t.HyperRoleGroupGuid_Id)
                .Index(t => t.ClusteredKey, clustered: true)
                .Index(t => new { t.RoleGroupId, t.RoleId }, unique: true, name: "IX_Group_Role")
                .Index(t => new { t.RoleId, t.RoleGroupId }, unique: true, name: "IX_Role_Group")
                .Index(t => t.HyperRoleGroupGuid_Id);
            
            CreateTable(
                "dbo.AspNetGroups",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ClusteredKey = c.Long(nullable: false, identity: true),
                        HostId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        Description = c.String(),
                        IsGlobal = c.Boolean(nullable: false),
                        IsGlobalOnly = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.ClusteredKey, clustered: true)
                .Index(t => new { t.HostId, t.Name }, unique: true, name: "IX_Host_Name")
                .Index(t => new { t.IsGlobal, t.Name }, name: "IX_Global_Name");
            
            CreateTable(
                "dbo.AspNetGroupUsers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ClusteredKey = c.Long(nullable: false, identity: true),
                        HostId = c.Guid(nullable: false),
                        RoleGroupId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        IsGlobal = c.Boolean(nullable: false),
                        HyperRoleGroupGuid_Id = c.Guid(),
                        ApplicationUser_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetGroups", t => t.HyperRoleGroupGuid_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ClusteredKey, clustered: true)
                .Index(t => new { t.RoleGroupId, t.UserId, t.HostId, t.IsGlobal }, name: "IX_Group_User_Host_Global")
                .Index(t => new { t.UserId, t.RoleGroupId, t.HostId, t.IsGlobal }, name: "IX_User_Group_Host_Global")
                .Index(t => t.HyperRoleGroupGuid_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ClusteredKey = c.Long(nullable: false, identity: true),
                        HostId = c.Guid(nullable: false),
                        IsGlobal = c.Boolean(nullable: false),
                        IsGlobalOnly = c.Boolean(nullable: false),
                        Sequence = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.ClusteredKey, clustered: true)
                .Index(t => new { t.HostId, t.Name }, unique: true, name: "IX_Host_Name")
                .Index(t => new { t.IsGlobal, t.Name }, name: "IX_Global_Name");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        RoleId = c.Guid(nullable: false),
                        HostId = c.Guid(nullable: false),
                        ClusteredKey = c.Long(nullable: false, identity: true),
                        RoleGroupId = c.Guid(),
                        IsGlobal = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId, t.HostId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => new { t.UserId, t.RoleId, t.HostId, t.IsGlobal }, unique: true, name: "IX_User_Role_Host_Global")
                .Index(t => new { t.RoleId, t.UserId, t.HostId, t.IsGlobal }, unique: true, name: "IX_Role_User_Host_Global")
                .Index(t => t.ClusteredKey, clustered: true);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        LastChangedBy = c.Guid(nullable: false),
                        LastChangedDate = c.DateTime(nullable: false),
                        FavoriteColor = c.String(),
                        ClusteredKey = c.Long(nullable: false, identity: true),
                        HostId = c.Guid(nullable: false),
                        IsGlobal = c.Boolean(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.ClusteredKey, clustered: true)
                .Index(t => new { t.HostId, t.UserName }, unique: true, name: "IX_User_Name")
                .Index(t => new { t.UserName, t.HostId, t.IsGlobal }, unique: true, name: "IX_Name_Host_Global")
                .Index(t => new { t.Email, t.HostId, t.IsGlobal }, unique: true, name: "IX_Email_Host_Global")
                .Index(t => new { t.IsGlobal, t.UserName }, name: "IX_Global_Name");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ClusteredKey = c.Long(nullable: false, identity: true),
                        HostId = c.Guid(nullable: false),
                        IsGlobal = c.Boolean(nullable: false),
                        UserId = c.Guid(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.ClusteredKey, clustered: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.Guid(nullable: false),
                        ClusteredKey = c.Long(nullable: false, identity: true),
                        HostId = c.Guid(nullable: false),
                        IsGlobal = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => new { t.LoginProvider, t.ProviderKey, t.HostId, t.IsGlobal }, unique: true, name: "IX_Provider_Key_Host_Global")
                .Index(t => t.UserId)
                .Index(t => t.ClusteredKey, clustered: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetGroupUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetGroupUsers", "HyperRoleGroupGuid_Id", "dbo.AspNetGroups");
            DropForeignKey("dbo.AspNetGroupRoles", "HyperRoleGroupGuid_Id", "dbo.AspNetGroups");
            DropForeignKey("dbo.InvoiceItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.InvoiceItems", "InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.AspNetHostDomains", "HostId", "dbo.AspNetHosts");
            DropForeignKey("dbo.AspNetAuditItems", "AuditPropertyId", "dbo.AspNetAuditProperties");
            DropForeignKey("dbo.AspNetAuditItems", "AuditId", "dbo.AspNetAudits");
            DropIndex("dbo.AspNetUserLogins", new[] { "ClusteredKey" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", "IX_Provider_Key_Host_Global");
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "ClusteredKey" });
            DropIndex("dbo.AspNetUsers", "IX_Global_Name");
            DropIndex("dbo.AspNetUsers", "IX_Email_Host_Global");
            DropIndex("dbo.AspNetUsers", "IX_Name_Host_Global");
            DropIndex("dbo.AspNetUsers", "IX_User_Name");
            DropIndex("dbo.AspNetUsers", new[] { "ClusteredKey" });
            DropIndex("dbo.AspNetUserRoles", new[] { "ClusteredKey" });
            DropIndex("dbo.AspNetUserRoles", "IX_Role_User_Host_Global");
            DropIndex("dbo.AspNetUserRoles", "IX_User_Role_Host_Global");
            DropIndex("dbo.AspNetRoles", "IX_Global_Name");
            DropIndex("dbo.AspNetRoles", "IX_Host_Name");
            DropIndex("dbo.AspNetRoles", new[] { "ClusteredKey" });
            DropIndex("dbo.AspNetGroupUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetGroupUsers", new[] { "HyperRoleGroupGuid_Id" });
            DropIndex("dbo.AspNetGroupUsers", "IX_User_Group_Host_Global");
            DropIndex("dbo.AspNetGroupUsers", "IX_Group_User_Host_Global");
            DropIndex("dbo.AspNetGroupUsers", new[] { "ClusteredKey" });
            DropIndex("dbo.AspNetGroups", "IX_Global_Name");
            DropIndex("dbo.AspNetGroups", "IX_Host_Name");
            DropIndex("dbo.AspNetGroups", new[] { "ClusteredKey" });
            DropIndex("dbo.AspNetGroupRoles", new[] { "HyperRoleGroupGuid_Id" });
            DropIndex("dbo.AspNetGroupRoles", "IX_Role_Group");
            DropIndex("dbo.AspNetGroupRoles", "IX_Group_Role");
            DropIndex("dbo.AspNetGroupRoles", new[] { "ClusteredKey" });
            DropIndex("dbo.InvoiceItems", new[] { "ProductId" });
            DropIndex("dbo.InvoiceItems", new[] { "InvoiceId" });
            DropIndex("dbo.AspNetHosts", new[] { "Name" });
            DropIndex("dbo.AspNetHosts", new[] { "ClusteredKey" });
            DropIndex("dbo.AspNetHostDomains", "IX_Host_Domain");
            DropIndex("dbo.AspNetHostDomains", "IX_Domain_Host");
            DropIndex("dbo.AspNetHostDomains", new[] { "ClusteredKey" });
            DropIndex("dbo.AspNetAuditProperties", "IX_Entity_Property");
            DropIndex("dbo.AspNetAuditProperties", new[] { "ClusteredKey" });
            DropIndex("dbo.AspNetAudits", "IX_Date");
            DropIndex("dbo.AspNetAudits", "IX_User_Date");
            DropIndex("dbo.AspNetAudits", "IX_Host_Date");
            DropIndex("dbo.AspNetAudits", new[] { "ClusteredKey" });
            DropIndex("dbo.AspNetAudits", "IX_Date_Id");
            DropIndex("dbo.AspNetAuditItems", "IX_Property");
            DropIndex("dbo.AspNetAuditItems", "IX_Entity2");
            DropIndex("dbo.AspNetAuditItems", "IX_Entity1");
            DropIndex("dbo.AspNetAuditItems", "IX_Audit");
            DropIndex("dbo.AspNetAuditItems", new[] { "ClusteredKey" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetGroupUsers");
            DropTable("dbo.AspNetGroups");
            DropTable("dbo.AspNetGroupRoles");
            DropTable("dbo.Products");
            DropTable("dbo.Invoices");
            DropTable("dbo.InvoiceItems");
            DropTable("dbo.AspNetHosts");
            DropTable("dbo.AspNetHostDomains");
            DropTable("dbo.AspNetAuditProperties");
            DropTable("dbo.AspNetAudits");
            DropTable("dbo.AspNetAuditItems");
        }
    }
}
