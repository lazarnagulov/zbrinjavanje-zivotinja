﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PetCenter.Repository;

#nullable disable

namespace PetCenter.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PetCenter.Domain.Model.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id_acc");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("password");

                    b.Property<int>("Type")
                        .HasColumnType("integer")
                        .HasColumnName("acc_type");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("username");

                    b.Property<Guid?>("person_id_person")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.HasIndex("person_id_person");

                    b.ToTable("account");
                });

            modelBuilder.Entity("PetCenter.Domain.Model.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id_adr");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("city");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("country");

                    b.Property<int>("Number")
                        .HasColumnType("integer")
                        .HasColumnName("number");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("street");

                    b.Property<int>("ZipCode")
                        .HasColumnType("integer")
                        .HasColumnName("zipcode");

                    b.HasKey("Id");

                    b.ToTable("address");
                });

            modelBuilder.Entity("PetCenter.Domain.Model.Animal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id_animal");

                    b.Property<int>("Age")
                        .HasColumnType("integer")
                        .HasColumnName("age_a");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)")
                        .HasColumnName("desc_a");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("name_a");

                    b.Property<Guid>("animalType_id_type")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("animalType_id_type");

                    b.ToTable("animal");
                });

            modelBuilder.Entity("PetCenter.Domain.Model.AnimalType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id_animal_type");

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("breed");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("typename");

                    b.HasKey("Id");

                    b.ToTable("animal_type");
                });

            modelBuilder.Entity("PetCenter.Domain.Model.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id_comment");

                    b.Property<Guid?>("PostId")
                        .HasColumnType("uuid");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)")
                        .HasColumnName("comment_text");

                    b.Property<Guid>("person_author_c")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("person_author_c");

                    b.ToTable("comment");
                });

            modelBuilder.Entity("PetCenter.Domain.Model.Offer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id_offer");

                    b.Property<Guid?>("PostId")
                        .HasColumnType("uuid");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status_o");

                    b.Property<int>("Type")
                        .HasColumnType("integer")
                        .HasColumnName("type_o");

                    b.Property<Guid>("person_author_o")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("person_author_o");

                    b.ToTable("offer");
                });

            modelBuilder.Entity("PetCenter.Domain.Model.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id_person");

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date")
                        .HasColumnName("birth");

                    b.Property<int>("Gender")
                        .HasColumnType("integer")
                        .HasColumnName("gender");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("phone");

                    b.Property<Guid?>("PostId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("RequestId")
                        .HasColumnType("uuid");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("surname");

                    b.Property<Guid>("address_id_adr")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("RequestId");

                    b.HasIndex("address_id_adr");

                    b.ToTable("person");
                });

            modelBuilder.Entity("PetCenter.Domain.Model.Photo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id_photo");

                    b.Property<Guid?>("AnimalId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)")
                        .HasColumnName("photo_desc");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("photo_url");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.ToTable("photo");
                });

            modelBuilder.Entity("PetCenter.Domain.Model.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id_post");

                    b.Property<DateOnly>("CreationDate")
                        .HasColumnType("date")
                        .HasColumnName("creation_date");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)")
                        .HasColumnName("text_p");

                    b.Property<Guid>("animal_animal_id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("person_author_p")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("animal_animal_id");

                    b.HasIndex("person_author_p");

                    b.ToTable("post");
                });

            modelBuilder.Entity("PetCenter.Domain.Model.Request", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id_req");

                    b.Property<DateOnly>("CreationDate")
                        .HasColumnType("date")
                        .HasColumnName("creation_date_req");

                    b.Property<int>("VotesAgainst")
                        .HasColumnType("integer")
                        .HasColumnName("against_promotion");

                    b.Property<int>("VotesFor")
                        .HasColumnType("integer")
                        .HasColumnName("for_promotion");

                    b.Property<Guid>("person_req_author")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("person_req_author");

                    b.ToTable("request");
                });

            modelBuilder.Entity("PetCenter.Domain.Model.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)")
                        .HasColumnName("comment_r");

                    b.Property<int>("Grade")
                        .HasColumnType("integer")
                        .HasColumnName("grade");

                    b.Property<Guid?>("OfferId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("OfferId");

                    b.ToTable("review");
                });

            modelBuilder.Entity("PetCenter.Domain.State.PostState", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("StateType")
                        .IsRequired()
                        .HasMaxLength(34)
                        .HasColumnType("character varying(34)");

                    b.HasKey("Id");

                    b.ToTable("postStates", (string)null);

                    b.HasDiscriminator<string>("StateType").HasValue("PostState");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("PetCenter.Domain.State.Accepted", b =>
                {
                    b.HasBaseType("PetCenter.Domain.State.PostState");

                    b.HasDiscriminator().HasValue("Accepted");
                });

            modelBuilder.Entity("PetCenter.Domain.State.Adopted", b =>
                {
                    b.HasBaseType("PetCenter.Domain.State.PostState");

                    b.HasDiscriminator().HasValue("Adopted");
                });

            modelBuilder.Entity("PetCenter.Domain.State.Created", b =>
                {
                    b.HasBaseType("PetCenter.Domain.State.PostState");

                    b.HasDiscriminator().HasValue("Created");
                });

            modelBuilder.Entity("PetCenter.Domain.State.Declined", b =>
                {
                    b.HasBaseType("PetCenter.Domain.State.PostState");

                    b.HasDiscriminator().HasValue("Declined");
                });

            modelBuilder.Entity("PetCenter.Domain.State.Hidden", b =>
                {
                    b.HasBaseType("PetCenter.Domain.State.PostState");

                    b.HasDiscriminator().HasValue("Hidden");
                });

            modelBuilder.Entity("PetCenter.Domain.State.OnHold", b =>
                {
                    b.HasBaseType("PetCenter.Domain.State.PostState");

                    b.HasDiscriminator().HasValue("OnHold");
                });

            modelBuilder.Entity("PetCenter.Domain.State.TemporaryAccommodation", b =>
                {
                    b.HasBaseType("PetCenter.Domain.State.PostState");

                    b.HasDiscriminator().HasValue("TemporaryAccommodation");
                });

            modelBuilder.Entity("PetCenter.Domain.Model.Account", b =>
                {
                    b.HasOne("PetCenter.Domain.Model.Person", "Person")
                        .WithMany()
                        .HasForeignKey("person_id_person");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("PetCenter.Domain.Model.Animal", b =>
                {
                    b.HasOne("PetCenter.Domain.Model.AnimalType", "Type")
                        .WithMany()
                        .HasForeignKey("animalType_id_type")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("PetCenter.Domain.Model.Comment", b =>
                {
                    b.HasOne("PetCenter.Domain.Model.Post", null)
                        .WithMany("Comments")
                        .HasForeignKey("PostId");

                    b.HasOne("PetCenter.Domain.Model.Person", "Author")
                        .WithMany()
                        .HasForeignKey("person_author_c")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("PetCenter.Domain.Model.Offer", b =>
                {
                    b.HasOne("PetCenter.Domain.Model.Post", null)
                        .WithMany("Offers")
                        .HasForeignKey("PostId");

                    b.HasOne("PetCenter.Domain.Model.Person", "Author")
                        .WithMany()
                        .HasForeignKey("person_author_o")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("PetCenter.Domain.Model.Person", b =>
                {
                    b.HasOne("PetCenter.Domain.Model.Post", null)
                        .WithMany("Likes")
                        .HasForeignKey("PostId");

                    b.HasOne("PetCenter.Domain.Model.Request", null)
                        .WithMany("Voters")
                        .HasForeignKey("RequestId");

                    b.HasOne("PetCenter.Domain.Model.Address", "Address")
                        .WithMany()
                        .HasForeignKey("address_id_adr")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("PetCenter.Domain.Model.Photo", b =>
                {
                    b.HasOne("PetCenter.Domain.Model.Animal", null)
                        .WithMany("Photos")
                        .HasForeignKey("AnimalId");
                });

            modelBuilder.Entity("PetCenter.Domain.Model.Post", b =>
                {
                    b.HasOne("PetCenter.Domain.Model.Animal", "Animal")
                        .WithMany()
                        .HasForeignKey("animal_animal_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetCenter.Domain.Model.Person", "Author")
                        .WithMany()
                        .HasForeignKey("person_author_p")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("PetCenter.Domain.Model.Request", b =>
                {
                    b.HasOne("PetCenter.Domain.Model.Person", "Author")
                        .WithMany()
                        .HasForeignKey("person_req_author")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("PetCenter.Domain.Model.Review", b =>
                {
                    b.HasOne("PetCenter.Domain.Model.Offer", null)
                        .WithMany("Reviews")
                        .HasForeignKey("OfferId");
                });

            modelBuilder.Entity("PetCenter.Domain.State.PostState", b =>
                {
                    b.HasOne("PetCenter.Domain.Model.Post", null)
                        .WithOne("State")
                        .HasForeignKey("PetCenter.Domain.State.PostState", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PetCenter.Domain.Model.Animal", b =>
                {
                    b.Navigation("Photos");
                });

            modelBuilder.Entity("PetCenter.Domain.Model.Offer", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("PetCenter.Domain.Model.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Likes");

                    b.Navigation("Offers");

                    b.Navigation("State")
                        .IsRequired();
                });

            modelBuilder.Entity("PetCenter.Domain.Model.Request", b =>
                {
                    b.Navigation("Voters");
                });
#pragma warning restore 612, 618
        }
    }
}
