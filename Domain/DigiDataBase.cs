using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.Models;

namespace Domain
{
    public class DigiDataBase : DbContext
    {
        public DigiDataBase()
        {

        }
        //static DigiDataBase()
        //{
        //    Database.SetInitializer(new MigrateDatabaseToLatestVersion<DigiDataBase, Configuration>());
        //}

        public DbSet<Accessory> Accessories { get; set; }
        public DbSet<AssembledCase> AssembledCases { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Commodity> Commodities { get; set; }
        public DbSet<ComputersAndAccessory> ComputersAndAccessories { get; set; }
        public DbSet<ExternalHard> ExternalHards { get; set; }
        public DbSet<Keyboard> Keyboards { get; set; }
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<Mobile> Mobiles { get; set; }
        public DbSet<MobileCover> MobileCovers { get; set; }
        public DbSet<MobileHolder> MobileHolders { get; set; }
        public DbSet<Monitor> Monitors { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<PostedComment> PostedComments { get; set; }
        public DbSet<PowerBank> PowerBanks { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Setting> Settings { get; set; }

        private void Initialize()
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
            Configuration.ValidateOnSaveEnabled = true;
            Configuration.AutoDetectChangesEnabled = true;

            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<DigiDataBase, Configuration>());
        }

        //public static void ExecuteMigration()
        //{
        //    try
        //    {
        //        var dbContext = new DigiDataBase();
        //        dbContext.Database.Initialize(true);
        //    }
        //    catch (Exception exception)
        //    {
        //        throw new Exception(exception.Message);
        //    }
        //}

        public System.Data.Entity.DbSet<Domain.Models.AttachmentFile> AttachmentFiles { get; set; }
    }
}
