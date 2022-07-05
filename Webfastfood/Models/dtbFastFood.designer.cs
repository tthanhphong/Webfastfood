﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Webfastfood.Models
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="QL_FastFood")]
	public partial class dtbFastFoodDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertAdmin(Admin instance);
    partial void UpdateAdmin(Admin instance);
    partial void DeleteAdmin(Admin instance);
    partial void InsertSanPham(SanPham instance);
    partial void UpdateSanPham(SanPham instance);
    partial void DeleteSanPham(SanPham instance);
    partial void InsertChiTietDDH(ChiTietDDH instance);
    partial void UpdateChiTietDDH(ChiTietDDH instance);
    partial void DeleteChiTietDDH(ChiTietDDH instance);
    partial void InsertDonDatHang(DonDatHang instance);
    partial void UpdateDonDatHang(DonDatHang instance);
    partial void DeleteDonDatHang(DonDatHang instance);
    partial void InsertKhachHang(KhachHang instance);
    partial void UpdateKhachHang(KhachHang instance);
    partial void DeleteKhachHang(KhachHang instance);
    partial void InsertLoaiSanPham(LoaiSanPham instance);
    partial void UpdateLoaiSanPham(LoaiSanPham instance);
    partial void DeleteLoaiSanPham(LoaiSanPham instance);
    #endregion
		
		public dtbFastFoodDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["QL_FastFoodConnectionString1"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public dtbFastFoodDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dtbFastFoodDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dtbFastFoodDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dtbFastFoodDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Admin> Admins
		{
			get
			{
				return this.GetTable<Admin>();
			}
		}
		
		public System.Data.Linq.Table<SanPham> SanPhams
		{
			get
			{
				return this.GetTable<SanPham>();
			}
		}
		
		public System.Data.Linq.Table<ChiTietDDH> ChiTietDDHs
		{
			get
			{
				return this.GetTable<ChiTietDDH>();
			}
		}
		
		public System.Data.Linq.Table<DonDatHang> DonDatHangs
		{
			get
			{
				return this.GetTable<DonDatHang>();
			}
		}
		
		public System.Data.Linq.Table<KhachHang> KhachHangs
		{
			get
			{
				return this.GetTable<KhachHang>();
			}
		}
		
		public System.Data.Linq.Table<LoaiSanPham> LoaiSanPhams
		{
			get
			{
				return this.GetTable<LoaiSanPham>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Admin")]
	public partial class Admin : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _UserAdmin;
		
		private string _PassAdmin;
		
		private string _HoTen;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserAdminChanging(string value);
    partial void OnUserAdminChanged();
    partial void OnPassAdminChanging(string value);
    partial void OnPassAdminChanged();
    partial void OnHoTenChanging(string value);
    partial void OnHoTenChanged();
    #endregion
		
		public Admin()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserAdmin", DbType="VarChar(20) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string UserAdmin
		{
			get
			{
				return this._UserAdmin;
			}
			set
			{
				if ((this._UserAdmin != value))
				{
					this.OnUserAdminChanging(value);
					this.SendPropertyChanging();
					this._UserAdmin = value;
					this.SendPropertyChanged("UserAdmin");
					this.OnUserAdminChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PassAdmin", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string PassAdmin
		{
			get
			{
				return this._PassAdmin;
			}
			set
			{
				if ((this._PassAdmin != value))
				{
					this.OnPassAdminChanging(value);
					this.SendPropertyChanging();
					this._PassAdmin = value;
					this.SendPropertyChanged("PassAdmin");
					this.OnPassAdminChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HoTen", DbType="NVarChar(50)")]
		public string HoTen
		{
			get
			{
				return this._HoTen;
			}
			set
			{
				if ((this._HoTen != value))
				{
					this.OnHoTenChanging(value);
					this.SendPropertyChanging();
					this._HoTen = value;
					this.SendPropertyChanged("HoTen");
					this.OnHoTenChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.SanPham")]
	public partial class SanPham : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _IDSanPham;
		
		private System.Nullable<int> _IDLoaiSanPham;
		
		private string _TenSanPham;
		
		private System.Nullable<decimal> _DonGia;
		
		private System.Nullable<System.DateTime> _NgayCapNhat;
		
		private string _ChuThich;
		
		private string _HinhAnh;
		
		private EntitySet<ChiTietDDH> _ChiTietDDHs;
		
		private EntityRef<LoaiSanPham> _LoaiSanPham;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDSanPhamChanging(int value);
    partial void OnIDSanPhamChanged();
    partial void OnIDLoaiSanPhamChanging(System.Nullable<int> value);
    partial void OnIDLoaiSanPhamChanged();
    partial void OnTenSanPhamChanging(string value);
    partial void OnTenSanPhamChanged();
    partial void OnDonGiaChanging(System.Nullable<decimal> value);
    partial void OnDonGiaChanged();
    partial void OnNgayCapNhatChanging(System.Nullable<System.DateTime> value);
    partial void OnNgayCapNhatChanged();
    partial void OnChuThichChanging(string value);
    partial void OnChuThichChanged();
    partial void OnHinhAnhChanging(string value);
    partial void OnHinhAnhChanged();
    #endregion
		
		public SanPham()
		{
			this._ChiTietDDHs = new EntitySet<ChiTietDDH>(new Action<ChiTietDDH>(this.attach_ChiTietDDHs), new Action<ChiTietDDH>(this.detach_ChiTietDDHs));
			this._LoaiSanPham = default(EntityRef<LoaiSanPham>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDSanPham", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int IDSanPham
		{
			get
			{
				return this._IDSanPham;
			}
			set
			{
				if ((this._IDSanPham != value))
				{
					this.OnIDSanPhamChanging(value);
					this.SendPropertyChanging();
					this._IDSanPham = value;
					this.SendPropertyChanged("IDSanPham");
					this.OnIDSanPhamChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDLoaiSanPham", DbType="Int")]
		public System.Nullable<int> IDLoaiSanPham
		{
			get
			{
				return this._IDLoaiSanPham;
			}
			set
			{
				if ((this._IDLoaiSanPham != value))
				{
					if (this._LoaiSanPham.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIDLoaiSanPhamChanging(value);
					this.SendPropertyChanging();
					this._IDLoaiSanPham = value;
					this.SendPropertyChanged("IDLoaiSanPham");
					this.OnIDLoaiSanPhamChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TenSanPham", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string TenSanPham
		{
			get
			{
				return this._TenSanPham;
			}
			set
			{
				if ((this._TenSanPham != value))
				{
					this.OnTenSanPhamChanging(value);
					this.SendPropertyChanging();
					this._TenSanPham = value;
					this.SendPropertyChanged("TenSanPham");
					this.OnTenSanPhamChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DonGia", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> DonGia
		{
			get
			{
				return this._DonGia;
			}
			set
			{
				if ((this._DonGia != value))
				{
					this.OnDonGiaChanging(value);
					this.SendPropertyChanging();
					this._DonGia = value;
					this.SendPropertyChanged("DonGia");
					this.OnDonGiaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NgayCapNhat", DbType="DateTime")]
		public System.Nullable<System.DateTime> NgayCapNhat
		{
			get
			{
				return this._NgayCapNhat;
			}
			set
			{
				if ((this._NgayCapNhat != value))
				{
					this.OnNgayCapNhatChanging(value);
					this.SendPropertyChanging();
					this._NgayCapNhat = value;
					this.SendPropertyChanged("NgayCapNhat");
					this.OnNgayCapNhatChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ChuThich", DbType="NVarChar(MAX)")]
		public string ChuThich
		{
			get
			{
				return this._ChuThich;
			}
			set
			{
				if ((this._ChuThich != value))
				{
					this.OnChuThichChanging(value);
					this.SendPropertyChanging();
					this._ChuThich = value;
					this.SendPropertyChanged("ChuThich");
					this.OnChuThichChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HinhAnh", DbType="VarChar(50)")]
		public string HinhAnh
		{
			get
			{
				return this._HinhAnh;
			}
			set
			{
				if ((this._HinhAnh != value))
				{
					this.OnHinhAnhChanging(value);
					this.SendPropertyChanging();
					this._HinhAnh = value;
					this.SendPropertyChanged("HinhAnh");
					this.OnHinhAnhChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="SanPham_ChiTietDDH", Storage="_ChiTietDDHs", ThisKey="IDSanPham", OtherKey="IDSanPham")]
		public EntitySet<ChiTietDDH> ChiTietDDHs
		{
			get
			{
				return this._ChiTietDDHs;
			}
			set
			{
				this._ChiTietDDHs.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="LoaiSanPham_SanPham", Storage="_LoaiSanPham", ThisKey="IDLoaiSanPham", OtherKey="IDLoaiSanPham", IsForeignKey=true)]
		public LoaiSanPham LoaiSanPham
		{
			get
			{
				return this._LoaiSanPham.Entity;
			}
			set
			{
				LoaiSanPham previousValue = this._LoaiSanPham.Entity;
				if (((previousValue != value) 
							|| (this._LoaiSanPham.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._LoaiSanPham.Entity = null;
						previousValue.SanPhams.Remove(this);
					}
					this._LoaiSanPham.Entity = value;
					if ((value != null))
					{
						value.SanPhams.Add(this);
						this._IDLoaiSanPham = value.IDLoaiSanPham;
					}
					else
					{
						this._IDLoaiSanPham = default(Nullable<int>);
					}
					this.SendPropertyChanged("LoaiSanPham");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_ChiTietDDHs(ChiTietDDH entity)
		{
			this.SendPropertyChanging();
			entity.SanPham = this;
		}
		
		private void detach_ChiTietDDHs(ChiTietDDH entity)
		{
			this.SendPropertyChanging();
			entity.SanPham = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ChiTietDDH")]
	public partial class ChiTietDDH : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _IDDonDatHang;
		
		private int _IDSanPham;
		
		private System.Nullable<int> _SoLuong;
		
		private System.Nullable<decimal> _Gia;
		
		private EntityRef<SanPham> _SanPham;
		
		private EntityRef<DonDatHang> _DonDatHang;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDDonDatHangChanging(int value);
    partial void OnIDDonDatHangChanged();
    partial void OnIDSanPhamChanging(int value);
    partial void OnIDSanPhamChanged();
    partial void OnSoLuongChanging(System.Nullable<int> value);
    partial void OnSoLuongChanged();
    partial void OnGiaChanging(System.Nullable<decimal> value);
    partial void OnGiaChanged();
    #endregion
		
		public ChiTietDDH()
		{
			this._SanPham = default(EntityRef<SanPham>);
			this._DonDatHang = default(EntityRef<DonDatHang>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDDonDatHang", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int IDDonDatHang
		{
			get
			{
				return this._IDDonDatHang;
			}
			set
			{
				if ((this._IDDonDatHang != value))
				{
					if (this._DonDatHang.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIDDonDatHangChanging(value);
					this.SendPropertyChanging();
					this._IDDonDatHang = value;
					this.SendPropertyChanged("IDDonDatHang");
					this.OnIDDonDatHangChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDSanPham", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int IDSanPham
		{
			get
			{
				return this._IDSanPham;
			}
			set
			{
				if ((this._IDSanPham != value))
				{
					if (this._SanPham.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIDSanPhamChanging(value);
					this.SendPropertyChanging();
					this._IDSanPham = value;
					this.SendPropertyChanged("IDSanPham");
					this.OnIDSanPhamChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SoLuong", DbType="Int")]
		public System.Nullable<int> SoLuong
		{
			get
			{
				return this._SoLuong;
			}
			set
			{
				if ((this._SoLuong != value))
				{
					this.OnSoLuongChanging(value);
					this.SendPropertyChanging();
					this._SoLuong = value;
					this.SendPropertyChanged("SoLuong");
					this.OnSoLuongChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Gia", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> Gia
		{
			get
			{
				return this._Gia;
			}
			set
			{
				if ((this._Gia != value))
				{
					this.OnGiaChanging(value);
					this.SendPropertyChanging();
					this._Gia = value;
					this.SendPropertyChanged("Gia");
					this.OnGiaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="SanPham_ChiTietDDH", Storage="_SanPham", ThisKey="IDSanPham", OtherKey="IDSanPham", IsForeignKey=true)]
		public SanPham SanPham
		{
			get
			{
				return this._SanPham.Entity;
			}
			set
			{
				SanPham previousValue = this._SanPham.Entity;
				if (((previousValue != value) 
							|| (this._SanPham.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._SanPham.Entity = null;
						previousValue.ChiTietDDHs.Remove(this);
					}
					this._SanPham.Entity = value;
					if ((value != null))
					{
						value.ChiTietDDHs.Add(this);
						this._IDSanPham = value.IDSanPham;
					}
					else
					{
						this._IDSanPham = default(int);
					}
					this.SendPropertyChanged("SanPham");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="DonDatHang_ChiTietDDH", Storage="_DonDatHang", ThisKey="IDDonDatHang", OtherKey="IDDonDatHang", IsForeignKey=true)]
		public DonDatHang DonDatHang
		{
			get
			{
				return this._DonDatHang.Entity;
			}
			set
			{
				DonDatHang previousValue = this._DonDatHang.Entity;
				if (((previousValue != value) 
							|| (this._DonDatHang.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._DonDatHang.Entity = null;
						previousValue.ChiTietDDHs.Remove(this);
					}
					this._DonDatHang.Entity = value;
					if ((value != null))
					{
						value.ChiTietDDHs.Add(this);
						this._IDDonDatHang = value.IDDonDatHang;
					}
					else
					{
						this._IDDonDatHang = default(int);
					}
					this.SendPropertyChanged("DonDatHang");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.DonDatHang")]
	public partial class DonDatHang : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _IDDonDatHang;
		
		private System.Nullable<bool> _DaThanhToan;
		
		private System.Nullable<bool> _TrangThaiGiaoHang;
		
		private string _DiaChiGH;
		
		private System.Nullable<System.DateTime> _NgayDH;
		
		private System.Nullable<System.DateTime> _NgayGiao;
		
		private System.Nullable<int> _IDKhachHang;
		
		private EntitySet<ChiTietDDH> _ChiTietDDHs;
		
		private EntityRef<KhachHang> _KhachHang;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDDonDatHangChanging(int value);
    partial void OnIDDonDatHangChanged();
    partial void OnDaThanhToanChanging(System.Nullable<bool> value);
    partial void OnDaThanhToanChanged();
    partial void OnTrangThaiGiaoHangChanging(System.Nullable<bool> value);
    partial void OnTrangThaiGiaoHangChanged();
    partial void OnDiaChiGHChanging(string value);
    partial void OnDiaChiGHChanged();
    partial void OnNgayDHChanging(System.Nullable<System.DateTime> value);
    partial void OnNgayDHChanged();
    partial void OnNgayGiaoChanging(System.Nullable<System.DateTime> value);
    partial void OnNgayGiaoChanged();
    partial void OnIDKhachHangChanging(System.Nullable<int> value);
    partial void OnIDKhachHangChanged();
    #endregion
		
		public DonDatHang()
		{
			this._ChiTietDDHs = new EntitySet<ChiTietDDH>(new Action<ChiTietDDH>(this.attach_ChiTietDDHs), new Action<ChiTietDDH>(this.detach_ChiTietDDHs));
			this._KhachHang = default(EntityRef<KhachHang>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDDonDatHang", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int IDDonDatHang
		{
			get
			{
				return this._IDDonDatHang;
			}
			set
			{
				if ((this._IDDonDatHang != value))
				{
					this.OnIDDonDatHangChanging(value);
					this.SendPropertyChanging();
					this._IDDonDatHang = value;
					this.SendPropertyChanged("IDDonDatHang");
					this.OnIDDonDatHangChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DaThanhToan", DbType="Bit")]
		public System.Nullable<bool> DaThanhToan
		{
			get
			{
				return this._DaThanhToan;
			}
			set
			{
				if ((this._DaThanhToan != value))
				{
					this.OnDaThanhToanChanging(value);
					this.SendPropertyChanging();
					this._DaThanhToan = value;
					this.SendPropertyChanged("DaThanhToan");
					this.OnDaThanhToanChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TrangThaiGiaoHang", DbType="Bit")]
		public System.Nullable<bool> TrangThaiGiaoHang
		{
			get
			{
				return this._TrangThaiGiaoHang;
			}
			set
			{
				if ((this._TrangThaiGiaoHang != value))
				{
					this.OnTrangThaiGiaoHangChanging(value);
					this.SendPropertyChanging();
					this._TrangThaiGiaoHang = value;
					this.SendPropertyChanged("TrangThaiGiaoHang");
					this.OnTrangThaiGiaoHangChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DiaChiGH", DbType="NVarChar(200)")]
		public string DiaChiGH
		{
			get
			{
				return this._DiaChiGH;
			}
			set
			{
				if ((this._DiaChiGH != value))
				{
					this.OnDiaChiGHChanging(value);
					this.SendPropertyChanging();
					this._DiaChiGH = value;
					this.SendPropertyChanged("DiaChiGH");
					this.OnDiaChiGHChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NgayDH", DbType="DateTime")]
		public System.Nullable<System.DateTime> NgayDH
		{
			get
			{
				return this._NgayDH;
			}
			set
			{
				if ((this._NgayDH != value))
				{
					this.OnNgayDHChanging(value);
					this.SendPropertyChanging();
					this._NgayDH = value;
					this.SendPropertyChanged("NgayDH");
					this.OnNgayDHChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NgayGiao", DbType="DateTime")]
		public System.Nullable<System.DateTime> NgayGiao
		{
			get
			{
				return this._NgayGiao;
			}
			set
			{
				if ((this._NgayGiao != value))
				{
					this.OnNgayGiaoChanging(value);
					this.SendPropertyChanging();
					this._NgayGiao = value;
					this.SendPropertyChanged("NgayGiao");
					this.OnNgayGiaoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDKhachHang", DbType="Int")]
		public System.Nullable<int> IDKhachHang
		{
			get
			{
				return this._IDKhachHang;
			}
			set
			{
				if ((this._IDKhachHang != value))
				{
					if (this._KhachHang.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIDKhachHangChanging(value);
					this.SendPropertyChanging();
					this._IDKhachHang = value;
					this.SendPropertyChanged("IDKhachHang");
					this.OnIDKhachHangChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="DonDatHang_ChiTietDDH", Storage="_ChiTietDDHs", ThisKey="IDDonDatHang", OtherKey="IDDonDatHang")]
		public EntitySet<ChiTietDDH> ChiTietDDHs
		{
			get
			{
				return this._ChiTietDDHs;
			}
			set
			{
				this._ChiTietDDHs.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="KhachHang_DonDatHang", Storage="_KhachHang", ThisKey="IDKhachHang", OtherKey="IDKhachHang", IsForeignKey=true)]
		public KhachHang KhachHang
		{
			get
			{
				return this._KhachHang.Entity;
			}
			set
			{
				KhachHang previousValue = this._KhachHang.Entity;
				if (((previousValue != value) 
							|| (this._KhachHang.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._KhachHang.Entity = null;
						previousValue.DonDatHangs.Remove(this);
					}
					this._KhachHang.Entity = value;
					if ((value != null))
					{
						value.DonDatHangs.Add(this);
						this._IDKhachHang = value.IDKhachHang;
					}
					else
					{
						this._IDKhachHang = default(Nullable<int>);
					}
					this.SendPropertyChanged("KhachHang");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_ChiTietDDHs(ChiTietDDH entity)
		{
			this.SendPropertyChanging();
			entity.DonDatHang = this;
		}
		
		private void detach_ChiTietDDHs(ChiTietDDH entity)
		{
			this.SendPropertyChanging();
			entity.DonDatHang = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.KhachHang")]
	public partial class KhachHang : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _IDKhachHang;
		
		private string _HoTenKhachHang;
		
		private string _TaiKhoan;
		
		private string _MatKhau;
		
		private System.Nullable<System.DateTime> _NgaySinh;
		
		private string _SoDienThoai;
		
		private string _DiaChi;
		
		private string _Email;
		
		private EntitySet<DonDatHang> _DonDatHangs;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDKhachHangChanging(int value);
    partial void OnIDKhachHangChanged();
    partial void OnHoTenKhachHangChanging(string value);
    partial void OnHoTenKhachHangChanged();
    partial void OnTaiKhoanChanging(string value);
    partial void OnTaiKhoanChanged();
    partial void OnMatKhauChanging(string value);
    partial void OnMatKhauChanged();
    partial void OnNgaySinhChanging(System.Nullable<System.DateTime> value);
    partial void OnNgaySinhChanged();
    partial void OnSoDienThoaiChanging(string value);
    partial void OnSoDienThoaiChanged();
    partial void OnDiaChiChanging(string value);
    partial void OnDiaChiChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    #endregion
		
		public KhachHang()
		{
			this._DonDatHangs = new EntitySet<DonDatHang>(new Action<DonDatHang>(this.attach_DonDatHangs), new Action<DonDatHang>(this.detach_DonDatHangs));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDKhachHang", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int IDKhachHang
		{
			get
			{
				return this._IDKhachHang;
			}
			set
			{
				if ((this._IDKhachHang != value))
				{
					this.OnIDKhachHangChanging(value);
					this.SendPropertyChanging();
					this._IDKhachHang = value;
					this.SendPropertyChanged("IDKhachHang");
					this.OnIDKhachHangChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HoTenKhachHang", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string HoTenKhachHang
		{
			get
			{
				return this._HoTenKhachHang;
			}
			set
			{
				if ((this._HoTenKhachHang != value))
				{
					this.OnHoTenKhachHangChanging(value);
					this.SendPropertyChanging();
					this._HoTenKhachHang = value;
					this.SendPropertyChanged("HoTenKhachHang");
					this.OnHoTenKhachHangChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TaiKhoan", DbType="VarChar(50)")]
		public string TaiKhoan
		{
			get
			{
				return this._TaiKhoan;
			}
			set
			{
				if ((this._TaiKhoan != value))
				{
					this.OnTaiKhoanChanging(value);
					this.SendPropertyChanging();
					this._TaiKhoan = value;
					this.SendPropertyChanged("TaiKhoan");
					this.OnTaiKhoanChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MatKhau", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string MatKhau
		{
			get
			{
				return this._MatKhau;
			}
			set
			{
				if ((this._MatKhau != value))
				{
					this.OnMatKhauChanging(value);
					this.SendPropertyChanging();
					this._MatKhau = value;
					this.SendPropertyChanged("MatKhau");
					this.OnMatKhauChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NgaySinh", DbType="DateTime")]
		public System.Nullable<System.DateTime> NgaySinh
		{
			get
			{
				return this._NgaySinh;
			}
			set
			{
				if ((this._NgaySinh != value))
				{
					this.OnNgaySinhChanging(value);
					this.SendPropertyChanging();
					this._NgaySinh = value;
					this.SendPropertyChanged("NgaySinh");
					this.OnNgaySinhChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SoDienThoai", DbType="VarChar(11)")]
		public string SoDienThoai
		{
			get
			{
				return this._SoDienThoai;
			}
			set
			{
				if ((this._SoDienThoai != value))
				{
					this.OnSoDienThoaiChanging(value);
					this.SendPropertyChanging();
					this._SoDienThoai = value;
					this.SendPropertyChanged("SoDienThoai");
					this.OnSoDienThoaiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DiaChi", DbType="NVarChar(200)")]
		public string DiaChi
		{
			get
			{
				return this._DiaChi;
			}
			set
			{
				if ((this._DiaChi != value))
				{
					this.OnDiaChiChanging(value);
					this.SendPropertyChanging();
					this._DiaChi = value;
					this.SendPropertyChanged("DiaChi");
					this.OnDiaChiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="VarChar(100)")]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="KhachHang_DonDatHang", Storage="_DonDatHangs", ThisKey="IDKhachHang", OtherKey="IDKhachHang")]
		public EntitySet<DonDatHang> DonDatHangs
		{
			get
			{
				return this._DonDatHangs;
			}
			set
			{
				this._DonDatHangs.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_DonDatHangs(DonDatHang entity)
		{
			this.SendPropertyChanging();
			entity.KhachHang = this;
		}
		
		private void detach_DonDatHangs(DonDatHang entity)
		{
			this.SendPropertyChanging();
			entity.KhachHang = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.LoaiSanPham")]
	public partial class LoaiSanPham : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _IDLoaiSanPham;
		
		private string _TenLoaiSanPham;
		
		private EntitySet<SanPham> _SanPhams;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDLoaiSanPhamChanging(int value);
    partial void OnIDLoaiSanPhamChanged();
    partial void OnTenLoaiSanPhamChanging(string value);
    partial void OnTenLoaiSanPhamChanged();
    #endregion
		
		public LoaiSanPham()
		{
			this._SanPhams = new EntitySet<SanPham>(new Action<SanPham>(this.attach_SanPhams), new Action<SanPham>(this.detach_SanPhams));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDLoaiSanPham", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int IDLoaiSanPham
		{
			get
			{
				return this._IDLoaiSanPham;
			}
			set
			{
				if ((this._IDLoaiSanPham != value))
				{
					this.OnIDLoaiSanPhamChanging(value);
					this.SendPropertyChanging();
					this._IDLoaiSanPham = value;
					this.SendPropertyChanged("IDLoaiSanPham");
					this.OnIDLoaiSanPhamChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TenLoaiSanPham", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string TenLoaiSanPham
		{
			get
			{
				return this._TenLoaiSanPham;
			}
			set
			{
				if ((this._TenLoaiSanPham != value))
				{
					this.OnTenLoaiSanPhamChanging(value);
					this.SendPropertyChanging();
					this._TenLoaiSanPham = value;
					this.SendPropertyChanged("TenLoaiSanPham");
					this.OnTenLoaiSanPhamChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="LoaiSanPham_SanPham", Storage="_SanPhams", ThisKey="IDLoaiSanPham", OtherKey="IDLoaiSanPham")]
		public EntitySet<SanPham> SanPhams
		{
			get
			{
				return this._SanPhams;
			}
			set
			{
				this._SanPhams.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_SanPhams(SanPham entity)
		{
			this.SendPropertyChanging();
			entity.LoaiSanPham = this;
		}
		
		private void detach_SanPhams(SanPham entity)
		{
			this.SendPropertyChanging();
			entity.LoaiSanPham = null;
		}
	}
}
#pragma warning restore 1591
