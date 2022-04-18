using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoApp.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Tenant_TenantId",
                table: "Car");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tenant",
                table: "Tenant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Car",
                table: "Car");

            migrationBuilder.DropIndex(
                name: "IX_Car_TenantId",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Car");

            migrationBuilder.RenameTable(
                name: "Tenant",
                newName: "Tenants");

            migrationBuilder.RenameTable(
                name: "Car",
                newName: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "RentId",
                table: "Tenants",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tenants",
                table: "Tenants",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cars",
                table: "Cars",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_RentId",
                table: "Tenants",
                column: "RentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_Cars_RentId",
                table: "Tenants",
                column: "RentId",
                principalTable: "Cars",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_Cars_RentId",
                table: "Tenants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tenants",
                table: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_Tenants_RentId",
                table: "Tenants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cars",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "RentId",
                table: "Tenants");

            migrationBuilder.RenameTable(
                name: "Tenants",
                newName: "Tenant");

            migrationBuilder.RenameTable(
                name: "Cars",
                newName: "Car");

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "Car",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tenant",
                table: "Tenant",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Car",
                table: "Car",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Car_TenantId",
                table: "Car",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Tenant_TenantId",
                table: "Car",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "Id");
        }
    }
}
