﻿// <auto-generated />
using System;
using GestionStock.Core.DataEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestionStock.Core.DataEF.Migrations
{
    [DbContext(typeof(GestionStockContext))]
    partial class GestionStockContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GestionStock.Core.Entities.Categoria", b =>
                {
                    b.Property<int>("categoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("categoriaId"));

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nombre");

                    b.HasKey("categoriaId");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("GestionStock.Core.Entities.Compra", b =>
                {
                    b.Property<int>("compraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("compraId"));

                    b.Property<int>("cantidad")
                        .HasColumnType("int")
                        .HasColumnName("Cantidad");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2")
                        .HasColumnName("Fecha");

                    b.Property<int>("productoId")
                        .HasColumnType("int")
                        .HasColumnName("ProductoId");

                    b.Property<int>("usuarioId")
                        .HasColumnType("int")
                        .HasColumnName("UsuarioId");

                    b.HasKey("compraId");

                    b.ToTable("Compra");
                });

            modelBuilder.Entity("GestionStock.Core.Entities.Producto", b =>
                {
                    b.Property<int>("productoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("productoId"));

                    b.Property<int>("categoriaId")
                        .HasColumnType("int")
                        .HasColumnName("CategoriaId");

                    b.Property<bool>("habilitado")
                        .HasColumnType("bit")
                        .HasColumnName("Habilitado");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nombre");

                    b.HasKey("productoId");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("GestionStock.Core.Entities.Usuario", b =>
                {
                    b.Property<int>("usuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("usuarioId"));

                    b.Property<string>("hash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Hash");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nombre");

                    b.Property<string>("salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Salt");

                    b.HasKey("usuarioId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("GestionStock.Core.Entities.Venta", b =>
                {
                    b.Property<int>("ventaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ventaId"));

                    b.Property<int>("cantidad")
                        .HasColumnType("int")
                        .HasColumnName("Cantidad");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2")
                        .HasColumnName("Fecha");

                    b.Property<int>("productoId")
                        .HasColumnType("int")
                        .HasColumnName("ProductoId");

                    b.Property<int>("usuarioId")
                        .HasColumnType("int")
                        .HasColumnName("UsuarioId");

                    b.HasKey("ventaId");

                    b.ToTable("Venta");
                });
#pragma warning restore 612, 618
        }
    }
}
