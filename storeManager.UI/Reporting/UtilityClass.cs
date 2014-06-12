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

namespace storeManager.Reporting
{
    class UtilityClass
    {
        DataTable dtTypeProp = new DataTable();

        /// <summary>
        /// Clears The Text Property Of All Textbox Controls And ComboBox Controls On The Form
        /// </summary>
        /// <param name="controls">Control Collection</param>
        public static void ClearForm(Control controls)
        {
            foreach (Control control in controls.Controls)
            {
                if (control is  TextBox)
                {
                    control.Text = string.Empty;
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

        public static string GetInvoiceNo()
        {
            SaleService saleService = new SaleService();
            List<string> invoiceNos;
            List<int> nos = new List<int>();

            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            string day = DateTime.Now.Day.ToString();

            month = month.Length == 1 ? "0" + month : month;
            day = day.Length == 1 ? "0" + day : day;

            string invoiceNo = "INV" + year + month + day;

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
                  new DataColumn("Price",typeof(string))
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
    }
}
