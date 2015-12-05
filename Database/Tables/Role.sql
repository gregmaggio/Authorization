
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Role]') AND type in (N'U')) BEGIN
	PRINT 'Dropping Table Role'
	DROP TABLE [dbo].[Role]
END
GO

PRINT 'Creating Table Role'
GO

CREATE TABLE [dbo].[Role]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL
)
GO
