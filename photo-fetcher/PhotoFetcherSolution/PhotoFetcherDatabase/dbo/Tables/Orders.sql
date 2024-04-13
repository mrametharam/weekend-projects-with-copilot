CREATE TABLE [dbo].[Orders] (
    [OrderId]    INT      IDENTITY (1, 1) NOT NULL,
    [OrderDate]  DATETIME DEFAULT (getdate()) NOT NULL,
    [CustomerId] INT      NOT NULL,
    PRIMARY KEY CLUSTERED ([OrderId] ASC)
);

