using BlogPostManager.Server.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace BlogPostManager.Server.BlogDBContexts;

public class BlogDBContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Blog> Blogs { get; set; }

    public string DbPath { get; }

    public BlogDBContext()
    {
        var path = AppContext.BaseDirectory;
        DbPath = System.IO.Path.Join(path, "blogging.db");


    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlite($"Data Source={DbPath}");

}