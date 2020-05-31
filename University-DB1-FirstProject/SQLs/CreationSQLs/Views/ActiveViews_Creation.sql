
create view activeProperties as
	select *
	from dbo.DB1P_Properties
	where Active = 1
go

create view activeOwners as
	select *
	from dbo.DB1P_Owners
	where Active = 1
go

create view activeLegalOwners as
	select *
	from dbo.DB1P_LegalOwners
	where Active = 1
go

create view activePropertyOwners as
	select *
	from dbo.DB1P_PropertyOwners
	where Active = 1
go

create view activeCC_onProperties as
	select *
	from dbo.DB1P_CC_onProperties
	where Active = 1
go

create view activeUsers as
	select *
	from dbo.DB1P_Users
	where Active = 1
go

create view activePropertiesUsers as
	select *
	from dbo.DB1P_PropertiesUsers
	where Active = 1
go
