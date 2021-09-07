CREATE TABLE [dbo].[Product] (
    [ProductID]       BIGINT         NOT NULL,
    [ProductName]     NVARCHAR (80)  NOT NULL,
    [TypeID]          BIGINT         NOT NULL,
    [Price]           MONEY          NOT NULL,
    [Discount]        INT            NULL,
    [Description]     NVARCHAR (200) NULL,
    [IsEnabled]       BIT            NOT NULL,
    [CreatedDateTime] BIGINT         NOT NULL,
    [CreatedUser]     VARCHAR (50)   NOT NULL,
    [UpdatedTimes]    TINYINT        NOT NULL,
    [UpdatedDateTime] BIGINT         NOT NULL,
    [UpdatedUser]     VARCHAR (50)   NOT NULL,
    [IsDeleted]       BIT            NOT NULL,
    [Rowversion]      ROWVERSION     NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([ProductID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'1:啟用 0:停用', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Product', @level2type = N'COLUMN', @level2name = N'IsEnabled';

