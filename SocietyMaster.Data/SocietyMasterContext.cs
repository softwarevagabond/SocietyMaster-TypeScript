using Core.Common.Contracts;
using SocietyMaster.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietyMaster.Data
{
    public class SocietyMasterContext : DbContext
    {
        public SocietyMasterContext()
            : base("name=SocietyMaster2")
        {
            Database.SetInitializer<SocietyMasterContext>(null);
            Configuration.LazyLoadingEnabled = true;
        }

        public virtual DbSet<Building> BuildingSet { get; set; }
        public virtual DbSet<House> HouseSet { get; set; }
        public virtual DbSet<Society> SocietySet { get; set; }
       
        public virtual DbSet<Resident> ResidentSet { get; set; }
       
        public virtual DbSet<ResidentSocietyMapping> ResidentSocietyMappingSet { get; set; }
        public virtual DbSet<ResidentSocietyRoleMapping> ResidentSocietyRoleMappingSet { get; set; }
        public virtual DbSet<Role> RoleSet { get; set; }
        public virtual DbSet<SocietyRolePrivilege> SocietyRolePrivilegeSet { get; set; }
       
        public virtual DbSet<Audit> AuditSet { get; set; }     
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();          
            modelBuilder.Ignore<IIdentifiableEntity>();
            modelBuilder.Ignore<IObjectWithState>();
            // Had to explicitly ignore the EntityId also as below..
            //Specify the Primary Key as well in the below
            //Society Schemas
            modelBuilder.Entity<Building>().ToTable("Building", "Society").HasKey<Guid>(e => e.Id).Ignore(e => e.EntityId).Ignore(e=>e.ObjectState);
            modelBuilder.Entity<House>().ToTable("House", "Society").HasKey<Guid>(e => e.Id).Ignore(e => e.EntityId).Ignore(e => e.ObjectState);
            modelBuilder.Entity<Society>().ToTable("Society", "Society").HasKey<Guid>(e => e.Id).Ignore(e => e.EntityId).Ignore(e => e.ObjectState);

                //Making surer the Code is the identity Column              
            modelBuilder.Entity<Society>().ToTable("Society", "Society").Property(p => p.Code).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            //Security Schemas
         
                // UserId is the identity column.
            modelBuilder.Entity<Resident>().ToTable("Resident", "Security").HasKey<Guid>(e => e.Id).Ignore(e => e.EntityId)
                .Property(p=>p.UserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

         
            modelBuilder.Entity<ResidentSocietyMapping>().ToTable("ResidentSocietyMapping", "Security").HasKey<Guid>(e => e.Id).Ignore(e => e.EntityId).Ignore(e => e.ObjectState);
            modelBuilder.Entity<ResidentSocietyRoleMapping>().ToTable("ResidentSocietyRoleMapping", "Security").HasKey<Guid>(e => e.Id).Ignore(e => e.EntityId).Ignore(e => e.ObjectState);
            modelBuilder.Entity<Role>().ToTable("Role", "Security").HasKey<Guid>(e => e.Id).Ignore(e => e.EntityId);
            modelBuilder.Entity<SocietyRolePrivilege>().ToTable("SocietyRolePrivilege", "Security").HasKey<Guid>(e => e.Id).Ignore(e => e.EntityId).Ignore(e => e.ObjectState);
                    

            //Instance Schemas
         
            modelBuilder.Entity<Audit>().ToTable("Audit", "Instance").HasKey<Guid>(e => e.Id).Ignore(e => e.EntityId);
            
         
        }
    }
}
