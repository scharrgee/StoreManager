using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Drawing;

using storeManager.UI;
using BusinessLayer;
using BusinessLayer.Interfaces;
using storeManager.Entities;
using storeManager.Entities.Interfaces;

namespace storeManager.UI.Reporting
{
    public static class Extensions
    {
        static IErrorService _logger;

        static Extensions()
        {
            _logger = new ErrorLogService();
        }

        public static int ToInt(this string value)
        {
            try
            {
                return int.Parse(value);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
           
        }

        public static int ToInt(this object value)
        {
            try
            {
                return int.Parse(value.ToString());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
           
        }

        public static decimal ToDecimal(this object value)
        {
            try
            {
                return decimal.Parse(value.ToString());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
           
        }

        public static decimal ToDecimal(this string value)
        {
            try
            {
                return decimal.Parse(value);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
           
        }

        public static void DetermineSelectedIndex(this ComboBox cmb)
        {
            try
            {
                cmb.SelectedIndex = cmb.Items.Count > 0 ? 0 : -1;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
           
        }

        public static void Select(this ComboBox cmb, string text)
        {
            try
            {
                int idx = cmb.FindStringExact(text);

                if (idx < 0) return;

                cmb.SelectedIndex = idx;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
            
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
            try
            {
                string text = string.Empty;
                text = txt.Text.Trim();

                if (text == string.Empty)
                {
                    try
                    {
                        Helper.ShowMessage(msg, "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
            
        }
    }
}
