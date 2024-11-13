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

SELECT
	I.InvoiceId,
	I.ExpeditionDate,
	I.Subtotal,
	I.Total,
	C.FullName
FROM Invoice I
	INNER JOIN Client C on C.ClientId = I.FK_ClientId
where I.Total > 50000