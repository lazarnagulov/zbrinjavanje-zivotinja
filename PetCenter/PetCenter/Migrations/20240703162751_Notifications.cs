using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetCenter.Migrations
{
    /// <inheritdoc />
    public partial class Notifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_account_person_id_person",
                table: "account");

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "account",
                type: "character varying(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.CreateTable(
                name: "notification",
                columns: table => new
                {
                    id_mess = table.Column<Guid>(type: "uuid", nullable: false),
                    id_recipient = table.Column<Guid>(type: "uuid", nullable: false),
                    message = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notification", x => x.id_mess);
                    table.ForeignKey(
                        name: "FK_notification_person_id_recipient",
                        column: x => x.id_recipient,
                        principalTable: "person",
                        principalColumn: "id_person",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_account_person_id_person",
                table: "account",
                column: "person_id_person",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_notification_id_recipient",
                table: "notification",
                column: "id_recipient");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "notification");

            migrationBuilder.DropIndex(
                name: "IX_account_person_id_person",
                table: "account");

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "account",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(64)",
                oldMaxLength: 64);

            migrationBuilder.CreateIndex(
                name: "IX_account_person_id_person",
                table: "account",
                column: "person_id_person");
        }
    }
}
