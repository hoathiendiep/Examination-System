USE [master]
GO
/****** Object:  Database [ProjectPRN292]    Script Date: 7/29/2020 7:44:04 AM ******/
CREATE DATABASE [ProjectPRN292]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProjectPRN292', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\ProjectPRN292.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ProjectPRN292_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\ProjectPRN292_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ProjectPRN292] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProjectPRN292].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProjectPRN292] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProjectPRN292] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProjectPRN292] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProjectPRN292] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProjectPRN292] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProjectPRN292] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProjectPRN292] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProjectPRN292] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProjectPRN292] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProjectPRN292] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProjectPRN292] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProjectPRN292] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProjectPRN292] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProjectPRN292] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProjectPRN292] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProjectPRN292] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProjectPRN292] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProjectPRN292] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProjectPRN292] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProjectPRN292] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProjectPRN292] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProjectPRN292] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProjectPRN292] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProjectPRN292] SET  MULTI_USER 
GO
ALTER DATABASE [ProjectPRN292] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProjectPRN292] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProjectPRN292] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProjectPRN292] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ProjectPRN292] SET DELAYED_DURABILITY = DISABLED 
GO
USE [ProjectPRN292]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 7/29/2020 7:44:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[Admin_ID] [int] IDENTITY(1,1) NOT NULL,
	[LoginName] [nvarchar](150) NOT NULL,
	[Password] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[Admin_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Answer]    Script Date: 7/29/2020 7:44:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answer](
	[Answer_ID] [int] IDENTITY(1,1) NOT NULL,
	[Question_ID] [int] NOT NULL,
	[Content] [nvarchar](250) NOT NULL,
	[isCorrect] [bit] NOT NULL,
 CONSTRAINT [PK_Answer] PRIMARY KEY CLUSTERED 
(
	[Answer_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Chapter]    Script Date: 7/29/2020 7:44:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chapter](
	[Chapter_ID] [int] IDENTITY(1,1) NOT NULL,
	[Subject_ID] [int] NOT NULL,
	[ChapterName] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_Chapter] PRIMARY KEY CLUSTERED 
(
	[Chapter_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Exam]    Script Date: 7/29/2020 7:44:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exam](
	[Exam_Code] [nvarchar](50) NOT NULL,
	[Subject_ID] [int] NOT NULL,
	[ExamName] [nvarchar](150) NOT NULL,
	[TotalQuestion] [int] NULL,
	[Time] [int] NULL,
 CONSTRAINT [PK_Exam] PRIMARY KEY CLUSTERED 
(
	[Exam_Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ExamQuestion]    Script Date: 7/29/2020 7:44:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExamQuestion](
	[Exam_Code] [nvarchar](50) NOT NULL,
	[Question_ID] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ExamResult]    Script Date: 7/29/2020 7:44:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExamResult](
	[Student_ID] [int] NOT NULL,
	[Exam_Code] [nvarchar](50) NOT NULL,
	[testDate] [datetime] NOT NULL CONSTRAINT [DF_Exam_testDate]  DEFAULT (getdate()),
	[Score] [float] NOT NULL,
	[Question_No] [int] NOT NULL,
	[Question_ID] [int] NOT NULL,
	[Answer_ID] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Question]    Script Date: 7/29/2020 7:44:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[Question_ID] [int] IDENTITY(1,1) NOT NULL,
	[Chapter_ID] [int] NOT NULL,
	[Content] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED 
(
	[Question_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Student]    Script Date: 7/29/2020 7:44:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[Student_ID] [int] IDENTITY(1,1) NOT NULL,
	[Password] [nvarchar](250) NOT NULL,
	[FirstName] [nvarchar](250) NOT NULL,
	[LastName] [nvarchar](250) NOT NULL,
	[DOB] [datetime] NOT NULL,
	[Gender] [bit] NOT NULL,
	[Email] [nvarchar](450) NOT NULL,
	[PhoneNumber] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Student_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StudentAnswer]    Script Date: 7/29/2020 7:44:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentAnswer](
	[Student_ID] [int] NOT NULL,
	[Exam_Code] [nvarchar](50) NOT NULL,
	[Question_No] [int] NOT NULL,
	[Question_ID] [int] NOT NULL,
	[Answer_ID] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Subject]    Script Date: 7/29/2020 7:44:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[Subject_ID] [int] IDENTITY(1,1) NOT NULL,
	[SubjectName] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[Subject_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Admin] ON 

INSERT [dbo].[Admin] ([Admin_ID], [LoginName], [Password]) VALUES (1, N'a', N'1')
SET IDENTITY_INSERT [dbo].[Admin] OFF
SET IDENTITY_INSERT [dbo].[Answer] ON 

INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (1, 1, N'People talking in an elevator.', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (2, 1, N'People discussing the weather at an airport.', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (3, 1, N'Fans cheering at a baseball game.', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (4, 1, N'Jury members deliberating a court case.', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (5, 1, N'A congregation listening to a sermon', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (6, 2, N'9', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (8, 2, N'666', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (9, 2, N'900', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (10, 2, N'966', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (11, 3, N'3-5 people', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (12, 3, N'4-6 people', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (13, 3, N'5-7 people', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (14, 3, N'6-9 people', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (16, 3, N'8-12 people', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (17, 4, N'having a minimum of 5 and a maximum of 12 members in a group', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (18, 4, N'a clear goal.', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (19, 4, N'strong leadership.', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (20, 4, N'member independence and interdependence.', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (21, 4, N'group morale', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (22, 5, N'the type and size of the group.', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (24, 5, N'the group''s physical and psychological setting.', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (26, 5, N'the group''s purpose, history, and status.', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (27, 5, N'the characteristics of and relationships among group members.', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (28, 5, N'all of the above', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (29, 6, N'channels', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (32, 6, N'external noise', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (33, 6, N'feedback', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (34, 6, N'verbal message', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (35, 6, N'internal noise', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (36, 7, N' a group''s physical and psychological environment.', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (37, 7, N' anything that interferes with or inhibits effective communication.', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (38, 7, N'the media through which group members share messages', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (39, 7, N'the response or reaction to a message', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (40, 7, N'ideas, information, opinions, and/or feelings that generate meaning.', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (41, 8, N'Members may take time off to "play" when work becomes too intense.', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (42, 8, N'Members may unexpectedly come up with new ideas and techniques.', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (43, 8, N'Effective groups have clear goals.', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (44, 8, N'Groups suffer if members fail to cooperate.', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (45, 8, N'Groups rely on member input to achieve a common goal', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (46, 9, N'interaction.', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (47, 9, N'common goals.', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (48, 9, N'interdependence.', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (49, 9, N'synergy.', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (50, 9, N'working.', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (51, 10, N'True', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (52, 10, N'False', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (53, 11, N'primary group.', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (54, 11, N'social group.', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (55, 11, N'public group.', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (56, 11, N'service group.', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (57, 11, N'none of the above', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (58, 12, N'True', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (59, 12, N'False', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (60, 13, N'True', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (61, 13, N'False', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (62, 14, N'symposium.', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (63, 14, N'forum.', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (64, 14, N'panel discussion.', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (65, 14, N'governance group.', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (66, 14, N'self-help group.', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (67, 15, N'symposium.', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (69, 15, N'forum.', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (70, 15, N'panel discussion.', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (71, 15, N'governance group.', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (72, 15, N'service group.', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (73, 16, N'True', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (74, 16, N'False', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (75, 17, N'True', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (76, 17, N'False', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (77, 18, N'Slow', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (78, 18, N'Slow to medium', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (79, 18, N'Rapid', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (80, 18, N'Non-existent', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (81, 19, N'Organization', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (82, 19, N'Specifics', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (83, 19, N'Design', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (84, 19, N'Architecture', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (85, 20, N'I/O mechanisms', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (86, 20, N'Control signals', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (87, 20, N'Interfaces', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (88, 20, N'Memory technology used', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (89, 21, N'True', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (90, 21, N'False', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (91, 22, N'True', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (92, 22, N'False', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (94, 24, N'Interface', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (95, 24, N'Organizational', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (96, 24, N'Memory', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (97, 24, N'Architectural', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (98, 25, N'Architectural', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (99, 25, N'Memory', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (100, 25, N'Elementary', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (101, 25, N'Organizational', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (102, 26, N'Architectural', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (103, 26, N'Memory', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (104, 26, N'Mechanical', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (105, 26, N'Organizational', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (106, 27, N'True', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (107, 27, N'False', 0)
GO
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (108, 28, N'True', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (109, 28, N'False', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (111, 30, N'Secondary', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (112, 30, N'Hierarchical', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (113, 30, N'Complex', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (114, 30, N'Functional', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (115, 31, N'CPU', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (116, 31, N'Control device', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (117, 31, N'Peripheral', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (118, 31, N'Register', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (119, 32, N'Data communications', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (120, 32, N'Registering', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (121, 32, N'Structuring', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (123, 32, N'Data transport', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (124, 33, N'True', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (125, 33, N'False', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (126, 34, N'True', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (127, 34, N'False', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (128, 36, N'capacitor', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (129, 36, N'transistor', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (130, 36, N'resistor', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (131, 36, N'inductor', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (132, 37, N' Linear', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (134, 37, N'Modern', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (135, 37, N'Boolean', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (136, 37, N'Fibonacci', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (137, 38, N'XOR', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (138, 38, N'NOT', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (139, 38, N'AND', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (140, 38, N'OR', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (142, 39, N'True', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (143, 39, N'False', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (144, 40, N'True', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (145, 40, N'False', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (146, 41, N'One', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (147, 41, N'Two', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (148, 41, N'Three', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (149, 41, N'Four', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (150, 42, N'Square', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (151, 42, N'First derivative', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (152, 42, N'Opposite', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (153, 42, N'Same', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (154, 43, N'OR', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (155, 43, N'XOR', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (156, 43, N'AND', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (157, 43, N'NAND', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (158, 44, N'True', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (159, 44, N'False', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (160, 45, N'True', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (161, 45, N'False', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (162, 46, N'variable', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (163, 46, N'data', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (164, 46, N' log', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (165, 46, N'truth', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (166, 47, N'controller', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (167, 47, N'ALU', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (168, 47, N'memory', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (169, 47, N'register', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (234, 2, N'90', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (235, 89, N'1', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (237, 89, N'2', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (238, 91, N'no', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (239, 91, N'yes', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (248, 97, N'True', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (249, 97, N'False', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (255, 103, N'True', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (256, 103, N'False', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (257, 105, N'2', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (258, 105, N'3', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (259, 105, N'4', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (260, 105, N'none', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (261, 107, N'Asia', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (262, 107, N'China', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (263, 107, N'Africa', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (274, 119, N'hanoi', 0)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (275, 119, N'hatinh', 1)
INSERT [dbo].[Answer] ([Answer_ID], [Question_ID], [Content], [isCorrect]) VALUES (276, 119, N'idk:(', 0)
SET IDENTITY_INSERT [dbo].[Answer] OFF
SET IDENTITY_INSERT [dbo].[Chapter] ON 

INSERT [dbo].[Chapter] ([Chapter_ID], [Subject_ID], [ChapterName]) VALUES (1, 1, N'Chap 1')
INSERT [dbo].[Chapter] ([Chapter_ID], [Subject_ID], [ChapterName]) VALUES (2, 1, N'Chap 2')
INSERT [dbo].[Chapter] ([Chapter_ID], [Subject_ID], [ChapterName]) VALUES (3, 1, N'Chap 3')
INSERT [dbo].[Chapter] ([Chapter_ID], [Subject_ID], [ChapterName]) VALUES (4, 2, N'Chap 1')
INSERT [dbo].[Chapter] ([Chapter_ID], [Subject_ID], [ChapterName]) VALUES (5, 2, N'Chap 2')
INSERT [dbo].[Chapter] ([Chapter_ID], [Subject_ID], [ChapterName]) VALUES (6, 2, N'Chap 3')
INSERT [dbo].[Chapter] ([Chapter_ID], [Subject_ID], [ChapterName]) VALUES (7, 3, N'Chap 1')
INSERT [dbo].[Chapter] ([Chapter_ID], [Subject_ID], [ChapterName]) VALUES (8, 3, N'Chap 2')
INSERT [dbo].[Chapter] ([Chapter_ID], [Subject_ID], [ChapterName]) VALUES (9, 3, N'Chap 3')
INSERT [dbo].[Chapter] ([Chapter_ID], [Subject_ID], [ChapterName]) VALUES (10, 1, N'chap 4')
INSERT [dbo].[Chapter] ([Chapter_ID], [Subject_ID], [ChapterName]) VALUES (12, 4, N'C1')
INSERT [dbo].[Chapter] ([Chapter_ID], [Subject_ID], [ChapterName]) VALUES (13, 4, N'C2')
INSERT [dbo].[Chapter] ([Chapter_ID], [Subject_ID], [ChapterName]) VALUES (14, 1, N'Chap 5')
INSERT [dbo].[Chapter] ([Chapter_ID], [Subject_ID], [ChapterName]) VALUES (15, 2, N'Chap 4')
SET IDENTITY_INSERT [dbo].[Chapter] OFF
INSERT [dbo].[Exam] ([Exam_Code], [Subject_ID], [ExamName], [TotalQuestion], [Time]) VALUES (N'1', 3, N'de1', 10, 10)
INSERT [dbo].[Exam] ([Exam_Code], [Subject_ID], [ExamName], [TotalQuestion], [Time]) VALUES (N'2', 2, N'de2', 4, 1)
INSERT [dbo].[Exam] ([Exam_Code], [Subject_ID], [ExamName], [TotalQuestion], [Time]) VALUES (N'3', 1, N'de3', 10, 10)
INSERT [dbo].[Exam] ([Exam_Code], [Subject_ID], [ExamName], [TotalQuestion], [Time]) VALUES (N'4', 1, N'de4', 5, 10)
INSERT [dbo].[ExamQuestion] ([Exam_Code], [Question_ID]) VALUES (N'1', 37)
INSERT [dbo].[ExamQuestion] ([Exam_Code], [Question_ID]) VALUES (N'1', 42)
INSERT [dbo].[ExamQuestion] ([Exam_Code], [Question_ID]) VALUES (N'1', 33)
INSERT [dbo].[ExamQuestion] ([Exam_Code], [Question_ID]) VALUES (N'1', 39)
INSERT [dbo].[ExamQuestion] ([Exam_Code], [Question_ID]) VALUES (N'1', 44)
INSERT [dbo].[ExamQuestion] ([Exam_Code], [Question_ID]) VALUES (N'1', 38)
INSERT [dbo].[ExamQuestion] ([Exam_Code], [Question_ID]) VALUES (N'1', 43)
INSERT [dbo].[ExamQuestion] ([Exam_Code], [Question_ID]) VALUES (N'1', 45)
INSERT [dbo].[ExamQuestion] ([Exam_Code], [Question_ID]) VALUES (N'1', 34)
INSERT [dbo].[ExamQuestion] ([Exam_Code], [Question_ID]) VALUES (N'1', 47)
INSERT [dbo].[ExamQuestion] ([Exam_Code], [Question_ID]) VALUES (N'2', 18)
INSERT [dbo].[ExamQuestion] ([Exam_Code], [Question_ID]) VALUES (N'2', 30)
INSERT [dbo].[ExamQuestion] ([Exam_Code], [Question_ID]) VALUES (N'2', 20)
INSERT [dbo].[ExamQuestion] ([Exam_Code], [Question_ID]) VALUES (N'2', 32)
INSERT [dbo].[ExamQuestion] ([Exam_Code], [Question_ID]) VALUES (N'4', 12)
INSERT [dbo].[ExamQuestion] ([Exam_Code], [Question_ID]) VALUES (N'4', 97)
INSERT [dbo].[ExamQuestion] ([Exam_Code], [Question_ID]) VALUES (N'4', 103)
INSERT [dbo].[ExamQuestion] ([Exam_Code], [Question_ID]) VALUES (N'3', 1)
INSERT [dbo].[ExamQuestion] ([Exam_Code], [Question_ID]) VALUES (N'3', 6)
INSERT [dbo].[ExamQuestion] ([Exam_Code], [Question_ID]) VALUES (N'3', 11)
INSERT [dbo].[ExamQuestion] ([Exam_Code], [Question_ID]) VALUES (N'3', 3)
INSERT [dbo].[ExamQuestion] ([Exam_Code], [Question_ID]) VALUES (N'3', 8)
INSERT [dbo].[ExamQuestion] ([Exam_Code], [Question_ID]) VALUES (N'3', 13)
INSERT [dbo].[ExamQuestion] ([Exam_Code], [Question_ID]) VALUES (N'3', 2)
INSERT [dbo].[ExamQuestion] ([Exam_Code], [Question_ID]) VALUES (N'3', 7)
INSERT [dbo].[ExamResult] ([Student_ID], [Exam_Code], [testDate], [Score], [Question_No], [Question_ID], [Answer_ID]) VALUES (1, N'2', CAST(N'2020-07-27 20:41:01.777' AS DateTime), 5, 1, 18, 77)
INSERT [dbo].[ExamResult] ([Student_ID], [Exam_Code], [testDate], [Score], [Question_No], [Question_ID], [Answer_ID]) VALUES (1, N'2', CAST(N'2020-07-27 20:41:01.777' AS DateTime), 5, 2, 20, 85)
INSERT [dbo].[ExamResult] ([Student_ID], [Exam_Code], [testDate], [Score], [Question_No], [Question_ID], [Answer_ID]) VALUES (1, N'2', CAST(N'2020-07-27 20:41:01.777' AS DateTime), 5, 3, 30, 111)
INSERT [dbo].[ExamResult] ([Student_ID], [Exam_Code], [testDate], [Score], [Question_No], [Question_ID], [Answer_ID]) VALUES (1, N'2', CAST(N'2020-07-27 20:41:01.777' AS DateTime), 5, 4, 32, 119)
INSERT [dbo].[ExamResult] ([Student_ID], [Exam_Code], [testDate], [Score], [Question_No], [Question_ID], [Answer_ID]) VALUES (2, N'1', CAST(N'2020-07-28 19:05:54.897' AS DateTime), 6, 1, 33, 124)
INSERT [dbo].[ExamResult] ([Student_ID], [Exam_Code], [testDate], [Score], [Question_No], [Question_ID], [Answer_ID]) VALUES (2, N'1', CAST(N'2020-07-28 19:05:54.897' AS DateTime), 6, 2, 34, 127)
INSERT [dbo].[ExamResult] ([Student_ID], [Exam_Code], [testDate], [Score], [Question_No], [Question_ID], [Answer_ID]) VALUES (3, N'4', CAST(N'2020-07-28 19:34:00.593' AS DateTime), 6, 1, 12, 58)
INSERT [dbo].[ExamResult] ([Student_ID], [Exam_Code], [testDate], [Score], [Question_No], [Question_ID], [Answer_ID]) VALUES (3, N'4', CAST(N'2020-07-28 19:34:00.593' AS DateTime), 6, 2, 97, 248)
INSERT [dbo].[ExamResult] ([Student_ID], [Exam_Code], [testDate], [Score], [Question_No], [Question_ID], [Answer_ID]) VALUES (3, N'4', CAST(N'2020-07-28 19:34:00.593' AS DateTime), 6, 4, 103, 255)
INSERT [dbo].[ExamResult] ([Student_ID], [Exam_Code], [testDate], [Score], [Question_No], [Question_ID], [Answer_ID]) VALUES (1, N'4', CAST(N'2020-07-28 19:39:16.087' AS DateTime), 2, 1, 12, 58)
INSERT [dbo].[ExamResult] ([Student_ID], [Exam_Code], [testDate], [Score], [Question_No], [Question_ID], [Answer_ID]) VALUES (1, N'4', CAST(N'2020-07-28 19:39:16.087' AS DateTime), 2, 2, 97, 249)
INSERT [dbo].[ExamResult] ([Student_ID], [Exam_Code], [testDate], [Score], [Question_No], [Question_ID], [Answer_ID]) VALUES (1, N'4', CAST(N'2020-07-28 19:39:16.087' AS DateTime), 2, 4, 103, 256)
INSERT [dbo].[ExamResult] ([Student_ID], [Exam_Code], [testDate], [Score], [Question_No], [Question_ID], [Answer_ID]) VALUES (2, N'1', CAST(N'2020-07-28 19:05:54.897' AS DateTime), 6, 3, 37, 132)
INSERT [dbo].[ExamResult] ([Student_ID], [Exam_Code], [testDate], [Score], [Question_No], [Question_ID], [Answer_ID]) VALUES (2, N'1', CAST(N'2020-07-28 19:05:54.897' AS DateTime), 6, 4, 38, 138)
INSERT [dbo].[ExamResult] ([Student_ID], [Exam_Code], [testDate], [Score], [Question_No], [Question_ID], [Answer_ID]) VALUES (2, N'1', CAST(N'2020-07-28 19:05:54.897' AS DateTime), 6, 5, 39, 142)
INSERT [dbo].[ExamResult] ([Student_ID], [Exam_Code], [testDate], [Score], [Question_No], [Question_ID], [Answer_ID]) VALUES (2, N'1', CAST(N'2020-07-28 19:05:54.897' AS DateTime), 6, 6, 42, 151)
INSERT [dbo].[ExamResult] ([Student_ID], [Exam_Code], [testDate], [Score], [Question_No], [Question_ID], [Answer_ID]) VALUES (2, N'1', CAST(N'2020-07-28 19:05:54.897' AS DateTime), 6, 7, 43, 154)
INSERT [dbo].[ExamResult] ([Student_ID], [Exam_Code], [testDate], [Score], [Question_No], [Question_ID], [Answer_ID]) VALUES (2, N'1', CAST(N'2020-07-28 19:05:54.897' AS DateTime), 6, 8, 44, 159)
INSERT [dbo].[ExamResult] ([Student_ID], [Exam_Code], [testDate], [Score], [Question_No], [Question_ID], [Answer_ID]) VALUES (2, N'1', CAST(N'2020-07-28 19:05:54.897' AS DateTime), 6, 9, 45, 160)
INSERT [dbo].[ExamResult] ([Student_ID], [Exam_Code], [testDate], [Score], [Question_No], [Question_ID], [Answer_ID]) VALUES (2, N'1', CAST(N'2020-07-28 19:05:54.897' AS DateTime), 6, 10, 47, 168)
INSERT [dbo].[ExamResult] ([Student_ID], [Exam_Code], [testDate], [Score], [Question_No], [Question_ID], [Answer_ID]) VALUES (5, N'4', CAST(N'2020-07-28 19:47:14.687' AS DateTime), 6, 1, 12, 58)
INSERT [dbo].[ExamResult] ([Student_ID], [Exam_Code], [testDate], [Score], [Question_No], [Question_ID], [Answer_ID]) VALUES (5, N'4', CAST(N'2020-07-28 19:47:14.687' AS DateTime), 6, 2, 97, 248)
INSERT [dbo].[ExamResult] ([Student_ID], [Exam_Code], [testDate], [Score], [Question_No], [Question_ID], [Answer_ID]) VALUES (5, N'4', CAST(N'2020-07-28 19:47:14.687' AS DateTime), 6, 4, 103, 255)
INSERT [dbo].[ExamResult] ([Student_ID], [Exam_Code], [testDate], [Score], [Question_No], [Question_ID], [Answer_ID]) VALUES (8, N'4', CAST(N'2020-07-28 19:53:39.700' AS DateTime), 6, 1, 12, 58)
INSERT [dbo].[ExamResult] ([Student_ID], [Exam_Code], [testDate], [Score], [Question_No], [Question_ID], [Answer_ID]) VALUES (8, N'4', CAST(N'2020-07-28 19:53:39.700' AS DateTime), 6, 2, 97, 248)
INSERT [dbo].[ExamResult] ([Student_ID], [Exam_Code], [testDate], [Score], [Question_No], [Question_ID], [Answer_ID]) VALUES (8, N'4', CAST(N'2020-07-28 19:53:39.700' AS DateTime), 6, 4, 103, 255)
INSERT [dbo].[ExamResult] ([Student_ID], [Exam_Code], [testDate], [Score], [Question_No], [Question_ID], [Answer_ID]) VALUES (6, N'3', CAST(N'2020-07-27 21:57:25.523' AS DateTime), 4, 1, 1, 1)
INSERT [dbo].[ExamResult] ([Student_ID], [Exam_Code], [testDate], [Score], [Question_No], [Question_ID], [Answer_ID]) VALUES (6, N'3', CAST(N'2020-07-27 21:57:25.523' AS DateTime), 4, 2, 2, 10)
INSERT [dbo].[ExamResult] ([Student_ID], [Exam_Code], [testDate], [Score], [Question_No], [Question_ID], [Answer_ID]) VALUES (6, N'3', CAST(N'2020-07-27 21:57:25.523' AS DateTime), 4, 3, 3, 14)
INSERT [dbo].[ExamResult] ([Student_ID], [Exam_Code], [testDate], [Score], [Question_No], [Question_ID], [Answer_ID]) VALUES (6, N'3', CAST(N'2020-07-27 21:57:25.523' AS DateTime), 4, 4, 6, 33)
INSERT [dbo].[ExamResult] ([Student_ID], [Exam_Code], [testDate], [Score], [Question_No], [Question_ID], [Answer_ID]) VALUES (6, N'3', CAST(N'2020-07-27 21:57:25.523' AS DateTime), 4, 5, 7, 40)
INSERT [dbo].[ExamResult] ([Student_ID], [Exam_Code], [testDate], [Score], [Question_No], [Question_ID], [Answer_ID]) VALUES (6, N'3', CAST(N'2020-07-27 21:57:25.523' AS DateTime), 4, 6, 8, 41)
INSERT [dbo].[ExamResult] ([Student_ID], [Exam_Code], [testDate], [Score], [Question_No], [Question_ID], [Answer_ID]) VALUES (6, N'3', CAST(N'2020-07-27 21:57:25.523' AS DateTime), 4, 7, 11, 55)
INSERT [dbo].[ExamResult] ([Student_ID], [Exam_Code], [testDate], [Score], [Question_No], [Question_ID], [Answer_ID]) VALUES (6, N'3', CAST(N'2020-07-27 21:57:25.523' AS DateTime), 4, 8, 13, 61)
SET IDENTITY_INSERT [dbo].[Question] ON 

INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (1, 1, N'Which of the following situations best represents group communication as defined in the textbook ?')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (2, 1, N'A group with 7 members has the potential for _______ different types of interactions.')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (3, 1, N'What is the ideal group size for a problem-solving discussion?')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (4, 1, N'According to your textbook, the most important factor separating successful groups from unsuccessful ones is')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (5, 1, N'According to your textbook, a group''s context refers to')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (6, 2, N'To which basic element of communication is Grace giving special attention when she prepares for an important group meeting by making sure her business suit is pressed, that her hair is well-groomed, that her perfume is pleasant but subtle, and that she takes a breath mint before entering the meeting room?')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (7, 2, N'In a communication transaction, feedback represents')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (8, 2, N'Which of the following examples best illustrates the systems theory principle that "systems try to maintain balance in their environment"?')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (9, 2, N'The cooperative interaction of several factors that results in a combined effect greater than the total of all individual parts is referred to as')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (10, 2, N'Decision making results in a position, judgment, or action.')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (11, 3, N'Your family is an example of a')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (12, 3, N'The process of decision making requires a group to analyze a problem, debate pros and cons, and select and implement a solution.
(T/F)')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (13, 3, N'
As a rule, group problem solving generates more ideas and produces better solutions to complex problems.(T/F)')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (14, 3, N'A group of police officers presenting short, uninterrupted speeches on different aspects of community safety are participating in a')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (15, 3, N'A college appoints a moderator and holds an open discussion to provide students with the opportunity to ask questions and express their concerns regarding a proposed increase in tuition. This setting for group communication is an example of a')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (16, 4, N'There is a tremendous variety of products, from single-chip microcomputers costing a few dollars to supercomputers costing tens of millions of dollars that can rightly claim the name "computer".
(T/F))')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (17, 4, N'The variety of computer products is exhibited only in cost.
(T/F)')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (18, 4, N'Computer _________ refers to those attributes that have a direct impact on the logical execution of a program.')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (19, 4, N'Architectural attributes include __________ .')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (20, 4, N'_________ attributes include hardware details transparent to the programmer.')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (21, 5, N'Computer organization refers to attributes of a system visible to the programmer.
(T/F)')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (22, 5, N'Changes in computer technology are finally slowing down.
(T/F)')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (24, 5, N'It is a(n) _________ design issue whether a computer will have a multiply instruction.')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (25, 5, N'A __________ system is a set of interrelated subsystems.')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (26, 5, N'An I/O device is referred to as a __________.')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (27, 6, N'The textbook for this course is about the structure and function of computers.
(T/F)')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (28, 6, N'The number of bits used to represent various data types is an example of an architectural attribute.
(T/F)')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (30, 6, N'When data are moved over longer distances, to or from a remote device, the process is known as __________.')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (31, 6, N'The _________ stores data.')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (32, 6, N'The __________ moves data between the computer and its external environment.')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (33, 7, N'Transistors are simply small electronic switches that can be in either an on or an off state.')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (34, 7, N'A truth table with two inputs would have two rows.')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (36, 7, N'By switching on and off, the ____ can be used to represent the 1s and 0s that are the foundation of all that goes on in the computer.')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (37, 7, N'____ algebra is concerned with the logic of the operators AND, OR, and NOT.')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (38, 7, N'The ____ operator works with a single input and its purpose is to reverse the input.')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (39, 8, N'The Boolean OR operator returns a 1 only when either or both of the inputs are 1.')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (40, 8, N'Each gate in a circuit reacts in a completely unpredictable way')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (41, 8, N'The AND circuit generates ____ output for each set of inputs.')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (42, 8, N'The truth table for the NOT gate shows that the output is the ____ of the input.')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (43, 8, N'The truth table for the ____ gate indicates that the output is 1 only when the inputs are different.')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (44, 9, N'In the adder, the bits are added according to the rules of the hexadecimal numbering system.')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (45, 9, N'The flip-flop circuit latches onto a bit and maintains the output until it is changed.')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (46, 9, N'A gate''s output for any set of inputs follows the specifications given in the ____ table.')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (47, 9, N'One of the main functions of the ____ component of the computer''s CPU is to add numbers.')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (89, 12, N'1+1 = ?')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (91, 13, N'is thien gay?')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (97, 10, N'1+1=2')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (103, 14, N'1+1 = 2')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (105, 15, N'How many siblings does Thien have?')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (107, 15, N'Where is Japan?')
INSERT [dbo].[Question] ([Question_ID], [Chapter_ID], [Content]) VALUES (119, 15, N'where is my house?')
SET IDENTITY_INSERT [dbo].[Question] OFF
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([Student_ID], [Password], [FirstName], [LastName], [DOB], [Gender], [Email], [PhoneNumber]) VALUES (1, N'123456', N'An', N'Hoang Hue', CAST(N'2000-10-02 00:00:00.000' AS DateTime), 1, N'AnHH@fpt.edu.vn', N'555567648')
INSERT [dbo].[Student] ([Student_ID], [Password], [FirstName], [LastName], [DOB], [Gender], [Email], [PhoneNumber]) VALUES (2, N'123456', N'Cuong', N'Ly Viet', CAST(N'2000-04-12 00:00:00.000' AS DateTime), 0, N'CuongLV@fpt.edu.vn', N'355522629')
INSERT [dbo].[Student] ([Student_ID], [Password], [FirstName], [LastName], [DOB], [Gender], [Email], [PhoneNumber]) VALUES (3, N'123456', N'Hoang', N'Nguyen Viet', CAST(N'2000-03-30 00:00:00.000' AS DateTime), 0, N'HoangNV@fpt.edu.vn', N'855551619')
INSERT [dbo].[Student] ([Student_ID], [Password], [FirstName], [LastName], [DOB], [Gender], [Email], [PhoneNumber]) VALUES (4, N'123456', N'Hung', N'Trinh The', CAST(N'2000-01-06 00:00:00.000' AS DateTime), 0, N'HungTT@fpt.edu.vn', N'355584266')
INSERT [dbo].[Student] ([Student_ID], [Password], [FirstName], [LastName], [DOB], [Gender], [Email], [PhoneNumber]) VALUES (5, N'123456', N'Huong', N'Nguyen Thanh', CAST(N'2000-02-20 00:00:00.000' AS DateTime), 1, N'HuongNT@fpt.edu.vn', N'975654321')
INSERT [dbo].[Student] ([Student_ID], [Password], [FirstName], [LastName], [DOB], [Gender], [Email], [PhoneNumber]) VALUES (6, N'123456', N'Huy', N'Ngo Xuan', CAST(N'2000-01-12 00:00:00.000' AS DateTime), 0, N'HuyNX@fpt.edu.vn', N'755523583')
INSERT [dbo].[Student] ([Student_ID], [Password], [FirstName], [LastName], [DOB], [Gender], [Email], [PhoneNumber]) VALUES (7, N'123456', N'Nhi', N'Phan Mai', CAST(N'2000-08-26 00:00:00.000' AS DateTime), 1, N'NhiPM@fpt.edu.vn', N'355582756')
INSERT [dbo].[Student] ([Student_ID], [Password], [FirstName], [LastName], [DOB], [Gender], [Email], [PhoneNumber]) VALUES (8, N'123456', N'Quang', N'Vu Huy', CAST(N'2000-04-08 00:00:00.000' AS DateTime), 0, N'QuangVH@fpt.edu.vn', N'555567648')
INSERT [dbo].[Student] ([Student_ID], [Password], [FirstName], [LastName], [DOB], [Gender], [Email], [PhoneNumber]) VALUES (9, N'123456', N'Quynh', N'Nguyen Bao', CAST(N'2000-03-12 00:00:00.000' AS DateTime), 1, N'QuynhNB@fpt.edu.vn', N'955595425')
INSERT [dbo].[Student] ([Student_ID], [Password], [FirstName], [LastName], [DOB], [Gender], [Email], [PhoneNumber]) VALUES (10, N'123456', N'Trang', N'Tran Thuc', CAST(N'2000-01-19 00:00:00.000' AS DateTime), 1, N'TrangTT@fpt.edu.vn', N'355568455')
INSERT [dbo].[Student] ([Student_ID], [Password], [FirstName], [LastName], [DOB], [Gender], [Email], [PhoneNumber]) VALUES (11, N'123456', N'Trinh', N'Dang Phuong', CAST(N'2000-03-19 00:00:00.000' AS DateTime), 1, N'TrinhDP@fpt.edu.vn', N'975468123')
INSERT [dbo].[Student] ([Student_ID], [Password], [FirstName], [LastName], [DOB], [Gender], [Email], [PhoneNumber]) VALUES (12, N'123456', N'Trong', N'Pham Dac', CAST(N'2000-06-01 00:00:00.000' AS DateTime), 0, N'TrongPD@fpt.edu.vn', N'355591673')
INSERT [dbo].[Student] ([Student_ID], [Password], [FirstName], [LastName], [DOB], [Gender], [Email], [PhoneNumber]) VALUES (13, N'123456', N'Tuan', N'Hoang Huy', CAST(N'2000-02-02 00:00:00.000' AS DateTime), 0, N'TuanHH@fpt.edu.vn', N'1234567890')
INSERT [dbo].[Student] ([Student_ID], [Password], [FirstName], [LastName], [DOB], [Gender], [Email], [PhoneNumber]) VALUES (16, N'q', N'sdf', N'df', CAST(N'2020-07-14 11:49:48.147' AS DateTime), 0, N'sd@gmai.c', N'1234567890')
SET IDENTITY_INSERT [dbo].[Student] OFF
SET IDENTITY_INSERT [dbo].[Subject] ON 

INSERT [dbo].[Subject] ([Subject_ID], [SubjectName]) VALUES (1, N'MAE101')
INSERT [dbo].[Subject] ([Subject_ID], [SubjectName]) VALUES (2, N'CEA201')
INSERT [dbo].[Subject] ([Subject_ID], [SubjectName]) VALUES (3, N'CSI101')
INSERT [dbo].[Subject] ([Subject_ID], [SubjectName]) VALUES (4, N'PRF192')
INSERT [dbo].[Subject] ([Subject_ID], [SubjectName]) VALUES (5, N'DBI202')
SET IDENTITY_INSERT [dbo].[Subject] OFF
ALTER TABLE [dbo].[Answer]  WITH CHECK ADD  CONSTRAINT [FK_Answer_Question] FOREIGN KEY([Question_ID])
REFERENCES [dbo].[Question] ([Question_ID])
GO
ALTER TABLE [dbo].[Answer] CHECK CONSTRAINT [FK_Answer_Question]
GO
ALTER TABLE [dbo].[Chapter]  WITH CHECK ADD  CONSTRAINT [FK_Chapter_Subject] FOREIGN KEY([Subject_ID])
REFERENCES [dbo].[Subject] ([Subject_ID])
GO
ALTER TABLE [dbo].[Chapter] CHECK CONSTRAINT [FK_Chapter_Subject]
GO
ALTER TABLE [dbo].[Exam]  WITH CHECK ADD  CONSTRAINT [FK_Exam_Subject] FOREIGN KEY([Subject_ID])
REFERENCES [dbo].[Subject] ([Subject_ID])
GO
ALTER TABLE [dbo].[Exam] CHECK CONSTRAINT [FK_Exam_Subject]
GO
ALTER TABLE [dbo].[ExamQuestion]  WITH CHECK ADD  CONSTRAINT [FK_ExamQuestion_Exam] FOREIGN KEY([Exam_Code])
REFERENCES [dbo].[Exam] ([Exam_Code])
GO
ALTER TABLE [dbo].[ExamQuestion] CHECK CONSTRAINT [FK_ExamQuestion_Exam]
GO
ALTER TABLE [dbo].[ExamQuestion]  WITH CHECK ADD  CONSTRAINT [FK_ExamQuestion_Question] FOREIGN KEY([Question_ID])
REFERENCES [dbo].[Question] ([Question_ID])
GO
ALTER TABLE [dbo].[ExamQuestion] CHECK CONSTRAINT [FK_ExamQuestion_Question]
GO
ALTER TABLE [dbo].[ExamResult]  WITH CHECK ADD  CONSTRAINT [FK_ExamResult_Answer] FOREIGN KEY([Answer_ID])
REFERENCES [dbo].[Answer] ([Answer_ID])
GO
ALTER TABLE [dbo].[ExamResult] CHECK CONSTRAINT [FK_ExamResult_Answer]
GO
ALTER TABLE [dbo].[ExamResult]  WITH CHECK ADD  CONSTRAINT [FK_ExamResult_Exam1] FOREIGN KEY([Question_ID])
REFERENCES [dbo].[Question] ([Question_ID])
GO
ALTER TABLE [dbo].[ExamResult] CHECK CONSTRAINT [FK_ExamResult_Exam1]
GO
ALTER TABLE [dbo].[ExamResult]  WITH CHECK ADD  CONSTRAINT [FK_ExamResult_Student] FOREIGN KEY([Student_ID])
REFERENCES [dbo].[Student] ([Student_ID])
GO
ALTER TABLE [dbo].[ExamResult] CHECK CONSTRAINT [FK_ExamResult_Student]
GO
ALTER TABLE [dbo].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_Chapter] FOREIGN KEY([Chapter_ID])
REFERENCES [dbo].[Chapter] ([Chapter_ID])
GO
ALTER TABLE [dbo].[Question] CHECK CONSTRAINT [FK_Question_Chapter]
GO
ALTER TABLE [dbo].[StudentAnswer]  WITH CHECK ADD FOREIGN KEY([Answer_ID])
REFERENCES [dbo].[Answer] ([Answer_ID])
GO
ALTER TABLE [dbo].[StudentAnswer]  WITH CHECK ADD FOREIGN KEY([Exam_Code])
REFERENCES [dbo].[Exam] ([Exam_Code])
GO
ALTER TABLE [dbo].[StudentAnswer]  WITH CHECK ADD FOREIGN KEY([Question_ID])
REFERENCES [dbo].[Question] ([Question_ID])
GO
ALTER TABLE [dbo].[StudentAnswer]  WITH CHECK ADD FOREIGN KEY([Student_ID])
REFERENCES [dbo].[Student] ([Student_ID])
GO
USE [master]
GO
ALTER DATABASE [ProjectPRN292] SET  READ_WRITE 
GO
