
SET IDENTITY_INSERT [dbo].[Role] ON
GO

INSERT INTO [dbo].[Role] ([Id], [Name]) VALUES (1, 'UserAdmin')
INSERT INTO [dbo].[Role] ([Id], [Name]) VALUES (2, 'RoleAdmin')
INSERT INTO [dbo].[Role] ([Id], [Name]) VALUES (3, 'ActionAdmin')
INSERT INTO [dbo].[Role] ([Id], [Name]) VALUES (4, 'LoginSessionAdmin')
INSERT INTO [dbo].[Role] ([Id], [Name]) VALUES (5, 'User')

SET IDENTITY_INSERT [dbo].[Role] OFF
GO

INSERT INTO [dbo].[RoleAction] ([RoleId], [ActionId]) VALUES (1, 1)
INSERT INTO [dbo].[RoleAction] ([RoleId], [ActionId]) VALUES (1, 2)
INSERT INTO [dbo].[RoleAction] ([RoleId], [ActionId]) VALUES (1, 3)
INSERT INTO [dbo].[RoleAction] ([RoleId], [ActionId]) VALUES (1, 4)
INSERT INTO [dbo].[RoleAction] ([RoleId], [ActionId]) VALUES (1, 5)
INSERT INTO [dbo].[RoleAction] ([RoleId], [ActionId]) VALUES (2, 6)
INSERT INTO [dbo].[RoleAction] ([RoleId], [ActionId]) VALUES (2, 7)
INSERT INTO [dbo].[RoleAction] ([RoleId], [ActionId]) VALUES (2, 8)
INSERT INTO [dbo].[RoleAction] ([RoleId], [ActionId]) VALUES (2, 9)
INSERT INTO [dbo].[RoleAction] ([RoleId], [ActionId]) VALUES (2, 10)
INSERT INTO [dbo].[RoleAction] ([RoleId], [ActionId]) VALUES (3, 11)
INSERT INTO [dbo].[RoleAction] ([RoleId], [ActionId]) VALUES (3, 12)
INSERT INTO [dbo].[RoleAction] ([RoleId], [ActionId]) VALUES (3, 13)
INSERT INTO [dbo].[RoleAction] ([RoleId], [ActionId]) VALUES (3, 14)
INSERT INTO [dbo].[RoleAction] ([RoleId], [ActionId]) VALUES (3, 15)
INSERT INTO [dbo].[RoleAction] ([RoleId], [ActionId]) VALUES (4, 18)
INSERT INTO [dbo].[RoleAction] ([RoleId], [ActionId]) VALUES (4, 19)
INSERT INTO [dbo].[RoleAction] ([RoleId], [ActionId]) VALUES (4, 20)
INSERT INTO [dbo].[RoleAction] ([RoleId], [ActionId]) VALUES (4, 21)
INSERT INTO [dbo].[RoleAction] ([RoleId], [ActionId]) VALUES (4, 22)
INSERT INTO [dbo].[RoleAction] ([RoleId], [ActionId]) VALUES (5, 16)
INSERT INTO [dbo].[RoleAction] ([RoleId], [ActionId]) VALUES (5, 17)





