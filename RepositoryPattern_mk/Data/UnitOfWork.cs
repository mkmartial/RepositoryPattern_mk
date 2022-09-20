﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RepositoryPattern_mk.Core.IConfiguration;
using RepositoryPattern_mk.Core.IRepositories;
using RepositoryPattern_mk.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace RepositoryPattern_mk.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;
        public IUserRepository Users { get; private set; }

       

        public UnitOfWork(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger=loggerFactory.CreateLogger("logs");
            Users = new UserRepository(context, _logger);
        }




        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

       
    }
}
