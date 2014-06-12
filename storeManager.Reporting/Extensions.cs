using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Drawing;

namespace storeManager.Reporting
{
    public static class Extensions
    {
        public static int ToInt(this string value)
        {
            return int.Parse(value);
        }

        public static int ToInt(this object value)
        {
            return int.Parse(value.ToString());
        }

        public static decimal ToDecimal(this object value)
        {
            return decimal.Parse(value.ToString());
        }

        public static decimal ToDecimal(this string value)
        {
            return decimal.Parse(value);
        }

        public static void DetermineSelectedIndex(this ComboBox cmb)
        {
            cmb.SelectedIndex = cmb.Items.Count > 0 ? 0 : -1;
        }

        public static void Select(this ComboBox cmb, string text)
        {
            int idx = cmb.FindStringExact(text);

            if (idx < 0) return;

            cmb.SelectedIndex = idx;
        }

        //public static void PopulateListView<T>(this ListView lv,IEnumerable<T> data) where T:storeManager.Entities.Interfaces.IBaseEntity
        //{
        //    DataTable dt;
            
        //    IEnumerable<T> _data = data;
        //    dt = UtilityClass.MapCollectionToDataTable(data);

        //    lv.Items.Clear();
        //    UtilityClass.PopulateListviewWithDataTable(lv, dt);
        //}

        public static bool ValidateTexBox(this TextBox txt, string msg)
        {
            string text = string.Empty;
            text = txt.Text.Trim();

            if (text == string.Empty)
            {
                try
                {
                    UtilityClass.ShowMessage(msg, "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
    }
}
