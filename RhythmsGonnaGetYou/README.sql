-- Add a new band

INSERT INTO "Bands" (
	"Name", "CountryOfOrigin", "NumberOfMembers", "Website",
  "Style", "IsSigned", "ContactName", "ContactPhoneNumber" )
VALUES (
	'Paramore', 'United States of America', 4, 'https://www.ParamoreBand.com',
  'Alternative', True, 'Paramore Agent', '+19810981810' );

-- View all the bands

SELECT * FROM "Bands";

-- Add an album for a band

INSERT INTO "Albums" ("BandId", "Title", "IsExplicit", "ReleaseDate")
VALUES (1, 'Brand New Eyes', False, '2009-01-01');

-- Add a song to an album

INSERT INTO "Songs" ("AlbumId", "TrackNumber", "Title", "Duration")
VALUES (1, 1, 'Brick by Boring Brick', 203);

-- Let a band go (update isSigned to false)

UPDATE "Bands"
SET "IsSigned" = False
WHERE "Id" = 1;

-- Resign a band (update isSigned to true)

UPDATE "Bands"
SET "IsSigned" = True
WHERE "Id" = 1;

-- Given a band name, view all their albums

SELECT * FROM "Albums"
WHERE "Bands"."Name" = 'Paramore'
JOIN "Bands" ON "Album"."BandId" = "Band"."Id"; 
													-- 						^- Band's Primary Key
													-- ^- Band's Foreign Key on Albums

-- |Title|IsExplicit|ReleaseDate|
-- | ... | ...      | ...       |


-- View all albums (and their associated songs) ordered by ReleaseDate

-- |Ablum.Title|Ablum.IsExplicit|Ablum.ReleaseDate|Song.TrackNumber|Song.Title|Song.Duration|
-- | ... | ...      | ...       |

SELECT "Albums".*, "Songs".*
FROM "Albums"
JOIN "Songs" ON "Song"."AlbumId" = "Album"."Id";
ORDER BY "Ablum"."ReleaseDate" ASC;

-- View all bands that are signed

SELECT * FROM "Bands" WHERE "IsSigned" = True;

-- View all bands that are not signed

SELECT * FROM "Bands" WHERE "IsSigned" = False;
 