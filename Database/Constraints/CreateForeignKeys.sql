
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LoginSession_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[UserRole]')) BEGIN
	PRINT 'Creating Constraint LoginSession - User'
	ALTER TABLE [LoginSession]
	ADD CONSTRAINT FK_LoginSession_User FOREIGN KEY ([UserId]) 
		REFERENCES [User] ([Id]) 
		ON DELETE CASCADE
END
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_User_UserRole]') AND parent_object_id = OBJECT_ID(N'[dbo].[UserRole]')) BEGIN
	PRINT 'Creating Constraint User - UserRole'
	ALTER TABLE [UserRole]
	ADD CONSTRAINT FK_User_UserRole FOREIGN KEY ([UserId]) 
		REFERENCES [User] ([Id]) 
		ON DELETE CASCADE
END
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Role_UserRole]') AND parent_object_id = OBJECT_ID(N'[dbo].[UserRole]')) BEGIN
	PRINT 'Creating Constraint Role - UserRole'
	ALTER TABLE [UserRole]
	ADD CONSTRAINT FK_Role_UserRole FOREIGN KEY ([RoleId]) 
		REFERENCES [Role] ([Id]) 
		ON DELETE CASCADE
END
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Role_RoleAction]') AND parent_object_id = OBJECT_ID(N'[dbo].[RoleAction]')) BEGIN
	PRINT 'Creating Constraint Role - RoleAction'
	ALTER TABLE [RoleAction]
	ADD CONSTRAINT FK_Role_RoleAction FOREIGN KEY ([RoleId]) 
		REFERENCES [Role] ([Id]) 
		ON DELETE CASCADE
END
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Action_RoleAction]') AND parent_object_id = OBJECT_ID(N'[dbo].[RoleAction]')) BEGIN
	PRINT 'Creating Constraint Action - RoleAction'
	ALTER TABLE [RoleAction]
	ADD CONSTRAINT FK_Action_RoleAction FOREIGN KEY ([ActionId]) 
		REFERENCES [Action] ([Id]) 
		ON DELETE CASCADE
END
GO


GO

