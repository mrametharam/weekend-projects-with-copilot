CREATE TABLE [dbo].[BoughtItem] (
    [CustomerID] INT NULL,
    [ItemID]     INT NULL,
    FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[customer4] ([Id]),
    FOREIGN KEY ([ItemID]) REFERENCES [dbo].[ApparelStore] ([ID])
);



