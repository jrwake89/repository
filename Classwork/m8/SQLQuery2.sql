USE master
IF EXISTS(select * from sys.databases where name='HotelReservation')

DROP DATABASE HotelReservation

CREATE DATABASE HotelReservation


USE HotelReservation
GO

CREATE TABLE Customers (
  CustomerID INT IDENTITY(1,1) PRIMARY KEY,
  StartDate DATE NOT NULL,
  FirstName VARCHAR(30) NOT NULL,
  LastName VARCHAR(30) NOT NULL,
  PhoneNumber INT,
  Email VARCHAR(30) NOT NULL
)
GO

CREATE TABLE PromoType (
    PromoTypeID INT IDENTITY(1,1) PRIMARY KEY,
    PromoType CHAR NOT NULL,
)
GO

CREATE TABLE Promo (
    PromoID INT IDENTITY(1,1) PRIMARY KEY,
    PromoTypeID INT FOREIGN KEY REFERENCES PromoType(PromoTypeID),
    PromoCode NVARCHAR NOT NULL,
    StartDate Datetime NULL,
    EndDate Datetime NULL
)

CREATE TABLE Reservation (
  ReservationID INT IDENTITY(1,1) PRIMARY KEY,
  PromoID INT FOREIGN KEY REFERENCES Promo(PromoID),
  CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID),
  StartDate Datetime NULL,
  EndDate Datetime NULL
)
GO

CREATE TABLE Guest (
  GuestID INT IDENTITY(1,1) PRIMARY KEY,
  CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID),
  FirstName VARCHAR(30) NOT NULL,
  LastName VARCHAR(30) NOT NULL,
  Age SMALLINT
)
GO

CREATE TABLE TaxType (
    TaxTypeID INT IDENTITY(1,1) PRIMARY KEY,
    TaxType VARCHAR(30) NOT NULL,
    TaxNum DECIMAL (3,0)
)
GO

CREATE TABLE Tax (
    TaxID INT IDENTITY(1,1) PRIMARY KEY,
	TaxTypeID INT FOREIGN KEY REFERENCES TaxType(TaxTypeID)
)
GO

CREATE TABLE Room (
    RoomID INT IDENTITY(1,1) PRIMARY KEY,
    RoomMax SMALLINT NOT NULL,
    RoomFloor SMALLINT NOT NULL,
	ReservationID INT FOREIGN KEY REFERENCES Reservation(ReservationID),
)
GO

CREATE TABLE RoomType (
    RoomTypeID INT IDENTITY(1,1) PRIMARY KEY,
	RoomDesc VARCHAR(30) NOT NULL,
	TaxID INT FOREIGN KEY REFERENCES Tax(TaxID),
    RoomRate INT NOT NULL,
    StartDate Datetime NULL,
    EndDate Datetime NULL
)

CREATE TABLE RoomRoomType (
    RoomTypeID INT NOT NULL,
    RoomID INT NOT NULL,
			CONSTRAINT PK_RoomRoomType
		PRIMARY KEY (RoomID, RoomTypeID),
	CONSTRAINT FK_Room_RoomRoomType
		FOREIGN KEY (RoomID) 
		REFERENCES Room(RoomID),
	CONSTRAINT FK_RoomTypeID_RoomRoomType
		FOREIGN KEY (RoomTypeID) 
		REFERENCES RoomType(RoomTypeID)
    
)


CREATE TABLE Amenity (
    AmenityTypeID INT IDENTITY(1,1) PRIMARY KEY,
    AmneityType VARCHAR(30) NOT NULL
)

CREATE TABLE RoomAmenity (
    RoomID INT NOT NULL,
    AmenityTypeID INT NOT NULL,
		CONSTRAINT PK_RoomAmenity
		PRIMARY KEY (RoomID, AmenityTypeID),
	CONSTRAINT FK_Room_RoomAmenity
		FOREIGN KEY (RoomID) 
		REFERENCES Room(RoomID),
	CONSTRAINT FK_AmenityTypeID_RoomAmenity
		FOREIGN KEY (AmenityTypeID) 
		REFERENCES Amenity(AmenityTypeID)
    )

CREATE TABLE ReservationInfo (
    ReservationInfoID INT IDENTITY(1,1) PRIMARY KEY,
    ReservationID INT FOREIGN KEY REFERENCES Reservation(ReservationID),
    RoomID INT FOREIGN KEY REFERENCES Room(RoomID),
    StartDate Datetime NULL,
    EndDate Datetime NULL
    )

	CREATE TABLE AddOn(
    AddOnID INT IDENTITY (1,1) PRIMARY KEY,
    AddOnType NVARCHAR NOT NULL,
    AddOnDescription NVARCHAR NOT NULL,
	Price INT NOT NULL,
	StartDate Datetime NULL,
    EndDate Datetime NULL,
	TaxID INT FOREIGN KEY REFERENCES Tax(TaxID)
    )

    CREATE TABLE RoomAddOn (
    AddOnID INT NOT NULL,
    RoomID INT NOT NULL,
			CONSTRAINT PK_RoomAddOn
		PRIMARY KEY (RoomID, AddOnID),
	CONSTRAINT FK_Room_RoomAddOn
		FOREIGN KEY (RoomID) 
		REFERENCES Room(RoomID),
	CONSTRAINT FK_AddOnID_AddOn
		FOREIGN KEY (AddOnID) 
		REFERENCES AddOn(AddOnID)
    )


