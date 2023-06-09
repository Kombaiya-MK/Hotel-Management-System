﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace UserAPI.Models
{
    public class JWTContext : DbContext
    {

        public JWTContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }

    }
}
