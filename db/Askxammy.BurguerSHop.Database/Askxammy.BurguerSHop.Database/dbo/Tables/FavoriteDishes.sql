CREATE TABLE [dbo].[FavoriteDishes] (
    [ClientId] BIGINT NOT NULL,
    [DishId]   BIGINT NOT NULL,
    PRIMARY KEY CLUSTERED ([ClientId] ASC, [DishId] ASC),
    FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Client] ([Id]),
    FOREIGN KEY ([DishId]) REFERENCES [dbo].[Dish] ([Id])
);

