USE [BasicCMS]
GO
/****** Object:  Table [dbo].[AboutUs]    Script Date: 01/12/2019 21:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AboutUs](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [nvarchar](max) NULL,
	[isactive] [bit] NULL,
	[createddate] [datetime] NULL,
 CONSTRAINT [PK_AboutUs] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Admins]    Script Date: 01/12/2019 21:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admins](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email] [nvarchar](255) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[authority] [nvarchar](50) NOT NULL,
	[isactive] [bit] NULL,
	[createddate] [datetime] NULL,
 CONSTRAINT [PK_Admins] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Blogs]    Script Date: 01/12/2019 21:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blogs](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](250) NOT NULL,
	[description] [nvarchar](max) NULL,
	[imageUrl] [nvarchar](255) NULL,
	[categoryid] [int] NULL,
	[isactive] [bit] NULL,
	[createddate] [datetime] NULL,
 CONSTRAINT [PK_Blogs] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categories]    Script Date: 01/12/2019 21:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NULL,
	[description] [nvarchar](max) NULL,
	[isactive] [bit] NULL,
	[createddate] [datetime] NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Contact]    Script Date: 01/12/2019 21:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[address] [nvarchar](max) NOT NULL,
	[phone] [nvarchar](50) NULL,
	[fax] [nvarchar](50) NULL,
	[email] [nvarchar](255) NULL,
	[whatsapp] [nvarchar](50) NULL,
	[facebook] [nvarchar](20) NULL,
	[twitter] [nvarchar](20) NULL,
	[instagram] [nvarchar](20) NULL,
	[isactive] [bit] NULL,
	[createddate] [datetime] NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OurServices]    Script Date: 01/12/2019 21:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OurServices](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NOT NULL,
	[description] [nvarchar](500) NULL,
	[imageUrl] [nvarchar](255) NULL,
	[isactive] [bit] NULL,
	[createddate] [datetime] NULL,
 CONSTRAINT [PK_OurServices] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SiteInfos]    Script Date: 01/12/2019 21:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SiteInfos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](150) NULL,
	[keywords] [nvarchar](255) NULL,
	[description] [nvarchar](500) NULL,
	[logoUrl] [nvarchar](255) NULL,
	[degree] [nvarchar](255) NULL,
	[isactive] [bit] NULL,
	[createddate] [datetime] NULL,
 CONSTRAINT [PK_SiteInfos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[AboutUs] ADD  CONSTRAINT [DF_AboutUs_isactive]  DEFAULT ((1)) FOR [isactive]
GO
ALTER TABLE [dbo].[AboutUs] ADD  CONSTRAINT [DF_AboutUs_createddate]  DEFAULT (getdate()) FOR [createddate]
GO
ALTER TABLE [dbo].[Admins] ADD  CONSTRAINT [DF_Admins_isactive]  DEFAULT ((1)) FOR [isactive]
GO
ALTER TABLE [dbo].[Admins] ADD  CONSTRAINT [DF_Admins_createddate]  DEFAULT (getdate()) FOR [createddate]
GO
ALTER TABLE [dbo].[Blogs] ADD  CONSTRAINT [DF_Blogs_isactive]  DEFAULT ((1)) FOR [isactive]
GO
ALTER TABLE [dbo].[Blogs] ADD  CONSTRAINT [DF_Blogs_createddate]  DEFAULT (getdate()) FOR [createddate]
GO
ALTER TABLE [dbo].[Categories] ADD  CONSTRAINT [DF_Categories_isactive]  DEFAULT ((1)) FOR [isactive]
GO
ALTER TABLE [dbo].[Categories] ADD  CONSTRAINT [DF_Categories_createddate]  DEFAULT (getdate()) FOR [createddate]
GO
ALTER TABLE [dbo].[Contact] ADD  CONSTRAINT [DF_Contact_isactive]  DEFAULT ((1)) FOR [isactive]
GO
ALTER TABLE [dbo].[Contact] ADD  CONSTRAINT [DF_Contact_createddate]  DEFAULT (getdate()) FOR [createddate]
GO
ALTER TABLE [dbo].[OurServices] ADD  CONSTRAINT [DF_OurServices_isactive]  DEFAULT ((1)) FOR [isactive]
GO
ALTER TABLE [dbo].[OurServices] ADD  CONSTRAINT [DF_OurServices_createddate]  DEFAULT (getdate()) FOR [createddate]
GO
ALTER TABLE [dbo].[SiteInfos] ADD  CONSTRAINT [DF_SiteInfos_isactive]  DEFAULT ((1)) FOR [isactive]
GO
ALTER TABLE [dbo].[SiteInfos] ADD  CONSTRAINT [DF_SiteInfos_createddate]  DEFAULT (getdate()) FOR [createddate]
GO
ALTER TABLE [dbo].[Blogs]  WITH CHECK ADD  CONSTRAINT [FK_Blogs_Categories] FOREIGN KEY([categoryid])
REFERENCES [dbo].[Categories] ([id])
GO
ALTER TABLE [dbo].[Blogs] CHECK CONSTRAINT [FK_Blogs_Categories]
GO
