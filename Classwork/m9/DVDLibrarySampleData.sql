SET IDENTITY_INSERT Rating ON

INSERT INTO Rating (RatingId, Rating)
VALUES (1, 'G'),
	(2, 'PG'),
	(3, 'PG-13'),
	(4, 'R')

SET IDENTITY_INSERT Rating OFF

SET IDENTITY_INSERT DVD ON

INSERT INTO DVD (DVDID, RatingID, Director, DVDTitle, ReleaseYear, Notes)
VALUES (1, 1, 'Disney Guy', 'The Lion King', 1995, 'FANTASTIC!'),
	(2, 4, 'Terminator Guy', 'Terminator', 1992, 'INCREDIBLE!'),
	(3, 3, 'Christopher Nolan', 'Inception', 2010, 'UNREAL'),
	(4, 3, 'Christopher Nolan', 'The Dark Knight', 2008, 'SO GOOD!')

SET IDENTITY_INSERT DVD OFF