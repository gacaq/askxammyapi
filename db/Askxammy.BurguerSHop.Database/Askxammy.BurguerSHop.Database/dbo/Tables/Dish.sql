CREATE TABLE [dbo].[Dish] (
    [Id]          BIGINT          IDENTITY (1, 1) NOT NULL,
    [ClientId]    BIGINT          NOT NULL,
    [Name]        VARCHAR (50)    NOT NULL,
    [Description] VARCHAR (200)   NULL,
    [Rate]        DECIMAL (10, 2) DEFAULT ((0)) NULL,
    [Price]       DECIMAL (10, 2) DEFAULT ((0)) NULL,
    [Type]        VARCHAR (10)    NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Client] ([Id])
);

