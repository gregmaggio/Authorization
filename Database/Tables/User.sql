
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U')) BEGIN
	PRINT 'Dropping Table User'
	DROP TABLE [dbo].[User]
END
GO

PRINT 'Creating Table User'
GO

CREATE TABLE [dbo].[User]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY, 
    [Email] VARCHAR(255) NOT NULL, 
	[Password] VARCHAR(255) NOT NULL, 
    [FirstName] VARCHAR(255) NOT NULL, 
    [LastName] VARCHAR(255) NOT NULL,
	CONSTRAINT [User_Email_Index] UNIQUE NONCLUSTERED ([Email])
)
GO
