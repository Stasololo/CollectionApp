using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace CollectionApp.Models
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        #region Auto-completion of the fields Creation, LastUpdate, LastUpdateUser

        public async override Task<int> SaveChangesAsync(CancellationToken cancelationToken)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())    
            {
                db.Database.Log = Console.Write;

                var changeSetAccount = ChangeTracker.Entries<Account>();
                if (changeSetAccount != null)
                {
                    foreach (var account in changeSetAccount.Where(c => c.State != EntityState.Modified))
                    {
                        account.Entity.Creation = DateTime.UtcNow;
                    }
                    foreach (var entry in changeSetAccount.Where(c => c.State != EntityState.Unchanged))
                    {
                        entry.Entity.LastUpdate = DateTime.UtcNow;
                        entry.Entity.LastUpdateUser = HttpContext.Current.User.Identity.Name;
                    }
                }

                var changeSetCashCentre = ChangeTracker.Entries<CashCentre>();
                if (changeSetCashCentre != null)
                {
                    foreach (var cashCentre in changeSetCashCentre.Where(c => c.State != EntityState.Modified))
                    {
                        cashCentre.Entity.Creation = DateTime.UtcNow;
                    }
                    foreach (var entry in changeSetCashCentre.Where(c => c.State != EntityState.Unchanged))
                    {
                        entry.Entity.LastUpdate = DateTime.UtcNow;
                        entry.Entity.LastUpdateUser = HttpContext.Current.User.Identity.Name;
                    }
                }

                var changeSetCashPoint = ChangeTracker.Entries<CashPoint>();
                if (changeSetCashPoint != null)
                {
                    foreach (var cashPoint in changeSetCashPoint.Where(c => c.State != EntityState.Modified))
                    {
                        cashPoint.Entity.Creation = DateTime.UtcNow;
                    }
                    foreach (var entry in changeSetCashPoint.Where(c => c.State != EntityState.Unchanged))
                    {
                        entry.Entity.LastUpdate = DateTime.UtcNow;
                        entry.Entity.LastUpdateUser = HttpContext.Current.User.Identity.Name;
                    }
                }

                var changeSetCity = ChangeTracker.Entries<City>();
                if (changeSetCity != null)
                {
                    foreach (var qwe in changeSetCity.Where(c => c.State != EntityState.Modified))
                    {
                        qwe.Entity.Creation = DateTime.UtcNow;
                    }
                    foreach (var entry in changeSetCity.Where(c => c.State != EntityState.Unchanged))
                    {
                        entry.Entity.LastUpdate = DateTime.UtcNow;
                        entry.Entity.LastUpdateUser = HttpContext.Current.User.Identity.Name;
                    }
                }

                var changeSetClient = ChangeTracker.Entries<Client>();
                if (changeSetClient != null)
                {
                    foreach (var client in changeSetClient.Where(c => c.State != EntityState.Modified))
                    {
                        client.Entity.Creation = DateTime.UtcNow;
                    }
                    foreach (var entry in changeSetClient.Where(c => c.State != EntityState.Unchanged))
                    {
                        entry.Entity.LastUpdate = DateTime.UtcNow;
                        entry.Entity.LastUpdateUser = HttpContext.Current.User.Identity.Name;
                    }
                }

                var changeSetClientTocc = ChangeTracker.Entries<ClientTocc>();
                if (changeSetClientTocc != null)
                {
                    foreach (var clientTocc in changeSetClientTocc.Where(c => c.State != EntityState.Modified))
                    {
                        clientTocc.Entity.Creation = DateTime.UtcNow;
                    }
                    foreach (var entry in changeSetClientTocc.Where(c => c.State != EntityState.Unchanged))
                    {
                        entry.Entity.LastUpdate = DateTime.UtcNow;
                        entry.Entity.LastUpdateUser = HttpContext.Current.User.Identity.Name;
                    }
                }

                var changeSetClisubfml = ChangeTracker.Entries<Clisubfml>();
                if (changeSetClisubfml != null)
                {
                    foreach (var clisubfml in changeSetClisubfml.Where(c => c.State != EntityState.Modified))
                    {
                        clisubfml.Entity.Creation = DateTime.UtcNow;
                    }
                    foreach (var entry in changeSetClisubfml.Where(c => c.State != EntityState.Unchanged))
                    {
                        entry.Entity.LastUpdate = DateTime.UtcNow;
                        entry.Entity.LastUpdateUser = HttpContext.Current.User.Identity.Name;
                    }
                }

                var changeSetCurrency = ChangeTracker.Entries<Currency>();
                if (changeSetCurrency != null)
                {
                    foreach (var currency in changeSetCurrency.Where(c => c.State != EntityState.Modified))
                    {
                        currency.Entity.Creation = DateTime.UtcNow;
                    }
                    foreach (var entry in changeSetCurrency.Where(c => c.State != EntityState.Unchanged))
                    {
                        entry.Entity.LastUpdate = DateTime.UtcNow;
                        entry.Entity.LastUpdateUser = HttpContext.Current.User.Identity.Name;
                    }
                }

                var changeSetDenomination = ChangeTracker.Entries<Denomination>();
                if (changeSetDenomination != null)
                {
                    foreach (var denomination in changeSetDenomination.Where(c => c.State != EntityState.Modified))
                    {
                        denomination.Entity.Creation = DateTime.UtcNow;
                    }
                    foreach (var entry in changeSetDenomination.Where(c => c.State != EntityState.Unchanged))
                    {
                        entry.Entity.LastUpdate = DateTime.UtcNow;
                        entry.Entity.LastUpdateUser = HttpContext.Current.User.Identity.Name;
                    }
                }

                var changeSetTest = ChangeTracker.Entries<Test>();
                if (changeSetTest != null)
                {
                    foreach (var qwe in changeSetTest.Where(c => c.State != EntityState.Modified))
                    {
                        qwe.Entity.Date = DateTime.UtcNow;
                    }
                    foreach (var entry in changeSetTest.Where(c => c.State != EntityState.Unchanged))
                    {
                        entry.Entity.Date = DateTime.UtcNow;
                    }
                }


                return await base.SaveChangesAsync(cancelationToken);
            }
        }

        #endregion

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        #region Access to tables

        public DbSet<Account> Accounts { get; set; }
        public DbSet<CashCentre> CashCentres { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Clisubfml> Clisubfmls { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Denomination> Denominations { get; set; }
        public DbSet<CashPoint> CashPoints { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<ClientTocc> ClientTocc { get; set; }
        public DbSet<CountingConfig> CountingConfigs { get; set; }
        public DbSet<Rules> Rules { get; set; }
        public DbSet<Test> Tests { get; set; }

        #endregion
    }
}