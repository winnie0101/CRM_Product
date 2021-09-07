CREATE TABLE [dbo].[ProductType] (
    [TypeID]          BIGINT        NOT NULL,
    [TypeName]        NVARCHAR (50) NOT NULL,
    [CreatedDateTime] BIGINT        NOT NULL,
    [CreatedUser]     VARCHAR (100) NOT NULL,
    [UpdatedTimes]    TINYINT       NOT NULL,
    [UpdatedDateTime] BIGINT        NOT NULL,
    [UpdatedUser]     VARCHAR (100) NOT NULL,
    [IsDeleted]       BIT           NOT NULL,
    [Rowversion]      ROWVERSION    NOT NULL,
    CONSTRAINT [PK_ProductType] PRIMARY KEY CLUSTERED ([TypeID] ASC)
);



