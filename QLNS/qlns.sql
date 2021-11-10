USE [master]
GO
/****** Object:  Database [QuanLyNhanSu]    Script Date: 10/29/2021 11:47:09 PM ******/
CREATE DATABASE [QuanLyNhanSu]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyNhanSu', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\QuanLyNhanSu.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QuanLyNhanSu_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\QuanLyNhanSu_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [QuanLyNhanSu] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyNhanSu].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyNhanSu] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyNhanSu] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyNhanSu] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QuanLyNhanSu] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyNhanSu] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuanLyNhanSu] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyNhanSu] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyNhanSu] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyNhanSu] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuanLyNhanSu] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QuanLyNhanSu] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [QuanLyNhanSu] SET QUERY_STORE = OFF
GO
USE [QuanLyNhanSu]
GO
/****** Object:  Table [dbo].[ChamCong]    Script Date: 10/29/2021 11:47:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChamCong](
	[MaNV] [nvarchar](50) NOT NULL,
	[TenNV] [nvarchar](50) NULL,
	[MaLuong] [nvarchar](50) NULL,
	[LuongChinh] [float] NULL,
	[SoNgayNghi] [int] NULL,
	[SoNgayDiLam] [int] NULL,
	[PhuCap] [float] NULL,
	[TienThuong] [float] NULL,
	[TienPhat] [float] NULL,
	[TONGTIEN] [float] NULL,
 CONSTRAINT [PK_ChamCong] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DangNhap]    Script Date: 10/29/2021 11:47:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DangNhap](
	[TenTaiKhoan] [nchar](10) NOT NULL,
	[MatKhau] [nchar](10) NOT NULL,
 CONSTRAINT [PK_DangNhap] PRIMARY KEY CLUSTERED 
(
	[TenTaiKhoan] ASC,
	[MatKhau] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DuAn]    Script Date: 10/29/2021 11:47:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DuAn](
	[MaDA] [nvarchar](50) NOT NULL,
	[TenDA] [nvarchar](50) NULL,
	[DiaDiem] [nvarchar](50) NULL,
	[Phong] [nvarchar](50) NULL,
 CONSTRAINT [PK_DuAn] PRIMARY KEY CLUSTERED 
(
	[MaDA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Luong]    Script Date: 10/29/2021 11:47:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Luong](
	[MaLuong] [nvarchar](50) NOT NULL,
	[TenLuong] [nvarchar](50) NULL,
	[LuongCB] [float] NULL,
	[HeSoLuong] [float] NULL,
 CONSTRAINT [PK_Luong] PRIMARY KEY CLUSTERED 
(
	[MaLuong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 10/29/2021 11:47:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [nvarchar](50) NOT NULL,
	[HoTenNV] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[Phong] [nvarchar](50) NULL,
	[CMND] [nchar](9) NULL,
	[CongViec] [nvarchar](50) NULL,
	[Luong] [nvarchar](50) NULL,
	[GhiChu] [nvarchar](500) NULL,
	[LoaiNV] [bit] NOT NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhanCongNV]    Script Date: 10/29/2021 11:47:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanCongNV](
	[MaDA] [nvarchar](50) NOT NULL,
	[MaNV] [nvarchar](50) NOT NULL,
	[ThoiGianStart] [date] NULL,
	[ThoiGianEnd] [date] NULL,
 CONSTRAINT [PK_PhanCongNV] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC,
	[MaDA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhongBan]    Script Date: 10/29/2021 11:47:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhongBan](
	[MaPB] [nvarchar](50) NOT NULL,
	[TenPB] [nvarchar](50) NULL,
	[TruongPhong] [nvarchar](50) NULL,
	[NgayNhanChuc] [date] NULL,
 CONSTRAINT [PK_PhongBan] PRIMARY KEY CLUSTERED 
(
	[MaPB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ChamCong] ([MaNV], [TenNV], [MaLuong], [LuongChinh], [SoNgayNghi], [SoNgayDiLam], [PhuCap], [TienThuong], [TienPhat], [TONGTIEN]) VALUES (N'100001', N'Nguyễn Bá cần', N'Nhân Viên', 250000, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[ChamCong] ([MaNV], [TenNV], [MaLuong], [LuongChinh], [SoNgayNghi], [SoNgayDiLam], [PhuCap], [TienThuong], [TienPhat], [TONGTIEN]) VALUES (N'1000012222', N'Nguyễn Bá cần', N'Nhân Viên', 250000, 0, 0, 0, 0, 0, 0)
GO
INSERT [dbo].[DangNhap] ([TenTaiKhoan], [MatKhau]) VALUES (N'admin     ', N'123       ')
GO
INSERT [dbo].[Luong] ([MaLuong], [TenLuong], [LuongCB], [HeSoLuong]) VALUES (N'Nhân Viên', N'Nhân Viên', 200000, 1.25)
INSERT [dbo].[Luong] ([MaLuong], [TenLuong], [LuongCB], [HeSoLuong]) VALUES (N'Quản Lý', N'Quản Lý', 300000, 1.5)
INSERT [dbo].[Luong] ([MaLuong], [TenLuong], [LuongCB], [HeSoLuong]) VALUES (N'Thử việc', N'Thử việc', 100000, 1)
GO
INSERT [dbo].[NhanVien] ([MaNV], [HoTenNV], [NgaySinh], [GioiTinh], [DiaChi], [Phong], [CMND], [CongViec], [Luong], [GhiChu], [LoaiNV]) VALUES (N'01', N'Võ Tấn Nguyên', CAST(N'2019-05-15' AS Date), N'nam', N'', N'IT', N'         ', N'', N'Quản Lý', N'Quản Lý', 0)
INSERT [dbo].[NhanVien] ([MaNV], [HoTenNV], [NgaySinh], [GioiTinh], [DiaChi], [Phong], [CMND], [CongViec], [Luong], [GhiChu], [LoaiNV]) VALUES (N'02', N'FF', CAST(N'2019-05-18' AS Date), N'Nữ', N'', N'KyT', N'444444444', N'Dev', N'Quản Lý', N'Quản Lý', 0)
INSERT [dbo].[NhanVien] ([MaNV], [HoTenNV], [NgaySinh], [GioiTinh], [DiaChi], [Phong], [CMND], [CongViec], [Luong], [GhiChu], [LoaiNV]) VALUES (N'03', N'GG', CAST(N'2019-05-18' AS Date), N'Nữ', N'', N'IT', N'111111111', N'Dev', N'Nhân Viên', N'Nhân Viên', 0)
INSERT [dbo].[NhanVien] ([MaNV], [HoTenNV], [NgaySinh], [GioiTinh], [DiaChi], [Phong], [CMND], [CongViec], [Luong], [GhiChu], [LoaiNV]) VALUES (N'05', N'jghjghjgh', CAST(N'2019-05-15' AS Date), N'nam', N'', N'KT', N'         ', N'', N'Nhân Viên', N'Nhân Viên', 0)
INSERT [dbo].[NhanVien] ([MaNV], [HoTenNV], [NgaySinh], [GioiTinh], [DiaChi], [Phong], [CMND], [CongViec], [Luong], [GhiChu], [LoaiNV]) VALUES (N'07', N'Mai Trọng Tường', CAST(N'2019-05-18' AS Date), N'nam', N'', N'KT', N'         ', N'', N'Thử việc', N'Nhân Viên', 0)
INSERT [dbo].[NhanVien] ([MaNV], [HoTenNV], [NgaySinh], [GioiTinh], [DiaChi], [Phong], [CMND], [CongViec], [Luong], [GhiChu], [LoaiNV]) VALUES (N'100001', N'Nguyễn Bá cần 2', CAST(N'2019-05-18' AS Date), N'Nữ', N'', N'IT', N'12345668 ', N'Dev', N'Nhân Viên', N'Nhân Viên', 1)
INSERT [dbo].[NhanVien] ([MaNV], [HoTenNV], [NgaySinh], [GioiTinh], [DiaChi], [Phong], [CMND], [CongViec], [Luong], [GhiChu], [LoaiNV]) VALUES (N'1000012222', N'Nguyễn Bá cần', CAST(N'2019-05-18' AS Date), N'Nữ', N'', N'IT', N'12345668 ', N'Dev', N'Nhân Viên', N'Nhân Viên', 0)
GO
INSERT [dbo].[PhongBan] ([MaPB], [TenPB], [TruongPhong], [NgayNhanChuc]) VALUES (N'IT', N'IT', N'01', CAST(N'2018-05-06' AS Date))
INSERT [dbo].[PhongBan] ([MaPB], [TenPB], [TruongPhong], [NgayNhanChuc]) VALUES (N'KT', N'Kế Toán', N'02', CAST(N'2017-07-09' AS Date))
INSERT [dbo].[PhongBan] ([MaPB], [TenPB], [TruongPhong], [NgayNhanChuc]) VALUES (N'KyT', N'Kỹ Thuật', N'03', CAST(N'2011-10-05' AS Date))
INSERT [dbo].[PhongBan] ([MaPB], [TenPB], [TruongPhong], [NgayNhanChuc]) VALUES (N'VC', N'Vận Chuyển', N'02', CAST(N'2019-05-16' AS Date))
GO
ALTER TABLE [dbo].[NhanVien] ADD  DEFAULT ((0)) FOR [LoaiNV]
GO
ALTER TABLE [dbo].[ChamCong]  WITH CHECK ADD  CONSTRAINT [FK_ChamCong_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[ChamCong] CHECK CONSTRAINT [FK_ChamCong_NhanVien]
GO
ALTER TABLE [dbo].[DuAn]  WITH CHECK ADD  CONSTRAINT [FK_DuAn_PhongBan] FOREIGN KEY([Phong])
REFERENCES [dbo].[PhongBan] ([MaPB])
GO
ALTER TABLE [dbo].[DuAn] CHECK CONSTRAINT [FK_DuAn_PhongBan]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_Luong] FOREIGN KEY([Luong])
REFERENCES [dbo].[Luong] ([MaLuong])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_Luong]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_PhongBan] FOREIGN KEY([Phong])
REFERENCES [dbo].[PhongBan] ([MaPB])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_PhongBan]
GO
ALTER TABLE [dbo].[PhanCongNV]  WITH CHECK ADD  CONSTRAINT [FK_PhanCongNV_DuAn] FOREIGN KEY([MaDA])
REFERENCES [dbo].[DuAn] ([MaDA])
GO
ALTER TABLE [dbo].[PhanCongNV] CHECK CONSTRAINT [FK_PhanCongNV_DuAn]
GO
ALTER TABLE [dbo].[PhanCongNV]  WITH CHECK ADD  CONSTRAINT [FK_PhanCongNV_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[PhanCongNV] CHECK CONSTRAINT [FK_PhanCongNV_NhanVien]
GO
ALTER TABLE [dbo].[PhongBan]  WITH CHECK ADD  CONSTRAINT [FK_PhongBan_NhanVien] FOREIGN KEY([TruongPhong])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[PhongBan] CHECK CONSTRAINT [FK_PhongBan_NhanVien]
GO
USE [master]
GO
ALTER DATABASE [QuanLyNhanSu] SET  READ_WRITE 
GO
