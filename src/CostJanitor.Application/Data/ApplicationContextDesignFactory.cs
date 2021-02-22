﻿using CloudEngineering.CodeOps.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CostJanitor.Application.Data
{
    public sealed class ApplicationContextDesignFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            const string connStr = "User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=postgres";
            var connection = new Npgsql.NpgsqlConnection(connStr); 

            connection.Open();

            var optionsBuilder = new DbContextOptionsBuilder<EntityContext>()
                .UseSqlite(connection);

            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}