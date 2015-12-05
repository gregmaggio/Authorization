
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserRole]') AND type in (N'U')) BEGIN
	PRINT 'Dropping Table UserRole'
	DROP TABLE [dbo].[UserRole]
END
GO

PRINT 'Creating Table UserRole'
GO

CREATE TABLE [dbo].[UserRole]
(
	[UserId] INT NOT NULL , 
    [RoleId] INT NOT NULL, 
    PRIMARY KEY ([RoleId], [UserId])
)
GO
