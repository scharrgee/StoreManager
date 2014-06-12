using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Linq;

using Spire.Barcode.Forms;
using Spire.Barcode;
using System.Drawing.Drawing2D;

using storeManager.UI.EventHub;
using BusinessLayer;
using BusinessLayer.Interfaces;
using storeManager.Entities;
using storeManager.Entities.Interfaces;
using storeManager.UI.ViewModels;
using Telerik.WinControls.UI;

namespace storeManager.UI
{
    public partial class frmGenerateLabels : Telerik.WinControls.UI.RadForm
    {
        DataTable dtBarcodes = new DataTable("Barcodes");
        DataSet _ds = new DataSet();
        IErrorService _logger;

        public frmGenerateLabels()
        {
            InitializeComponent();

            LoadComboBoxes();
            CreateColumns();
            rdSequential.IsChecked = true;
            _logger = new ErrorLogService();
        }

        void LoadComboBoxes()
        {
            cmbLabelType.DataSource = Enum.GetNames(typeof(BarCodeType));
            cmbBorderType.DataSource = Enum.GetNames(typeof(DashStyle));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearList();
        }

        void CreateColumns()
        {
            DataColumn colBarcode = new DataColumn("Barcode", typeof(byte[]));
            DataColumn colData = new DataColumn("Data", typeof(string));

            dtBarcodes.Columns.Add(colBarcode);
            dtBarcodes.Columns.Add(colData);

            _ds.Tables.Add(dtBarcodes);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (lbSeries.DataSource == null)
            {
                Helper.ShowMessage("No list has been created yet", "No Barcode List Created", 
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                int qty = txtQuantity.Text == "" ? 1 : txtQuantity.Text.ToInt();
                qty = qty == 0 ? 1 : qty;

                dtBarcodes.Rows.Clear();

                Helper.WaitCursor(this);

                List<string> codeseries = ((IEnumerable<string>)lbSeries.DataSource).ToList();

                codeseries.ForEach(s =>
                {
                    for (int i = 0; i < qty; i++)
                    {
                        DataRow dr = dtBarcodes.NewRow();
                        dr["Barcode"] = Helper.ImageToByteArray(CreateBarCode(s, cmbLabelType.Text));
                        dr["Data"] = s;
                        dtBarcodes.Rows.Add(dr);
                    }

                });

                SaveSettings();

                Reporting.frmReportOutput rep = new Reporting.frmReportOutput();

                rep.RunReport("BarCodePrintingReport", _ds);
                rep.ShowDialog();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "frmGenrateLabel", "btnGenrate");
                Helper.ShowMessage("Brand was not saved successfully \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Helper.DefaultCursor(this);
        }

        private Image CreateBarCode(string data, string type)
        {
            //set the configuration of barcode
            BarcodeSettings settings = new BarcodeSettings();
            string locdata = "12345";
            type = "Code128";

            if (data != null && data.Length > 0)
            {
                locdata = data;
            }

            //settings.Data2D = locdata;
            settings.Data = locdata;

            if (cmbLabelType.SelectedItem != null)
            {
                type = cmbLabelType.SelectedItem.ToString();
            }

            settings.Type = (BarCodeType)Enum.Parse(typeof(BarCodeType), type);

            if (this.chkShowBorder.Checked)
            {
                if (cmbBorderType.SelectedItem != null)
                {
                    settings.HasBorder = true;
                    settings.BorderDashStyle = (DashStyle)Enum.Parse(typeof(DashStyle), cmbBorderType.SelectedItem.ToString());
                }
            }

            short fontSize = 8;
            string font = "SimSun";

            if (this.cmbFont.SelectedItem != null)
            {
                font = this.cmbFont.SelectedItem.ToString();
            }

            if (this.txtSize.Text != null && this.txtSize.Text.Length > 0 && Int16.TryParse(this.txtSize.Text, out fontSize))
            {
                if (font != null && font.Length > 0)
                {
                    settings.TextFont = new System.Drawing.Font(font, fontSize, FontStyle.Bold);
                }
            }

            short barHeight = 15;
            if (this.txtHeight.Text != null && this.txtHeight.Text.Length > 0 && Int16.TryParse(this.txtHeight.Text, out barHeight))
            {
                settings.BarHeight = barHeight;
            }
            if (this.chkShowText.Checked)
            {
                settings.ShowText = true;
            }
            else
            {
                settings.ShowText = false;
            }

            if (this.chkShowChecksum.Checked)
            {
                settings.ShowCheckSumChar = true;
            }
            else
            {
                settings.ShowCheckSumChar = false;
            }

            if (this.cmbColor.SelectedItem != null)
            {
                string foreColor = this.cmbColor.SelectedItem.ToString();
                settings.ForeColor = Color.FromName(foreColor);
            }

            //generate the barcode use the settings
            BarCodeGenerator generator = new BarCodeGenerator(settings);
            Image barcode = generator.GenerateImage();

            return barcode;
        }

        private void btnCreateSeq_Click(object sender, EventArgs e)
        {
            ClearList();

            int start = txtStart.Text.ToInt();
            int end = txtEnd.Text.ToInt();
            int lengh = txtLength.Text.ToInt();

            List<string> series = new List<string>();
            Enumerable.Range(start, end).ToList().ForEach(s =>
            {
                series.Add(GetPaddingZeroes(lengh - s.ToString().Length) + s.ToString());
            });

            lbSeries.DataSource = series;
            lblListTotal.Text = "Total Labels : " + lbSeries.Items.Count;
        }

        private void ClearList()
        {
            lbSeries.DataSource = null;
        }

        private void btnCreateRan_Click(object sender, EventArgs e)
        {
            if (txtTotal.Text == "" || txtTotal.Text == "0")
            {
                Helper.ShowMessage("Number cannot be empty or 0", "Invalid Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ClearList();

            List<string> generatedCodes = new List<string>();
            List<string> existingCodes = GetExistingBarcodes();
            MersenneTwister randGen = new MersenneTwister();

            int counter = 1;
            int totalLabels = txtTotal.Text.ToInt();
            int length = txtLength.Text.ToInt();
            string newcode = "";

            while (counter <= totalLabels)
            {
                string num = randGen.Next().ToString();

                if (existingCodes.Contains(num)) continue;

                if (num.Length > length)
                {
                    num = num.Substring(0, length);
                }

                newcode = GetPaddingZeroes(length - num.Length) + num;

                if (generatedCodes.Contains(newcode)) continue;

                generatedCodes.Add(newcode);
                counter++;
            }

            lbSeries.DataSource = generatedCodes;
            lblListTotal.Text = "Total Labels : " + lbSeries.Items.Count;
        }

        string GetPaddingZeroes(int length)
        {
            string zeroes = "";

            for (int i = 0; i < length; i++)
            {
                zeroes += "0";
            }

            return zeroes;
        }

        private void frmGenerateLabels_Load(object sender, EventArgs e)
        {
            LoadLastSettings();
        }

        void SaveSettings()
        {
            LabelSetting settings;

            if ((settings = new GenericService<LabelSetting>().GetAll().FirstOrDefault()) == null)
            {
                new GenericService<LabelSetting>().Add(new LabelSetting
                {
                    BarcodeType = cmbLabelType.Text,
                    BarHeight = txtHeight.Text.ToInt(),
                    BorderType = cmbBorderType.Text,
                    FontFamily = cmbFont.Text,
                    FontSize = txtSize.Text.ToInt(),
                    ForeColor = cmbColor.Text,
                    LabelLenghth = txtLength.Text.ToInt(),
                    ListEnd = txtEnd.Text.ToInt(),
                    ListStart = txtStart.Text.ToInt(),
                    QtyToPrint = txtQuantity.Text.ToInt(),
                    ShowBorder = chkShowBorder.Checked,
                    ShowCheckSum = chkShowChecksum.Checked,
                    ShowTest = chkShowText.Checked
                });
            }
            else
            {
                new GenericService<LabelSetting>().Update(new LabelSetting
                {
                    BarcodeType = cmbLabelType.Text,
                    BarHeight = txtHeight.Text.ToInt(),
                    BorderType = cmbBorderType.Text,
                    FontFamily = cmbFont.Text,
                    FontSize = txtSize.Text.ToInt(),
                    ForeColor = cmbColor.Text,
                    LabelLenghth = txtLength.Text.ToInt(),
                    ListEnd = txtEnd.Text.ToInt(),
                    ListStart = txtStart.Text.ToInt(),
                    QtyToPrint = txtQuantity.Text.ToInt(),
                    ShowBorder = chkShowBorder.Checked,
                    ShowCheckSum = chkShowChecksum.Checked,
                    ShowTest = chkShowText.Checked,
                    id = settings.id,
                }, l => l.id == settings.id);
            }
        }

        void LoadLastSettings()
        {
            LabelSetting settings = new GenericService<LabelSetting>().GetAll().FirstOrDefault();

            if (settings == null) return;

            cmbLabelType.Text = settings.BarcodeType;
            txtHeight.Text = settings.BarHeight.ToString();
            cmbBorderType.Text = settings.BorderType;
            cmbFont.Text = settings.FontFamily;
            txtSize.Text = settings.FontSize.ToString();
            cmbColor.Text = settings.ForeColor;
            txtLength.Text = settings.LabelLenghth.ToString();
            txtEnd.Text = settings.ListEnd.ToString();
            txtStart.Text = settings.ListStart.ToString();
            txtQuantity.Text = settings.QtyToPrint.ToString();
            chkShowBorder.Checked = settings.ShowBorder.Value;
            chkShowChecksum.Checked = settings.ShowCheckSum.Value;
            chkShowText.Checked = settings.ShowTest.Value;
        }

        List<string> GetExistingBarcodes()
        {
            return new ProductService().GetExistingBarCodes();
        }

        private void rdRandom_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            btnCreateRan.Enabled = rdRandom.IsChecked;
        }

        private void rdSequential_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            btnCreateSeq.Enabled = rdSequential.IsChecked;
        }
    }
}
