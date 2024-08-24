USE [dockerdemoDb]
GO

/****** Object:  Table [dbo].[Employees]    Script Date: 24-08-2024 1.00.11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Employees](
    [Id] [int] NOT NULL,
    [Name] [nvarchar](50) NULL,
    [Position] [nvarchar](50) NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]
    GO

