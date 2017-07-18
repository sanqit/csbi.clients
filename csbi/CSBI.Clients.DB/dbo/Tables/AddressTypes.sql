CREATE TABLE [dbo].[AddressTypes]
(
    [id] TINYINT,
    [code] NVARCHAR(128) NOT NULL,
    CONSTRAINT [PK_AddressTypes] PRIMARY KEY CLUSTERED ([id] ASC),
)