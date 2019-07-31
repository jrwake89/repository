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
    TaxID INT IDENTITY(1,1) PRIMARY KEY
	TaxTypeID INT FOREIGN KEY REFERENCES TaxType(TaxTypeID)
)
GO

CREATE TABLE RoomType (
    RoomTypeID INT IDENTITY(1,1) PRIMARY KEY,
    RoomID INT FOREIGN KEY REFERENCES Room(RoomID),
    RoomType VARCHAR(30) NOT NULL
)

CREATE TABLE Room (
    RoomID INT IDENTITY(1,1) PRIMARY KEY,
    RoomMax SMALLINT NOT NULL,
    RoomFloor SMALLINT NOT NULL,
	ReservationID INT FOREIGN KEY REFERENCES Reservation(ReservationID),
	RoomTypeID INT FOREIGN KEY REFERENCES RoomType(RoomTypeID)
)
GO

CREATE TABLE RoomRate (
    RoomRateID INT IDENTITY(1,1) PRIMARY KEY,
    RoomTypeID INT FOREIGN KEY REFERENCES RoomType(RoomTypeID),
	TaxID INT FOREIGN KEY REFERENCES Tax(TaxID)
    RoomRate INT NOT NULL,
    StartDate Datetime NULL,
    EndDate Datetime NULL
)

CREATE TABLE RoomAmenityType (
    RoomAmenityTypeID INT IDENTITY(1,1) PRIMARY KEY,
    RoomAmneityType VARCHAR(30) NOT NULL
)

CREATE TABLE RoomAmenity (
    RoomID INT FOREIGN KEY REFERENCES Room(RoomID),
    RoomAmenityTypeID INT FOREIGN KEY REFERENCES RoomAmenityType(RoomAmenityTypeID),
	RoomID INT FOREIGN KEY REFERENCES Room(RoomID)  
    )

CREATE TABLE ReservationInfo (
    ReservationInfoID INT IDENTITY(1,1) PRIMARY KEY,
    ReservationID INT FOREIGN KEY REFERENCES Reservation(ReservationID),
    RoomID INT FOREIGN KEY REFERENCES Room(RoomID),
    StartDate Datetime NULL,
    EndDate Datetime NULL
    )

    CREATE TABLE Orders (
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    RoomID INT FOREIGN KEY REFERENCES Room(RoomID)
    )

    CREATE TABLE OrderDetails (
    OrderDetailsID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
    Amount INT NOT NULL,
    OrderType NVARCHAR NOT NULL
    )

    CREATE TABLE AddOnOrders (
    AddOnOrdersID INT IDENTITY (1,1) PRIMARY KEY,
    AddOnType NVARCHAR NOT NULL,
    AddOnDescription NVARCHAR NOT NULL
    )

    CREATE TABLE AddOnPrices (
    AddOnPriceID INT IDENTITY(1,1) PRIMARY KEY,
    AddOnOrdersID INT FOREIGN KEY REFERENCES AddOnOrders(AddOnOrdersID),
    StartDate Datetime NULL,
    EndDate Datetime NULL,
    Price INT NOT NULL,
    TaxID INT FOREIGN KEY REFERENCES Tax(TaxID)
    )