

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LoadActions]') AND type in (N'P', N'PC')) BEGIN
	PRINT 'Dropping Procedure LoadActions'
	DROP PROCEDURE [dbo].[LoadActions]
END
GO

PRINT 'Creating Procedure LoadActions'
GO

CREATE PROCEDURE [dbo].[LoadActions]
	@userId [int]
AS
	SELECT a.* FROM [dbo].[Action] a
	INNER JOIN [dbo].[RoleAction] ra ON a.[Id] = ra.[ActionId]
	INNER JOIN [dbo].[UserRole] ur ON ra.[RoleId] = ur.[RoleId]
	WHERE ur.[UserId] = @userId
GO
