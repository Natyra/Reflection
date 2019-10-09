using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.IO;
using System.Reflection;

namespace Reflection
{
   
    class Program
    {
        
        static void Main(string[] args)
        {

            string sourcePDFpath = "C:/Users/Natyra ATIS/source/repos/Reflection/Reflection/Documents/Core2.0.pdf";
            string outputPDFpath = "C:/Users/Natyra ATIS/source/repos/Reflection/Reflection/FinalDocuments";

            //var dir = @"C:\Users\Natyra ATIS\source\repos\Reflection\Reflection\FinalDocuments";
            //if (!Directory.Exists(dir))  // if it doesn't exist, create
            //    Directory.CreateDirectory(dir);

            //string[] paths = { @"C:/Users/Natyra ATIS/source/repos/", "Reflection", "/Reflection", "/Documents" };
            //string fullPath = System.IO.Path.Combine(paths);
            //Console.WriteLine("fullPath", fullPath);
            //string outputPDFpath = "C:/Users/Natyra ATIS/source/repos/Reflection/Reflection/Documents";

            PdfTextExtractorDemo.ExtractPages(sourcePDFpath, outputPDFpath, 100, 200);
            //string returnPdf = PdfTextExtractorDemo.pdfText(path);

            //GeneratePdf();
            //var assembly = Assembly.GetExecutingAssembly();

            //int i = 100;
            //var type = i.GetType();
            //Console.WriteLine(type);
            //Console.WriteLine(assembly.FullName);

            //var type = typeof(Customer);
            //Console.WriteLine("Class: " + type.Name);
            //Console.WriteLine("Namespace: " + type.Namespace);

            //var propertyInfo = type.GetProperties();

            //Console.WriteLine("The list of properties of Customer class are:--");
            //foreach (var item in propertyInfo)
            //{
            //    Console.WriteLine(item.Name);
            //}

            //var constructorInfo = type.GetConstructors();

            //Console.WriteLine("The Customer class contains the following Constructors:--");
            //foreach (var item in constructorInfo)
            //{
            //    Console.WriteLine(item);
            //}

            //var methodInfo = type.GetMethods();

            //Console.WriteLine("The methods of the Customer class are:--");
            //foreach (var item in methodInfo)
            //{
            //    Console.WriteLine(item.Name);
            //}
        }

        public static class PdfTextExtractorDemo
        {
            public static string pdfText(string path)
            {
                PdfReader reader = new PdfReader(path);
                string text = string.Empty;
                for (int page = 1; page <= reader.NumberOfPages; page++)
                {
                    text += PdfTextExtractor.GetTextFromPage(reader, page);
                }
                reader.Close();
                return text;
            }


           

public static void ExtractPages(string sourcePDFpath, string outputPDFpath, int startpage, int endpage)
            {
                PdfReader reader = null;
                Document sourceDocument = null;
                PdfCopy pdfCopyProvider = null;
                PdfImportedPage importedPage = null;

                reader = new PdfReader(sourcePDFpath);
                sourceDocument = new Document(reader.GetPageSizeWithRotation(startpage));
                string file_name = System.IO.Path.GetFileNameWithoutExtension(sourcePDFpath);
                outputPDFpath = System.IO.Path.Combine(outputPDFpath, "archive_" + file_name + ".pdf");
                pdfCopyProvider = new PdfCopy(sourceDocument, new System.IO.FileStream(outputPDFpath, System.IO.FileMode.Create));

                sourceDocument.Open();

                for (int i = startpage; i <= endpage; i++)
                {
                    importedPage = pdfCopyProvider.GetImportedPage(reader, i);
                    pdfCopyProvider.AddPage(importedPage);
                }
                sourceDocument.Close();
                reader.Close();
            }
        }



        private static void GeneratePdf()
        {
            Document doc = new Document();
            PdfPTable tableLayout = new PdfPTable(4);

            //PdfWriter.GetInstance(doc, File.Create("Sample-PDF-File.pdf"));
            //string pathToFiles = Server.MapPath("/UploadedFiles");
            //PdfWriter.GetInstance(doc, new FileStream(HostingEnvironment.MapPath("Sample-PDF-File.pdf"), FileMode.Create));



            doc.Open();
            //Add Content to PDF  
            doc.Add(Add_Content_To_PDF(tableLayout));
            // Closing the document  
            doc.Close();
          
        }

        private static PdfPTable Add_Content_To_PDF(PdfPTable tableLayout)
        {
            float[] headers = {
        20,
        20,
        30,
        30
    }; //Header Widths  
            tableLayout.SetWidths(headers); //Set the pdf headers  
            tableLayout.WidthPercentage = 80; //Set the PDF File witdh percentage  
                                              //Add Title to the PDF file at the top  
            tableLayout.AddCell(new PdfPCell(new Phrase("Creating PDF file using iTextsharp", new Font(Font.FontFamily.HELVETICA, 13, 1, new iTextSharp.text.BaseColor(0, 51, 102))))
            {
                Colspan = 4,
                Border = 0,
                PaddingBottom = 20,
                HorizontalAlignment = Element.ALIGN_CENTER
            });
            //Add header  
            AddCellToHeader(tableLayout, "Cricketer Name");
            AddCellToHeader(tableLayout, "Height");
            AddCellToHeader(tableLayout, "Born On");
            AddCellToHeader(tableLayout, "Parents");
            //Add body  
            AddCellToBody(tableLayout, "Sachin Tendulkar");
            AddCellToBody(tableLayout, "1.65 m");
            AddCellToBody(tableLayout, "April 24, 1973");
            AddCellToBody(tableLayout, "Ramesh Tendulkar, Rajni Tendulkar");
            AddCellToBody(tableLayout, "Mahendra Singh Dhoni");
            AddCellToBody(tableLayout, "1.75 m");
            AddCellToBody(tableLayout, "July 7, 1981");
            AddCellToBody(tableLayout, "Devki Devi, Pan Singh");
            AddCellToBody(tableLayout, "Virender Sehwag");
            AddCellToBody(tableLayout, "1.70 m");
            AddCellToBody(tableLayout, "October 20, 1978");
            AddCellToBody(tableLayout, "Aryavir Sehwag, Vedant Sehwag");
            AddCellToBody(tableLayout, "Virat Kohli");
            AddCellToBody(tableLayout, "1.75 m");
            AddCellToBody(tableLayout, "November 5, 1988");
            AddCellToBody(tableLayout, "Saroj Kohli, Prem Kohli");
            return tableLayout;
        }
        // Method to add single cell to the header  
        private static void AddCellToHeader(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.WHITE)))
            {
                HorizontalAlignment = Element.ALIGN_CENTER,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(0, 51, 102)
            });
        }
        // Method to add single cell to the body  
        private static void AddCellToBody(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_CENTER,
                Padding = 5,
                BackgroundColor = iTextSharp.text.BaseColor.WHITE
            });
        }
    }
}
