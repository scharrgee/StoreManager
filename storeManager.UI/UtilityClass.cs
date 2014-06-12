using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Reflection;
using storeManager.Entities;
using storeManager.Entities.Interfaces;
using BusinessLayer.Interfaces;
using BusinessLayer;

using Microsoft.PointOfService;
using System.Security.AccessControl;
using System.Security.Principal;

namespace storeManager.UI
{
  public  class Helper
    {

      
        DataTable dtTypeProp = new DataTable();
        public enum IconType
        {
            Success,
            Failure
        }

        static IErrorService _logger;

        static Helper()
        {
            _logger = new ErrorLogService();
        }

        /// <summary>
        /// Clears The Text Property Of All Textbox Controls And ComboBox Controls On The Form
        /// </summary>
        /// <param name="controls">Control Collection</param>
        public static void ClearForm(Control controls)
        {
            foreach (Control control in controls.Controls)
            {

                if (control is TextBox)
                {
                    if (control.Tag == null)
                        control.Text = string.Empty;
                    //if((bool)control.Tag) != false)
                }
                //else
                //    if (control is ComboBox)
                //    {
                //        (control as ComboBox).SelectedIndex = -1;
                //    }

                if (control.HasChildren)
                {
                    ClearForm(control);
                }
            }
        }

        public static void PopulateListviewWithDataTable(ListView lv, DataTable dt)
        {
            //lv.Columns[0].Width = 0;
            //lv.Columns[1].Width = 150;

            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem lvi = lv.Items.Add(dr[0].ToString());

                for (int i = 1; i < dt.Columns.Count; i++)
                {
                    lvi.SubItems.Add(dr[i].ToString());
                }
            }
        }

        public static void PopulateListviewWithCollection<T>(ListView lv, IEnumerable<T> collection) where T : class
        {
            foreach (var dr in collection)
            {

                //ListViewItem lvi = lv.Items.Add(dr[0].ToString());

                //for (int i = 1; i < dt.Columns.Count; i++)
                //{
                //    lvi.SubItems.Add(dr[i].ToString());
                //}
            }
        }

        public static DataTable MapCollectionToDataTable<T>(IEnumerable<T> collection) where T : IBaseEntity
        {
            DataTable dt = CreateTable<T>();

            foreach (var itm in collection)
            {
                DataRow dr = dt.NewRow();

                if (typeof(T) == typeof(Product))
                {

                    dr["ID"] = itm.ID;
                    dr["Name"] = itm.DisplayName;
                    dr["Price"] = ((IProduct)itm).ItemPrice;
                    dr["Measurement"] = new GenericService<Measurement>()
                        .GetSingle(m => m.Id == ((IProduct)itm).ProdMeasurementID).Description;
                }
                if (typeof(T) == typeof(Tax))
                {

                    dr["ID"] = itm.ID;
                    dr["Name"] = itm.DisplayName;
                    dr["TaxRate"] = ((ITax)itm).Rate;
                }
                else
                {
                    dr["ID"] = itm.ID;
                    dr["Name"] = itm.DisplayName;
                }

                dt.Rows.Add(dr);
            }

            return dt;
        }

        public static bool ValidateTexBox(TextBox txt)
        {
            string text = string.Empty;
            text = txt.Text.Trim();

            //ErrorProvider err = new ErrorProvider();
            //frmMessageDialog msg = new frmMessageDialog();

            if (text == string.Empty)
            {
                //ValidationInfoDTO info = (ValidationInfoDTO)txt.Tag;
                //err.SetIconAlignment(txt, ErrorIconAlignment.MiddleRight);

                //err.SetError(txt,info.Name +  " " + info.Message);
                try
                {
                    //msg.ShowMessage(info.Name + " " + info.Message, frmMessageDialog.IconType.Success);
                    //MessageBox.Show(info.Name + " " + info.Message);

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred", "", "");
                    throw;
                }


                txt.BackColor = Color.LightSkyBlue;
                txt.Focus();
                return false;
            }
            else
            {
                txt.BackColor = Color.White;
                return true;
            }
        }

