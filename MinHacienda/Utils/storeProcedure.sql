create or alter procedure sp_consulta
(
	@nombre_1 as varchar(100),
	@nombre_2 as varchar(100) null
) as
begin
	declare @clienteID as INT;
	declare @total_compra as INT;
	select top 1 @clienteID = ClientId from Client where FullName in (@nombre_1,@nombre_2) ;
	--select * from Invoice where InvoiceId in(select FK_InvoiceId from Detail where Total in (100, 300))

	select @total_compra = Total from Invoice where FK_ClientId = @clienteID;
	
	IF(@total_compra >= 150)
	BEGIN
		UPDATE Client set PrincipalAddress = 'Tiene premio' where ClientId = @clienteID;
		INSERT INTO Auditory([CreatedAt],[CreatedBy],[UpdateAt]) VALUES(SYSDATETIME(),'El total es mayor a 150',null)
	END
	ELSE
	BEGIN
		
		INSERT INTO Auditory([CreatedAt],[CreatedBy],[UpdateAt]) VALUES(SYSDATETIME(), CONCAT('Hay un error con cliente',@nombre_1),null)
	END

	select 'FIN DE LA EJECUCION'

end

-- Para ejecutarlo

exec sp_consulta 'Ana Gómez', 'Miguel Martínez'