USE [master]
GO
/****** Object:  Database [BasicCMS]    Script Date: 17.12.2019 14:51:46 ******/
CREATE DATABASE [BasicCMS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BasicCMS', FILENAME = N'E:\Databases\BasicCMS.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BasicCMS_log', FILENAME = N'E:\Databases\BasicCMS_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BasicCMS] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BasicCMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BasicCMS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BasicCMS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BasicCMS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BasicCMS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BasicCMS] SET ARITHABORT OFF 
GO
ALTER DATABASE [BasicCMS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BasicCMS] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [BasicCMS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BasicCMS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BasicCMS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BasicCMS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BasicCMS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BasicCMS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BasicCMS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BasicCMS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BasicCMS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BasicCMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BasicCMS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BasicCMS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BasicCMS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BasicCMS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BasicCMS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BasicCMS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BasicCMS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BasicCMS] SET  MULTI_USER 
GO
ALTER DATABASE [BasicCMS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BasicCMS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BasicCMS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BasicCMS] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [BasicCMS]
GO
/****** Object:  Table [dbo].[AboutUs]    Script Date: 17.12.2019 14:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AboutUs](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [nvarchar](max) NOT NULL,
	[isactive] [bit] NOT NULL,
	[createddate] [datetime] NOT NULL,
 CONSTRAINT [PK_AboutUs] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Admins]    Script Date: 17.12.2019 14:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admins](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[surname] [nvarchar](100) NOT NULL,
	[email] [nvarchar](255) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[authority] [nvarchar](50) NULL,
	[isactive] [bit] NOT NULL,
	[createddate] [datetime] NOT NULL,
 CONSTRAINT [PK_Admins] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Blogs]    Script Date: 17.12.2019 14:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blogs](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](250) NOT NULL,
	[description] [nvarchar](max) NOT NULL,
	[imageUrl] [nvarchar](255) NOT NULL,
	[categoryid] [int] NOT NULL,
	[isactive] [bit] NOT NULL,
	[createddate] [datetime] NOT NULL,
 CONSTRAINT [PK_Blogs] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categories]    Script Date: 17.12.2019 14:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NOT NULL,
	[description] [nvarchar](max) NULL,
	[isactive] [bit] NOT NULL,
	[createddate] [datetime] NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Comments]    Script Date: 17.12.2019 14:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[blogid] [int] NOT NULL,
	[name] [nvarchar](250) NOT NULL,
	[email] [nvarchar](255) NOT NULL,
	[comment] [nvarchar](max) NOT NULL,
	[isactive] [bit] NOT NULL,
	[createddate] [datetime] NOT NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Contact]    Script Date: 17.12.2019 14:51:46 ******/
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
	[isactive] [bit] NOT NULL,
	[createddate] [datetime] NOT NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OurServices]    Script Date: 17.12.2019 14:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OurServices](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NOT NULL,
	[description] [nvarchar](max) NULL,
	[imageUrl] [nvarchar](255) NOT NULL,
	[isactive] [bit] NOT NULL,
	[createddate] [datetime] NOT NULL,
 CONSTRAINT [PK_OurServices] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SiteInfos]    Script Date: 17.12.2019 14:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SiteInfos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](150) NOT NULL,
	[keywords] [nvarchar](255) NOT NULL,
	[description] [nvarchar](max) NOT NULL,
	[logoUrl] [nvarchar](255) NOT NULL,
	[degree] [nvarchar](255) NULL,
	[isactive] [bit] NOT NULL,
	[createddate] [datetime] NOT NULL,
 CONSTRAINT [PK_SiteInfos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Slides]    Script Date: 17.12.2019 14:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slides](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](255) NOT NULL,
	[description] [nvarchar](max) NOT NULL,
	[imageUrl] [nvarchar](255) NOT NULL,
	[url] [nvarchar](255) NULL,
	[isactive] [bit] NOT NULL,
	[createddate] [datetime] NOT NULL,
 CONSTRAINT [PK_Slides] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[AboutUs] ON 

