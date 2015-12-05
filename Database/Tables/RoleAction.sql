
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RoleAction]') AND type in (N'U')) BEGIN
	PRINT 'Dropping Table RoleAction'
	DROP TABLE [dbo].[RoleAction]
END
GO

PRINT 'Creating Table RoleAction'
GO

CREATE TABLE [dbo].[RoleAction]
(
	[RoleId] INT NOT NULL , 
    [ActionId] INT NOT NULL, 
    PRIMARY KEY ([ActionId], [RoleId])
)
GO
