using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventInvitationQrCodeApi.Migrations
{
    /// <inheritdoc />
    public partial class q1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropForeignKey(
                name: "FK_UserEvent_Event_UserId",
                table: "UserEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserEvent",
                table: "UserEvent");

            migrationBuilder.RenameColumn(
                name: "QrCodeString",
                table: "QrCode",
                newName: "UserQrCodeString");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUserAddedToEvent",
                table: "UserEvent",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserEvent",
                table: "UserEvent",
                columns: new[] { "EventId", "UserId" });

            migrationBuilder.InsertData(
                table: "QrCode",
                columns: new[] { "QrCodeId", "QrCode_User_Id", "UserQrCodeString" },
                values: new object[] { 1, 1, "dsfsfwfw" });

            migrationBuilder.CreateIndex(
                name: "IX_UserEvent_UserId",
                table: "UserEvent",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserEvent_Event_EventId",
                table: "UserEvent",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserEvent_Event_EventId",
                table: "UserEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserEvent",
                table: "UserEvent");

            migrationBuilder.DropIndex(
                name: "IX_UserEvent_UserId",
                table: "UserEvent");

            migrationBuilder.DeleteData(
                table: "QrCode",
                keyColumn: "QrCodeId",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "DateUserAddedToEvent",
                table: "UserEvent");

            migrationBuilder.RenameColumn(
                name: "UserQrCodeString",
                table: "QrCode",
                newName: "QrCodeString");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserEvent",
                table: "UserEvent",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserEvent_Event_UserId",
                table: "UserEvent",
                column: "UserId",
                principalTable: "Event",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
