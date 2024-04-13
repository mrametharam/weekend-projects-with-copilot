CREATE TABLE [dbo].[orders2] (
    [OrderId]    INT      IDENTITY (1000, 1) NOT NULL,
    [CustomerId] INT      NULL,
    [OrderDate]  DATETIME DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([OrderId] ASC),
    FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[customers3] ([Id])
);

