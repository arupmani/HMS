IF NOT EXISTS(SELECT 1 FROM SYS.tables WHERE name='RoomType')
BEGIN
	Create table RoomType
	(
	Id INT Primary Key IDENTITY(1,1),
	Name VARCHAR(100) NOT NULL,
	IsActive BIT Default(1),
	CreatedDate Datetime Default(GetDate())
	)
END
GO


IF NOT EXISTS(SELECT 1 FROM SYS.tables WHERE name='BookingStatus')
BEGIN
	Create table BookingStatus
	(
	Id INT Primary Key IDENTITY(1,1),
	Name VARCHAR(100) NOT NULL,
	IsActive BIT Default(1),
	CreatedDate Datetime Default(GetDate())
	)
END
GO


IF NOT EXISTS(SELECT 1 FROM SYS.tables WHERE name='Room')
BEGIN
	Create Table Room
	(
	Id INT  Primary Key IDENTITY(1,1),
	RoomNo VARCHAR(100) CONSTRAINT UC_RoomNumber UNIQUE (RoomNo) NOT NULL,
	RoomTypeId INT  CONSTRAINT FK_RoomType_Room Foreign Key References RoomType(Id),
	IsActive BIT Default(1),
	CreatedDate Datetime Default(GetDate())
	)
END
GO

IF NOT EXISTS(SELECT 1 FROM SYS.tables WHERE name='Booking')
BEGIN
	Create Table Booking
	(
	Id INT  Primary Key IDENTITY(1,1),
	RoomId  INT  CONSTRAINT FK_Room_RoomId Foreign Key References Room(Id) NOT NULL,
	BookingFrom DateTime,
	BookingTo DateTime,
	IsActive BIT DEFAULT(1),
	CreatedDate Datetime Default(GetDate()),
	BookedBy NVARCHAR(256)  NOT NULL,
	)
END
GO

IF NOT EXISTS(SELECT 1 FROM SYS.tables WHERE name='AppUser')
BEGIN
	Create Table AppUser
	(
	UserId INT  Primary Key IDENTITY(1,1),
	UserName VARCHAR(100) CONSTRAINT UC_AppUserUserName UNIQUE (UserName) NOT NULL,
	Password  VARCHAR(100)  NOT NULL,
	Email VARCHAR(100) CONSTRAINT UC_AppUserEmail UNIQUE (Email) NULL,
	CreatedDate Datetime Default(GetDate()),
	IsActive BIT Default(1)

	)
END