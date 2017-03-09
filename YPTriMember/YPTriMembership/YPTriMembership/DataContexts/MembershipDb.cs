using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using YPTriMembership.Models;

namespace YPTriMembership.DataContexts
{
    public class MembershipDb : IdentityDbContext<ApplicationUser>
    {
        public MembershipDb()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }


        public static MembershipDb Create()
        {
            return new MembershipDb();
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<Dues_Weak> MemberDues { get; set; }
        public DbSet<EventVolunteer> EventVolunteers { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<SponsorGift> SponsorGifts { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<VendorDiscount> VendorDiscounts { get; set; }
       
    }
}