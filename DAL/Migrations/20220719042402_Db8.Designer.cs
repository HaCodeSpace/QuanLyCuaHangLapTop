﻿// <auto-generated />
using System;
using DAL.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(DA1Context))]
    [Migration("20220719042402_Db8")]
    partial class Db8
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DAL.Model.HoaDon", b =>
                {
                    b.Property<string>("MaHD")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GhiChu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HinhThucGiaoHang")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HinhThucThanhToan")
                        .HasColumnType("int");

                    b.Property<string>("MaKH")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaNV")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("NgayLapHD")
                        .HasColumnType("datetime2");

                    b.Property<string>("NguoiLapHD")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenKH")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("TienKhachDua")
                        .HasColumnType("real");

                    b.Property<float>("TienTraLai")
                        .HasColumnType("real");

                    b.Property<float>("TongTienHD")
                        .HasColumnType("real");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("MaHD");

                    b.HasIndex("MaKH");

                    b.HasIndex("MaNV");

                    b.ToTable("hoaDons");
                });

            modelBuilder.Entity("DAL.Model.HoaDonChiTiet", b =>
                {
                    b.Property<string>("MaHD")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("DonGia")
                        .HasColumnType("real");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<string>("TenSP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaHD");

                    b.ToTable("hoaDonChiTiets");
                });

            modelBuilder.Entity("DAL.Model.KhachHang", b =>
                {
                    b.Property<string>("MaKH")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GioiTinh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenKH")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("MaKH");

                    b.ToTable("khachHangs");
                });

            modelBuilder.Entity("DAL.Model.NhanVien", b =>
                {
                    b.Property<string>("MaNV")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaQuanLi")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("SoDienThoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaiKhoan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenNV")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("MaNV");

                    b.HasIndex("MaQuanLi");

                    b.ToTable("nhanViens");
                });

            modelBuilder.Entity("DAL.Model.HoaDon", b =>
                {
                    b.HasOne("DAL.Model.KhachHang", "khachHang")
                        .WithMany("hoaDons")
                        .HasForeignKey("MaKH")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Model.NhanVien", "NhanVien")
                        .WithMany("hoaDons")
                        .HasForeignKey("MaNV")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NhanVien");

                    b.Navigation("khachHang");
                });

            modelBuilder.Entity("DAL.Model.HoaDonChiTiet", b =>
                {
                    b.HasOne("DAL.Model.HoaDon", "hoaDon")
                        .WithMany("hoadonchitiets")
                        .HasForeignKey("MaHD")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("hoaDon");
                });

            modelBuilder.Entity("DAL.Model.NhanVien", b =>
                {
                    b.HasOne("DAL.Model.NhanVien", "QuanLi")
                        .WithMany("nhanViens")
                        .HasForeignKey("MaQuanLi");

                    b.Navigation("QuanLi");
                });

            modelBuilder.Entity("DAL.Model.HoaDon", b =>
                {
                    b.Navigation("hoadonchitiets");
                });

            modelBuilder.Entity("DAL.Model.KhachHang", b =>
                {
                    b.Navigation("hoaDons");
                });

            modelBuilder.Entity("DAL.Model.NhanVien", b =>
                {
                    b.Navigation("hoaDons");

                    b.Navigation("nhanViens");
                });
#pragma warning restore 612, 618
        }
    }
}
