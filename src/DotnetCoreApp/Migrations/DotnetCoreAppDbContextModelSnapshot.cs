using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DotnetCoreApp.Entities;

namespace DotnetCoreApp.Migrations
{
    [DbContext(typeof(DotnetCoreAppDbContext))]
    partial class DotnetCoreAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DotnetCoreApp.Entities.MovieData", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cast");

                    b.Property<string>("Classification");

                    b.Property<string>("Genre");

                    b.Property<int>("Rating");

                    b.Property<int>("ReleaseDate");

                    b.Property<string>("Title");

                    b.HasKey("MovieId");

                    b.ToTable("Movies");
                });
        }
    }
}
