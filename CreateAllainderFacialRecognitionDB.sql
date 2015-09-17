CREATE DATABASE [AllianderFacialRecognition]


USE [AllianderFacialRecognition]
GO

/****** Object:  Table [dbo].[FaceInformation]    Script Date: 14-9-2015 15:32:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FaceInformation](
	[ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[FacialID] [numeric](18, 0) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[DateOFBirth] [date] NULL,
	[CoffeePreference] [nvarchar](50) NULL,
 CONSTRAINT [PK_FaceInformation] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[FaceInformation]  WITH CHECK ADD  CONSTRAINT [FK_FaceInformation_Faces] FOREIGN KEY([FacialID])
REFERENCES [dbo].[Faces] ([ID])
GO

ALTER TABLE [dbo].[FaceInformation] CHECK CONSTRAINT [FK_FaceInformation_Faces]
GO

USE [AllianderFacialRecognition]
GO

/****** Object:  Table [dbo].[Faces]    Script Date: 14-9-2015 15:32:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Faces](
	[ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[FacialPic] [varbinary](max) NOT NULL,
	[DateInserted] [date] NOT NULL,
	[DateLastRetrieved] [date] NOT NULL,
 CONSTRAINT [PK_Faces] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [AllianderFacialRecognition]
GO

/****** Object:  StoredProcedure [dbo].[SP_Insert_Picture]    Script Date: 14-9-2015 15:33:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_Insert_Picture]
	@FacePicToInsert varbinary(MAX),
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@DateOFBirth date,
	@CoffeePreference nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

DECLARE @NewID INT
INSERT INTO Faces
(FacialPic, DateInserted, DateLastRetrieved) 
VALUES
(@FacePicToInsert, getdate(), getdate())

SELECT @NewID = SCOPE_IDENTITY()

INSERT INTO FaceInformation
(FacialID, FirstName, LastName, DateOFBirth, CoffeePreference) 
VALUES
(@NewID, @FirstName, @LastName, @DateOFBirth, @CoffeePreference)

END

GO

USE [AllianderFacialRecognition]
GO

/****** Object:  StoredProcedure [dbo].[SP_Select_All_FAces]    Script Date: 14-9-2015 15:33:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_Select_All_FAces]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    select [ID], [FacialPic]
	from [dbo].[Faces]
END

GO

USE [AllianderFacialRecognition]
GO

/****** Object:  StoredProcedure [dbo].[SP_Select_Face]    Script Date: 14-9-2015 15:33:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_Select_Face] 
	-- Add the parameters for the stored procedure here
	@LastName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		FaceInfo.ID,
		FaceInfo.FacialID,
		FaceInfo.FirstName,
		FaceInfo.LastName,
		FaceInfo.DateOFBirth,
		FaceInfo.CoffeePreference,
		Faces.DateInserted,
		Faces.DateLastRetrieved,
		Faces.FacialPic
  FROM 
	[AllianderFacialRecognition].[dbo].[FaceInformation] FaceInfo,
	[AllianderFacialRecognition].[dbo].[Faces] Faces
  WHERE 
	FaceInfo.FacialID = Faces.ID
  AND
  	LastName = @LastName
END

GO


USE [AllianderFacialRecognition]
GO

/****** Object:  StoredProcedure [dbo].[SP_Select_Face_By_ID]    Script Date: 14-9-2015 15:33:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_Select_Face_By_ID] 
	-- Add the parameters for the stored procedure here
	@FacialID numeric(18, 0)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		FaceInfo.ID,
		FaceInfo.FacialID,
		FaceInfo.FirstName,
		FaceInfo.LastName,
		FaceInfo.DateOFBirth,
		FaceInfo.CoffeePreference,
		Faces.DateInserted,
		Faces.DateLastRetrieved,
		Faces.FacialPic
  FROM 
	[AllianderFacialRecognition].[dbo].[FaceInformation] FaceInfo,
	[AllianderFacialRecognition].[dbo].[Faces] Faces
  WHERE 
	FaceInfo.FacialID = @FacialID
  AND
  	Faces.ID = @FacialID
END

GO

