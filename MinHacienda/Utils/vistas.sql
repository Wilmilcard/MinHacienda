create view vw_facturas as
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


--Para consultar luego la vista

select * from vw_facturas where FullName = 'Luis Fernández'