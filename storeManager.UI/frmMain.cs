using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using storeManager.UI.Controls;
using storeManager.UI.Reporting;
using BusinessLayer;
using BusinessLayer.Interfaces;
using storeManager.Entities;
using storeManager.Entities.Interfaces;

using System.Linq;

using Microsoft.PointOfService;

namespace storeManager.UI
{
    public partial class frmMain : Telerik.WinControls.UI.RadForm
    {
        List<Control> _controls = new List<Control>();
        PosPrinter m_Printer = null;
        private PosExplorer posExplorer;
        private Scanner activeScanner;
        IErrorService _logger;

        public frmMain()
        {
            InitializeComponent();
            _logger = new ErrorLogService();
        }

        public frmMain(PosPrinter posprinter)
        {
            InitializeComponent();
            m_Printer = posprinter;
            _logger = new ErrorLogService();
        }

        private void btnNewProduct_Click(object sender, EventArgs e)
        {
            if (!Helper.HasWriteAccess(ApplicationFroms.ucNewProduct)) return;

            Helper.WaitCursor(this);

            HideControls(_controls);

            Suspend();

            ucNewProduct newProduct = new ucNewProduct();
            newProduct.Dock = DockStyle.Fill;

            scContainer.Panel2.Controls.Add(newProduct);
            AddControls(newProduct);

            Resume();

            Helper.DefaultCursor(this);
        }

        private void Resume()
        {
            this.ResumeLayout();
        }

        private void Suspend()
        {
            this.SuspendLayout();
        }

        void HideControls<T>(List<T> controls) where T : Control
        {
            DisposeSearchForm();
            scContainer.Panel2.Controls.Clear();
        }

        private void btnProductList_Click(object sender, EventArgs e)
        {
            if (!Helper.HasViewAccess(ApplicationFroms.ucProductList)) return;

            Helper.WaitCursor(this);

            HideControls(_controls);

            ucProductList list = new ucProductList();
            list.Dock = DockStyle.Fill;

            scContainer.Panel2.Controls.Add(list);
            AddControls(list);

            Helper.DefaultCursor(this);
        }

        void AddControls(Control ctl)
        {
            // _controls.Add(ctl);
        }

        private void tsAddCard_Click(object sender, EventArgs e)
        {
            Helper.WaitCursor(this);
            HideControls(_controls);
            Suspend();

            ucCardInfo card = new ucCardInfo();
            card.Dock = DockStyle.Fill;

            //frmControlHost host = new frmControlHost();
            //host.Controls.Add(card);
            scContainer.Panel2.Controls.Add(card);
            AddControls(card);

            Resume();

            Helper.DefaultCursor(this);

            //host.ShowDialog();
        }

        private void btnProductPricing_Click(object sender, EventArgs e)
        {
            if (!Helper.HasWriteAccess(ApplicationFroms.ucProductPricing)) return;

            Helper.WaitCursor(this);

            HideControls(_controls);

            Suspend();

            ucProductPricing pricing = new ucProductPricing();
            pricing.Dock = DockStyle.Fill;

            scContainer.Panel2.Controls.Add(pricing);
            AddControls(pricing);

            Resume();

            Helper.DefaultCursor(this);
        }

        private void btnAdjustStock_Click(object sender, EventArgs e)
        {
            if (!Helper.HasWriteAccess(ApplicationFroms.ucAdjustStock)) return;

            Helper.WaitCursor(this);

            HideControls(_controls);

            Suspend();

            ucAdjustStock stock = new ucAdjustStock();
            stock.Dock = DockStyle.Fill;

            scContainer.Panel2.Controls.Add(stock);
            AddControls(stock);

            Resume();

            Helper.DefaultCursor(this);
        }

        private void btnTranferStock_Click(object sender, EventArgs e)
        {
            if (!Helper.HasWriteAccess(ApplicationFroms.ucTransferStocks)) return;

            Helper.WaitCursor(this);

            HideControls(_controls);

            Suspend();

            ucTransferStocks stock = new ucTransferStocks();
            stock.Dock = DockStyle.Fill;

            scContainer.Panel2.Controls.Add(stock);
            AddControls(stock);

            Resume();

            Helper.DefaultCursor(this);
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            //if (CurrentUser.User.IsAdmin.Value) return;

            if (!Helper.HasWriteAccess(ApplicationFroms.ucSale)) return;

            Helper.WaitCursor(this);

            HideControls(_controls);

            Suspend();

            ucSale sale = new ucSale();
            sale.Dock = DockStyle.Fill;
            sale.ReceiptPrinter = m_Printer;
            sale.BarCodeSanner = activeScanner;

            scContainer.Panel2.Controls.Add(sale);
            AddControls(sale);

            Resume();

            Helper.DefaultCursor(this);
        }



