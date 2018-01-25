CREATE TABLE [dbo].[VideoGames] (
    [GameId]               INT          NOT NULL,
    [GameTitle]        TEXT         NULL,
    [DateAdded]        DATE         NULL,
    [GameUPC]          NUMERIC (18) NULL,
    [GameDescription]  TEXT         NULL,
    [PurchaseDate]     DATE         NULL,
    [PurchaseAmount]   MONEY        DEFAULT ((0.00)) NULL,
    [PurchaseLocation] TEXT         NULL,
    [RetailValue]      MONEY        DEFAULT ((0.00)) NULL,
    [DiscountValue]    FLOAT (53)   DEFAULT ((0)) NULL,
    [ReleaseDate]      DATE         NULL,
    [GamePlatform]     TEXT         NULL,
    PRIMARY KEY CLUSTERED ([GameId] ASC)
);

