CREATE TABLE [dbo].[SampleData] (
    [Id]          UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Name]        NVARCHAR (30)    NOT NULL,
    [PhoneNumber] NVARCHAR (12)    NULL,
    [StartDate]   DATE             NULL,
    [EndTime]     TIME (7)         NULL,
    [Rate]        NUMERIC (18, 4)  NULL,
    [IsActive]    BIT              DEFAULT ((0)) NOT NULL,
    [Notes]       NVARCHAR (MAX)   NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Name] ASC)
);

