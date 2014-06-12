using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using storeManager.Entities;
using DataAccess.Interfaces;

namespace DataAccess.Repositories
{
    //public class VoucherDetailRepository : IVoucherDetailRepository
    //{
    //    Connection conn;

    //    public VoucherDetailRepository()
    //    {
    //        conn = new Connection();
    //    }

    //    #region IRepository<VoucherDetail,int> Members

    //    public VoucherDetail GetById(int id)
    //    {
    //        using (StoreManagerDBEntities ctx = conn.GetContext())
    //        {
    //           return ctx.VoucherDetails.Where(x => x.CardDetailsID == id).FirstOrDefault();
    //        }
    //    }

    //    public List<VoucherDetail> GetAll()
    //    {
    //        using (StoreManagerDBEntities ctx = conn.GetContext())
    //        {
    //            return ctx.VoucherDetails.ToList();
    //        }
    //    }

    //    public void SaveObject(VoucherDetail entity)
    //    {
    //        using (StoreManagerDBEntities ctx = conn.GetContext())
    //        {
    //            ctx.VoucherDetails.Attach(new VoucherDetail { CardDetailsID = entity.CardDetailsID });
    //            ctx.VoucherDetails.ApplyCurrentValues(entity);
    //            ctx.SaveChanges();
    //        }
    //    }

    //    public void AddObject(VoucherDetail entity)
    //    {
    //        using (StoreManagerDBEntities ctx = conn.GetContext())
    //        {
    //            ctx.VoucherDetails.AddObject(entity);
    //            ctx.SaveChanges();
    //        }
    //    }

    //    public void DeleteObject(VoucherDetail entity)
    //    {
    //        using (StoreManagerDBEntities ctx = conn.GetContext())
    //        {
    //            ctx.VoucherDetails.DeleteObject(new VoucherDetail { CardDetailsID = entity.CardDetailsID });
    //            ctx.SaveChanges();
    //        }
    //    }

    //    public VoucherDetail GetByCode(string code)
    //    {
    //        using (StoreManagerDBEntities ctx = conn.GetContext())
    //        {
    //            return ctx.VoucherDetails.Where(x => x.CardCode == code).FirstOrDefault();
    //        }
    //    }

    //    public void TopUp(VoucherDetail voucherDetail, decimal amt)
    //    {
    //        VoucherDetail voucher;
    //        VoucherTopUp topUp = new VoucherTopUp();

    //        decimal amountBeforeTopUp = 0;

    //        try
    //        {
    //            using (StoreManagerDBEntities ctx = conn.GetContext())
    //            {
    //                voucher = ctx.VoucherDetails.Where(x => x.CardCode == voucherDetail.CardCode).FirstOrDefault();
    //                amountBeforeTopUp = voucher.Amount.Value;
    //                voucher.Amount = voucher.Amount + amt;

    //                topUp.Amount = amt;
    //                topUp.CardCode = voucher.CardCode;
    //                topUp.CardDetailsID = voucher.CardDetailsID;
    //                topUp.DateIssued = DateTime.Now;
    //                topUp.AmountBeforeTopUp = amountBeforeTopUp;
    //                topUp.EmployeeID = "EMP0001";

    //                voucher.VoucherTopUps.Add(topUp);

    //                ctx.VoucherDetails.ApplyCurrentValues(voucher);
    //                ctx.SaveChanges();
    //            }
    //        }
    //        catch (Exception)
    //        {                
    //            throw;
    //        }              
    //    }

    //    public void ReduceBalance(string code, decimal amt)
    //    {
    //        VoucherDetail voucher;
    //        try
    //        {
    //            using (StoreManagerDBEntities ctx = conn.GetContext())
    //            {
    //                voucher = ctx.VoucherDetails.Where(x => x.CardCode == code).FirstOrDefault();
    //                voucher.Amount = voucher.Amount - amt;

    //                ctx.VoucherDetails.ApplyCurrentValues(voucher);
    //                ctx.SaveChanges();
    //            }
    //        }
    //        catch (Exception)
    //        {                
    //            throw;
    //        }
    //    }

    //    #endregion
    //}
}
