﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using OrderManagement.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

public partial class OrderManagementSystemEntities19 : DbContext
{
    public OrderManagementSystemEntities19()
        : base("name=OrderManagementSystemEntities19")
    {
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }

    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<OrderItem> OrderItems { get; set; }
}