using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace ConceptBiotech.Data
{
    public class ConceptBiotech : DbContext
    {
        public ConceptBiotech() : 
            base("name=ConceptBiotech")
        {
            Database.SetInitializer<ConceptBiotech>(new CreateDatabaseIfNotExists<ConceptBiotech>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //throw new UnintentionalCodeFirstException();
            // modelBuilder.Entity<IncomingCallSetting>().ToTable("EmailCampaigns");

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<CategorysMaster> CategoryMasters { get; set; }
        public DbSet<SubCategorysMaster> SubCategoryMasters { get; set; }
        public DbSet<ShopMaster> ShopMasters { get; set; }
        public DbSet<ProductMaster> ProductMasters { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
