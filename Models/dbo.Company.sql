CREATE TABLE [dbo].[Company] (
    [ID]             INT             IDENTITY (1, 1) NOT NULL,
    [Title]          NVARCHAR (50)   NOT NULL,
    [Rating]      DECIMAL (18, 2) NULL,
    [EnrollmentDate] DATETIME2 (7)   NOT NULL,
    [Bonus]          NVARCHAR (50)   NULL,
    [Description]    NVARCHAR (50)   NULL,
    [Images]         NVARCHAR(50)         NULL,
    [Video]          NVARCHAR(50)         NULL,
    [Topic]          NVARCHAR (50)   NULL,
    [News]           NVARCHAR (50)   NULL,
    [Price]          DECIMAL (18, 2) NULL,
    [Tags]           NVARCHAR (50)   NULL,
    CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED ([ID] ASC)
);