        private void btnReportList_Click(object sender, EventArgs e)
        {
            if (!Helper.HasViewAccess(ApplicationFroms.frmReportParameters)) return;

            Helper.WaitCursor(this);

            new frmReportParameters().ShowDialog();

            Helper.DefaultCursor(this);
        }

        public void PrepareFormForProductUpdate()
        {
            btnNewProduct.PerformClick();
        }

        private void mnCompany_Click(object sender, EventArgs e)
        {
            new frmAddCompany().ShowDialog();
        }

        private void btnSaleList_Click(object sender, EventArgs e)
        {
            if (!Helper.HasViewAccess(ApplicationFroms.ucSale)) return;

            Helper.WaitCursor(this);

            HideControls(_controls);

            Suspend();

            ucSalesList salelist = new ucSalesList();
            salelist.Dock = DockStyle.Fill;
            salelist.ReceiptPrinter = m_Printer;

            scContainer.Panel2.Controls.Add(salelist);
            AddControls(salelist);

            Resume();

            Helper.DefaultCursor(this);
        }

        private void radButton5_Click(object sender, EventArgs e)
        {
            HideControls(_controls);

            Suspend();

            ucManageSale salelist = new ucManageSale();
            salelist.Dock = DockStyle.Fill;

            scContainer.Panel2.Controls.Add(salelist);
            AddControls(salelist);

            Resume();
        }

        private void mnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsNewSale_Click(object sender, EventArgs e)
        {
            btnSale.PerformClick();
        }

        private void tsNewProd_Click(object sender, EventArgs e)
        {
            btnNewProduct.PerformClick();
        }

        private void tsReports_Click(object sender, EventArgs e)
        {
            btnReportList.PerformClick();
        }

        private void btnQuote_Click(object sender, EventArgs e)
        {
            if (!Helper.HasWriteAccess(ApplicationFroms.ucQuote)) return;

            Helper.WaitCursor(this);

            HideControls(_controls);

            Suspend();

            ucQuote quote = new ucQuote(Prefix.QUO);
            quote.Status = SaleStatuses.Quote;
            //quote.SalePrefix = Prefix.QUO;
            quote.Dock = DockStyle.Fill;

            scContainer.Panel2.Controls.Add(quote);
            AddControls(quote);

            Resume();

            Helper.DefaultCursor(this);
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (!Helper.HasWriteAccess(ApplicationFroms.ucOrder)) return;

            Helper.WaitCursor(this);

            HideControls(_controls);

            Suspend();

            ucQuote order = new ucQuote(Prefix.ORD);
            order.Dock = DockStyle.Fill;
            order.Status = SaleStatuses.Order;
           // order.SalePrefix = Prefix.ORD;

            scContainer.Panel2.Controls.Add(order);
            AddControls(order);

            Resume();

            Helper.DefaultCursor(this);
        }

        private void btnAddBrand_Click(object sender, EventArgs e)
        {
            if (!Helper.IsAdmin()) return;

            Helper.WaitCursor(this);
            frmSetupDetails frm = new frmSetupDetails();
            frm.LoadGridWithDataDatasource<Entities.Brand>(() =>
            {
                return new BusinessLayer.GenericService<Entities.Brand>().GetAll().ToList();
            });

            frm.SetFormTitle = "Brand Set up";
            frm.SetGroupBoxTitle = "Brand List";

            frm.ShowDialog();
            Helper.DefaultCursor(this);
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            if (!Helper.IsAdmin()) return;

            Helper.WaitCursor(this);
            frmSetupDetails frm = new frmSetupDetails();
            frm.LoadGridWithDataDatasource<Entities.Category>(() =>
            {
                return new BusinessLayer.GenericService<Entities.Category>().GetAll().ToList();
            });

            frm.SetFormTitle = "Category Set up";
            frm.SetGroupBoxTitle = "Category List";
            frm.ShowDialog();
            Helper.DefaultCursor(this);
        }

