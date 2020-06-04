create view completeLegalOwners as
	select o.Id as Id, o.Name as LegalName, o.DocValue as LegalDocValue, o.DocType_Id as LegalDocType_Id, 
		  lo.ResponsibleName as ResponsibleName, lo.RespDocValue as RespDocValue, lo.Resp_DocType_Id as RespDocType_Id
	from dbo.activeOwners as o
		inner join dbo.activeLegalOwners as lo
			on o.Id = lo.Id
go
