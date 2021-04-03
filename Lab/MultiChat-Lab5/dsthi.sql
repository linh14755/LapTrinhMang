create database DsThi
go
use DsThi
go
create table DSLop
(
  Lop nvarchar(30) primary key
)
go
create table SinhVien
(
	MSSV int primary key,
	TEN nvarchar(30),
	Lop nvarchar(30) references DSLop(Lop)
)

select * from dslop

insert into DSLop values('CKT41')
insert into DSLop values('CKT42')
insert into DSLop values('CKT43')
insert into DSLop values('CKT44')

insert into SinhVien values('1812790',N'Nguyễn Khánh Linh','CKT42')
insert into SinhVien values('1812823',N'Vi Văn Phúc','CKT42')
insert into SinhVien values('1813865',N'Nguyễn Quốc Vương','CKT42')
insert into SinhVien values('1812859',N'Nguyễn Thị Thùy Trang','CKT42')