using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestTaskOCS.Migrations
{
    /// <inheritdoc />
    public partial class InitialCrete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeetingRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RequestTopic = table.Column<string>(type: "text", nullable: false),
                    Author = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsRequestSend = table.Column<bool>(type: "boolean", nullable: false),
                    MeetingName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    MeetingDescription = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    MeetingPlan = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingRequests", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeetingRequests");
        }
    }
}
