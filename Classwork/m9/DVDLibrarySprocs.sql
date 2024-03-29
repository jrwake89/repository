﻿USE DVDLibrary
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DVDByID')
      DROP PROCEDURE DVDByID
GO

CREATE PROCEDURE DVDByID (
	@DVDID INT
)
AS

SELECT *
FROM DVD
	INNER JOIN Rating
	ON Rating.RatingID = DVD.RatingID
WHERE @DVDID = DVD.DVDID

GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'AllDVD')
      DROP PROCEDURE AllDVD
GO
CREATE PROCEDURE AllDVD 
AS

SELECT *
FROM DVD
	INNER JOIN Rating
	ON Rating.RatingID = DVD.RatingID

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DVDTitle')
      DROP PROCEDURE DVDTitle
GO
CREATE PROCEDURE DVDTitle (
	@DVDTitle VARCHAR(30)
)
AS

SELECT *
FROM DVD
	INNER JOIN Rating
	ON Rating.RatingID = DVD.RatingID
	WHERE @DVDTitle = DVD.DVDTitle
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DVDReleaseYear')
      DROP PROCEDURE DVDReleaseYear
GO
CREATE PROCEDURE DVDReleaseYear (
	@ReleaseYear INT
)
AS

SELECT *
FROM DVD
	INNER JOIN Rating
	ON Rating.RatingID = DVD.RatingID
	WHERE @ReleaseYear = DVD.ReleaseYear

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DVDDirector')
      DROP PROCEDURE DVDDirector
GO
CREATE PROCEDURE DVDDirector (
	@Director VARCHAR(30)
)
AS

SELECT *
FROM DVD
	INNER JOIN Rating
	ON Rating.RatingID = DVD.RatingID
	WHERE @Director = DVD.Director
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DVDByRating')
      DROP PROCEDURE DVDByRating
GO
CREATE PROCEDURE DVDByRating (
	@RatingID INT
)
AS

SELECT *
FROM Rating
	INNER JOIN DVD
	ON DVD.RatingID = Rating.RatingID
	WHERE @RatingID = DVD.RatingID

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'InsertDVD')
      DROP PROCEDURE InsertDVD
GO
CREATE PROCEDURE InsertDVD (
	@DVDID INT OUTPUT,
	@Director VARCHAR(30),
	@RatingID INT,
	@DVDTitle VARCHAR(30),
	@ReleaseYear INT,
	@Notes VARCHAR(150)
)
AS

INSERT INTO DVD (Director, RatingID, DVDTitle, ReleaseYear, Notes)
	VALUES (@Director, @RatingID, @DVDTitle, @ReleaseYear, @Notes)

	SET @DVDID = SCOPE_IDENTITY()

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'UpdateDVD')
      DROP PROCEDURE UpdateDVD
GO

CREATE PROCEDURE UpdateDVD (
	@DVDID INT,
	@Director VARCHAR(30),
	@RatingID INT,
	@DVDTitle VARCHAR(30),
	@ReleaseYear INT,
	@Notes VARCHAR(150)
)
AS
	UPDATE DVD
		SET Director = @Director,
		RatingID = @RatingID,
		DVDTitle = @DVDTitle,
		ReleaseYear = @ReleaseYear,
		Notes = @Notes
	WHERE DVDID = @DVDID;
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DVDDelete')
      DROP PROCEDURE DVDDelete
GO

CREATE PROCEDURE DVDDelete (
	@DVDID INT
)
AS
	DELETE FROM DVD
	WHERE DVDID = @DVDID
GO