
-- @ Nguyễn Công Thuận

CREATE DATABASE HoTenDB
GO
USE HoTenDB
GO
-- Tạo table UserAccount
CREATE TABLE UserAccount
(
	ID	int IDENTITY(1,1)  PRIMARY KEY,
	UserName varchar(50) not null,
	Password varchar(50) not null,
	Status nvarchar(100) null,
)
INSERT INTO UserAccount (UserName, Password, Status)
	VALUES	('congThuan','123123','Active'),
			('vanABC','456456','Blocked'),
			('caoBa','878ba','Blocked'),
			('hoangVan','hihi123','Active'),
			('leVanKhoa','hoang123','Blocked'),
			('caoVanHuy','huy000','Active'),
			('tranViet','viet1111','Active'),
			('huongTram','tram999','Active'),
			('thiDEF','789789','Active'); 
GO
-- Tạo table Category
CREATE TABLE Category
(
	ID int primary key,
	Name nvarchar(100) not null,
	Description nvarchar(200) null
)
INSERT INTO Category
	VALUES	(54372,N'Sách Bán Chạy',null),
			(58891,N'Sách Kinh Tế',null),
			(51119,N'Sách Mới Ra Mắt',null);
GO
-- Tạo table Product
CREATE TABLE Product
(
	ID int PRIMARY KEY,
	Name nvarchar(100) not null,
	UnitCost money not null,
	Quantity int not null default 0,
	Image nvarchar(225) null,
	Description nvarchar(200) null,
	Status nvarchar(100) null,
	IDCategoryNo int foreign key references Category(ID)
)
INSERT INTO Product
	VALUES	('12341',N'Người Nam Châm',120000,14,'~/Content/Images/nguoiNamCham.jpg', null, null, 58891),
			('19931',N'Trên Đường Băng',98000,53,'~/Content/Images/nguoiNamCham.jpg', null, null, 54372);
	