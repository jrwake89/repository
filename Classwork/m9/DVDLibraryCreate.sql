﻿USE master
GO

IF EXISTS(SELECT * FROM sys.sysdatabases WHERE NAME='DVDLibrary')
BEGIN
	DROP DATABASE DVDLibrary
END

CREATE DATABASE DVDLibrary
GO

USE DVDLibrary
GO


IF EXISTS(SELECT * FROM sys.tables WHERE name='Rating')
	DROP TABLE Rating
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='DVD')
	DROP TABLE DVD
GO


CREATE TABLE Rating (
	RatingID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Rating VARCHAR(5) NOT NULL
)

CREATE TABLE DVD (
	DVDID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	RatingID INT FOREIGN KEY REFERENCES Rating(RatingID) NOT NULL,
	Director VARCHAR(30) NOT NULL,
	DVDTitle VARCHAR(30) NOT NULL,
	ReleaseYear INT NOT NULL,
	Notes VARCHAR(150)
)

