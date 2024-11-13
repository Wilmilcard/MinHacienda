--Este es un comentario
use master

IF EXISTS (SELECT name FROM sys.databases WHERE name = 'min_hacienda')
BEGIN
    DROP DATABASE min_hacienda;
END
GO

create database min_hacienda;
go

use min_hacienda;
create table Auditory
(
    CreatedAt Date,
    CreatedBy VARCHAR(100),
    UpdateAt Date
);

create table Client
(
      ClientId int identity(1,1) primary key,
      FullName varchar(100),
      Phone varchar(15),
      PrincipalAddress varchar(300)
);

create table Invoice
(
	InvoiceId int identity(1,1) primary key,
	ExpeditionDate DateTime,
	Subtotal decimal,
	Total decimal,
	FK_ClientId int,

	foreign key(FK_ClientId) references Client(ClientId)
);

create table Products
(
	ProductId int identity(1,1) primary key,
	ProductName varchar(100),
	Price decimal,
	Inventory int
); 

create table Detail
(
	DetailId int identity(1,1) primary key,
	ProductNumer varchar(100),
	Cant int,
	Total decimal,
	FK_ProductId int,
	FK_InvoiceId int,

	foreign key(FK_ProductId) references Products(ProductId),
	foreign key(FK_InvoiceId) references Invoice(InvoiceId)
); 

go

--CRUD
-- C = Create
-- R = Read
-- U = Update
-- D = Delete

-- C
INSERT INTO Client (FullName, Phone, PrincipalAddress)
VALUES
('Carlos Pérez', '123-456-7890', 'Av. Reforma 100, Ciudad de México'),
('Ana Gómez', '234-567-8901', 'Calle de la Paz 23, Monterrey'),
('Juan López', '345-678-9012', 'Av. Insurgentes 45, Guadalajara'),
('María Rodríguez', '456-789-0123', 'Calle 7, Puebla'),
('Luis Fernández', '567-890-1234', 'Av. Juárez 78, Cancún'),
('Laura Sánchez', '678-901-2345', 'Calle 8, Mérida'),
('José Ramírez', '789-012-3456', 'Av. Constitución 98, Tijuana'),
('Patricia Díaz', '890-123-4567', 'Calle 3, León'),
('Miguel Martínez', '901-234-5678', 'Av. Libertador 54, Oaxaca'),
('Sara Pérez', '012-345-6789', 'Callejón 21, Veracruz');

INSERT INTO Invoice (ExpeditionDate, Subtotal, Total, FK_ClientId)
VALUES
('2024-10-01', 100.50, 115.50, 10),
('2024-10-02', 150.75, 173.50, 2),
('2024-10-03', 200.00, 230.00, 2),
('2024-10-04', 250.25, 288.00, 4),
('2024-10-05', 300.00, 345.00, 5),
('2024-10-06', 120.30, 138.00, 6),
('2024-10-07', 180.50, 207.50, 2),
('2024-10-08', 220.75, 253.00, 8),
('2024-10-09', 170.00, 196.50, 3),
('2024-10-10', 130.90, 150.00, 10);

INSERT INTO Products (ProductName, Price, Inventory)
VALUES
('Laptop', 1500.00, 20),
('Smartphone', 800.00, 50),
('Tablet', 300.00, 35),
('Monitor', 250.00, 40),
('Mouse', 25.00, 100),
('Keyboard', 40.00, 80),
('Headphones', 60.00, 60),
('Webcam', 120.00, 30),
('Printer', 200.00, 25),
('Router', 100.00, 70),
('USB Cable', 5.00, 200),
('External Hard Drive', 80.00, 50),
('Smartwatch', 150.00, 60),
('Charger', 10.00, 150),
('Desk Chair', 180.00, 25),
('Desk', 220.00, 30),
('Laptop Stand', 40.00, 40),
('Microphone', 90.00, 15),
('Speakers', 80.00, 20),
('Camera', 500.00, 10),
('Projector', 400.00, 10),
('Surge Protector', 20.00, 100),
('Printer Ink', 30.00, 90),
('Smart Bulb', 25.00, 200),
('Smart Plug', 15.00, 150),
('VR Headset', 300.00, 25),
('Smart Thermostat', 150.00, 20),
('Cable Organizer', 10.00, 150),
('Monitor Stand', 25.00, 60),
('Portable Speaker', 50.00, 80);

