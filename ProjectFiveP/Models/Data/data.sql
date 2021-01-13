USE [master]
GO
/****** Object:  Database [DataProjectFiveP]    Script Date: 13/01/2021 10:33:10 AM ******/
CREATE DATABASE [DataProjectFiveP]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DataProjectFiveP', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\DataProjectFiveP.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DataProjectFiveP_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\DataProjectFiveP_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DataProjectFiveP] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DataProjectFiveP].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DataProjectFiveP] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DataProjectFiveP] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DataProjectFiveP] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DataProjectFiveP] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DataProjectFiveP] SET ARITHABORT OFF 
GO
ALTER DATABASE [DataProjectFiveP] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DataProjectFiveP] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [DataProjectFiveP] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DataProjectFiveP] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DataProjectFiveP] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DataProjectFiveP] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DataProjectFiveP] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DataProjectFiveP] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DataProjectFiveP] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DataProjectFiveP] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DataProjectFiveP] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DataProjectFiveP] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DataProjectFiveP] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DataProjectFiveP] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DataProjectFiveP] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DataProjectFiveP] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DataProjectFiveP] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DataProjectFiveP] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DataProjectFiveP] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DataProjectFiveP] SET  MULTI_USER 
GO
ALTER DATABASE [DataProjectFiveP] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DataProjectFiveP] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DataProjectFiveP] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DataProjectFiveP] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [DataProjectFiveP]
GO
/****** Object:  Table [dbo].[Question]    Script Date: 13/01/2021 10:33:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[question_id] [int] IDENTITY(1,1) NOT NULL,
	[question_content] [nvarchar](max) NULL,
	[question_dateCreate] [datetime] NULL,
	[question_dateEdit] [datetime] NULL,
	[user_id] [int] NULL,
	[question_activate] [bit] NULL,
	[question_title] [nvarchar](300) NULL,
	[question_totalAnswer] [int] NULL,
	[question_totalComment] [int] NULL,
	[question_view] [int] NULL,
	[question_totalRate] [int] NULL,
	[question_medalCalculator] [int] NULL,
	[question_recycleBin] [bit] NULL,
	[question_userStatus] [bit] NULL,
	[question_popular] [int] NULL,
	[question_admin_recycleBin] [bit] NULL,
 CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED 
(
	[question_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Question_View]    Script Date: 13/01/2021 10:33:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question_View](
	[questionView_id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Question_View] PRIMARY KEY CLUSTERED 
(
	[questionView_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Roles]    Script Date: 13/01/2021 10:33:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[role_id] [int] IDENTITY(1,1) NOT NULL,
	[role_name] [nvarchar](200) NULL,
	[role_active] [bit] NULL,
	[role_option] [int] NULL,
	[role_bin] [bit] NULL,
	[role_datecreate] [datetime] NULL,
	[role_dateedit] [datetime] NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 13/01/2021 10:33:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[user_name] [nvarchar](200) NULL,
	[user_pass] [nvarchar](max) NULL,
	[user_email] [varchar](200) NULL,
	[user_token] [varchar](max) NULL,
	[user_code] [nvarchar](max) NULL,
	[role_id] [int] NULL,
	[user_active] [bit] NULL,
	[user_option] [int] NULL,
	[user_datecreate] [datetime] NULL,
	[user_datelogin] [datetime] NULL,
	[user_bin] [bit] NULL,
	[user_dateedit] [datetime] NULL,
	[user_img] [varchar](max) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Question] ON 

INSERT [dbo].[Question] ([question_id], [question_content], [question_dateCreate], [question_dateEdit], [user_id], [question_activate], [question_title], [question_totalAnswer], [question_totalComment], [question_view], [question_totalRate], [question_medalCalculator], [question_recycleBin], [question_userStatus], [question_popular], [question_admin_recycleBin]) VALUES (1, N'I have one main app and several product apps that I want to serve using single url.', CAST(0x0000ACAD010D292E AS DateTime), CAST(0x0000ACAD010D292E AS DateTime), 2, 1, N'Angular multiple apps dist folder doesn''t load the index file on local server
', 0, 0, 0, 0, 0, 0, 1, 0, 0)
INSERT [dbo].[Question] ([question_id], [question_content], [question_dateCreate], [question_dateEdit], [user_id], [question_activate], [question_title], [question_totalAnswer], [question_totalComment], [question_view], [question_totalRate], [question_medalCalculator], [question_recycleBin], [question_userStatus], [question_popular], [question_admin_recycleBin]) VALUES (2, N'<pre><code class="language-plaintext">let view = UIView()</code></pre><p>is acceptable, but the only UIView initializer documented is init(frame: CGRect)</p><p>specifically, I am trying to write a new class that inherits from UIView, but this code throws an error</p><pre><code class="language-plaintext">class SquadHorizontalScrollViewCell: UIView {

    init(var: FIRDataSnapshot){
        super.init()
....</code></pre>', CAST(0x0000ACAD010D292E AS DateTime), CAST(0x0000ACAD010D292E AS DateTime), 2, 1, N'How come I can initialize a UIView without parameters, but it''s documentation does not have an empty initializer?', 0, 0, 0, 0, 0, 0, 1, 0, 0)
INSERT [dbo].[Question] ([question_id], [question_content], [question_dateCreate], [question_dateEdit], [user_id], [question_activate], [question_title], [question_totalAnswer], [question_totalComment], [question_view], [question_totalRate], [question_medalCalculator], [question_recycleBin], [question_userStatus], [question_popular], [question_admin_recycleBin]) VALUES (3, N'<pre><code class="language-plaintext">void Update()
{
#if UNITY_ANDROID

    if(Input.touchCount&gt;0 &amp;&amp; Input.GetTouch(0).phase == TouchPhase.Moved )
    {
        Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
        float offset = touchDeltaPosition.x * 40f / 18 * Mathf.Deg2Rad;
        transform.position += new Vector3(0f, 0f, offset);
        transform.position = new Vector3(0f, 0f, Mathf.Clamp(transform.position.z, -7.1f, 7.1f));
    }     
#endif   
}</code></pre><p>&nbsp;</p>', CAST(0x0000ACAD01707ADF AS DateTime), CAST(0x0000ACAD01707ADF AS DateTime), 2, 1, N'How to make the character move along the axis using touch?', 0, 0, 0, 0, 0, 0, 1, 0, 0)
INSERT [dbo].[Question] ([question_id], [question_content], [question_dateCreate], [question_dateEdit], [user_id], [question_activate], [question_title], [question_totalAnswer], [question_totalComment], [question_view], [question_totalRate], [question_medalCalculator], [question_recycleBin], [question_userStatus], [question_popular], [question_admin_recycleBin]) VALUES (4, N'<p>I have a drop down menu where options are enumerated and shuffled, so that the selected option becomes the first. This script is working as intended:</p><pre><code class="language-plaintext">&lt;div id="main"&gt;
  &lt;sub-select :subs="data" @comp-update="onShufflePaths($event)"&gt;&lt;/sub-select&gt;
&lt;/div&gt;</code></pre><p>&nbsp;</p>', CAST(0x0000ACAD0171043A AS DateTime), CAST(0x0000ACAD0171043A AS DateTime), 2, 1, N'Attribute :value binding in select tag doesn''t update inside Vue 3 component template (Composition API)', 0, 0, 0, 0, 0, 0, 1, 0, 0)
INSERT [dbo].[Question] ([question_id], [question_content], [question_dateCreate], [question_dateEdit], [user_id], [question_activate], [question_title], [question_totalAnswer], [question_totalComment], [question_view], [question_totalRate], [question_medalCalculator], [question_recycleBin], [question_userStatus], [question_popular], [question_admin_recycleBin]) VALUES (5, N'<p>So I have this overview tab, when I click it it bring the overview tab initial route, from there I can click to see more details and this will route to a different Route/page let''s call it (B)</p><p>My issue is if I am in this Route/page (B) inside my Overview Tab then I click on a different tab and I go back to Overview it show me Route/page (B) however I want it to display Route/page (A) if I change a tab and come back to it.</p><p>How can I do that?</p><p>This is my OverviewStack.js</p>', CAST(0x0000ACAD01719130 AS DateTime), CAST(0x0000ACAD01719130 AS DateTime), 2, 1, N'How come I can initialize a UIView without parameters, but it''s documentation does not have an empty initializer?', 0, 0, 0, 0, 0, 0, 1, 0, 0)
SET IDENTITY_INSERT [dbo].[Question] OFF
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([role_id], [role_name], [role_active], [role_option], [role_bin], [role_datecreate], [role_dateedit]) VALUES (1, N'Người dùng', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Roles] ([role_id], [role_name], [role_active], [role_option], [role_bin], [role_datecreate], [role_dateedit]) VALUES (2, N'Admin', 1, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Roles] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([user_id], [user_name], [user_pass], [user_email], [user_token], [user_code], [role_id], [user_active], [user_option], [user_datecreate], [user_datelogin], [user_bin], [user_dateedit], [user_img]) VALUES (2, N'cuong hoang', N'trung2010203', N'hoangmaicuong99@gmail.com', N'85fde255-228e-44ae-bdc4-1ca971f2630c', N'#user-2', 1, 1, 1, CAST(0x0000AC9700000000 AS DateTime), CAST(0x0000ACAD01705A5A AS DateTime), 0, CAST(0x0000AC9100000000 AS DateTime), N'images.png')
INSERT [dbo].[Users] ([user_id], [user_name], [user_pass], [user_email], [user_token], [user_code], [role_id], [user_active], [user_option], [user_datecreate], [user_datelogin], [user_bin], [user_dateedit], [user_img]) VALUES (21, N'cuong hoang vlog', N'trung2010203', N'cuongembaubang@gmail.com', N'f6d97b7f-7db2-4115-942f-75a72e5d3dae', N'#user-3', 1, 1, 1, CAST(0x0000AC980133EA21 AS DateTime), CAST(0x0000AC980133EA21 AS DateTime), 0, CAST(0x0000AC980133EA21 AS DateTime), N'images.png')
INSERT [dbo].[Users] ([user_id], [user_name], [user_pass], [user_email], [user_token], [user_code], [role_id], [user_active], [user_option], [user_datecreate], [user_datelogin], [user_bin], [user_dateedit], [user_img]) VALUES (27, N'cuong hoang', N'cuongembaubang', N'huynhminhtan4019@gmail.com', N'3009c5a5-e975-4d9d-ab00-e31c820db6f7', N'#user-27', 1, 1, 7, CAST(0x0000ACA000DFDCC0 AS DateTime), CAST(0x0000ACA000DFDCC0 AS DateTime), 0, CAST(0x0000ACA000DFDCC0 AS DateTime), N'129download.jpg')
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_Users] FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([user_id])
GO
ALTER TABLE [dbo].[Question] CHECK CONSTRAINT [FK_Question_Users]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([role_id])
REFERENCES [dbo].[Roles] ([role_id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
USE [master]
GO
ALTER DATABASE [DataProjectFiveP] SET  READ_WRITE 
GO
