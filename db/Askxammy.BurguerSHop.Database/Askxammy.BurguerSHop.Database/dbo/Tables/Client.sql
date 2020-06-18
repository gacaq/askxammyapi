CREATE TABLE [dbo].[Client] (
    [Id]          BIGINT       IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (50) NOT NULL,
    [Address]     VARCHAR (50) NULL,
    [Role]        INT          NOT NULL,
    [Username]    VARCHAR (20) NOT NULL,
    [Password]    VARCHAR (20) NOT NULL,
    [PhoneNumber] VARCHAR (15) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

