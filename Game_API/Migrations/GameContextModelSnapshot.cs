﻿// <auto-generated />
using Game_API;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Game_API.Migrations
{
    [DbContext(typeof(GameContext))]
    partial class GameContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Game_API.Models.GameResult", b =>
                {
                    b.Property<int>("PkGameResultId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GameName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<long>("Timestamp")
                        .HasColumnType("bigint");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkGameResultId");

                    b.ToTable("GameResults");
                });

            modelBuilder.Entity("Game_API.Models.GameSession", b =>
                {
                    b.Property<int>("PkGameSessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DifficultyLevel")
                        .HasColumnType("int");

                    b.Property<int>("DurationSeconds")
                        .HasColumnType("int");

                    b.Property<long>("EndTimeStamp")
                        .HasColumnType("bigint");

                    b.Property<int>("GameResultId")
                        .HasColumnType("int");

                    b.Property<int>("NegativeActions")
                        .HasColumnType("int");

                    b.Property<string>("Outcome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PositiveActions")
                        .HasColumnType("int");

                    b.Property<long>("StartTimeStamp")
                        .HasColumnType("bigint");

                    b.HasKey("PkGameSessionId");

                    b.HasIndex("GameResultId");

                    b.ToTable("GameSession");
                });

            modelBuilder.Entity("Game_API.Models.GameSession", b =>
                {
                    b.HasOne("Game_API.Models.GameResult", "GameResult")
                        .WithMany("Session")
                        .HasForeignKey("GameResultId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameResult");
                });

            modelBuilder.Entity("Game_API.Models.GameResult", b =>
                {
                    b.Navigation("Session");
                });
#pragma warning restore 612, 618
        }
    }
}
