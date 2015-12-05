
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LoginSession]') AND type in (N'U')) BEGIN
	PRINT 'Dropping Table LoginSession'
	DROP TABLE [dbo].[LoginSession]
END
GO

PRINT 'Creating Table LoginSession'
GO

CREATE TABLE [dbo].[LoginSession]
(
	[SessionId] VARCHAR(45) NOT NULL PRIMARY KEY, 
    [UserId] INT NOT NULL, 
	[CreationTime] DATETIME NOT NULL, 
    [Expires] DATETIME NOT NULL
)
GO
