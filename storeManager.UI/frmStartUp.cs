using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Threading;

using BusinessLayer;
using BusinessLayer.Interfaces;
using storeManager.Entities;
using storeManager.Entities.Interfaces;

using Microsoft.PointOfService;
using System.Linq;
using System.IO;
using System.Configuration;

namespace storeManager.UI
{
    public partial class frmStartUp : Telerik.WinControls.UI.RadForm
    {
        PosPrinter m_Printer = null;
        IErrorService _logger;

        delegate void InitializePosPrinter();
        delegate void CheckDBInstallation();

        public frmStartUp()
        {
            InitializeComponent();
            _logger = new ErrorLogService();
            SetUpProgressBar();
        }

        void SetUpProgressBar()
        {
            pgStartUpProgress.Maximum = 100;
            pgStartUpProgress.Enabled = true;

        }

        void UpdateProgress(int value)
        {
            if (pgStartUpProgress.InvokeRequired)
            {
                pgStartUpProgress.Invoke(new Action(() => {
                    if (pgStartUpProgress.Value1 > 100)
                        pgStartUpProgress.Value1 = 0;

                    pgStartUpProgress.Value1 += value;
                
                }));
            }         
        }

        private void frmStartUp_Shown(object sender, EventArgs e)
        {
            lblLoadStatus.Text = "Starting system initialization...";
            //Thread.Sleep(1000);

            CheckDBInstallation checkDB = new CheckDBInstallation(RestoreDatabase);

            SetStatusMessage("Checking Database installation");

            checkDB.BeginInvoke((checkDBres) =>
            {
                try
                {
                    CheckDBInstallation checkDBend = checkDBres.AsyncState as CheckDBInstallation;
                    checkDBend.EndInvoke(checkDBres);

                    UpdateProgress(25);
                    SetStatusMessage("Database installation successful");

                    SetStatusMessage("Starting pos printer initialization...");
                }
                catch (Exception ex)
                {
                    Helper.ShowMessage(ex.Message + "\n" + ex.InnerException ?? "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                InitializePosPrinter posprinter = new InitializePosPrinter(InitializePrinter);
                posprinter.BeginInvoke((res =>
                {
                    InitializePosPrinter posprint = res.AsyncState as InitializePosPrinter;
                    posprint.EndInvoke(res);

                    UpdateProgress(25);

                    InitializePosPrinter openposprinter = new InitializePosPrinter(OpenPrinter);
                    openposprinter.BeginInvoke((resopen) =>
                    {
                        InitializePosPrinter openposprint = resopen.AsyncState as InitializePosPrinter;
                        openposprint.EndInvoke(resopen);

                        UpdateProgress(45);

                        InitializePosPrinter claimposprinter = new InitializePosPrinter(ClaimPrinter);
                        claimposprinter.BeginInvoke((claimres) =>
                        {
                            InitializePosPrinter claimposprint = claimres.AsyncState as InitializePosPrinter;
                            claimposprint.EndInvoke(claimres);                      

                            SetStatusMessage("Printer setup successful");

                            UpdateProgress(5);

                            OpenMainForm();

                        }, claimposprinter);

                    }, openposprinter);

                }), posprinter);

            }, checkDB);


        }

        private void OpenMainForm()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    this.Hide();

                    new frmLogIn().ShowDialog();

                    if (CurrentUser.LogInSuccessful)
                    {
                        new frmMain(m_Printer).Show();
                    }

                }), null);
            }
        }

        void InitializePrinter()
        {
            //<<<step1>>>--Start
            //Use a Logical Device Name which has been set on the SetupPOS.
            //string strLogicalName = "PosPrinter";
            string printerName = Properties.Settings.Default.DefaultPrinterName;
            try
            {
                //Create PosExplorer
                PosExplorer posExplorer = new PosExplorer();

                DeviceInfo deviceInfo =
                    PosDeviceInfo.CreatePosDeviceInfoCollection(posExplorer.GetDevices(DeviceType.PosPrinter))
                    .Where(d => d.Description == printerName)
                    .FirstOrDefault().DeviceInfo;

                SetStatusMessage("Checking if device drivers are installed...");

                try
                {
                    //deviceInfo = posExplorer.GetDevice(DeviceType.PosPrinter);
                    m_Printer = (PosPrinter)posExplorer.CreateInstance(deviceInfo);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Application received an error while trying to initialize device.",
                        "frmStartUp", "InitializePrinter");
                    SetStatusMessage("Application received an error while trying to initialize device.");
                    return;
                }
            }
            catch (PosControlException ex)
            {
                _logger.LogError(ex, "Application received an error while trying to initialize device...",
                    "frmStartUp", "InitializePrinter");
                SetStatusMessage("Application received an error while trying to initialize device...");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Application received an error while trying to initialize device...",
                    "frmStartUp", "InitializePrinter");
                SetStatusMessage("Application received an error while trying to initialize device...");
            }
            //<<<step1>>>--End
        }

        private void SetStatusMessage(string msg)
        {
            if (lblLoadStatus.InvokeRequired)
            {
                lblLoadStatus.Invoke(new Action(() =>
                {
                    lblLoadStatus.Text = msg;
                }), null);
            }
        }

        private void ClaimPrinter()
        {
            try
            {
                SetStatusMessage("The application is trying to access printer...");
                //Get the exclusive control right for the opened device.
                //Then the device is disable from other application.
                m_Printer.Claim(1000);

                m_Printer.DeviceEnabled = true;

                //<<<step3>>>--Start
                //Output by the high quality mode
                m_Printer.RecLetterQuality = true;

                //<<<step5>>>--Start
                // Even if using any printers, 0.01mm unit makes it possible to print neatly.
                m_Printer.MapMode = MapMode.Metric;
                //<<<step5>>>--End
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Application received an error while trying to initialize device...",
                    "frmStartUp", "ClaimPrinter");
                SetStatusMessage("Application received an error while trying to initialize device.");
                Thread.Sleep(1000);
            }

        }

        private void OpenPrinter()
        {
            try
            {
                SetStatusMessage("Drivers detected...Attempting to open device...");
                //Open the device
                m_Printer.Open();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Application received an error while trying to initialize device...",
                    "frmStartUp", "OpenPrinter");
                SetStatusMessage("Application received an error while trying open device.");
            }

        }

        void RestoreDatabase()
        {
            SetStatusMessage("Verifying database...");
            if (!Helper.TestDatabaseExists())
            {
                SetStatusMessage("Installing database...");
                DBInstaller installer = new DBInstaller();

                try
                {
                    //string mdfFilePath = Directory.GetFiles(ResourceHelper.WriteResourceToDisk("storeManager.UI.StoreManagerDB.mdf", "StoreManagerDB"), "*.mdf")[0];
                    //string logFilePath = Directory.GetFiles(ResourceHelper.WriteResourceToDisk("storeManager.UI.StoreManagerDB_log.ldf", "StoreManagerDB"), "*.ldf")[0];

                    //installer.AttachDB(mdfFilePath, logFilePath,
                    //    new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["StoreManagerConnString"].ConnectionString));

                    installer.RunDBScript(Properties.Resources.StoremanagerDBScript, Properties.Resources.StoremanagerDBSeedData);
                    //installer.RunDBScript(Properties.Resources.StoremanagerDBSeedData);
                }
                catch (Exception ex)
                {

                    Helper.ShowMessage(ex.Message + " \n" + ex.InnerException ?? "Inner exception is empty" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}
