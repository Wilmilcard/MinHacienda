--Este es un comentario
use master
drop database min_hacienda;
create database min_hacienda;

drop database min_hacienda_dev;
create database min_hacienda_dev;

use min_hacienda;
go

--create table Auditory
--(
--    CreatedAt Date,
--    CreatedBy VARCHAR(100),
--    UpdateAt Date
--);

create table Client
(
      ClientId int identity(1,1) primary key,
      FullName varchar(100),
      Phone varchar(15),
      PrincipalAddress varchar(300)
);
go

--CRUD
-- C = Create
-- R = Read
-- U = Update
-- D = Delete

-- C
insert into Client(FullName, Phone, PrincipalAddress) values
('Juan', '3043405607', 'Ibague'),
('Eduard', '31000000', 'Bogota'),
('Cristian', '999999', 'Cali')

-- R
select 'Saludos JUAN LEON' as mensaje

select
      c.ClientId,
      c.FullName as nombre,
      c.PrincipalAddress,
      CONCAT(c.FullName,' ------ ',((5 * c.ClientId) - 10)) as ecuacion,
      (select
            PrincipalAddress
      from
            Client as x
      where x.ClientId = c.ClientId +1 ) as subconsulta
from
      Client as c

select * from Client as c

-- U
update Client set Phone = '000000' where ClientId = 1 and FullName = 'Juan'

-- D
delete Client where ClientId = 1 and FullName = 'Juan'
go