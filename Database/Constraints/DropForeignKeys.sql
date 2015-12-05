
IF EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LoginSession_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[UserRole]')) BEGIN
	PRINT 'Dropping Constraint LoginSession - User'
	ALTER TABLE [LoginSession] DROP CONSTRAINT FK_LoginSession_User 
END
GO

IF EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_User_UserRole]') AND parent_object_id = OBJECT_ID(N'[dbo].[UserRole]')) BEGIN
	PRINT 'Dropping Constraint User - UserRole'
	ALTER TABLE [dbo].[UserRole] DROP CONSTRAINT [FK_User_UserRole]
END
GO

IF EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Role_UserRole]') AND parent_object_id = OBJECT_ID(N'[dbo].[UserRole]')) BEGIN
	PRINT 'Dropping Constraint Role - UserRole'
	ALTER TABLE [dbo].[UserRole] DROP CONSTRAINT [FK_Role_UserRole]
END
GO

IF EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Role_RoleAction]') AND parent_object_id = OBJECT_ID(N'[dbo].[RoleAction]')) BEGIN
	PRINT 'Dropping Constraint Role - RoleAction'
	ALTER TABLE [dbo].[RoleAction] DROP CONSTRAINT [FK_Role_RoleAction]
END
GO

IF EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Action_RoleAction]') AND parent_object_id = OBJECT_ID(N'[dbo].[RoleAction]')) BEGIN
	PRINT 'Dropping Constraint Action - RoleAction'
	ALTER TABLE [dbo].[RoleAction] DROP CONSTRAINT [FK_Action_RoleAction]
END
GO
