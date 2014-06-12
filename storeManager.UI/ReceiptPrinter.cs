using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.PointOfService;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        //public Form1()
        //{
        //    InitializeComponent();
        //}

        private void Form1_Load(object sender, EventArgs e)
        {
            PrintReceipt();
        }

        private void PrintReceipt()
        {
            PosPrinter printer = GetReceiptPrinter();

            try
            {
                ConnectToPrinter(printer);

                PrintReceiptHeader(printer, "ABCDEF Pte. Ltd.", "123 My Street, My City,", "My State, My Country", "012-3456789", DateTime.Now, "ABCDEF");

                PrintLineItem(printer, "Item 1", 10, 99.99);
                PrintLineItem(printer, "Item 2", 101, 0.00);
                PrintLineItem(printer, "Item 3", 9, 0.1);
                PrintLineItem(printer, "Item 4", 1000, 1);

                PrintReceiptFooter(printer, 1, 0.1, 0.1, "THANK YOU FOR CHOOSING ABC Ptr. Ltd.");
            }
            finally
            {
                DisconnectFromPrinter(printer);
            }
        }

        private void DisconnectFromPrinter(PosPrinter printer)
        {
            printer.Release();
            printer.Close();
        }

        private void ConnectToPrinter(PosPrinter printer)
        {
            printer.Open();
            printer.Claim(10000);
            printer.DeviceEnabled = true;
        }

        private PosPrinter GetReceiptPrinter()
        {
            PosExplorer posExplorer = new PosExplorer(this);
            DeviceInfo receiptPrinterDevice = posExplorer.GetDevice("PosPrinter", "ReceiptPrinter"); //May need to change this if you don't use a logicial name or use a different one.
            return (PosPrinter)posExplorer.CreateInstance(receiptPrinterDevice);
        }

        private void PrintReceiptFooter(PosPrinter printer, int subTotal, double tax, double discount, string footerText)
        {
            string offSetString = new string(' ', printer.RecLineChars / 2);

            PrintTextLine(printer, new string('-', (printer.RecLineChars / 3) * 2));
            PrintTextLine(printer, offSetString + String.Format("SUB-TOTAL     {0}", subTotal.ToString("#0.00")));
            PrintTextLine(printer, offSetString + String.Format("TAX           {0}", tax.ToString("#0.00")));
            PrintTextLine(printer, offSetString + String.Format("DISCOUNT      {0}", discount.ToString("#0.00")));
            PrintTextLine(printer, offSetString + new string('-', (printer.RecLineChars / 3)));
            PrintTextLine(printer, offSetString + String.Format("TOTAL         {0}", (subTotal - (tax + discount)).ToString("#0.00")));
            PrintTextLine(printer, offSetString + new string('-', (printer.RecLineChars / 3)));
            PrintTextLine(printer, String.Empty);

            //Embed 'center' alignment tag on front of string below to have it printed in the center of the receipt.
            PrintTextLine(printer, System.Text.ASCIIEncoding.ASCII.GetString(new byte[] { 27, (byte)'|', (byte)'c', (byte)'A' }) + footerText);

            //Added in these blank lines because RecLinesToCut seems to be wrong on my printer and
            //these extra blank lines ensure the cut is after the footer ends.
            PrintTextLine(printer, String.Empty);
            PrintTextLine(printer, String.Empty);
            PrintTextLine(printer, String.Empty);
            PrintTextLine(printer, String.Empty);
            PrintTextLine(printer, String.Empty);

            //Print 'advance and cut' escape command.
            PrintTextLine(printer, System.Text.ASCIIEncoding.ASCII.GetString(new byte[] { 27, (byte)'|', (byte)'1', (byte)'0', (byte)'0', (byte)'P', (byte)'f', (byte)'P' }));
        }

        private void PrintLineItem(PosPrinter printer, string itemCode, int quantity, double unitPrice)
        {
            PrintText(printer, TruncateAt(itemCode.PadRight(9), 9));
            PrintText(printer, TruncateAt(quantity.ToString("#0.00").PadLeft(9), 9));
            PrintText(printer, TruncateAt(unitPrice.ToString("#0.00").PadLeft(10), 10));
            PrintTextLine(printer, TruncateAt((quantity * unitPrice).ToString("#0.00").PadLeft(10), 10));
        }

        private void PrintReceiptHeader(PosPrinter printer, string companyName, string addressLine1, string addressLine2, string taxNumber, DateTime dateTime, string cashierName)
        {
            PrintTextLine(printer, companyName);
            PrintTextLine(printer, addressLine1);
            PrintTextLine(printer, addressLine2);
            PrintTextLine(printer, taxNumber);
            PrintTextLine(printer, new string('-', printer.RecLineChars / 2));
            PrintTextLine(printer, String.Format("DATE : {0}", dateTime.ToShortDateString()));
            PrintTextLine(printer, String.Format("CASHIER : {0}", cashierName));
            PrintTextLine(printer, String.Empty);
            PrintText(printer, "item      ");
            PrintText(printer, "qty       ");
            PrintText(printer, "Unit Price ");
            PrintTextLine(printer, "Total      ");
            PrintTextLine(printer, new string('=', printer.RecLineChars));
            PrintTextLine(printer, String.Empty);

        }

        private void PrintText(PosPrinter printer, string text)
        {
            if (text.Length <= printer.RecLineChars)
                printer.PrintNormal(PrinterStation.Receipt, text); //Print text
            else if (text.Length > printer.RecLineChars)
                printer.PrintNormal(PrinterStation.Receipt, TruncateAt(text, printer.RecLineChars)); //Print exactly as many characters as the printer allows, truncating the rest.
        }

        private void PrintTextLine(PosPrinter printer, string text)
        {
            if (text.Length < printer.RecLineChars)
                printer.PrintNormal(PrinterStation.Receipt, text + Environment.NewLine); //Print text, then a new line character.
            else if (text.Length > printer.RecLineChars)
                printer.PrintNormal(PrinterStation.Receipt, TruncateAt(text, printer.RecLineChars)); //Print exactly as many characters as the printer allows, truncating the rest, no new line character (printer will probably auto-feed for us)
            else if (text.Length == printer.RecLineChars)
                printer.PrintNormal(PrinterStation.Receipt, text + Environment.NewLine); //Print text, no new line character, printer will probably auto-feed for us.
        }

        private string TruncateAt(string text, int maxWidth)
        {
            string retVal = text;
            if (text.Length > maxWidth)
                retVal = text.Substring(0, maxWidth);

            return retVal;
        }

    }
}
