using Microsoft.EntityFrameworkCore;
using PresenileNotes.Entity.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresenileNotes.Entity
{
    public partial class ModelContext : DbContext
    {
        public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
        { }
        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Workspace> Workspaces { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;;Database=Notes;Trusted_Connection=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            modelBuilder.Entity<Workspace>()
              .HasOne<User>(u => u.User)
              .WithMany(c => c.Workspaces)
              .HasForeignKey(f => f.UserId);
            //------------------------------
            modelBuilder.Entity<Category>()
                .HasOne<Workspace>(z => z.Workspace)
                .WithMany(x => x.Categories)
                .HasForeignKey(s => s.WorkspaceId);
            modelBuilder.Entity<Category>()
                .HasOne<User>(u => u.User)
                .WithMany(c => c.Categories)
                .HasForeignKey(f => f.UserId);
            //------------------------------
            modelBuilder.Entity<Note>()
                .HasOne<User>(u => u.User)
                .WithMany(c => c.Notes)
                .HasForeignKey(f => f.UserId);
            modelBuilder.Entity<Note>()
                .HasOne<Category>(u => u.Category)
                .WithMany(c => c.Notes)
                .HasForeignKey(f => f.CategoryId);
            //------------------------------


        }
    }
    
}
