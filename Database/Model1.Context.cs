﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Database
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EmpOrgEntities : DbContext
    {
        public EmpOrgEntities()
            : base("name=EmpOrgEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DepMst> DepMsts { get; set; }
        public virtual DbSet<EmpAddressDet> EmpAddressDets { get; set; }
        public virtual DbSet<EmployeeMst> EmployeeMsts { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }
        public virtual DbSet<StateMst> StateMsts { get; set; }
    }
}
