USE [Game]
GO

/****** Object:  Table [dbo].[GameSession]    Script Date: 2/27/2023 9:34:59 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[GameSession](
	[PkGameSessionId] [int] IDENTITY(1,1) NOT NULL,
	[DurationSeconds] [int] NOT NULL,
	[StartTimeStamp] [bigint] NOT NULL,
	[EndTimeStamp] [bigint] NOT NULL,
	[PositiveActions] [int] NOT NULL,
	[NegativeActions] [int] NOT NULL,
	[DifficultyLevel] [int] NOT NULL,
	[Outcome] [nvarchar](max) NULL,
	[GameResultId] [int] NOT NULL,
 CONSTRAINT [PK_GameSession] PRIMARY KEY CLUSTERED 
(
	[PkGameSessionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[GameSession]  WITH CHECK ADD  CONSTRAINT [FK_GameSession_GameResults_GameResultId] FOREIGN KEY([GameResultId])
REFERENCES [dbo].[GameResults] ([PkGameResultId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[GameSession] CHECK CONSTRAINT [FK_GameSession_GameResults_GameResultId]
GO

