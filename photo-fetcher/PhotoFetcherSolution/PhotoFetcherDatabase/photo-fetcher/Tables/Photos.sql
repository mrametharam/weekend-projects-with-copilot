CREATE TABLE [photo-fetcher].[Photos] (
    [Id]           UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [PhotoId]      INT  UNIQUE            NOT NULL,
    [AlbumId]      INT              NULL,
    [Title]        NVARCHAR (250)   NULL,
    [URL]          VARCHAR (300)    NULL,
    [ThumbnailURL] VARCHAR (300)    NULL,
    [DownloadedUTC] DATETIME        NOT NULL,
    [PayLoad]       VARCHAR(MAX)    NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

