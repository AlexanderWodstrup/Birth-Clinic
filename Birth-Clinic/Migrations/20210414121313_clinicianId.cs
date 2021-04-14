using Microsoft.EntityFrameworkCore.Migrations;

namespace Birth_Clinic.Migrations
{
    public partial class clinicianId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Clinicians_ClinicianFirstName_ClinicianLastName",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Schedule_ClinicianFirstName_ClinicianLastName",
                table: "Schedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clinicians",
                table: "Clinicians");

            migrationBuilder.DropColumn(
                name: "ClinicianFirstName",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "ClinicianLastName",
                table: "Schedule");

            migrationBuilder.AddColumn<int>(
                name: "ClinicianId",
                table: "Schedule",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Clinicians",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Clinicians",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "ClinicianId",
                table: "Clinicians",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clinicians",
                table: "Clinicians",
                column: "ClinicianId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_ClinicianId",
                table: "Schedule",
                column: "ClinicianId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Clinicians_ClinicianId",
                table: "Schedule",
                column: "ClinicianId",
                principalTable: "Clinicians",
                principalColumn: "ClinicianId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Clinicians_ClinicianId",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Schedule_ClinicianId",
                table: "Schedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clinicians",
                table: "Clinicians");

            migrationBuilder.DropColumn(
                name: "ClinicianId",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "ClinicianId",
                table: "Clinicians");

            migrationBuilder.AddColumn<string>(
                name: "ClinicianFirstName",
                table: "Schedule",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClinicianLastName",
                table: "Schedule",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Clinicians",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Clinicians",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clinicians",
                table: "Clinicians",
                columns: new[] { "FirstName", "LastName" });

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_ClinicianFirstName_ClinicianLastName",
                table: "Schedule",
                columns: new[] { "ClinicianFirstName", "ClinicianLastName" });

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Clinicians_ClinicianFirstName_ClinicianLastName",
                table: "Schedule",
                columns: new[] { "ClinicianFirstName", "ClinicianLastName" },
                principalTable: "Clinicians",
                principalColumns: new[] { "FirstName", "LastName" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
