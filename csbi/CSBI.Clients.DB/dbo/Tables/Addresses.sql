CREATE TABLE [dbo].[Addresses]
(
    [id] UNIQUEIDENTIFIER NOT NULL,
    [address_type] TINYINT NOT NULL,
    [client_id] UNIQUEIDENTIFIER NOT NULL,
    [raw_address] NVARCHAR(512) NULL,
    CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_ClientAddress] FOREIGN KEY ([client_id]) references Clients(id),
    CONSTRAINT [FK_AddressTypeAddress] FOREIGN KEY ([address_type]) references AddressTypes(id)
)
GO


CREATE INDEX [IX_Addresses_raw_address] ON [dbo].[Addresses] ([raw_address])
