
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Action]') AND type in (N'U')) BEGIN
	PRINT 'Dropping Table Action'
	DROP TABLE [dbo].[Action]
END
GO

PRINT 'Creating Table Action'
GO

CREATE TABLE [dbo].[Action]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL
)
GO
