﻿using HuzlabBlog.Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HuzlabBlog.Data.Context
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid, AppUserClaim, AppUserRole, AppUserLogin, AppRoleClaim, AppUserToken>
    {
        protected AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Article> Articles {  get; set; }
        public DbSet<Category> Categories {  get; set; }
        public DbSet<Setting> Settings {  get; set; }
        public DbSet<Image> Images {  get; set; }
        public DbSet<Visitor> Visitors {  get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<ArticleVisitor> ArticleVisitors {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
