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
                name: "person",
                columns: table => new
                {
                    id_person = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    surname = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    phone = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    gender = table.Column<int>(type: "integer", nullable: false),
                    birth = table.Column<DateOnly>(type: "date", nullable: false),
                    address_id_adr = table.Column<Guid>(type: "uuid", nullable: false)
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
                name: "animal",
                columns: table => new
                {
                    id_animal = table.Column<Guid>(type: "uuid", nullable: false),
                    animal_type_id_type = table.Column<Guid>(type: "uuid", nullable: false),
                    name_a = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    age_a = table.Column<int>(type: "integer", nullable: false),
                    desc_a = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_animal", x => x.id_animal);
                    table.ForeignKey(
                        name: "FK_animal_animal_type_animal_type_id_type",
                        column: x => x.animal_type_id_type,
                        principalTable: "animal_type",
                        principalColumn: "id_animal_type",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_account_person_person_id_person",
                        column: x => x.person_id_person,
                        principalTable: "person",
                        principalColumn: "id_person");
                });

            migrationBuilder.CreateTable(
                name: "comment",
                columns: table => new
                {
                    id_comment = table.Column<Guid>(type: "uuid", nullable: false),
                    person_author_c = table.Column<Guid>(type: "uuid", nullable: false),
                    comment_text = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment", x => x.id_comment);
                    table.ForeignKey(
                        name: "FK_comment_person_person_author_c",
                        column: x => x.person_author_c,
                        principalTable: "person",
                        principalColumn: "id_person",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "offer",
                columns: table => new
                {
                    id_offer = table.Column<Guid>(type: "uuid", nullable: false),
                    person_author_o = table.Column<Guid>(type: "uuid", nullable: false),
                    type_o = table.Column<int>(type: "integer", nullable: false),
                    status_o = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_offer", x => x.id_offer);
                    table.ForeignKey(
                        name: "FK_offer_person_person_author_o",
                        column: x => x.person_author_o,
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
                name: "review",
                columns: table => new
                {
                    id_review = table.Column<Guid>(type: "uuid", nullable: false),
                    grade = table.Column<int>(type: "integer", nullable: false),
                    comment_r = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    OfferId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_review", x => x.id_review);
                    table.ForeignKey(
                        name: "FK_review_offer_OfferId",
                        column: x => x.OfferId,
                        principalTable: "offer",
                        principalColumn: "id_offer");
                });

            migrationBuilder.CreateTable(
                name: "vote",
                columns: table => new
                {
                    person_id_voter = table.Column<Guid>(type: "uuid", nullable: false),
                    request_id_voted = table.Column<Guid>(type: "uuid", nullable: false),
                    voted_for = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vote", x => new { x.person_id_voter, x.request_id_voted });
                    table.ForeignKey(
                        name: "FK_vote_person_person_id_voter",
                        column: x => x.person_id_voter,
                        principalTable: "person",
                        principalColumn: "id_person",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vote_request_request_id_voted",
                        column: x => x.request_id_voted,
                        principalTable: "request",
                        principalColumn: "id_req",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "post_comments",
                columns: table => new
                {
                    comment_id_comment = table.Column<Guid>(type: "uuid", nullable: false),
                    post_id_post_cmt = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_post_comments", x => new { x.comment_id_comment, x.post_id_post_cmt });
                    table.ForeignKey(
                        name: "FK_post_comments_comment_comment_id_comment",
                        column: x => x.comment_id_comment,
                        principalTable: "comment",
                        principalColumn: "id_comment",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_post_comments_post_post_id_post_cmt",
                        column: x => x.post_id_post_cmt,
                        principalTable: "post",
                        principalColumn: "id_post",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "post_likes",
                columns: table => new
                {
                    person_id_liked = table.Column<Guid>(type: "uuid", nullable: false),
                    post_id_liked = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_post_likes", x => new { x.person_id_liked, x.post_id_liked });
                    table.ForeignKey(
                        name: "FK_post_likes_person_person_id_liked",
                        column: x => x.person_id_liked,
                        principalTable: "person",
                        principalColumn: "id_person",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_post_likes_post_post_id_liked",
                        column: x => x.post_id_liked,
                        principalTable: "post",
                        principalColumn: "id_post",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "post_offers",
                columns: table => new
                {
                    offer_id_offer = table.Column<Guid>(type: "uuid", nullable: false),
                    post_id_post = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_post_offers", x => new { x.offer_id_offer, x.post_id_post });
                    table.ForeignKey(
                        name: "FK_post_offers_offer_offer_id_offer",
                        column: x => x.offer_id_offer,
                        principalTable: "offer",
                        principalColumn: "id_offer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_post_offers_post_post_id_post",
                        column: x => x.post_id_post,
                        principalTable: "post",
                        principalColumn: "id_post",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "post_state",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StateType = table.Column<string>(type: "character varying(34)", maxLength: 34, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_post_state", x => x.Id);
                    table.ForeignKey(
                        name: "FK_post_state_post_Id",
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
                name: "IX_animal_animal_type_id_type",
                table: "animal",
                column: "animal_type_id_type");

            migrationBuilder.CreateIndex(
                name: "IX_comment_person_author_c",
                table: "comment",
                column: "person_author_c");

            migrationBuilder.CreateIndex(
                name: "IX_offer_person_author_o",
                table: "offer",
                column: "person_author_o");

            migrationBuilder.CreateIndex(
                name: "IX_person_address_id_adr",
                table: "person",
                column: "address_id_adr");

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
                name: "IX_post_comments_post_id_post_cmt",
                table: "post_comments",
                column: "post_id_post_cmt");

            migrationBuilder.CreateIndex(
                name: "IX_post_likes_post_id_liked",
                table: "post_likes",
                column: "post_id_liked");

            migrationBuilder.CreateIndex(
                name: "IX_post_offers_post_id_post",
                table: "post_offers",
                column: "post_id_post");

            migrationBuilder.CreateIndex(
                name: "IX_request_person_req_author",
                table: "request",
                column: "person_req_author");

            migrationBuilder.CreateIndex(
                name: "IX_review_OfferId",
                table: "review",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_vote_request_id_voted",
                table: "vote",
                column: "request_id_voted");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "account");

            migrationBuilder.DropTable(
                name: "photo");

            migrationBuilder.DropTable(
                name: "post_comments");

            migrationBuilder.DropTable(
                name: "post_likes");

            migrationBuilder.DropTable(
                name: "post_offers");

            migrationBuilder.DropTable(
                name: "post_state");

            migrationBuilder.DropTable(
                name: "review");

            migrationBuilder.DropTable(
                name: "vote");

            migrationBuilder.DropTable(
                name: "comment");

            migrationBuilder.DropTable(
                name: "post");

            migrationBuilder.DropTable(
                name: "offer");

            migrationBuilder.DropTable(
                name: "request");

            migrationBuilder.DropTable(
                name: "animal");

            migrationBuilder.DropTable(
                name: "person");

            migrationBuilder.DropTable(
                name: "animal_type");

            migrationBuilder.DropTable(
                name: "address");
        }
    }
}
