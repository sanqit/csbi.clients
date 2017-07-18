CREATE TABLE [dbo].[Clients]
(
    [id] UNIQUEIDENTIFIER NOT NULL,
    [first_name] NVARCHAR(128) NOT NULL,
    [middle_name] NVARCHAR(128) NULL,
    [last_name] NVARCHAR(128) NULL,
    CONSTRAINT [PK__Clients] PRIMARY KEY CLUSTERED ([id] ASC)
)