INSERT [dbo].[AboutUs] ([id], [description], [isactive], [createddate]) VALUES (1, N'<p>Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam non mod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et eabum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet</p>

<ul>
	<li>Lorem ipsum dolor sit amet</li>
	<li>Consectetur adipiscing elit</li>
	<li>Integer molestie lorem at massa</li>
	<li>Facilisis in pretium nisl aliquet</li>
	<li>Nulla volutpat aliquam velit
	<ul>
		<li>Phasellus iaculis neque</li>
		<li>Purus sodales ultricies</li>
		<li>Vestibulum laoreet porttitor sem</li>
		<li>Ac tristique libero volutpat at</li>
	</ul>
	</li>
	<li>Faucibus porta lacus fringilla vel</li>
	<li>Aenean sit amet erat nunc</li>
	<li>Eget porttitor lorem</li>
</ul>

<p>Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam non mod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua.</p>

<p><strong>Description lists</strong></p>

<p>A description list is perfect for defining terms.</p>

<p><strong>Euismod</strong></p>

<p>Vestibulum id ligula porta felis euismod semper eget lacinia odio sem nec elit.</p>

<p>Donec id elit non mi porta gravida at eget metus.</p>

<p><strong>Malesuada porta</strong></p>

<p>Etiam porta sem malesuada magna mollis euismod.</p>
', 1, CAST(0x0000AB2600C2F2A4 AS DateTime))
SET IDENTITY_INSERT [dbo].[AboutUs] OFF
SET IDENTITY_INSERT [dbo].[Admins] ON 

INSERT [dbo].[Admins] ([id], [name], [surname], [email], [password], [authority], [isactive], [createddate]) VALUES (1, N'Demo', N'User', N'admin@admin.com', N'21232F297A57A5A743894A0E4A801FC3', N'admin', 1, CAST(0x0000AB2600BF5A41 AS DateTime))
SET IDENTITY_INSERT [dbo].[Admins] OFF
SET IDENTITY_INSERT [dbo].[Blogs] ON 

INSERT [dbo].[Blogs] ([id], [title], [description], [imageUrl], [categoryid], [isactive], [createddate]) VALUES (1, N'This is an example of standard post format', N'<p>Qui ut ceteros comprehensam. Cu eos sale sanctus eligendi, id ius elitr saperet, ocurreret pertinacia pri an. No mei nibh consectetuer, semper laoreet perfecto ad qui, est rebum nulla argumentum ei. Fierent adipisci iracundia est ei, usu timeam persius ea. Usu ea justo malis, pri quando everti electram ei, ex homero omittam salutatus sed.</p>
', N'this-is-an-example-of-standard-post-format.jpeg', 1, 1, CAST(0x0000AB2600BFBAD0 AS DateTime))
INSERT [dbo].[Blogs] ([id], [title], [description], [imageUrl], [categoryid], [isactive], [createddate]) VALUES (2, N'What is Lorem Ipsum?', N'<p><em>Lorem ipsum</em>, or&nbsp;<em>lipsum</em>&nbsp;as it is sometimes known, is dummy text used in laying out print, graphic or web designs. The passage is attributed to an unknown typesetter in the 15th century who is thought to have scrambled parts of Cicero&#39;s&nbsp;<em>De Finibus Bonorum et Malorum</em>&nbsp;for use in a type specimen book. It usually begins with:</p>

<p>The purpose of&nbsp;<em>lorem ipsum</em>&nbsp;is to create a natural looking block of text (sentence, paragraph, page, etc.) that doesn&#39;t distract from the layout. A practice not without&nbsp;controversy, laying out pages with meaningless filler text can be very useful when the focus is meant to be on design, not content.</p>

<p>The passage experienced a surge in popularity during the 1960s when Letraset used it on their dry-transfer sheets, and again during the 90s as desktop publishers bundled the text with their software. Today it&#39;s seen all around the web; on templates, websites, and stock designs. Use our&nbsp;generator&nbsp;to get your own, or read on for the authoritative history of&nbsp;<em>lorem ipsum</em>.</p>
', N'what-is-lorem-ipsum.jpeg', 1, 1, CAST(0x0000AB2600C00E04 AS DateTime))
INSERT [dbo].[Blogs] ([id], [title], [description], [imageUrl], [categoryid], [isactive], [createddate]) VALUES (3, N'Fuzzy Beginnings', N'<p>So how did the classical Latin become so incoherent? According to McClintock, a 15th century typesetter likely scrambled part of Cicero&#39;s&nbsp;<em>De Finibus</em>&nbsp;in order to provide placeholder text to mockup various fonts for a type specimen book.</p>

<p>It&#39;s difficult to find examples of&nbsp;<em>lorem ipsum</em>&nbsp;in use before Letraset made it popular as a dummy text in the 1960s, although McClintock says he remembers coming across the&nbsp;<em>lorem ipsum</em>&nbsp;passage in a book of old metal type samples. So far he hasn&#39;t relocated where he once saw the passage, but the popularity of Cicero in the 15th century supports the theory that the filler text has been used for centuries.</p>

<p>And anyways, as&nbsp;Cecil Adams reasoned, &ldquo;[Do you really] think graphic arts supply houses were hiring classics scholars in the 1960s?&rdquo; Perhaps. But it seems reasonable to imagine that there was a version in use far before the age of Letraset.</p>

<p>McClintock&nbsp;wrote&nbsp;to&nbsp;<em>Before &amp; After</em>&nbsp;to explain his discovery;</p>

<p>As an&nbsp;alternative theory, (and because Latin scholars do this sort of thing) someone tracked down a 1914 Latin edition of&nbsp;<em>De Finibus</em>&nbsp;which challenges McClintock&#39;s 15th century claims and suggests that the dawn of&nbsp;<em>lorem ipsum</em>&nbsp;was as recent as the 20th century. The 1914 Loeb Classical Library Edition ran out of room on page 34 for the Latin phrase &ldquo;dolorem ipsum&rdquo; (sorrow in itself). Thus, the truncated phrase leaves one page dangling with &ldquo;do-&rdquo;, while another begins with the now ubiquitous &ldquo;lorem ipsum&rdquo;.</p>
', N'fuzzy-beginnings.jpeg', 1, 1, CAST(0x0000AB2600C051FC AS DateTime))
SET IDENTITY_INSERT [dbo].[Blogs] OFF
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([id], [title], [description], [isactive], [createddate]) VALUES (1, N'Technology', N'Technology category meta description', 1, CAST(0x0000AB2600BF90A0 AS DateTime))
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[Comments] ON 

INSERT [dbo].[Comments] ([id], [blogid], [name], [email], [comment], [isactive], [createddate]) VALUES (1, 2, N'Name', N'name@surname.com', N'Test comment description', 1, CAST(0x0000AB2600E30AA8 AS DateTime))
INSERT [dbo].[Comments] ([id], [blogid], [name], [email], [comment], [isactive], [createddate]) VALUES (2, 3, N'Name', N'name@surname.com', N'Test comment description', 1, CAST(0x0000AB2600E38CBC AS DateTime))
INSERT [dbo].[Comments] ([id], [blogid], [name], [email], [comment], [isactive], [createddate]) VALUES (3, 1, N'Name', N'name@surname.com', N'Test comment description', 0, CAST(0x0000AB2600E39298 AS DateTime))
SET IDENTITY_INSERT [dbo].[Comments] OFF
SET IDENTITY_INSERT [dbo].[Contact] ON 

INSERT [dbo].[Contact] ([id], [address], [phone], [fax], [email], [whatsapp], [facebook], [twitter], [instagram], [isactive], [createddate]) VALUES (1, N'<p>BasicCMS<br />
Modernbuilding suite V124, AB 01<br />
Someplace 16425 Earth</p>
', N'5555555555', N'5555555555', N'email@email.com', N'5555555555', N'basiccms', N'basiccms', N'basiccms', 1, CAST(0x0000AB2600F37758 AS DateTime))
SET IDENTITY_INSERT [dbo].[Contact] OFF
SET IDENTITY_INSERT [dbo].[OurServices] ON 

INSERT [dbo].[OurServices] ([id], [title], [description], [imageUrl], [isactive], [createddate]) VALUES (1, N'Portfolio name 1', N'<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus quis elementum odio. Curabitur pellentesque, dolor vel pharetra mollis.</p>
', N'portfolio-name-1.jpeg', 1, CAST(0x0000AB2600DC017C AS DateTime))
INSERT [dbo].[OurServices] ([id], [title], [description], [imageUrl], [isactive], [createddate]) VALUES (2, N'Portfolio name 2', N'<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus quis elementum odio. Curabitur pellentesque, dolor vel pharetra mollis.</p>
', N'portfolio-name-2.jpeg', 1, CAST(0x0000AB2600DC26FC AS DateTime))
INSERT [dbo].[OurServices] ([id], [title], [description], [imageUrl], [isactive], [createddate]) VALUES (3, N'Portfolio name 3', N'<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus quis elementum odio. Curabitur pellentesque, dolor vel pharetra mollis.</p>
', N'portfolio-name-3.jpeg', 1, CAST(0x0000AB2600DC3638 AS DateTime))
INSERT [dbo].[OurServices] ([id], [title], [description], [imageUrl], [isactive], [createddate]) VALUES (4, N'Portfolio name 4', N'<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus quis elementum odio. Curabitur pellentesque, dolor vel pharetra mollis.</p>
', N'portfolio-name-4.jpeg', 1, CAST(0x0000AB2600DC431C AS DateTime))
INSERT [dbo].[OurServices] ([id], [title], [description], [imageUrl], [isactive], [createddate]) VALUES (5, N'Portfolio name 5', N'<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus quis elementum odio. Curabitur pellentesque, dolor vel pharetra mollis.</p>
', N'portfolio-name-5.jpeg', 1, CAST(0x0000AB2600DC5000 AS DateTime))
INSERT [dbo].[OurServices] ([id], [title], [description], [imageUrl], [isactive], [createddate]) VALUES (6, N'Portfolio name 6', N'<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus quis elementum odio. Curabitur pellentesque, dolor vel pharetra mollis.</p>
', N'portfolio-name-6.jpeg', 1, CAST(0x0000AB2600DC5CE4 AS DateTime))
INSERT [dbo].[OurServices] ([id], [title], [description], [imageUrl], [isactive], [createddate]) VALUES (7, N'Portfolio name 7', N'<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus quis elementum odio. Curabitur pellentesque, dolor vel pharetra mollis.</p>
', N'portfolio-name-7.jpeg', 1, CAST(0x0000AB2600DC6E78 AS DateTime))
INSERT [dbo].[OurServices] ([id], [title], [description], [imageUrl], [isactive], [createddate]) VALUES (8, N'Portfolio name 8', N'<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus quis elementum odio. Curabitur pellentesque, dolor vel pharetra mollis.</p>
', N'portfolio-name-8.jpeg', 1, CAST(0x0000AB2600DC8138 AS DateTime))
SET IDENTITY_INSERT [dbo].[OurServices] OFF
SET IDENTITY_INSERT [dbo].[SiteInfos] ON 

INSERT [dbo].[SiteInfos] ([id], [title], [keywords], [description], [logoUrl], [degree], [isactive], [createddate]) VALUES (1, N'BasicCMS', N'content management system', N'Easy to use content management system for corporate companies', N'site-logo.png', NULL, 1, CAST(0x0000AB2600C2B6E0 AS DateTime))
SET IDENTITY_INSERT [dbo].[SiteInfos] OFF
SET IDENTITY_INSERT [dbo].[Slides] ON 

INSERT [dbo].[Slides] ([id], [title], [description], [imageUrl], [url], [isactive], [createddate]) VALUES (1, N'Modern Design', N'<p>Duis fermentum auctor ligula ac malesuada. <strong>Mauris et metus odio</strong>, in pulvinar urna</p>
', N'modern-design.jpeg', NULL, 1, CAST(0x0000AB2600C23BD4 AS DateTime))
INSERT [dbo].[Slides] ([id], [title], [description], [imageUrl], [url], [isactive], [createddate]) VALUES (2, N'Fully Responsive', N'<p>Sodales neque vitae justo sollicitudin aliquet sit amet diam curabitur sed fermentum.</p>
', N'fully-responsive.jpeg', N'https://www.google.com', 1, CAST(0x0000AB2600C25CA4 AS DateTime))
INSERT [dbo].[Slides] ([id], [title], [description], [imageUrl], [url], [isactive], [createddate]) VALUES (3, N'Clean and Fast', N'<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit donec mer lacinia.</p>
', N'clean-and-fast.jpeg', NULL, 1, CAST(0x0000AB2600C29160 AS DateTime))
SET IDENTITY_INSERT [dbo].[Slides] OFF
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
ALTER TABLE [dbo].[Comments] ADD  CONSTRAINT [DF_Comments_isactive]  DEFAULT ((1)) FOR [isactive]
GO
ALTER TABLE [dbo].[Comments] ADD  CONSTRAINT [DF_Comments_createddate]  DEFAULT (getdate()) FOR [createddate]
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
ALTER TABLE [dbo].[Slides] ADD  CONSTRAINT [DF_Slides_isactive]  DEFAULT ((1)) FOR [isactive]
GO
ALTER TABLE [dbo].[Slides] ADD  CONSTRAINT [DF_Slides_createddate]  DEFAULT (getdate()) FOR [createddate]
GO
USE [master]
GO
ALTER DATABASE [BasicCMS] SET  READ_WRITE 
GO
