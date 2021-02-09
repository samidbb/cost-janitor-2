﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CostJanitor.Infrastructure.Migrations
{
    public partial class x : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CostItemReportItem_CostItem_CostItemsLabel",
                table: "CostItemReportItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CostItemReportItem_ReportItem_CostItemsId",
                table: "CostItemReportItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CostItemReportItem",
                table: "CostItemReportItem");

            migrationBuilder.DropIndex(
                name: "IX_CostItemReportItem_CostItemsLabel",
                table: "CostItemReportItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CostItem",
                table: "CostItem");

            migrationBuilder.RenameColumn(
                name: "CostItemsLabel",
                table: "CostItemReportItem",
                newName: "_costItemsCapabilityIdentifier");

            migrationBuilder.RenameColumn(
                name: "CostItemsId",
                table: "CostItemReportItem",
                newName: "_costItemsId");

            migrationBuilder.AddColumn<string>(
                name: "_costItemsLabel",
                table: "CostItemReportItem",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ReportItemId",
                table: "CostItem",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CostItemReportItem",
                table: "CostItemReportItem",
                columns: new[] { "_costItemsId", "_costItemsLabel", "_costItemsCapabilityIdentifier" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CostItem",
                table: "CostItem",
                columns: new[] { "Label", "CapabilityIdentifier" });

            migrationBuilder.CreateIndex(
                name: "IX_CostItemReportItem__costItemsLabel__costItemsCapabilityIden~",
                table: "CostItemReportItem",
                columns: new[] { "_costItemsLabel", "_costItemsCapabilityIdentifier" });

            migrationBuilder.CreateIndex(
                name: "IX_CostItem_ReportItemId",
                table: "CostItem",
                column: "ReportItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_CostItem_ReportItem_ReportItemId",
                table: "CostItem",
                column: "ReportItemId",
                principalTable: "ReportItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CostItemReportItem_CostItem__costItemsLabel__costItemsCapab~",
                table: "CostItemReportItem",
                columns: new[] { "_costItemsLabel", "_costItemsCapabilityIdentifier" },
                principalTable: "CostItem",
                principalColumns: new[] { "Label", "CapabilityIdentifier" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CostItemReportItem_ReportItem__costItemsId",
                table: "CostItemReportItem",
                column: "_costItemsId",
                principalTable: "ReportItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CostItem_ReportItem_ReportItemId",
                table: "CostItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CostItemReportItem_CostItem__costItemsLabel__costItemsCapab~",
                table: "CostItemReportItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CostItemReportItem_ReportItem__costItemsId",
                table: "CostItemReportItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CostItemReportItem",
                table: "CostItemReportItem");

            migrationBuilder.DropIndex(
                name: "IX_CostItemReportItem__costItemsLabel__costItemsCapabilityIden~",
                table: "CostItemReportItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CostItem",
                table: "CostItem");

            migrationBuilder.DropIndex(
                name: "IX_CostItem_ReportItemId",
                table: "CostItem");

            migrationBuilder.DropColumn(
                name: "_costItemsLabel",
                table: "CostItemReportItem");

            migrationBuilder.DropColumn(
                name: "ReportItemId",
                table: "CostItem");

            migrationBuilder.RenameColumn(
                name: "_costItemsCapabilityIdentifier",
                table: "CostItemReportItem",
                newName: "CostItemsLabel");

            migrationBuilder.RenameColumn(
                name: "_costItemsId",
                table: "CostItemReportItem",
                newName: "CostItemsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CostItemReportItem",
                table: "CostItemReportItem",
                columns: new[] { "CostItemsId", "CostItemsLabel" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CostItem",
                table: "CostItem",
                column: "Label");

            migrationBuilder.CreateIndex(
                name: "IX_CostItemReportItem_CostItemsLabel",
                table: "CostItemReportItem",
                column: "CostItemsLabel");

            migrationBuilder.AddForeignKey(
                name: "FK_CostItemReportItem_CostItem_CostItemsLabel",
                table: "CostItemReportItem",
                column: "CostItemsLabel",
                principalTable: "CostItem",
                principalColumn: "Label",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CostItemReportItem_ReportItem_CostItemsId",
                table: "CostItemReportItem",
                column: "CostItemsId",
                principalTable: "ReportItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
