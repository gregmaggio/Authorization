
SET IDENTITY_INSERT [dbo].[User] ON
GO

INSERT INTO [dbo].[User] ([Id], [Email], [Password], [FirstName], [LastName])
	VALUES (1, 'gregorymaggio@gmail.com', 'F906CC424FF2B5259AE1D569BCA4A1AF', 'Gregory', 'Maggio')
--password: MhfSlcNPFmiy8L7sYZQw
--encryptedPassword: F906CC424FF2B5259AE1D569BCA4A1AF


INSERT INTO [dbo].[UserRole]([UserId], [RoleId]) VALUES (1, 1)
INSERT INTO [dbo].[UserRole]([UserId], [RoleId]) VALUES (1, 2)
INSERT INTO [dbo].[UserRole]([UserId], [RoleId]) VALUES (1, 3)
INSERT INTO [dbo].[UserRole]([UserId], [RoleId]) VALUES (1, 4)
INSERT INTO [dbo].[UserRole]([UserId], [RoleId]) VALUES (1, 5)

SET IDENTITY_INSERT [dbo].[User] OFF
GO