        public static byte[] ImageToByteArray(Image img)
        {
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
        public static Image ByteArrayToImage(byte[] data)
        {
            MemoryStream ms = new MemoryStream(data);
            Image img = new Bitmap(ms);
            return img;
        }

        public static string GetInvoiceNo(string prefix)
        {
            try
            {
                SaleService saleService = new SaleService();
                List<string> invoiceNos;
                List<int> nos = new List<int>();

                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString();
                string day = DateTime.Now.Day.ToString();

                month = month.Length == 1 ? "0" + month : month;
                day = day.Length == 1 ? "0" + day : day;

                string invoiceNo = prefix + year + month + day;

                invoiceNos = saleService.GetInvoiceNos(invoiceNo);

                if (invoiceNos.Count == 0)
                    return invoiceNo + "00001";

                invoiceNos.ForEach(delegate(string s)
                {
                    nos.Add(s.Substring(11, 5).ToInt());
                });

                string digit = (nos.Max() + 1).ToString();

                return invoiceNo + GetPaddingZeros(digit);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }

        }

        public static void MakeReadOnly(Control ctr)
        {
            TextBox txt;
            foreach (Control con in ctr.Controls)
            {
                if (con is TextBox)
                {
                    txt = con as TextBox;
                    txt.ReadOnly = true;
                }

                MakeReadOnly(con);
            }
        }

        private static DataTable CreateTable<T>() where T : IBaseEntity
        {
            DataTable dt = new DataTable();
            DataColumn[] cols;

            if (typeof(T) == typeof(Product))
            {
                cols = new DataColumn[]{new DataColumn("ID",typeof(string)),
                new DataColumn("Name",typeof(string)),
                new DataColumn("Price",typeof(string)),
                new DataColumn("Measurement",typeof(string))
            };
            }
            else if (typeof(T) == typeof(Tax))
            {
                cols = new DataColumn[]{new DataColumn("ID",typeof(string)),
                new DataColumn("Name",typeof(string)),
                 new DataColumn("TaxRate",typeof(string))
            };
            }
            else
            {
                cols = new DataColumn[]{new DataColumn("ID",typeof(string)),
                new DataColumn("Name",typeof(string))
            };
            }

            dt.Columns.AddRange(cols);

            return dt;
        }

        private static string GetPaddingZeros(string no)
        {
            string pad = "0000000000";

            return pad.Substring(0, 5 - no.Length) + no;
        }

        public DataTable MapEntityPropertiesToDataTable<T>(T entity) where T : new()
        {
            Type type = typeof(T);
            dtTypeProp = new DataTable();

            foreach (PropertyInfo propInfo in type.GetProperties())
            {
                CreateTableColumn(propInfo.Name);
            }

            return dtTypeProp;
        }

        private void CreateTableColumn(string colName)
        {
            dtTypeProp.Columns.Add(new DataColumn(colName, typeof(string)));
        }

        public static T CreateInstanceFor<T>(string form) where T : class,new()
        {
            T frm = Application.OpenForms[form] as T;

            if (frm != null)
                return frm;

            return default(T);
        }

        public static DialogResult ShowMessage(string msg, string title, MessageBoxButtons btns, MessageBoxIcon icon)
        {
            return MessageBox.Show(msg, title, btns, icon);
        }

        public static void WaitCursor(Control control)
        {
            control.Cursor = Cursors.WaitCursor;
        }

        public static void DefaultCursor(Control control)
        {
            control.Cursor = Cursors.Default;
        }

        private static bool HasEditAccessRight(ApplicationFroms form)
        {
            //if (form == null) return false;

            AccessRight right = new GenericService<AccessRight>().GetSingle(a => a.FormID == form.ToString() && a.UserID == CurrentUser.User.UserID && a.CanEdit.Value == true);
            return right == null ? false : right.CanEdit.Value;
        }

        private static bool HasViewAccessRight(ApplicationFroms form)
        {
            //if (form == null) return false;

            AccessRight right = new GenericService<AccessRight>().GetSingle(a => a.FormID == form.ToString() && a.UserID == CurrentUser.User.UserID && a.CanView.Value == true);
            return right == null ? false : right.CanView.Value;
        }

        public static bool HasWriteAccess(ApplicationFroms form)
        {
            if (!HasEditAccessRight(form))
            {
                Helper.ShowMessage("You dont have permission to make changes to this form", "Access Control", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        public static bool HasViewAccess(ApplicationFroms form)
        {
            if (!HasViewAccessRight(form))
            {
                Helper.ShowMessage("You dont have access right to view this form", "Access Control", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        public static void CheckUserRight(Control uccontrol)
        {
            ApplicationFroms control;

            Enum.TryParse<ApplicationFroms>(uccontrol.Name, out control);
            if (!HasWriteAccess(control))
                uccontrol.Visible = false;
        }

        public static bool IsAdmin()
        {
            if (!CurrentUser.User.IsAdmin.Value)
            {
                ShowMessage("You dont have permission to view this form", "Access Control", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        public static bool TestDatabaseExists()
        {
            String connString = ConfigurationHelper.TestDbConnectionString;
            
            Boolean bRet;

            System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(connString);
            String cmdText = ("select * from master.dbo.sysdatabases where name= '" + "StoreManagerDB" + "'");

            System.Data.SqlClient.SqlCommand sqlCmd = new System.Data.SqlClient.SqlCommand(cmdText, sqlConnection);

            try
            {
                sqlConnection.Open();
                System.Data.SqlClient.SqlDataReader reader = sqlCmd.ExecuteReader();
                bRet = reader.HasRows;
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                bRet = false;
                sqlConnection.Close();
                MessageBox.Show(e.Message);
                return false;
            }

            return bRet;
        }

        private static IEnumerable<int> GetQuantityList(int productID, DataGridView grid)
        {
            if (grid.Rows.Count > 0)
            {
                foreach (DataGridViewRow gr in grid.Rows)
                {
                    if (gr.Cells[1].Value.ToString() == productID.ToString())
                        yield return int.Parse(gr.Cells[0].Value.ToString());
                }

            }

            yield return 0;
        }

        public static void SetControlName(string controlName)
        {
            frmMain main = CreateInstanceFor<frmMain>("frmMain");
            main.ControlName = controlName;
        }

        public static bool HaveEnoughProductQuantityToFulfillSale(int productID, int locationID, int enteredQty, DataGridView grid, string productName)
        {
            int qty = new ProductService().GetCurrentStock(productID, locationID);

            IEnumerable<int> lineQty = GetQuantityList(productID, grid);

            if (GetTotalItemQtyInLine(lineQty) + enteredQty > qty)
            {
                Helper.ShowMessage("The quantity of this product " + "\""
                    + productName + "\"" + " you have entered is more than the number in your inventory,The product's current quantity is " + qty + " ,Please decrease the product's quantity",
                    "Requested Quantity Not Available", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (qty < enteredQty)
            {
                Helper.ShowMessage("The quantity of this product " + "\""
                    + productName + "\"" + " you have entered is more than the number in your inventory,The product's current quantity is " + qty + " ,Please decrease the product's quantity",
                    "Requested Quantity Not Available", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private static int GetTotalItemQtyInLine(IEnumerable<int> lineQty)
        {
            int lineItemQty = 0;

            foreach (var qty in lineQty)
            {
                lineItemQty += qty;
            }

            return lineItemQty;
        }

        public static List<Location> LoadLocations()
        {
            return new GenericService<Location>().GetAll().ToList();
        }

        public static List<SaleStatus> LoadSaleStatuses()
        {
            return new GenericService<SaleStatus>().GetAll().ToList();
        }

        public static List<Customer> LoadCustomers()
        {
            return new GenericService<Customer>().GetAll().ToList();
        }

        public static List<Employee> LoadEmployees()
        {
            return new GenericService<Employee>().GetAll().ToList();
        }

        public static List<Tax> LoadTaxes()
        {
            List<Tax> taxes = new List<Tax>
            {
                 new Tax(){ TaxID = 0, TaxName = "No Tax"}
            };

            taxes.AddRange(new GenericService<Tax>().GetAll().ToList());

            return taxes;
        }

        public static List<PaymentMode> LoadPaymentModes()
        {
            return new GenericService<PaymentMode>().GetAll().ToList();
        }

    }

    public class MersenneTwister
    {
        // Class MersenneTwister generates random numbers
        // from a uniform distribution using the Mersenne
        // Twister algorithm.
        private const int N = 624;
        private const int M = 397;
        private const uint MATRIX_A = 0x9908b0dfU;
        private const uint UPPER_MASK = 0x80000000U;
        private const uint LOWER_MASK = 0x7fffffffU;
        private const int MAX_RAND_INT = 0x7fffffff;
        private uint[] mag01 = { 0x0U, MATRIX_A };
        private uint[] mt = new uint[N];
        private int mti = N + 1;
        public MersenneTwister()
        { init_genrand((uint)DateTime.Now.Millisecond); }
        public MersenneTwister(int seed)
        {
            init_genrand((uint)seed);
        }

        public MersenneTwister(int[] init)
        {
            uint[] initArray = new uint[init.Length];
            for (int i = 0; i < init.Length; ++i)
                initArray[i] = (uint)init[i];
            init_by_array(initArray, (uint)initArray.Length);
        }
        public static int MaxRandomInt
        { get { return 0x7fffffff; } }
        public int Next()
        { return genrand_int31(); }
        public int Next(int maxValue)
        { return Next(0, maxValue); }
        public int Next(int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                int tmp = maxValue;
                maxValue = minValue;
                minValue = tmp;
            }
            return (int)(Math.Floor((maxValue - minValue + 1) * genrand_real1() +
            minValue));
        }
        public float NextFloat()
        { return (float)genrand_real2(); }
        public float NextFloat(bool includeOne)
        {
            if (includeOne)
            {
                return (float)genrand_real1();
            }
            return (float)genrand_real2();
        }
        public float NextFloatPositive()
        { return (float)genrand_real3(); }
        public double NextDouble()
        { return genrand_real2(); }
        public double NextDouble(bool includeOne)
        {
            if (includeOne)
            {
                return genrand_real1();
            }
            return genrand_real2();
        }

        public double NextDoublePositive()
        { return genrand_real3(); }
        public double Next53BitRes()
        { return genrand_res53(); }
        public void Initialize()
        { init_genrand((uint)DateTime.Now.Millisecond); }
        public void Initialize(int seed)
        { init_genrand((uint)seed); }
        public void Initialize(int[] init)
        {
            uint[] initArray = new uint[init.Length];
            for (int i = 0; i < init.Length; ++i)
                initArray[i] = (uint)init[i];
            init_by_array(initArray, (uint)initArray.Length);
        }
        private void init_genrand(uint s)
        {
            mt[0] = s & 0xffffffffU;
            for (mti = 1; mti < N; mti++)
            {
                mt[mti] = (uint)(1812433253U * (mt[mti - 1] ^ (mt[mti - 1] >> 30)) + mti);
                mt[mti] &= 0xffffffffU;
            }
        }
        private void init_by_array(uint[] init_key, uint key_length)
        {
            int i, j, k;
            init_genrand(19650218U);
            i = 1; j = 0;
            k = (int)(N > key_length ? N : key_length);
            for (; k > 0; k--)
            {
                mt[i] = (uint)((uint)(mt[i] ^ ((mt[i - 1] ^ (mt[i - 1] >> 30)) * 1664525U)) + init_key[j] + j);
                mt[i] &= 0xffffffffU;
                i++; j++;
                if (i >= N) { mt[0] = mt[N - 1]; i = 1; }
                if (j >= key_length) j = 0;
            }
            for (k = N - 1; k > 0; k--)
            {
                mt[i] = (uint)((uint)(mt[i] ^ ((mt[i - 1] ^ (mt[i - 1] >> 30)) *
                1566083941U)) - i);
                mt[i] &= 0xffffffffU;
                i++;
                if (i >= N) { mt[0] = mt[N - 1]; i = 1; }
            }
            mt[0] = 0x80000000U;
        }

        uint genrand_int32()
        {
            uint y;
            if (mti >= N)
            {
                int kk;
                if (mti == N + 1)
                    init_genrand(5489U);
                for (kk = 0; kk < N - M; kk++)
                {
                    y = (mt[kk] & UPPER_MASK) | (mt[kk + 1] & LOWER_MASK);
                    mt[kk] = mt[kk + M] ^ (y >> 1) ^ mag01[y & 0x1U];
                }
                for (; kk < N - 1; kk++)
                {
                    y = (mt[kk] & UPPER_MASK) | (mt[kk + 1] & LOWER_MASK);
                    mt[kk] = mt[kk + (M - N)] ^ (y >> 1) ^ mag01[y & 0x1U];
                }
                y = (mt[N - 1] & UPPER_MASK) | (mt[0] & LOWER_MASK);
                mt[N - 1] = mt[M - 1] ^ (y >> 1) ^ mag01[y & 0x1U];
                mti = 0;
            }
            y = mt[mti++];
            y ^= (y >> 11);
            y ^= (y << 7) & 0x9d2c5680U;
            y ^= (y << 15) & 0xefc60000U;
            y ^= (y >> 18);
            return y;
        }
        private int genrand_int31()
        { return (int)(genrand_int32() >> 1); }
        double genrand_real1()
        { return genrand_int32() * (1.0 / 4294967295.0); }
        double genrand_real2()
        { return genrand_int32() * (1.0 / 4294967296.0); }
        double genrand_real3()
        {
            return (((double)genrand_int32()) + 0.5) * (1.0 / 4294967296.0);
        }
        double genrand_res53()
        {
            uint a = genrand_int32() >> 5, b = genrand_int32() >> 6;
            return (a * 67108864.0 + b) * (1.0 / 9007199254740992.0);
        }
    }

    public class PosDeviceInfo
    {
        public DeviceInfo DeviceInfo { get; set; }
        public string LogicalName { get; set; }
        public string Description { get; set; }

        public static IEnumerable<PosDeviceInfo> CreatePosDeviceInfoCollection(DeviceCollection devices)
        {
            foreach (DeviceInfo dev in devices)
            {
                yield return new PosDeviceInfo
                {
                    Description = dev.Description,
                    DeviceInfo = dev,
                    LogicalName = CombineNames(dev.LogicalNames)
                };
            }
        }

        public override string ToString()
        {
            return Description;// + " [" + LogicalName == "" ? "N/A" : LogicalName + "]";
        }

        static string CombineNames(string[] names)
        {
            string s = "";
            foreach (string name in names)
            {
                if (s.Length > 0)
                    s += ';';
                s += name;
            }

            return s;
        }
    }

    public class ResourceHelper
    {
        public static string ExtractEmbededResource(string resourceName)
        {

            //look for the resource name
            resourceName = "." + resourceName;
            foreach (string currentResource in Assembly.GetExecutingAssembly().GetManifestResourceNames())
            {
                if (currentResource.LastIndexOf(resourceName) != -1)
                {
                    string fqnTempFile = System.IO.Path.GetTempFileName();
                    string path = System.IO.Path.GetDirectoryName(fqnTempFile);
                    string rootName = System.IO.Path.GetFileNameWithoutExtension(fqnTempFile);
                    string destFile = path + @"\" + rootName + System.IO.Path.GetExtension(currentResource);

                    System.IO.Stream fs = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(currentResource);
                    byte[] buff = new byte[fs.Length];
                    fs.Read(buff, 0, (int)fs.Length);
                    fs.Close();

                    System.IO.FileStream destStream = new System.IO.FileStream(destFile, FileMode.Create);
                    destStream.Write(buff, 0, buff.Length);
                    destStream.Close();
                    return destFile;
                }
            }
            return "";
        }

        public static string WriteResourceToDisk(string resourceName,string filename)
        {
            Assembly assem = Assembly.GetExecutingAssembly();
            string folderPath = CreateFileToWriteTo(filename);
            string ext = Path.GetExtension(resourceName);
            string name = Path.GetFileNameWithoutExtension(resourceName).Split(".".ToCharArray())[1];

            FileSecurity fSecurity = File.GetAccessControl(folderPath);
            WindowsIdentity wi = WindowsIdentity.GetCurrent();

            // Add the FileSystemAccessRule to the security settings.
            fSecurity.AddAccessRule(new FileSystemAccessRule(wi.Name, FileSystemRights.FullControl, AccessControlType.Allow));

            // Set the new access settings.
            File.SetAccessControl(folderPath, fSecurity);

            using (Stream stream = assem.GetManifestResourceStream(resourceName))
            {
                ReadWriteStream(stream, File.Create(folderPath + "\\" + name + ext));
            }

            return folderPath;
        }

        // readStream is the stream you need to read
        // writeStream is the stream you want to write to
        private static void ReadWriteStream(Stream readStream, Stream writeStream)
        {
            int length = (int)readStream.Length;
            Byte[] buffer = new Byte[readStream.Length];
            int bytesRead = readStream.Read(buffer, 0, length);
            // write the required bytes
            while (bytesRead > 0)
            {
                writeStream.Write(buffer, 0, bytesRead);
                bytesRead = readStream.Read(buffer, 0, length);
            }
            readStream.Close();
            writeStream.Close();
        }

        private static string CreateFileToWriteTo(string filename)
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\" + filename;
            DirectoryInfo info;

            if (Directory.Exists(folderPath))
                info = new DirectoryInfo((Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\" + filename));
            else
                info = Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\" + filename);
            return info.FullName;
        }
    }
}
