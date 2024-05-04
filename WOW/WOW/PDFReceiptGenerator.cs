using System;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.IO.Image;

namespace ParkingManagementSystem
{
    class PDFReceiptGenerator
    {
        public static void GenerateReceipt(string fullName, string vehicleType, string vehicleNumber, DateTime entryTime, DateTime exitTime, TimeSpan duration, double totalCost)
        {
            string directoryPath = @"C:\Users\SSD\Desktop\New folder";
            Directory.CreateDirectory(directoryPath);

            string fileName = Path.Combine(directoryPath, $"{vehicleNumber}.pdf");

            // Create PDF document
            using (PdfWriter writer = new PdfWriter(fileName))
            {
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    Document document = new Document(pdf);

                    // Add content to the PDF
                    Paragraph title = new Paragraph("Parking Receipt").SetFontSize(24).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                    Paragraph line = new Paragraph("-------------------------------------------------------------").SetFontSize(14).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                    Paragraph fullNameInfo = new Paragraph($"Driver's Full Name: {fullName}").SetFontSize(16).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                    Paragraph vehicleTypeInfo = new Paragraph($"Vehicle Type: {vehicleType}").SetFontSize(16).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                    Paragraph vehicleInfo = new Paragraph($"Vehicle License: {vehicleNumber}").SetFontSize(16).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                    Paragraph entryInfo = new Paragraph($"Entry Time: {entryTime}").SetFontSize(16).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                    Paragraph exitInfo = new Paragraph($"Exit Time: {exitTime}").SetFontSize(16).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                    Paragraph durationInfo = new Paragraph($"Duration: {duration}").SetFontSize(16).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                    Paragraph costInfo = new Paragraph($"Total Cost: {totalCost} PHP").SetFontSize(16).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                    Paragraph additionalInfo = new Paragraph("Thank you for using our parking services.\nHave a safe journey!\n\nPlease keep this receipt for future reference.").SetFontSize(16).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);

                    // Load the logo
                    string logoPath = @"D:\HDD\School\Parking System Files C#\_c3eab08b-6a57-4be3-a880-534f2b7b795c1.png";
                    iText.Layout.Element.Image logo = new iText.Layout.Element.Image(ImageDataFactory.Create(logoPath));
                    logo.SetWidth(200); // Adjust the width of the logo as needed
                    logo.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);

                    document.Add(logo); // Add the logo to the document
                    document.Add(title);
                    document.Add(line);
                    document.Add(fullNameInfo);
                    document.Add(vehicleTypeInfo);
                    document.Add(vehicleInfo);
                    document.Add(entryInfo);
                    document.Add(exitInfo);
                    document.Add(durationInfo);
                    document.Add(costInfo);
                    document.Add(line); // Add another line
                    document.Add(additionalInfo); // Add additional information
                }
            }

            Console.WriteLine($"Receipt generated and saved in the Receipts Folder.");
        }
    }
}
