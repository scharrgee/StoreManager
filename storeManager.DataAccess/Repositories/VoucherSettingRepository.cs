using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using storeManager.Entities;
using DataAccess.Interfaces;

namespace DataAccess.Repositories
{
   //public class VoucherSettingRepository:IVoucherSettingRepository
   // {
   //     Connection conn;

   //     public VoucherSettingRepository()
   //     {
   //         conn = new Connection();
   //     }

   //     #region IRepository<VoucherSetting,int> Members

   //     public VoucherSetting GetById(int id)
   //     {
   //         using (StoreManagerDBEntities ctx = conn.GetContext())
   //         {
   //             return ctx.VoucherSettings.Where(x => x.SettingID == id).FirstOrDefault();
   //         }
   //     }

   //     public List<VoucherSetting> GetAll()
   //     {
   //         throw new NotImplementedException();
   //     }

   //     public void SaveObject(VoucherSetting entity)
   //     {
   //         using (StoreManagerDBEntities ctx = conn.GetContext())
   //         {
   //             ctx.VoucherSettings.Attach(new VoucherSetting { SettingID = entity.SettingID });
   //             ctx.VoucherSettings.ApplyCurrentValues(entity);
   //             ctx.SaveChanges();
   //         }
   //     }

   //     public void AddObject(VoucherSetting entity)
   //     {
   //         using (StoreManagerDBEntities ctx = conn.GetContext())
   //         {
   //             ctx.VoucherSettings.AddObject(entity);
   //             ctx.SaveChanges();
   //         }
   //     }

   //     public void DeleteObject(VoucherSetting entity)
   //     {
   //         throw new NotImplementedException();
   //     }

   //     #endregion
   // }
}