INSERT INTO Detail (ProductNumer, Cant, Total, FK_ProductId, FK_InvoiceId)
VALUES
('P001', 2, 300.00, 3, 1),
('P002', 1, 800.00, 5, 1),
('P003', 3, 900.00, 8, 2),
('P004', 1, 250.00, 12, 2),
('P005', 5, 125.00, 14, 3),
('P006', 2, 80.00, 7, 3),
('P007', 1, 60.00, 4, 4),
('P008', 2, 240.00, 9, 4),
('P009', 1, 200.00, 16, 5),
('P010', 2, 400.00, 13, 5),
('P011', 3, 15.00, 17, 6),
('P012', 1, 80.00, 18, 6),
('P013', 2, 300.00, 22, 7),
('P014', 1, 40.00, 1, 7),
('P015', 4, 160.00, 26, 8),
('P016', 3, 120.00, 27, 8),
('P017', 2, 50.00, 5, 9),
('P018', 1, 120.00, 19, 9),
('P019', 1, 500.00, 23, 10),
('P020', 1, 400.00, 29, 10),
('P021', 2, 40.00, 11, 1),
('P022', 5, 100.00, 8, 1),
('P023', 3, 300.00, 24, 2),
('P024', 2, 250.00, 17, 2),
('P025', 4, 80.00, 19, 3),
('P026', 6, 240.00, 21, 3),
('P027', 2, 30.00, 20, 4),
('P028', 1, 50.00, 12, 4),
('P029', 5, 75.00, 6, 5),
('P030', 3, 60.00, 10, 5),
('P031', 2, 90.00, 25, 6),
('P032', 1, 180.00, 28, 6),
('P033', 1, 50.00, 3, 7),
('P034', 2, 100.00, 30, 7),
('P035', 3, 150.00, 4, 8),
('P036', 2, 50.00, 9, 8),
('P037', 4, 100.00, 18, 9),
('P038', 5, 120.00, 12, 9),
('P039', 2, 150.00, 13, 10),
('P040', 1, 180.00, 5, 10),
('P041', 1, 30.00, 7, 1),
('P042', 2, 50.00, 8, 1),
('P043', 1, 70.00, 3, 2),
('P044', 4, 160.00, 9, 2),
('P045', 2, 160.00, 6, 3),
('P046', 3, 120.00, 1, 3),
('P047', 5, 200.00, 27, 4),
('P048', 6, 240.00, 16, 4),
('P049', 3, 60.00, 15, 5),
('P050', 1, 100.00, 12, 5),
('P051', 4, 120.00, 21, 6),
('P052', 2, 80.00, 14, 6),
('P053', 3, 90.00, 28, 7),
('P054', 5, 150.00, 30, 7),
('P055', 4, 200.00, 1, 8),
('P056', 1, 250.00, 7, 8),
('P057', 2, 40.00, 3, 9),
('P058', 6, 180.00, 24, 9),
('P059', 1, 120.00, 2, 10),
('P060', 5, 100.00, 6, 10),
('P061', 2, 50.00, 13, 1),
('P062', 3, 30.00, 15, 1),
('P063', 1, 80.00, 17, 2),
('P064', 4, 160.00, 19, 2),
('P065', 5, 200.00, 20, 3),
('P066', 1, 90.00, 4, 3),
('P067', 3, 150.00, 16, 4),
('P068', 2, 100.00, 21, 4),
('P069', 1, 60.00, 10, 5),
('P070', 2, 120.00, 25, 5),
('P071', 4, 80.00, 11, 6),
('P072', 3, 120.00, 28, 6),
('P073', 2, 50.00, 22, 7),
('P074', 5, 250.00, 14, 7),
('P075', 1, 80.00, 3, 8),
('P076', 2, 100.00, 4, 8),
('P077', 3, 150.00, 16, 9),
('P078', 4, 120.00, 18, 9),
('P079', 1, 200.00, 12, 10),
('P080', 2, 150.00, 27, 10),
('P081', 1, 50.00, 15, 1),
('P082', 2, 100.00, 22, 1),
('P083', 3, 90.00, 30, 2),
('P084', 2, 200.00, 16, 2),
('P085', 5, 250.00, 24, 3),
('P086', 4, 160.00, 28, 3),
('P087', 1, 300.00, 14, 4),
('P088', 2, 100.00, 5, 4),
('P089', 5, 50.00, 12, 5),
('P090', 6, 200.00, 20, 5),
('P091', 2, 150.00, 10, 6),
('P092', 4, 200.00, 13, 6),
('P093', 3, 250.00, 29, 7),
('P094', 1, 120.00, 7, 7),
('P095', 2, 60.00, 5, 8),
('P096', 1, 80.00, 9, 8),
('P097', 4, 200.00, 16, 9),
('P098', 5, 100.00, 3, 9),
('P099', 3, 120.00, 20, 10),
('P100', 1, 250.00, 17, 10);

