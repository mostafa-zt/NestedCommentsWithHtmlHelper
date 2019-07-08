using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using NestedCommentsWithExtensionHtmlHelper.Model;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace NestedCommentsWithExtensionHtmlHelper.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("DefaultConnection")
        {
        }

        #region Override OnModelCreating
        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
                throw new ArgumentNullException();

            System.Data.Entity.Database.SetInitializer(new System.Data.Entity.CreateDatabaseIfNotExists<AppDbContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppDbContext, MigrateDBConfiguration>());

            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Comment>().ToTable("Comments");
            //modelBuilder.Entity<Comment>().HasOptional(x => x.Question).WithMany(x => x.Responses).HasForeignKey(x => x.QuestionId).WillCascadeOnDelete(true);

        }
        #endregion

        public virtual DbSet<Comment> Comments { get; set; }
    }

    public class MigrateDBConfiguration : System.Data.Entity.Migrations.DbMigrationsConfiguration<AppDbContext>
    {
        public MigrateDBConfiguration()
        {
            //base.AutomaticMigrationDataLossAllowed = true;
            base.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AppDbContext context)
        {
            if (context.Comments.AsNoTracking().Count() <= 0)
            {
                List<Comment> comments_Arman = new List<Comment>()
            {
                new Comment() { Alias = "سینا", CreatorDateTime = System.DateTime.Now, Email = "test@test.com", Text = "این پست عالیه"   },
                new Comment() { Alias = "سهیل" , CreatorDateTime = System.DateTime.Now , Email ="test@test.com" , Text = "این پست واقعا عالیه"},
                new Comment() { Alias = "فرزین", CreatorDateTime = System.DateTime.Now, Email = "test@test.com", Text = "این پست عالیه"  },
                new Comment() { Alias = "امید" , CreatorDateTime = System.DateTime.Now , Email ="test@test.com" , Text = "این پست واقعا عالیه"}
            };

                List<Comment> comments_azadeh = new List<Comment>()
            {
                new Comment() { Alias = "آرمان", CreatorDateTime = System.DateTime.Now, Email = "test@test.com", Text = "این پست عالیه"  , Responses = comments_Arman},
                new Comment() { Alias = "آرام" , CreatorDateTime = System.DateTime.Now , Email ="test@test.com" , Text = "این پست واقعا عالیه"}
            };

                List<Comment> comments = new List<Comment>()
            {
                new Comment() { Alias = "امید" , CreatorDateTime = System.DateTime.Now , Email ="test@test.com" , Text = "این پست جالبه" },
                new Comment() { Alias = "آزاده" , CreatorDateTime = System.DateTime.Now , Email ="test@test.com" , Text = "این پست خوبه" , Responses = comments_azadeh }
            };

                context.Comments.AddRange(comments);
                context.SaveChanges();
            }

        }
    }
}