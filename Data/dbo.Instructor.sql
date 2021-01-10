CREATE TABLE [dbo].[Instructor] (
    [ID]        INT           IDENTITY (1, 1) NOT NULL,
    [LastName]  NVARCHAR (50) NOT NULL,
    [FirstName] NVARCHAR (50) NOT NULL,
    [HireDate]  DATETIME2 (7) NULL,
    [Age]       NVARCHAR(50)           NULL,
    [Country]   NVARCHAR (50) NULL,
    [City]      NVARCHAR (50) NULL,
    [Email]     NVARCHAR (50) NOT NULL,
    [AboutMe]   NVARCHAR (50) NULL,
    [Comments]  NVARCHAR (50) NULL,
    CONSTRAINT [PK_Instructor] PRIMARY KEY CLUSTERED ([ID] ASC)
);

