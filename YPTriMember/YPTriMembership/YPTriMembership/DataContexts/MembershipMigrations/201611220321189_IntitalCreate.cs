namespace YPTriMembership.DataContexts.MembershipMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntitalCreate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Dues", "MemberId", "dbo.Members");
            DropIndex("dbo.Dues", new[] { "MemberId" });
            DropPrimaryKey("dbo.Members");
            CreateTable(
                "dbo.Dues_Weak",
                c => new
                    {
                        Dues_id = c.Int(nullable: false),
                        Member_id = c.Int(nullable: false),
                        Date_Of_Payment = c.DateTime(nullable: false),
                        Amount_Paid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Membership_Exp = c.DateTime(nullable: false),
                        Member_Member_id = c.Int(),
                        Member_Dues_Member_id = c.Int(),
                    })
                .PrimaryKey(t => new { t.Dues_id, t.Member_id })
                .ForeignKey("dbo.Members", t => t.Member_Member_id)
                .ForeignKey("dbo.Members", t => t.Member_id, cascadeDelete: false)
                .ForeignKey("dbo.Members", t => t.Member_Dues_Member_id)
                .Index(t => t.Member_id)
                .Index(t => t.Member_Member_id)
                .Index(t => t.Member_Dues_Member_id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Member_Number = c.Int(nullable: false),
                        Sponsor_Number = c.Int(nullable: false),
                        Vendor_Number = c.Int(nullable: false),
                        Event_id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Street_Number = c.String(nullable: false),
                        Street_Address = c.String(nullable: false, maxLength: 20),
                        State_Abr = c.String(nullable: false),
                        Zip_Code = c.String(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        Description = c.String(nullable: false, maxLength: 300),
                        Vendor_Vendor_id = c.Int(),
                        Host_Vendor_id = c.Int(),
                        MemberOrganizer_Member_id = c.Int(),
                        Sponsor_Sponsor_id = c.Int(),
                        SponsorOrganizer_Sponsor_id = c.Int(),
                        Member_Member_id = c.Int(),
                    })
                .PrimaryKey(t => t.Event_id)
                .ForeignKey("dbo.Vendors", t => t.Vendor_Vendor_id)
                .ForeignKey("dbo.Vendors", t => t.Host_Vendor_id)
                .ForeignKey("dbo.Members", t => t.Member_Number, cascadeDelete: false)
                .ForeignKey("dbo.Members", t => t.MemberOrganizer_Member_id)
                .ForeignKey("dbo.Sponsors", t => t.Sponsor_Sponsor_id)
                .ForeignKey("dbo.Sponsors", t => t.Sponsor_Number, cascadeDelete: false)
                .ForeignKey("dbo.Sponsors", t => t.SponsorOrganizer_Sponsor_id)
                .ForeignKey("dbo.Vendors", t => t.Vendor_Number, cascadeDelete: false)
                .ForeignKey("dbo.Members", t => t.Member_Member_id)
                .Index(t => t.Member_Number)
                .Index(t => t.Sponsor_Number)
                .Index(t => t.Vendor_Number)
                .Index(t => t.Vendor_Vendor_id)
                .Index(t => t.Host_Vendor_id)
                .Index(t => t.MemberOrganizer_Member_id)
                .Index(t => t.Sponsor_Sponsor_id)
                .Index(t => t.SponsorOrganizer_Sponsor_id)
                .Index(t => t.Member_Member_id);
            
            CreateTable(
                "dbo.VendorDiscounts",
                c => new
                    {
                        VendorId = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 500),
                        Value = c.String(nullable: false),
                        Event_Event_id = c.Int(),
                        Vendor_Vendor_id = c.Int(),
                        Event_Event_id1 = c.Int(),
                    })
                .PrimaryKey(t => new { t.VendorId, t.EventId })
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: false)
                .ForeignKey("dbo.Vendors", t => t.VendorId, cascadeDelete: false)
                .ForeignKey("dbo.Events", t => t.Event_Event_id)
                .ForeignKey("dbo.Vendors", t => t.Vendor_Vendor_id)
                .ForeignKey("dbo.Events", t => t.Event_Event_id1)
                .Index(t => t.VendorId)
                .Index(t => t.EventId)
                .Index(t => t.Event_Event_id)
                .Index(t => t.Vendor_Vendor_id)
                .Index(t => t.Event_Event_id1);
            
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        Vendor_id = c.Int(nullable: false, identity: true),
                        Company_Name = c.String(nullable: false, maxLength: 5),
                        Phone = c.String(nullable: false, maxLength: 14),
                        Street_Number = c.Int(nullable: false),
                        Street_Address = c.String(nullable: false, maxLength: 50),
                        State_Abr = c.String(nullable: false, maxLength: 2),
                        Zip_Code = c.String(nullable: false, maxLength: 10),
                        Email = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Vendor_id);
            
            CreateTable(
                "dbo.EventVolunteers",
                c => new
                    {
                        MemberId = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                        Hours = c.Time(nullable: false, precision: 7),
                        VolunteerEvent_Event_id = c.Int(),
                        VolunteerMember_Member_id = c.Int(),
                        Event_Event_id = c.Int(),
                        Member_Member_id = c.Int(),
                    })
                .PrimaryKey(t => new { t.MemberId, t.EventId })
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: false)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: false)
                .ForeignKey("dbo.Events", t => t.VolunteerEvent_Event_id)
                .ForeignKey("dbo.Members", t => t.VolunteerMember_Member_id)
                .ForeignKey("dbo.Events", t => t.Event_Event_id)
                .ForeignKey("dbo.Members", t => t.Member_Member_id)
                .Index(t => t.MemberId)
                .Index(t => t.EventId)
                .Index(t => t.VolunteerEvent_Event_id)
                .Index(t => t.VolunteerMember_Member_id)
                .Index(t => t.Event_Event_id)
                .Index(t => t.Member_Member_id);
            
            CreateTable(
                "dbo.Sponsors",
                c => new
                    {
                        Sponsor_id = c.Int(nullable: false, identity: true),
                        Company_Name = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 14),
                        Street_Number = c.Int(nullable: false),
                        Street_Address = c.String(nullable: false, maxLength: 50),
                        State_Abr = c.String(nullable: false, maxLength: 2),
                        Zip_Code = c.String(nullable: false, maxLength: 10),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Sponsor_id);
            
            CreateTable(
                "dbo.SponsorGifts",
                c => new
                    {
                        Eventid = c.Int(nullable: false),
                        Sponsorid = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 50),
                        Gift_Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GiftEvent_Event_id = c.Int(),
                        GiftSponsor_Sponsor_id = c.Int(),
                        Sponsor_Sponsor_id = c.Int(),
                    })
                .PrimaryKey(t => new { t.Eventid, t.Sponsorid })
                .ForeignKey("dbo.Events", t => t.Eventid, cascadeDelete: false)
                .ForeignKey("dbo.Events", t => t.GiftEvent_Event_id)
                .ForeignKey("dbo.Sponsors", t => t.GiftSponsor_Sponsor_id)
                .ForeignKey("dbo.Sponsors", t => t.Sponsorid, cascadeDelete: false)
                .ForeignKey("dbo.Sponsors", t => t.Sponsor_Sponsor_id)
                .Index(t => t.Eventid)
                .Index(t => t.Sponsorid)
                .Index(t => t.GiftEvent_Event_id)
                .Index(t => t.GiftSponsor_Sponsor_id)
                .Index(t => t.Sponsor_Sponsor_id);
            
            AddColumn("dbo.Hobbies", "Member_Member_id", c => c.Int());
            AddColumn("dbo.Members", "Member_id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Members", "First_Name", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Members", "Last_Name", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Members", "Street_Number", c => c.String(nullable: false));
            AddColumn("dbo.Members", "Street_Address", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Members", "Zip_Code", c => c.String(nullable: false, maxLength: 10));
            AddColumn("dbo.Members", "Phone", c => c.String(maxLength: 14));
            AddColumn("dbo.Members", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Members", "gender", c => c.String(nullable: false, maxLength: 1));
            AddColumn("dbo.Members", "DoB", c => c.DateTime(nullable: false));
            AddColumn("dbo.Members", "Occupation", c => c.String(maxLength: 500));
            AddColumn("dbo.Members", "Employer", c => c.String(maxLength: 50));
            AddColumn("dbo.Skills", "Member_Member_id", c => c.Int());
            AddPrimaryKey("dbo.Members", "Member_id");
            CreateIndex("dbo.Hobbies", "Member_Member_id");
            CreateIndex("dbo.Skills", "Member_Member_id");
            AddForeignKey("dbo.Hobbies", "Member_Member_id", "dbo.Members", "Member_id");
            AddForeignKey("dbo.Skills", "Member_Member_id", "dbo.Members", "Member_id");
            DropColumn("dbo.Members", "MemberId");
            DropColumn("dbo.Members", "FirstName");
            DropColumn("dbo.Members", "MiddleName");
            DropColumn("dbo.Members", "LastName");
            DropTable("dbo.Dues");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Dues",
                c => new
                    {
                        DuesId = c.String(nullable: false, maxLength: 128),
                        MemberId = c.String(nullable: false, maxLength: 128),
                        DatePaid = c.String(nullable: false),
                        AmountPaid = c.Double(nullable: false),
                        MembershipExpiration = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.DuesId, t.MemberId });
            
            AddColumn("dbo.Members", "LastName", c => c.String());
            AddColumn("dbo.Members", "MiddleName", c => c.String());
            AddColumn("dbo.Members", "FirstName", c => c.String());
            AddColumn("dbo.Members", "MemberId", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.Dues_Weak", "Member_Dues_Member_id", "dbo.Members");
            DropForeignKey("dbo.Dues_Weak", "Member_id", "dbo.Members");
            DropForeignKey("dbo.EventVolunteers", "Member_Member_id", "dbo.Members");
            DropForeignKey("dbo.Skills", "Member_Member_id", "dbo.Members");
            DropForeignKey("dbo.Hobbies", "Member_Member_id", "dbo.Members");
            DropForeignKey("dbo.Dues_Weak", "Member_Member_id", "dbo.Members");
            DropForeignKey("dbo.Events", "Member_Member_id", "dbo.Members");
            DropForeignKey("dbo.Events", "Vendor_Number", "dbo.Vendors");
            DropForeignKey("dbo.Events", "SponsorOrganizer_Sponsor_id", "dbo.Sponsors");
            DropForeignKey("dbo.Events", "Sponsor_Number", "dbo.Sponsors");
            DropForeignKey("dbo.SponsorGifts", "Sponsor_Sponsor_id", "dbo.Sponsors");
            DropForeignKey("dbo.SponsorGifts", "Sponsorid", "dbo.Sponsors");
            DropForeignKey("dbo.SponsorGifts", "GiftSponsor_Sponsor_id", "dbo.Sponsors");
            DropForeignKey("dbo.SponsorGifts", "GiftEvent_Event_id", "dbo.Events");
            DropForeignKey("dbo.SponsorGifts", "Eventid", "dbo.Events");
            DropForeignKey("dbo.Events", "Sponsor_Sponsor_id", "dbo.Sponsors");
            DropForeignKey("dbo.Events", "MemberOrganizer_Member_id", "dbo.Members");
            DropForeignKey("dbo.Events", "Member_Number", "dbo.Members");
            DropForeignKey("dbo.Events", "Host_Vendor_id", "dbo.Vendors");
            DropForeignKey("dbo.EventVolunteers", "Event_Event_id", "dbo.Events");
            DropForeignKey("dbo.EventVolunteers", "VolunteerMember_Member_id", "dbo.Members");
            DropForeignKey("dbo.EventVolunteers", "VolunteerEvent_Event_id", "dbo.Events");
            DropForeignKey("dbo.EventVolunteers", "MemberId", "dbo.Members");
            DropForeignKey("dbo.EventVolunteers", "EventId", "dbo.Events");
            DropForeignKey("dbo.VendorDiscounts", "Event_Event_id1", "dbo.Events");
            DropForeignKey("dbo.VendorDiscounts", "Vendor_Vendor_id", "dbo.Vendors");
            DropForeignKey("dbo.VendorDiscounts", "Event_Event_id", "dbo.Events");
            DropForeignKey("dbo.VendorDiscounts", "VendorId", "dbo.Vendors");
            DropForeignKey("dbo.Events", "Vendor_Vendor_id", "dbo.Vendors");
            DropForeignKey("dbo.VendorDiscounts", "EventId", "dbo.Events");
            DropIndex("dbo.Skills", new[] { "Member_Member_id" });
            DropIndex("dbo.SponsorGifts", new[] { "Sponsor_Sponsor_id" });
            DropIndex("dbo.SponsorGifts", new[] { "GiftSponsor_Sponsor_id" });
            DropIndex("dbo.SponsorGifts", new[] { "GiftEvent_Event_id" });
            DropIndex("dbo.SponsorGifts", new[] { "Sponsorid" });
            DropIndex("dbo.SponsorGifts", new[] { "Eventid" });
            DropIndex("dbo.EventVolunteers", new[] { "Member_Member_id" });
            DropIndex("dbo.EventVolunteers", new[] { "Event_Event_id" });
            DropIndex("dbo.EventVolunteers", new[] { "VolunteerMember_Member_id" });
            DropIndex("dbo.EventVolunteers", new[] { "VolunteerEvent_Event_id" });
            DropIndex("dbo.EventVolunteers", new[] { "EventId" });
            DropIndex("dbo.EventVolunteers", new[] { "MemberId" });
            DropIndex("dbo.VendorDiscounts", new[] { "Event_Event_id1" });
            DropIndex("dbo.VendorDiscounts", new[] { "Vendor_Vendor_id" });
            DropIndex("dbo.VendorDiscounts", new[] { "Event_Event_id" });
            DropIndex("dbo.VendorDiscounts", new[] { "EventId" });
            DropIndex("dbo.VendorDiscounts", new[] { "VendorId" });
            DropIndex("dbo.Events", new[] { "Member_Member_id" });
            DropIndex("dbo.Events", new[] { "SponsorOrganizer_Sponsor_id" });
            DropIndex("dbo.Events", new[] { "Sponsor_Sponsor_id" });
            DropIndex("dbo.Events", new[] { "MemberOrganizer_Member_id" });
            DropIndex("dbo.Events", new[] { "Host_Vendor_id" });
            DropIndex("dbo.Events", new[] { "Vendor_Vendor_id" });
            DropIndex("dbo.Events", new[] { "Vendor_Number" });
            DropIndex("dbo.Events", new[] { "Sponsor_Number" });
            DropIndex("dbo.Events", new[] { "Member_Number" });
            DropIndex("dbo.Dues_Weak", new[] { "Member_Dues_Member_id" });
            DropIndex("dbo.Dues_Weak", new[] { "Member_Member_id" });
            DropIndex("dbo.Dues_Weak", new[] { "Member_id" });
            DropIndex("dbo.Hobbies", new[] { "Member_Member_id" });
            DropPrimaryKey("dbo.Members");
            DropColumn("dbo.Skills", "Member_Member_id");
            DropColumn("dbo.Members", "Employer");
            DropColumn("dbo.Members", "Occupation");
            DropColumn("dbo.Members", "DoB");
            DropColumn("dbo.Members", "gender");
            DropColumn("dbo.Members", "Email");
            DropColumn("dbo.Members", "Phone");
            DropColumn("dbo.Members", "Zip_Code");
            DropColumn("dbo.Members", "Street_Address");
            DropColumn("dbo.Members", "Street_Number");
            DropColumn("dbo.Members", "Last_Name");
            DropColumn("dbo.Members", "First_Name");
            DropColumn("dbo.Members", "Member_id");
            DropColumn("dbo.Hobbies", "Member_Member_id");
            DropTable("dbo.SponsorGifts");
            DropTable("dbo.Sponsors");
            DropTable("dbo.EventVolunteers");
            DropTable("dbo.Vendors");
            DropTable("dbo.VendorDiscounts");
            DropTable("dbo.Events");
            DropTable("dbo.Dues_Weak");
            AddPrimaryKey("dbo.Members", "MemberId");
            CreateIndex("dbo.Dues", "MemberId");
            AddForeignKey("dbo.Dues", "MemberId", "dbo.Members", "MemberId", cascadeDelete: false);
        }
    }
}
