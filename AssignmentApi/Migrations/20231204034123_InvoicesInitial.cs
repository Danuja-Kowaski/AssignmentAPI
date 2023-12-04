using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssignmentApi.Migrations
{
    /// <inheritdoc />
    public partial class InvoicesInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceLines_Invoices_InvoiceId",
                table: "InvoiceLines");

            migrationBuilder.RenameColumn(
                name: "InvoiceId",
                table: "InvoiceLines",
                newName: "invoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceLines_InvoiceId",
                table: "InvoiceLines",
                newName: "IX_InvoiceLines_invoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceLines_Invoices_invoiceId",
                table: "InvoiceLines",
                column: "invoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceLines_Invoices_invoiceId",
                table: "InvoiceLines");

            migrationBuilder.RenameColumn(
                name: "invoiceId",
                table: "InvoiceLines",
                newName: "InvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceLines_invoiceId",
                table: "InvoiceLines",
                newName: "IX_InvoiceLines_InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceLines_Invoices_InvoiceId",
                table: "InvoiceLines",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