        private void btnAddTax_Click(object sender, EventArgs e)
        {
            if (!Helper.IsAdmin()) return;

            Helper.WaitCursor(this);
            new frmAddTax().ShowDialog();
            Helper.DefaultCursor(this);
        }

        private void btnAddLocation_Click(object sender, EventArgs e)
        {
            if (!Helper.IsAdmin()) return;

            Helper.WaitCursor(this);

            frmSetupDetails frm = new frmSetupDetails();
            frm.LoadGridWithDataDatasource<Entities.Location>(() =>
            {
                return new BusinessLayer.GenericService<Entities.Location>().GetAll();
            });

            frm.SetFormTitle = "Location Set up";
            frm.SetGroupBoxTitle = "Location List";
            frm.ShowDialog();

            Helper.DefaultCursor(this);
        }

        //private bool IsAdmin()
        //{
        //    if (!CurrentUser.User.IsAdmin.Value)
        //    {
        //        UtilityClass.ShowMessage("You dont have permission to view this form", "Access Control", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return false;
        //    }

        //    return true;
        //}

        private void frmMain_Shown(object sender, EventArgs e)
        {
            //new frmLogIn().ShowDialog();
        }

        private void btnCountSheet_Click(object sender, EventArgs e)
        {
            if (!Helper.HasViewAccess(ApplicationFroms.ucCurrentStock)) return;

            Helper.WaitCursor(this);

            HideControls(_controls);

            ucCurrentStock list = new ucCurrentStock();
            list.Dock = DockStyle.Fill;

            scContainer.Panel2.Controls.Add(list);
            AddControls(list);

            Helper.DefaultCursor(this);
        }

        //void InitializePrinter()
        //{
        //    //<<<step1>>>--Start
        //    //Use a Logical Device Name which has been set on the SetupPOS.
        //    string strLogicalName = "PosPrinter";
        //    try
        //    {
        //        //Create PosExplorer
        //        posExplorer = new PosExplorer();

        //        DeviceInfo deviceInfo = null;

        //        try
        //        {
        //            deviceInfo = posExplorer.GetDevice(DeviceType.PosPrinter, strLogicalName);
        //            m_Printer = (PosPrinter)posExplorer.CreateInstance(deviceInfo);
        //        }
        //        catch (Exception)
        //        {
        //            //ChangeButtonStatus();
        //            return;
        //        }

        //        //Open the device
        //        m_Printer.Open();

        //        //Get the exclusive control right for the opened device.
        //        //Then the device is disable from other application.
        //        m_Printer.Claim(1000);

        //        //Enable the device.
        //        m_Printer.DeviceEnabled = true;

        //        //<<<step3>>>--Start
        //        //Output by the high quality mode
        //        m_Printer.RecLetterQuality = true;

        //        //<<<step5>>>--Start
        //        // Even if using any printers, 0.01mm unit makes it possible to print neatly.
        //        m_Printer.MapMode = MapMode.Metric;
        //        //<<<step5>>>--End
        //    }
        //    catch (PosControlException ex)
        //    {
        //        _logger.LogError(ex, "An error occurred", "frmMain", "InitializePrinter");
        //    }
        //    //<<<step1>>>--End
        //}

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DisposePrinter();

            Application.Exit();
        }

