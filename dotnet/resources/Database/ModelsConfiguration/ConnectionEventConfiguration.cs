﻿using Database.Models.AccountEvents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.ModelsConfiguration
{
    public class ConnectionEventConfiguration : IEntityTypeConfiguration<ConnectionEvent>
    {
        public void Configure(EntityTypeBuilder<ConnectionEvent> builder)
        {
            builder.HasKey(c => c.Id);
        }
    }
}