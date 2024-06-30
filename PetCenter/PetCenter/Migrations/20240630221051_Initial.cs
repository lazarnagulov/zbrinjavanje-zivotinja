using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetCenter.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    id_adr = table.Column<Guid>(type: "uuid", nullable: false),
                    street = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    number = table.Column<int>(type: "integer", nullable: false),
                    city = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    country = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    zipcode = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.id_adr);
                });

            migrationBuilder.CreateTable(
                name: "animal_type",
                columns: table => new
                {
                    id_animal_type = table.Column<Guid>(type: "uuid", nullable: false),
                    typename = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    breed = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_animal_type", x => x.id_animal_type);
                });

            migrationBuilder.CreateTable(
                name: "animal",
                columns: table => new
                {
                    id_animal = table.Column<Guid>(type: "uuid", nullable: false),
                    animalType_id_type = table.Column<Guid>(type: "uuid", nullable: false),
                    name_a = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    age_a = table.Column<int>(type: "integer", nullable: false),
                    desc_a = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_animal", x => x.id_animal);
                    table.ForeignKey(
                        name: "FK_animal_animal_type_animalType_id_type",
                        column: x => x.animalType_id_type,
                        principalTable: "animal_type",
                        principalColumn: "id_animal_type",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "photo",
                columns: table => new
                {
                    id_photo = table.Column<Guid>(type: "uuid", nullable: false),
                    photo_url = table.Column<string>(type: "text", nullable: false),
                    photo_desc = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    AnimalId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_photo", x => x.id_photo);
                    table.ForeignKey(
                        name: "FK_photo_animal_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "animal",
                        principalColumn: "id_animal");
                });

            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    id_acc = table.Column<Guid>(type: "uuid", nullable: false),
                    username = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    email = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    password = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    acc_type = table.Column<int>(type: "integer", nullable: false),
                    person_id_person = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account", x => x.id_acc);
                });

            migrationBuilder.CreateTable(
                name: "comment",
                columns: table => new
                {
                    id_comment = table.Column<Guid>(type: "uuid", nullable: false),
                    person_author_c = table.Column<Guid>(type: "uuid", nullable: false),
                    comment_text = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    PostId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment", x => x.id_comment);
                });

            migrationBuilder.CreateTable(
                name: "offer",
                columns: table => new
                {
                    id_offer = table.Column<Guid>(type: "uuid", nullable: false),
                    person_author_o = table.Column<Guid>(type: "uuid", nullable: false),
                    type_o = table.Column<int>(type: "integer", nullable: false),
                    status_o = table.Column<int>(type: "integer", nullable: false),
                    PostId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_offer", x => x.id_offer);
                });

            migrationBuilder.CreateTable(
                name: "review",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    grade = table.Column<int>(type: "integer", nullable: false),
                    comment_r = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    OfferId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_review_offer_OfferId",
                        column: x => x.OfferId,
                        principalTable: "offer",
                        principalColumn: "id_offer");
                });

            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    id_person = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    surname = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    phone = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    gender = table.Column<int>(type: "integer", nullable: false),
                    birth = table.Column<DateOnly>(type: "date", nullable: false),
                    address_id_adr = table.Column<Guid>(type: "uuid", nullable: false),
                    PostId = table.Column<Guid>(type: "uuid", nullable: true),
                    RequestId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.id_person);
                    table.ForeignKey(
                        name: "FK_person_address_address_id_adr",
                        column: x => x.address_id_adr,
                        principalTable: "address",
                        principalColumn: "id_adr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "post",
                columns: table => new
                {
                    id_post = table.Column<Guid>(type: "uuid", nullable: false),
                    person_author_p = table.Column<Guid>(type: "uuid", nullable: false),
                    text_p = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    animal_animal_id = table.Column<Guid>(type: "uuid", nullable: false),
                    creation_date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_post", x => x.id_post);
                    table.ForeignKey(
                        name: "FK_post_animal_animal_animal_id",
                        column: x => x.animal_animal_id,
                        principalTable: "animal",
                        principalColumn: "id_animal",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_post_person_person_author_p",
                        column: x => x.person_author_p,
                        principalTable: "person",
                        principalColumn: "id_person",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "request",
                columns: table => new
                {
                    id_req = table.Column<Guid>(type: "uuid", nullable: false),
                    person_req_author = table.Column<Guid>(type: "uuid", nullable: false),
                    creation_date_req = table.Column<DateOnly>(type: "date", nullable: false),
                    for_promotion = table.Column<int>(type: "integer", nullable: false),
                    against_promotion = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_request", x => x.id_req);
                    table.ForeignKey(
                        name: "FK_request_person_person_req_author",
                        column: x => x.person_req_author,
                        principalTable: "person",
                        principalColumn: "id_person",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "postStates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StateType = table.Column<string>(type: "character varying(34)", maxLength: 34, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_postStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_postStates_post_Id",
                        column: x => x.Id,
                        principalTable: "post",
                        principalColumn: "id_post",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_account_email",
                table: "account",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_account_person_id_person",
                table: "account",
                column: "person_id_person");

            migrationBuilder.CreateIndex(
                name: "IX_account_username",
                table: "account",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_animal_animalType_id_type",
                table: "animal",
                column: "animalType_id_type");

            migrationBuilder.CreateIndex(
                name: "IX_comment_person_author_c",
                table: "comment",
                column: "person_author_c");

            migrationBuilder.CreateIndex(
                name: "IX_comment_PostId",
                table: "comment",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_offer_person_author_o",
                table: "offer",
                column: "person_author_o");

            migrationBuilder.CreateIndex(
                name: "IX_offer_PostId",
                table: "offer",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_person_address_id_adr",
                table: "person",
                column: "address_id_adr");

            migrationBuilder.CreateIndex(
                name: "IX_person_PostId",
                table: "person",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_person_RequestId",
                table: "person",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_photo_AnimalId",
                table: "photo",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_post_animal_animal_id",
                table: "post",
                column: "animal_animal_id");

            migrationBuilder.CreateIndex(
                name: "IX_post_person_author_p",
                table: "post",
                column: "person_author_p");

            migrationBuilder.CreateIndex(
                name: "IX_request_person_req_author",
                table: "request",
                column: "person_req_author");

            migrationBuilder.CreateIndex(
                name: "IX_review_OfferId",
                table: "review",
                column: "OfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_account_person_person_id_person",
                table: "account",
                column: "person_id_person",
                principalTable: "person",
                principalColumn: "id_person");

            migrationBuilder.AddForeignKey(
                name: "FK_comment_person_person_author_c",
                table: "comment",
                column: "person_author_c",
                principalTable: "person",
                principalColumn: "id_person",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comment_post_PostId",
                table: "comment",
                column: "PostId",
                principalTable: "post",
                principalColumn: "id_post");

            migrationBuilder.AddForeignKey(
                name: "FK_offer_person_person_author_o",
                table: "offer",
                column: "person_author_o",
                principalTable: "person",
                principalColumn: "id_person",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_offer_post_PostId",
                table: "offer",
                column: "PostId",
                principalTable: "post",
                principalColumn: "id_post");

            migrationBuilder.AddForeignKey(
                name: "FK_person_post_PostId",
                table: "person",
                column: "PostId",
                principalTable: "post",
                principalColumn: "id_post");

            migrationBuilder.AddForeignKey(
                name: "FK_person_request_RequestId",
                table: "person",
                column: "RequestId",
                principalTable: "request",
                principalColumn: "id_req");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_post_person_person_author_p",
                table: "post");

            migrationBuilder.DropForeignKey(
                name: "FK_request_person_person_req_author",
                table: "request");

            migrationBuilder.DropTable(
                name: "account");

            migrationBuilder.DropTable(
                name: "comment");

            migrationBuilder.DropTable(
                name: "photo");

            migrationBuilder.DropTable(
                name: "postStates");

            migrationBuilder.DropTable(
                name: "review");

            migrationBuilder.DropTable(
                name: "offer");

            migrationBuilder.DropTable(
                name: "person");

            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "post");

            migrationBuilder.DropTable(
                name: "request");

            migrationBuilder.DropTable(
                name: "animal");

            migrationBuilder.DropTable(
                name: "animal_type");
        }
    }
}
