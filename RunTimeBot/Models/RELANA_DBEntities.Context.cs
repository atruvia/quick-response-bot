﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RunTimeBot.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QRBot_DBEntities : DbContext
    {
        public QRBot_DBEntities()
            : base("name=QRBot_DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ANSWERS> ANSWERS { get; set; }
        public virtual DbSet<ANSWERS_TYPE> ANSWERS_TYPE { get; set; }
        public virtual DbSet<DICTIONARY> DICTIONARY { get; set; }
        public virtual DbSet<INTENT_TYPE> INTENT_TYPE { get; set; }
        public virtual DbSet<LUIS_TYPE> LUIS_TYPE { get; set; }
        public virtual DbSet<LUIS_TIMELINE> LUIS_TIMELINE { get; set; }
    }
}