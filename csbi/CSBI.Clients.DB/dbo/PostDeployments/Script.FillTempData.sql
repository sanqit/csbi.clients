IF (NOT EXISTS(SELECT * FROM [dbo].[AddressTypes]))
BEGIN
    insert AddressTypes (id, code) values(0, 'registration'), (1, 'residence'), (2, 'temporary')
END

IF (NOT EXISTS(SELECT * FROM [dbo].[Clients]))
BEGIN
    INSERT Clients(id, first_name, middle_name, last_name) VALUES
    ('CC656DE0-BC43-47BF-BC06-A2B4C886B0F8', 'Иван', 'Александрович', 'Артемов'),
    ('7CB67C77-2ABD-473A-A5AF-C2AA7133ADAC', 'Артем', 'Иванович', 'Александров'),
    ('4B4051D6-484F-409C-A1D0-F2800A5CB101', 'Петров', 'Евгений', 'Петрович'),
    ('80D67FAC-326E-4D91-B059-45B6FF5AA4B0', 'Алексей', 'Владимирович', 'Пушкин'),
    ('66B89D18-3A78-4522-9718-3ED8BFCC765C', 'Имя', NULL, 'Фамилия'),
    ('7C094FAE-88EA-4197-B98B-C3612FB7F6CC', 'Имя', 'Отчество', null),
    ('03B38CA3-C4D9-4FDE-81B4-A8695CC707CA', 'Евгений', NULL, NULL)

    INSERT dbo.Addresses (id, address_type, client_id, raw_address) VALUES
    (NEWID(), 0, 'CC656DE0-BC43-47BF-BC06-A2B4C886B0F8', 'Москва, улица Пушкина, дом 23'),
    (NEWID(), 1, 'CC656DE0-BC43-47BF-BC06-A2B4C886B0F8', 'Москва, улица Лермонтова, дом 23'),

    (NEWID(), 0, '7CB67C77-2ABD-473A-A5AF-C2AA7133ADAC', 'Москва, улица Лермонтова, дом 23'),
    (NEWID(), 2, '7CB67C77-2ABD-473A-A5AF-C2AA7133ADAC', 'СПб, улица Лермонтова, дом 23'),

    (NEWID(), 0, '4B4051D6-484F-409C-A1D0-F2800A5CB101', 'СПб, Литейный проспект, дом 23'),
    (NEWID(), 1, '4B4051D6-484F-409C-A1D0-F2800A5CB101', 'СПб, Литейный проспект, дом 23'),
    (NEWID(), 2, '4B4051D6-484F-409C-A1D0-F2800A5CB101', 'СПб, Литейный проспект, дом 25'),

    (NEWID(), 0, '80D67FAC-326E-4D91-B059-45B6FF5AA4B0', 'Ярославль, улица Некрасова, д. 23'),
    (NEWID(), 1, '80D67FAC-326E-4D91-B059-45B6FF5AA4B0', 'Новосибирск, дом 66'),
    (NEWID(), 2, '80D67FAC-326E-4D91-B059-45B6FF5AA4B0', 'Калининград, проспект Ленина, дом 25'),

    (NEWID(), 0, '66B89D18-3A78-4522-9718-3ED8BFCC765C', 'Ярославль, улица Некрасова, д. 23'),
    (NEWID(), 1, '66B89D18-3A78-4522-9718-3ED8BFCC765C', 'Новосибирск, дом 66'),
    (NEWID(), 2, '66B89D18-3A78-4522-9718-3ED8BFCC765C', 'Калининград, проспект Ленина, дом 25'),

    (NEWID(), 0, '7C094FAE-88EA-4197-B98B-C3612FB7F6CC', 'Ярославль, улица Некрасова, д. 23'),
    (NEWID(), 1, '7C094FAE-88EA-4197-B98B-C3612FB7F6CC', 'Новосибирск, дом 66'),
    (NEWID(), 2, '7C094FAE-88EA-4197-B98B-C3612FB7F6CC', 'Калининград, проспект Ленина, дом 25')

END