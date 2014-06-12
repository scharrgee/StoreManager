using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Linq;

using Microsoft.PointOfService;

using storeManager.UI.EventHub;
using BusinessLayer;
using BusinessLayer.Interfaces;
using storeManager.Entities;
using storeManager.Entities.Interfaces;
using storeManager.UI.ViewModels;
using Telerik.WinControls.UI;

namespace storeManager.UI
{
    public partial class frmHardwareSetup : Telerik.WinControls.UI.RadForm
    {
        PosExplorer _posexplorer;
        private DeviceCollection _printerscannerList;
        private DeviceCollection _barcodescannerList;
        private Scanner activeScanner;
        private PosPrinter activePrinter;
        IErrorService _logger;

        delegate void LoadDevices();

        public frmHardwareSetup()
        {
            InitializeComponent();
            _logger = new ErrorLogService();
        }

        void LoadPrinters()
        {
            try
            {
                _posexplorer = new PosExplorer();
                _printerscannerList = _posexplorer.GetDevices(DeviceType.PosPrinter);

                IEnumerable<PosDeviceInfo> posdevinfo = PosDeviceInfo.CreatePosDeviceInfoCollection(_printerscannerList);

                foreach (PosDeviceInfo item in posdevinfo)
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(() => lbPrinterDevs.Items.Add(item)));
                    }
                }
            }
            catch (PosControlException ex)
            {
                _logger.LogError(ex, "The application received an error ", "frmHardwaresetup", "Load Printer");
                Helper.ShowMessage("The application received an error  \n" + ex.Message,
                    "Test Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "The application received an error ", "frmHardwaresetup", "Load Printer");
                Helper.ShowMessage("The application received an error  \n" + ex.Message,
                    "Test Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        void LoadBarcodes()
        {
            try
            {
                _posexplorer = new PosExplorer();
                _barcodescannerList = _posexplorer.GetDevices(DeviceType.Scanner);

                IEnumerable<PosDeviceInfo> posdevinfo = PosDeviceInfo.CreatePosDeviceInfoCollection(_barcodescannerList);

                foreach (PosDeviceInfo item in posdevinfo)
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(() => lbBarcodeDevs.Items.Add(item)));
                    }
                }
            }
            catch (PosControlException ex)
            {
                _logger.LogError(ex, "The application received an error ", "frmHardwaresetup", "ActivateScanner");
                Helper.ShowMessage("The application received an error  \n" + ex.Message,
                    "Test Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "The application received an error ", "frmHardwaresetup", "ActivateScanner");
                Helper.ShowMessage("The application received an error  \n" + ex.Message,
                    "Test Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmHardwareSetup_Load(object sender, EventArgs e)
        {
            try
            {
                pbPrintersWait.Visible = true;
                pbBarcodeWait.Visible = true;

                LoadDevices pdevices = new LoadDevices(LoadPrinters);

                pdevices.BeginInvoke((res) =>
                {
                    try
                    {
                        LoadDevices printerdevices = res.AsyncState as LoadDevices;
                        printerdevices.EndInvoke(res);

                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action(() =>
                            {
                                pbPrintersWait.Visible = false;
                                LoadDefaultsPrinter();
                            }));

                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "The application received an error ", "frmHardwaresetup", "ActivateScanner");
                        Helper.ShowMessage("The application received an error  \n" + ex.Message,
                            "Test Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);                   
                    }
                   

                }, pdevices);

                LoadDevices bdevices = new LoadDevices(LoadBarcodes);
                bdevices.BeginInvoke((res) =>
                {
                    try
                    {
                        LoadDevices bardevices = res.AsyncState as LoadDevices;
                        bardevices.EndInvoke(res);

                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action(() =>
                            {
                                pbBarcodeWait.Visible = false;
                                LoadDefaultsBarcodeDev();
                            }));

                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "The application received an error ", "frmHardwaresetup", "ActivateScanner");
                        Helper.ShowMessage("The application received an error  \n" + ex.Message,
                            "Test Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    

                }, bdevices);
            }
            catch (PosControlException ex)
            {
                _logger.LogError(ex, "The application received an error ", "frmHardwaresetup", "ActivateScanner");
                Helper.ShowMessage("The application received an error  \n" + ex.Message,
                    "Test Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "The application received an error ", "frmHardwaresetup", "ActivateScanner");
                Helper.ShowMessage("The application received an error  \n" + ex.Message,
                    "Test Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void lbPrinterDevs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnPrintTest_Click(object sender, EventArgs e)
        {
            if (lbPrinterDevs.SelectedItem != null)
            {
                ActivatePrinter(((PosDeviceInfo)lbPrinterDevs.SelectedItem).DeviceInfo);
            }
        }

        private void ActivateScanner(DeviceInfo selectedScanner)
        {
            //Verifify that the selectedScanner is not null
            // and that it is not the same scanner already selected
            if (selectedScanner != null && !selectedScanner.IsDeviceInfoOf(activeScanner))
            {
                // Configure the new scanner
                DeactivateScanner();

                // Activate the new scanner
                try
                {
                    activeScanner = (Scanner)_posexplorer.CreateInstance(selectedScanner);
                    activeScanner.Open();
                    activeScanner.Claim(1000);
                    activeScanner.DeviceEnabled = true;
                    activeScanner.DecodeData = true;
                    activeScanner.DataEventEnabled = true;

                    Helper.ShowMessage("Test successful",
                       "Test Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (PosControlException ex)
                {
                    _logger.LogError(ex, "The application received an error ", "frmHardwaresetup", "ActivateScanner");
                    Helper.ShowMessage("The application received an error  \n" + ex.Message,
                        "Test Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    activeScanner = null;
                }
            }
        }

        private void ActivatePrinter(DeviceInfo selectedPrinter)
        {
            //Verifify that the selectedScanner is not null
            // and that it is not the same scanner already selected
            if (selectedPrinter != null && !selectedPrinter.IsDeviceInfoOf(activePrinter))
            {
                // Configure the new scanner
                DeactivatePrinter();

                // Activate the new scanner
                try
                {
                    activePrinter = (PosPrinter)_posexplorer.CreateInstance(selectedPrinter);
                    activePrinter.Open();
                    activePrinter.Claim(1000);
                    activePrinter.DeviceEnabled = true;

                    Helper.ShowMessage("Test successful",
                      "Test Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (PosControlException ex)
                {
                    _logger.LogError(ex, "The application received an error", "frmHardwaresetup", "ActivatePrinter");
                    Helper.ShowMessage("The application received an error  \n" + ex.Message,
                        "Test Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    activePrinter = null;
                }
            }
        }

        private void DeactivateScanner()
        {
            if (activeScanner != null)
            {
                // We have an active scanner, lets log that we are
                // about to close it.

                try
                {
                    // Close the active scanner
                    activeScanner.Close();
                }
                catch (PosControlException ex)
                {
                    _logger.LogError(ex, "The application received an error", "frmHardwaresetup", "DeactivateScanner");
                    Helper.ShowMessage("The application received an error  \n" + ex.Message,
                        "Test Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Don't forget to set activeScanner to null to
                    // indicate that we no longer have an active
                    // scanner configured.
                    activeScanner = null;
                }
            }
        }

        private void DeactivatePrinter()
        {
            if (activePrinter != null)
            {
                // We have an active scanner, lets log that we are
                // about to close it.

                try
                {
                    // Close the active scanner
                    activePrinter.Close();
                }
                catch (PosControlException ex)
                {
                    _logger.LogError(ex, "The application received an error", "frmHardwaresetup", "DeactivatePrinter");
                    Helper.ShowMessage("The application received an error  \n" + ex.Message,
                        "Test Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Don't forget to set activeScanner to null to
                    // indicate that we no longer have an active
                    // scanner configured.
                    activePrinter = null;
                }
            }
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            if (lbBarcodeDevs.SelectedItem != null)
            {
                ActivateScanner(((PosDeviceInfo)lbBarcodeDevs.SelectedItem).DeviceInfo);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedprinter = "";
                string selectedbarreader = "";

                if (lbPrinterDevs.SelectedItem != null) selectedprinter = lbPrinterDevs.SelectedItem.ToString();
                if (lbBarcodeDevs.SelectedItem != null) selectedbarreader = lbBarcodeDevs.SelectedItem.ToString();

                Properties.Settings.Default.DefaultPrinterName = selectedprinter;
                Properties.Settings.Default.DefaultScannerName = selectedbarreader;
                Properties.Settings.Default.DefaultReceiptFooter = txtRceiptFooter.Text;

                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "The application received an error", "frmHardwaresetup", "save settings");
                Helper.ShowMessage("The application received an error  \n" + ex.Message,
                    "Test Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        void LoadDefaultsPrinter()
        {
            lbPrinterDevs.SelectedItem = Properties.Settings.Default.DefaultPrinterName;
            txtRceiptFooter.Text = Properties.Settings.Default.DefaultReceiptFooter;
        }

        void LoadDefaultsBarcodeDev()
        {
            lbBarcodeDevs.SelectedItem = Properties.Settings.Default.DefaultScannerName;
        }
    }
}
