CREATE TABLE [dbo].[Photos] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [AlbumId]      INT            NULL,
    [Title]        NVARCHAR (250) NULL,
    [URL]          VARCHAR (300)  NULL,
    [ThumbnailURL] VARCHAR (300)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

