﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bykova41p_Pr6
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities1 : DbContext
    {
        public Entities1()
            : base("name=Entities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Table_Characteristic> Table_Characteristic { get; set; }
        public virtual DbSet<Table_Customer> Table_Customer { get; set; }
        public virtual DbSet<Table_Gender> Table_Gender { get; set; }
        public virtual DbSet<Table_Meaning> Table_Meaning { get; set; }
        public virtual DbSet<Table_Nomenclature> Table_Nomenclature { get; set; }
        public virtual DbSet<Table_Phot> Table_Phot { get; set; }
        public virtual DbSet<Table_Products> Table_Products { get; set; }
        public virtual DbSet<Table_Purchase> Table_Purchase { get; set; }
        public virtual DbSet<Table_Role> Table_Role { get; set; }
        public virtual DbSet<Table_Users> Table_Users { get; set; }
        public virtual DbSet<Table_VidNom> Table_VidNom { get; set; }
    }
}
