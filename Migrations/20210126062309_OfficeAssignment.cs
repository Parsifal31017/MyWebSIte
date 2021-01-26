using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWebSite.Migrations
{
    public partial class OfficeAssignment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminAssignment_Admin_AdminID",
                table: "AdminAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_AdminAssignment_Company_CompanyID",
                table: "AdminAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_AdminAssignment_User_UserID",
                table: "AdminAssignment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdminAssignment",
                table: "AdminAssignment");

            migrationBuilder.DropIndex(
                name: "IX_AdminAssignment_AdminID",
                table: "AdminAssignment");

            migrationBuilder.RenameTable(
                name: "AdminAssignment",
                newName: "AdminAssigment ");

            migrationBuilder.RenameIndex(
                name: "IX_AdminAssignment_CompanyID",
                table: "AdminAssigment ",
                newName: "IX_AdminAssigment _CompanyID");

            migrationBuilder.AddColumn<int>(
                name: "OfficeAssignmentUserID",
                table: "Company",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyID",
                table: "Admin",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompayID",
                table: "AdminAssigment ",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdminAssigment ",
                table: "AdminAssigment ",
                columns: new[] { "UserID", "AdminID" });

            migrationBuilder.CreateIndex(
                name: "IX_Company_OfficeAssignmentUserID",
                table: "Company",
                column: "OfficeAssignmentUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Admin_CompanyID",
                table: "Admin",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_AdminAssigment _AdminID",
                table: "AdminAssigment ",
                column: "AdminID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdminAssigment _UserID",
                table: "AdminAssigment ",
                column: "UserID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_Company_CompanyID",
                table: "Admin",
                column: "CompanyID",
                principalTable: "Company",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AdminAssigment _Admin_AdminID",
                table: "AdminAssigment ",
                column: "AdminID",
                principalTable: "Admin",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdminAssigment _Company_CompanyID",
                table: "AdminAssigment ",
                column: "CompanyID",
                principalTable: "Company",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AdminAssigment _User_UserID",
                table: "AdminAssigment ",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_OfficeAssignment_OfficeAssignmentUserID",
                table: "Company",
                column: "OfficeAssignmentUserID",
                principalTable: "OfficeAssignment",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admin_Company_CompanyID",
                table: "Admin");

            migrationBuilder.DropForeignKey(
                name: "FK_AdminAssigment _Admin_AdminID",
                table: "AdminAssigment ");

            migrationBuilder.DropForeignKey(
                name: "FK_AdminAssigment _Company_CompanyID",
                table: "AdminAssigment ");

            migrationBuilder.DropForeignKey(
                name: "FK_AdminAssigment _User_UserID",
                table: "AdminAssigment ");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_OfficeAssignment_OfficeAssignmentUserID",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Company_OfficeAssignmentUserID",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Admin_CompanyID",
                table: "Admin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdminAssigment ",
                table: "AdminAssigment ");

            migrationBuilder.DropIndex(
                name: "IX_AdminAssigment _AdminID",
                table: "AdminAssigment ");

            migrationBuilder.DropIndex(
                name: "IX_AdminAssigment _UserID",
                table: "AdminAssigment ");

            migrationBuilder.DropColumn(
                name: "OfficeAssignmentUserID",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "CompayID",
                table: "AdminAssigment ");

            migrationBuilder.RenameTable(
                name: "AdminAssigment ",
                newName: "AdminAssignment");

            migrationBuilder.RenameIndex(
                name: "IX_AdminAssigment _CompanyID",
                table: "AdminAssignment",
                newName: "IX_AdminAssignment_CompanyID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdminAssignment",
                table: "AdminAssignment",
                columns: new[] { "UserID", "AdminID" });

            migrationBuilder.CreateIndex(
                name: "IX_AdminAssignment_AdminID",
                table: "AdminAssignment",
                column: "AdminID");

            migrationBuilder.AddForeignKey(
                name: "FK_AdminAssignment_Admin_AdminID",
                table: "AdminAssignment",
                column: "AdminID",
                principalTable: "Admin",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdminAssignment_Company_CompanyID",
                table: "AdminAssignment",
                column: "CompanyID",
                principalTable: "Company",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AdminAssignment_User_UserID",
                table: "AdminAssignment",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
