using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using Telerik.WinControls.UI;

using BusinessLayer;
using BusinessLayer.Interfaces;
using storeManager.Entities;
using storeManager.Entities.Interfaces;

namespace storeManager.UI
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
                if (string.IsNullOrEmpty(value.ToString())) return 0;
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
                if (string.IsNullOrEmpty(value.ToString())) return 0;
                return int.Parse(value.ToString());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
            //return 0;
        }

        public static decimal ToDecimal(this object value)
        {
            try
            {
                if (string.IsNullOrEmpty(value.ToString())) return 0;
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
                if (string.IsNullOrEmpty(value.ToString())) return 0;
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

        public static void Select(this RadDropDownList cmb, string text)
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

        public static void Load<T>(this RadDropDownList cmb, string valueMember, string displayMember, List<T> dataSource)
        {
            cmb.DataSource = dataSource;
            cmb.ValueMember = valueMember;
            cmb.DisplayMember = displayMember;
        }

        public static void Load<T>(this ComboBox cmb, string valueMember, string displayMember, List<T> dataSource)
        {
            cmb.DataSource = dataSource;
            cmb.ValueMember = valueMember;
            cmb.DisplayMember = displayMember;
        }

        public static void PopulateListView<T>(this ListView lv,IEnumerable<T> data) where T:storeManager.Entities.Interfaces.IBaseEntity
        {
            try
            {
                DataTable dt;

                IEnumerable<T> _data = data;
                dt = Helper.MapCollectionToDataTable(data);

                lv.Items.Clear();
                Helper.PopulateListviewWithDataTable(lv, dt);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
           
        }

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

        public static string GetValue(this RadDateTimePicker dtp,bool check)
        {
            try
            {
                if (check)
                    return dtp.Checked ? dtp.Value.ToShortDateString() : "";

                return dtp.Value.ToShortDateString();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
           
        }

        public static bool CompareTo(this RadDateTimePicker dtp1, RadDateTimePicker dtp2)
        {
            try
            {
                if (!dtp1.Checked) return true;

                return dtp1.Value <= dtp2.Value;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
            
        }

        public static void Reset(this RadDateTimePicker dtp1)
        {
            try
            {
                dtp1.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
         
        }
    }
}
