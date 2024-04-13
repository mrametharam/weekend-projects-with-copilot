CREATE TABLE [dbo].[Customers2] (
    [CustomerId]   INT          IDENTITY (1002, 2) NOT NULL,
    [CustomerName] VARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([CustomerId] ASC)
);

