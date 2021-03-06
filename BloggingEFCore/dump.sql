USE [BloggingEFCore]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 8/7/2018 7:30:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 8/7/2018 7:30:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Surname] [nvarchar](max) NOT NULL,
	[Bio] [nvarchar](max) NULL,
 CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PostAuthorLink]    Script Date: 8/7/2018 7:30:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostAuthorLink](
	[PostId] [int] NOT NULL,
	[AuthorId] [int] NOT NULL,
 CONSTRAINT [PK_PostAuthorLink] PRIMARY KEY CLUSTERED 
(
	[AuthorId] ASC,
	[PostId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PostMetaData]    Script Date: 8/7/2018 7:30:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostMetaData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PostId] [int] NOT NULL,
	[Key] [nvarchar](max) NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_PostMetaData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Posts]    Script Date: 8/7/2018 7:30:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Content] [nvarchar](max) NULL,
 CONSTRAINT [PK_Posts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20180807155452_Init', N'2.1.1-rtm-30846')
SET IDENTITY_INSERT [dbo].[Authors] ON 

INSERT [dbo].[Authors] ([Id], [Name], [Surname], [Bio]) VALUES (1, NULL, N'Johnson', N'Some info')
INSERT [dbo].[Authors] ([Id], [Name], [Surname], [Bio]) VALUES (2, NULL, N'Smith', NULL)
INSERT [dbo].[Authors] ([Id], [Name], [Surname], [Bio]) VALUES (3, N'John', N'Dow', NULL)
INSERT [dbo].[Authors] ([Id], [Name], [Surname], [Bio]) VALUES (4, NULL, N'Pupkin', NULL)
SET IDENTITY_INSERT [dbo].[Authors] OFF
INSERT [dbo].[PostAuthorLink] ([PostId], [AuthorId]) VALUES (1, 1)
INSERT [dbo].[PostAuthorLink] ([PostId], [AuthorId]) VALUES (1, 2)
INSERT [dbo].[PostAuthorLink] ([PostId], [AuthorId]) VALUES (2, 1)
INSERT [dbo].[PostAuthorLink] ([PostId], [AuthorId]) VALUES (3, 2)
INSERT [dbo].[PostAuthorLink] ([PostId], [AuthorId]) VALUES (3, 3)
INSERT [dbo].[PostAuthorLink] ([PostId], [AuthorId]) VALUES (3, 4)
INSERT [dbo].[PostAuthorLink] ([PostId], [AuthorId]) VALUES (4, 1)
SET IDENTITY_INSERT [dbo].[Posts] ON 

INSERT [dbo].[Posts] ([Id], [Content]) VALUES (1, N'Post 1')
INSERT [dbo].[Posts] ([Id], [Content]) VALUES (2, N'Post 2')
INSERT [dbo].[Posts] ([Id], [Content]) VALUES (3, N'Post 3')
INSERT [dbo].[Posts] ([Id], [Content]) VALUES (4, N'Post 4')
SET IDENTITY_INSERT [dbo].[Posts] OFF
ALTER TABLE [dbo].[PostAuthorLink]  WITH CHECK ADD  CONSTRAINT [FK_PostAuthorLink_Authors_AuthorId] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Authors] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PostAuthorLink] CHECK CONSTRAINT [FK_PostAuthorLink_Authors_AuthorId]
GO
ALTER TABLE [dbo].[PostAuthorLink]  WITH CHECK ADD  CONSTRAINT [FK_PostAuthorLink_Posts_PostId] FOREIGN KEY([PostId])
REFERENCES [dbo].[Posts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PostAuthorLink] CHECK CONSTRAINT [FK_PostAuthorLink_Posts_PostId]
GO
ALTER TABLE [dbo].[PostMetaData]  WITH CHECK ADD  CONSTRAINT [FK_PostMetaData_Posts_PostId] FOREIGN KEY([PostId])
REFERENCES [dbo].[Posts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PostMetaData] CHECK CONSTRAINT [FK_PostMetaData_Posts_PostId]
GO
