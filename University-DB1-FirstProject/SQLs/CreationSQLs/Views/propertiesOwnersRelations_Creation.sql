use [DB1-FirstProject]
go

create view activePropertiesOwnersRelations as
	
	select o.Id as ownerId, o.Name as ownerName, o.DocType_Id as ownerDocType, o.DocValue as ownerDocValue,
		   p.Id as PropertyId, p.Name as PropertyName, p.Address as PropertyAddress, p.PropertyNumber as PropertyNumber, p.Value as PropertyValue,
		   po.Id as relationId
	from activePropertyOwners as po
		inner join activeProperties as p 
			on po.Property_Id = p.Id
				inner join activeOwners as o 
					on po.Owner_Id = o.Id
go