use [DB1-FirstProject]
go

create view activePropertiesUsersRelations as
	
	select u.Id as UserId, u.Username, u.UserType, u.Password,
		   p.Id as PropertyId, p.Name as PropertyName, p.Address as PropertyAddress, p.PropertyNumber as PropertyNumber, p.Value as PropertyValue,
		   pu.RelationId as RelationId
	from activePropertiesUsers as pu
		inner join activeProperties as p 
			on pu.PropertyId = p.Id
				inner join activeUsers as u 
					on pu.UserId = u.Id
go