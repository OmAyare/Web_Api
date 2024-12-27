using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using Web_Api.Models;
using System.Drawing.Printing;

namespace Web_Api.ViewModels
{
    public class PrinterHelper
    {
        public static void PrintComments(List<Employee> employees)
        {
            if (employees == null || employees.Count == 0)
            {
                MessageBox.Show("No data to print.");
                return;
            }

            // Create a PrintDocument object
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += (sender, e) =>
            {
                // Set the font for printing
                var font = new System.Drawing.Font("Arial", 12);
                float lineHeight = font.GetHeight(e.Graphics);
                float lineWidth = e.PageBounds.Width;

                // Starting point for printing
                float yPos = 20;

                // Loop through each employee and print their name and email
                foreach (var employee in employees)
                {
                    string printText = $"PostId: {employee.PostId}, Id: {employee.Id}, Name: {employee.Name}, Email: {employee.Email}, body: {employee.Body}  ";

                    // Print each line of data
                    e.Graphics.DrawString(printText, font, System.Drawing.Brushes.Black, 10, yPos);

                    yPos += lineHeight; // Move down for the next line  

                    // Stop printing if we reach the end of the page
                    if (yPos > e.PageBounds.Height - lineHeight)
                    {
                        e.HasMorePages = true;
                        return;
                    }
                }

                // No more pages to print
                e.HasMorePages = false;
            };

            // Show the print dialog and print if user agrees
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDocument.Print();
            }
        }
    }

}
