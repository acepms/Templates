﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a CodeSmith Template.
//
//     DO NOT MODIFY contents of this file. Changes to this
//     file will be lost if the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Tracker.Core
{
    public partial class TrackerContext
        : System.Data.Entity.DbContext
    {
        static TrackerContext()
        {
            System.Data.Entity.Database.SetInitializer<TrackerContext>(null);
        }

        public System.Data.Entity.DbSet<Tracker.Core.Entities.Audit> Audit { get; set; }
        public System.Data.Entity.DbSet<Tracker.Core.Entities.Task> Task { get; set; }
        public System.Data.Entity.DbSet<Tracker.Core.Entities.User> User { get; set; }
        public System.Data.Entity.DbSet<Tracker.Core.Entities.Priority> Priority { get; set; }
        public System.Data.Entity.DbSet<Tracker.Core.Entities.Role> Role { get; set; }
        public System.Data.Entity.DbSet<Tracker.Core.Entities.Status> Status { get; set; }
        public System.Data.Entity.DbSet<Tracker.Core.Entities.TaskExtended> TaskExtended { get; set; }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<System.Data.Entity.Infrastructure.IncludeMetadataConvention>();
            modelBuilder.Configurations.Add(new Tracker.Core.Mapping.AuditMap());
            modelBuilder.Configurations.Add(new Tracker.Core.Mapping.TaskMap());
            modelBuilder.Configurations.Add(new Tracker.Core.Mapping.UserMap());
            modelBuilder.Configurations.Add(new Tracker.Core.Mapping.PriorityMap());
            modelBuilder.Configurations.Add(new Tracker.Core.Mapping.RoleMap());
            modelBuilder.Configurations.Add(new Tracker.Core.Mapping.StatusMap());
            modelBuilder.Configurations.Add(new Tracker.Core.Mapping.TaskExtendedMap());

            InitializeMapping(modelBuilder);
        }
    }
}