﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.IRepository.IRepositorySanPham;
using DAL.Model;
using DAL.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository.RepositorySanPham
{
    public class SanPhamRepository : ISanPhamRepository
    {
        private DA1Context context;
        public SanPhamRepository()
        {
            this.context= new DA1Context();
        }

        public bool AddSP(SanPham san)
        {
            var check = context.sanPhams.Any(p => p.TenSP.ToUpper().Trim() == san.TenSP.ToUpper().Trim());
            if (check)
                throw new Exception("San pham nay da ton tai");
            this.context.sanPhams.Add(san);
            this.context.SaveChanges();
            return true;
        }

        public bool DeleteSP(SanPham san)
        {
            var sanpham = this.context.sanPhams.Find(san.MaSP);
            if (sanpham != null)
            {
                this.context.sanPhams.Remove(sanpham);
                this.context.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool Edit(SanPham san)
        {
            var existingSanPham = new SanPham();
            var existingChild = Type.Missing;
            if (san.laptop !=null)
            {
                existingSanPham = context.sanPhams
               .Where(p => p.TenSP == san.TenSP)
               .Include(p => p.laptop)
               .SingleOrDefault();
                san.laptop.MaLaptop = existingSanPham.MaSP;
                existingChild=existingSanPham.laptop;
            }
            else if (san.banPhim != null)
            {
                existingSanPham = context.sanPhams
                .Where(p => p.TenSP == san.TenSP)
                .Include(p => p.banPhim)
                .SingleOrDefault();
                san.banPhim.MaSP=existingSanPham.MaSP;
                existingChild=existingSanPham.banPhim;
            }
            else if (san.chuot != null)
            {
                existingSanPham = context.sanPhams
                .Where(p => p.TenSP == san.TenSP)
                .Include(p => p.chuot)
                .SingleOrDefault();
                san.chuot.MaChuot=existingSanPham.MaSP;
                existingChild=existingSanPham.chuot;
            }
            else
            {
                existingSanPham = context.sanPhams
                .Where(p => p.TenSP == san.TenSP)
                .SingleOrDefault();
            }



            if (existingSanPham != null)
            {
                // update Sanpham
                san.MaSP = existingSanPham.MaSP;
                context.Entry(existingSanPham).CurrentValues.SetValues(san);
                //throw new Exception(existingSanPham.MaSP + "");
                //update child
                if(san.laptop!=null)
                    context.Entry(existingChild).CurrentValues.SetValues(san.laptop);
                else if (san.banPhim != null)
                    context.Entry(existingChild).CurrentValues.SetValues(san.banPhim);
                else if (san.chuot != null)
                    context.Entry(existingChild).CurrentValues.SetValues(san.chuot);

                context.SaveChanges();
                return true;
            }
            else
                return false;
        }



        public ICollection<SanPham> GetAll()
        {

            var result = context.sanPhams
                .Include(s => s.laptop)
                .Include(s => s.banPhim)
                .Include(s => s.chuot)
                .ToList();
            return result;
        }

        public IEnumerable<SanPham> GetByValue(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return context.sanPhams.ToList();
            }
            else
            {
                var listsp = (from sp in context.sanPhams.ToList()
                              where sp.TenSP.Contains(value)
                              select sp);

                return listsp;
            }

        }
    }

}
