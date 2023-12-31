﻿namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class demo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DoctorFees = c.Double(nullable: false),
                        AppId = c.Int(nullable: false),
                        DcMail = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Appointments", t => t.AppId, cascadeDelete: true)
                .ForeignKey("dbo.Doctors", t => t.DcMail, cascadeDelete: true)
                .Index(t => t.AppId)
                .Index(t => t.DcMail);
            
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Dr_Name = c.String(nullable: false, maxLength: 15),
                        Specialist = c.String(nullable: false, maxLength: 10),
                        Fee = c.String(nullable: false, maxLength: 10),
                        DateTime = c.DateTime(nullable: false),
                        Chember_Address = c.String(nullable: false, maxLength: 15),
                        Status = c.String(maxLength: 10),
                        MngMail = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Managers", t => t.MngMail, cascadeDelete: true)
                .Index(t => t.MngMail);
            
            CreateTable(
                "dbo.Fees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Paid = c.Double(nullable: false),
                        PaymentDate = c.DateTime(nullable: false),
                        PId = c.Int(nullable: false),
                        AId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Appointments", t => t.AId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PId, cascadeDelete: true)
                .Index(t => t.PId)
                .Index(t => t.AId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 15),
                        Name = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                        Age = c.String(nullable: false, maxLength: 10),
                        Gender = c.String(nullable: false, maxLength: 10),
                        BloodGroup = c.String(nullable: false, maxLength: 10),
                        PhoneNumber = c.String(nullable: false, maxLength: 20),
                        Address = c.String(nullable: false, maxLength: 20),
                        Balance = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Gender = c.String(nullable: false, maxLength: 10),
                        Address = c.String(nullable: false, maxLength: 10),
                        Phonenumber = c.String(nullable: false, maxLength: 11),
                    })
                .PrimaryKey(t => t.Email);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 15),
                        Uname = c.String(nullable: false, maxLength: 20),
                        Name = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 6),
                        Age = c.String(nullable: false, maxLength: 10),
                        Gender = c.String(nullable: false, maxLength: 10),
                        BloodGroup = c.String(nullable: false, maxLength: 10),
                        Address = c.String(nullable: false, maxLength: 10),
                        Phonenumber = c.String(nullable: false, maxLength: 11),
                    })
                .PrimaryKey(t => t.Email);
            
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TKey = c.String(nullable: false, maxLength: 100),
                        CreatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                        MngMail = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Managers", t => t.MngMail, cascadeDelete: true)
                .Index(t => t.MngMail);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tokens", "MngMail", "dbo.Managers");
            DropForeignKey("dbo.AppDetails", "DcMail", "dbo.Doctors");
            DropForeignKey("dbo.AppDetails", "AppId", "dbo.Appointments");
            DropForeignKey("dbo.Appointments", "MngMail", "dbo.Managers");
            DropForeignKey("dbo.Fees", "PId", "dbo.Patients");
            DropForeignKey("dbo.Fees", "AId", "dbo.Appointments");
            DropIndex("dbo.Tokens", new[] { "MngMail" });
            DropIndex("dbo.Fees", new[] { "AId" });
            DropIndex("dbo.Fees", new[] { "PId" });
            DropIndex("dbo.Appointments", new[] { "MngMail" });
            DropIndex("dbo.AppDetails", new[] { "DcMail" });
            DropIndex("dbo.AppDetails", new[] { "AppId" });
            DropTable("dbo.Tokens");
            DropTable("dbo.Doctors");
            DropTable("dbo.Managers");
            DropTable("dbo.Patients");
            DropTable("dbo.Fees");
            DropTable("dbo.Appointments");
            DropTable("dbo.AppDetails");
        }
    }
}
