using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetCenter.Migrations
{
    /// <inheritdoc />
    public partial class Associations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id_mess",
                table: "notification",
                newName: "id_notification");

            migrationBuilder.CreateTable(
                name: "association",
                columns: table => new
                {
                    id_assoc = table.Column<Guid>(type: "uuid", nullable: false),
                    assoc_name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    assoc_acc_number = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    assoc_website = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_association", x => x.id_assoc);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "association");

            migrationBuilder.RenameColumn(
                name: "id_notification",
                table: "notification",
                newName: "id_mess");
        }
    }
}
