
SET IDENTITY_INSERT [dbo].[Action] ON
GO

INSERT INTO [dbo].[Action] ([Id], [Name]) VALUES (1, 'User.Create')
INSERT INTO [dbo].[Action] ([Id], [Name]) VALUES (2, 'User.List')
INSERT INTO [dbo].[Action] ([Id], [Name]) VALUES (3, 'User.Read')
INSERT INTO [dbo].[Action] ([Id], [Name]) VALUES (4, 'User.Update')
INSERT INTO [dbo].[Action] ([Id], [Name]) VALUES (5, 'User.Delete')
INSERT INTO [dbo].[Action] ([Id], [Name]) VALUES (6, 'Role.Create')
INSERT INTO [dbo].[Action] ([Id], [Name]) VALUES (7, 'Role.List')
INSERT INTO [dbo].[Action] ([Id], [Name]) VALUES (8, 'Role.Read')
INSERT INTO [dbo].[Action] ([Id], [Name]) VALUES (9, 'Role.Update')
INSERT INTO [dbo].[Action] ([Id], [Name]) VALUES (10, 'Role.Delete')
INSERT INTO [dbo].[Action] ([Id], [Name]) VALUES (11, 'Action.Create')
INSERT INTO [dbo].[Action] ([Id], [Name]) VALUES (12, 'Action.List')
INSERT INTO [dbo].[Action] ([Id], [Name]) VALUES (13, 'Action.Read')
INSERT INTO [dbo].[Action] ([Id], [Name]) VALUES (14, 'Action.Update')
INSERT INTO [dbo].[Action] ([Id], [Name]) VALUES (15, 'Action.Delete')
INSERT INTO [dbo].[Action] ([Id], [Name]) VALUES (16, 'Self.Read')
INSERT INTO [dbo].[Action] ([Id], [Name]) VALUES (17, 'Self.Update')
INSERT INTO [dbo].[Action] ([Id], [Name]) VALUES (18, 'LoginSession.Create')
INSERT INTO [dbo].[Action] ([Id], [Name]) VALUES (19, 'LoginSession.List')
INSERT INTO [dbo].[Action] ([Id], [Name]) VALUES (20, 'LoginSession.Read')
INSERT INTO [dbo].[Action] ([Id], [Name]) VALUES (21, 'LoginSession.Update')
INSERT INTO [dbo].[Action] ([Id], [Name]) VALUES (22, 'LoginSession.Delete')

SET IDENTITY_INSERT [dbo].[Action] OFF
GO
