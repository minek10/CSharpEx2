using DemoApp.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Data.Context
{
    public class DemoAppDBContext : DbContext
    {
        public DemoAppDBContext(DbContextOptions<DemoAppDBContext> options) : base(options)
        {

        }

        #region DBSET
        public DbSet<User> Users { get; set; }
        #endregion


        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var AddedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Added).ToList();

            AddedEntities.ForEach(E =>
            {
                E.Property("CreationDate").CurrentValue = DateTime.Now;
            });

            var EditedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Modified).ToList();


            EditedEntities.ForEach(E =>
            {
                /*Attention SofDelete*/
                if (E.Property("DeleteTrackingUserId").CurrentValue?.ToString() != "00000000-0000-0000-0000-000000000000")
                {
                    E.Property("DeleteDate").CurrentValue = DateTime.Now;
                }
                else
                {
                    E.Property("UpdateDate").CurrentValue = DateTime.Now;
                }
            });

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
