using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventInvitationQrCodeApi.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QrCode_Users_QrCode_User_Id",
                table: "QrCode");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QrCode",
                table: "QrCode");

            migrationBuilder.RenameTable(
                name: "QrCode",
                newName: "QrCodes");

            migrationBuilder.RenameIndex(
                name: "IX_QrCode_QrCode_User_Id",
                table: "QrCodes",
                newName: "IX_QrCodes_QrCode_User_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QrCodes",
                table: "QrCodes",
                column: "QrCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_QrCodes_Users_QrCode_User_Id",
                table: "QrCodes",
                column: "QrCode_User_Id",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QrCodes_Users_QrCode_User_Id",
                table: "QrCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QrCodes",
                table: "QrCodes");

            migrationBuilder.RenameTable(
                name: "QrCodes",
                newName: "QrCode");

            migrationBuilder.RenameIndex(
                name: "IX_QrCodes_QrCode_User_Id",
                table: "QrCode",
                newName: "IX_QrCode_QrCode_User_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QrCode",
                table: "QrCode",
                column: "QrCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_QrCode_Users_QrCode_User_Id",
                table: "QrCode",
                column: "QrCode_User_Id",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
