

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LoadRoles]') AND type in (N'P', N'PC')) BEGIN
	PRINT 'Dropping Procedure LoadRoles'
	DROP PROCEDURE [dbo].[LoadRoles]
END
GO

PRINT 'Creating Procedure LoadRoles'
GO

CREATE PROCEDURE [dbo].[LoadRoles]
	@userId [int]
AS
	SELECT r.* FROM [dbo].[Role] r
	INNER JOIN [dbo].[UserRole] ur ON r.[Id] = ur.[RoleId]
	WHERE ur.[UserId] = @userId
GO
