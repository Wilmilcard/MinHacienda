CREATE OR ALTER TRIGGER trg_AfterDelete_Client
ON Client
FOR UPDATE
AS
BEGIN
    declare @clienteId as int;

	SELECT @clienteId = i.ClientId
    FROM INSERTED i
    INNER JOIN DELETED d ON i.ClientId = d.ClientId;

	INSERT INTO Auditory([CreatedAt],[CreatedBy],[UpdateAt]) 
	VALUES(SYSDATETIME(), concat('Se ACTUALIZO el cliente: ',@clienteId),null);
END;

-- como se prueba

UPDATE Client SET FullName = 'XXXXXXXXXX' where ClientId = 10;

select * from Auditory;