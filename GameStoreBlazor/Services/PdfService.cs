﻿using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

public class PdfService
{
    public byte[] CreatePdfWithQrCode(byte[] qrCodeImage, string gameName, string genre, decimal price, string releaseDate)
    {
        return Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(1, Unit.Centimetre);

                // Sidhuvud
                page.Header().Text("Game QR Code").FontSize(20).Bold();

                // Innehåll
                page.Content().Column(column =>
                {
                    column.Item().Text($"Game: {gameName}").FontSize(16);
                    column.Item().Text($"Genre: {genre}").FontSize(14);
                    column.Item().Text($"Price: {price:C2}").FontSize(14);
                    column.Item().Text($"Release Date: {releaseDate}").FontSize(14);
                    column.Item().Image(qrCodeImage);
                });

                // Sidfot
                page.Footer().Text("Generated by GameStoreBlazor");
            });
        }).GeneratePdf();
    }
}