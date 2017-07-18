CREATE PROCEDURE [dbo].[spSearchClients]
    @first_name NVARCHAR(128) = NULL,
    @middle_name NVARCHAR(128) = NULL,
    @last_name NVARCHAR(128) = NULL,
    @raw_address NVARCHAR(512) = NULL,
    @offset INT = 0,
    @limit INT = 20
AS

;WITH Results_CTE AS
(
SELECT
 DENSE_RANK() OVER (ORDER BY c.id) AS RowNum,
    c.id, c.first_name, c.middle_name, c.last_name, a.id as address_id, a.address_type, a.client_id, a.raw_address
FROM dbo.Clients c
FULL JOIN dbo.Addresses a
    ON c.id = a.client_id
WHERE (c.first_name LIKE '%' + COALESCE(@first_name, '') + '%' OR (@first_name IS NULL AND c.first_name IS NULL))
AND (c.middle_name LIKE '%' + COALESCE(@middle_name, '') + '%' OR (@middle_name IS NULL AND c.middle_name IS NULL))
AND (c.last_name LIKE '%' + COALESCE(@last_name, '') + '%' OR (@last_name IS NULL AND c.last_name IS NULL))
AND (a.raw_address LIKE '%' + COALESCE(@raw_address, '') + '%' OR (@raw_address IS NULL AND a.raw_address IS NULL))
)

SELECT *
FROM Results_CTE
WHERE RowNum >= @offset + 1
AND RowNum < @offset + @limit + 1

RETURN 0