        private void DisposePrinter()
        {
            if (m_Printer != null)
            {
                try
                {
                    //Cancel the device
                    m_Printer.DeviceEnabled = false;

                    //Release the device exclusive control right.
                    m_Printer.Release();

                    //Finish using the device.
                    m_Printer.Close();
                }
                catch (PosControlException ex)
                {
                    _logger.LogError(ex, "An error occurred", "frmMain", "DeactivateScanner");
                }
                finally
                {

                    Application.Exit();
                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (new GenericService<Company>().GetAll().ToList().Count == 0)
            {
                new frmAddCompany().ShowDialog();
            }

            SetUserName();

            try
            {
                this.BeginInvoke(new Action(() =>
                {
                    try
                    {
                        posExplorer = new PosExplorer(this);
                        string barocodename = Properties.Settings.Default.DefaultScannerName;
                        DeviceInfo deviceInfo =
                        PosDeviceInfo.CreatePosDeviceInfoCollection(posExplorer.GetDevices(DeviceType.Scanner))
                       .Where(d => d.Description == barocodename)
                       .FirstOrDefault().DeviceInfo;

                        ActivateScanner(deviceInfo);
                    }
                    catch (PosControlException ex)
                    {
                        _logger.LogError(ex, "The application received an error ", "frmMain", "ActivateScanner");
                        Helper.ShowMessage("The application received an error  \n" + ex.Message,
                            "Test Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    catch (Exception ex)
                    {
                        Helper.ShowMessage(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        _logger.LogError(ex, "An error occurred", "frmMain", "scanner initialization");
                    }

                }));
            }

            catch (Exception ex)
            {
                Helper.ShowMessage(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.LogError(ex, "An error occurred", "frmMain", "scanner initialization");
            }
        }

        private void btnCompanySettings_Click(object sender, EventArgs e)
        {
            if (!Helper.HasViewAccess(ApplicationFroms.frmAddCompany)) return;

            new frmAddCompany().ShowDialog();
        }

        private void btnMeasurement_Click(object sender, EventArgs e)
        {
            if (!Helper.IsAdmin()) return;

            Helper.WaitCursor(this);
            frmSetupDetails frm = new frmSetupDetails();
            frm.LoadGridWithDataDatasource<Entities.Measurement>(() =>
            {
                return new BusinessLayer.GenericService<Entities.Measurement>().GetAll().ToList();
            });

            frm.SetFormTitle = "Measurement Set up";
            frm.SetGroupBoxTitle = "Measurement List";
            frm.ShowDialog();
            Helper.DefaultCursor(this);
        }

        private void btnUserSettings_Click(object sender, EventArgs e)
        {
            if (!Helper.IsAdmin()) return;

            new frmAddUser().ShowDialog();
        }

        private void mnSale_Click(object sender, EventArgs e)
        {
            btnSale.PerformClick();
        }

        private void mnOrder_Click(object sender, EventArgs e)
        {
            btnOrder.PerformClick();
        }

        private void mnQuote_Click(object sender, EventArgs e)
        {
            btnQuote.PerformClick();
        }

        private void mnNewProduct_Click(object sender, EventArgs e)
        {
            btnNewProduct.PerformClick();
        }

        private void mnProductList_Click(object sender, EventArgs e)
        {
            btnProductList.PerformClick();
        }

        private void mnProdPricing_Click(object sender, EventArgs e)
        {
            btnProductPricing.PerformClick();
        }

        private void mnAdjustStock_Click(object sender, EventArgs e)
        {
            btnAdjustStock.PerformClick();
        }

        private void mnTransferStock_Click(object sender, EventArgs e)
        {
            btnTranferStock.PerformClick();
        }

        private void mnReports_Click(object sender, EventArgs e)
        {
            btnReportList.PerformClick();
        }



        private void mnLogOff_Click(object sender, EventArgs e)
        {
            new frmLogIn().ShowDialog();
        }

        private void tsLogOut_Click(object sender, EventArgs e)
        {
            mnLogOff.PerformClick();
        }

        private void tsUsers_Click(object sender, EventArgs e)
        {
            btnUserSettings.PerformClick();
        }

        public void SetUserName()
        {
            try
            {
                lblUser.Text = "Current User - " + CurrentUser.User.UserName.ToUpper();
            }
            catch
            {
                Application.Exit();
            }

        }

        private void mnBarcodes_Click(object sender, EventArgs e)
        {
            if (!Helper.IsAdmin()) return;

            new frmGenerateLabels().ShowDialog();
        }

        private void mnReset_Click(object sender, EventArgs e)
        {

        }

        private void mnCurrentStock_Click(object sender, EventArgs e)
        {
            btnCurrentStock.PerformClick();
        }

        private void mnPrintSettings_Click(object sender, EventArgs e)
        {

        }

        private void mnBackup_Click(object sender, EventArgs e)
        {
            new frmDatabaseBackUp().ShowDialog();
        }

        private void mnRestroe_Click(object sender, EventArgs e)
        {
            new frmDatabaseRestore().ShowDialog();
        }

        public void ShowNewProductWindow()
        {
            btnNewProduct.PerformClick();
        }

        private void DeactivateScanner()
        {
            if (activeScanner != null)
            {
                try
                {
                    // Close the active scanner
                    activeScanner.Close();
                }
                catch (PosControlException ex)
                {
                    // Log any error that happens
                    _logger.LogError(ex, "An error occurred", "frmMain", "DeactivateScanner");
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

        private void ActivateScanner(DeviceInfo selectedScanner)
        {
            //Verifify that the selectedScanner is not null
            // and that it is not the same scanner already selected
            if (selectedScanner != null && !selectedScanner.IsDeviceInfoOf(activeScanner))
            {
                // Configure the new scanner
                DeactivateScanner();

                try
                {
                    activeScanner = (Scanner)posExplorer.CreateInstance(selectedScanner);
                    activeScanner.Open();
                    activeScanner.Claim(1000);
                    activeScanner.DeviceEnabled = true;
                    activeScanner.DecodeData = true;
                    activeScanner.DataEventEnabled = true;
                }
                catch (PosControlException ex)
                {
                    // Log error and set the active scanner to none
                    activeScanner = null;
                    _logger.LogError(ex, "An error occurred", "frmMain", "ActivateScanner");
                }
            }
        }

        private void mnHardwaresettings_Click(object sender, EventArgs e)
        {
            new frmHardwareSetup().ShowDialog();
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            //ApplicationFroms control;
            //if (scContainer.Panel2.Controls.Count > 0 && scContainer.Panel2.Controls.Count == 1)
            //{
            //    if (Enum.TryParse<ApplicationFroms>(scContainer.Panel2.Controls[0].Name, out control))
            //    {
            //        if (!UtilityClass.HasReadAccess(control)) scContainer.Panel2.Controls.Clear();
            //    }
            //}
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                Control control = this.scContainer.Panel2.Controls.Find(ControlName, true).FirstOrDefault();

                if (control == null) return;

                RadButton radBtn = null;
                Button btn = null;
                Control btncontrol = null;

                switch (e.KeyCode)
                {
                    case Keys.F1:
                        btncontrol = FindControl(control, "btnRecord");
                        radBtn = btncontrol as RadButton;
                        radBtn.PerformClick();
                        break;
                    case Keys.F2:
                        btncontrol = FindControl(control, "btnChooseProduct");
                        btn = btncontrol as Button;
                        btn.PerformClick();
                        SetFocus(control);
                        break;
                    case Keys.F10:
                        btncontrol = FindControl(control, "btnInsert");
                        btn = btncontrol as Button;
                        btn.PerformClick();
                        break;
                    case Keys.F11:
                        break;
                    case Keys.F12:
                        break;
                    case Keys.F3:
                        btncontrol = FindControl(control, "btnAddCustomer");
                        btn = btncontrol as Button;
                        btn.PerformClick();
                        break;
                    case Keys.F4:
                        break;
                    case Keys.F5:
                        break;
                    case Keys.F6:
                        break;
                    case Keys.F7:
                        break;
                    case Keys.F8:
                        btncontrol = FindControl(control, "btnNew");
                        btn = btncontrol as Button;
                        btn.PerformClick();
                        break;
                    case Keys.F9:
                        btncontrol = FindControl(control, "btnDelete");
                        btn = btncontrol as Button;
                        btn.PerformClick();
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "The application received an error ", "frmMain", "Sales screen key press");
                Helper.ShowMessage("The application received an error  \n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static Control FindControl(Control control, string controlName)
        {
            Control btncontrol = control.Controls.Find(controlName, true).FirstOrDefault();

            return btncontrol;
        }

        void SetFocus(Control control)
        {
            TextBox txt = control.Controls.Find("txtItemName", true).FirstOrDefault() as TextBox;
            txt.Focus();
        }

        public string ControlName { get; set; }

        private void btnManageSales_Click(object sender, EventArgs e)
        {
            frmControlHost host = new frmControlHost();
            host.WindowState = FormWindowState.Normal;
            host.StartPosition = FormStartPosition.CenterParent;
            //host.BackColor = Color.LightBlue;
            ucManageSale control = new ucManageSale();
            control.Dock = DockStyle.Fill;
            host.Controls.Add(control);

            host.ShowDialog();
        }

        void DisposeSearchForm()
        {
            frmChooseItem frm = Helper.CreateInstanceFor<frmChooseItem>("frmChooseItem");
            if (frm != null) frm.Close();
        }
    }
}
