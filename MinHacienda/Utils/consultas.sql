
--------------------
-- READ ------------
--------------------

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

select * from Client as c;

select 
	c.FullName,
	i.InvoiceId,
	i.ExpeditionDate,
	d.DetailId,
	p.ProductName,
	d.ProductNumer,
	d.Cant,
	d.Total as valor_unitario,
	(d.Total * d.Cant) as total
from 
	Detail d
	inner join Products p on d.FK_ProductId = p.ProductId
	inner join Invoice i on d.FK_InvoiceId = i.InvoiceId
	inner join Client c on i.FK_ClientId = c.ClientId
where
	i.InvoiceId = 6;


SELECT
	I.InvoiceId,
	I.ExpeditionDate,
	I.Subtotal,
	I.Total,
	C.FullName
FROM Invoice I
	INNER JOIN Client C on C.ClientId = I.FK_ClientId
where I.Total > 50000;





------------------------
-- UPDATE --------------
------------------------

update Client set Phone = '000000' where ClientId = 1 and FullName = 'Juan'




-------------------------
-- DELETE ---------------
-------------------------

delete Client where ClientId = 1 and FullName = 'Juan'
go
