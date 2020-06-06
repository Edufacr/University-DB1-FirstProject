create view completeCC_onProperties as
	select cc_p.RelationId, cc_p.BeginDate, cc_p.EndDate, 
		   cc.Id as CC_Id, cc.Name as CCName, cc.ExpirationDays, cc.MoratoryInterestRate, cc.ReciptEmisionDay,
		   p.Id as Property_Id, p.PropertyNumber
	from dbo.activeCC_onProperties as cc_p
		inner join dbo.activeProperties as p
			on cc_p.PropertyId = p.Id
				inner join dbo.DB1P_ChargeConcepts as cc
					on cc.Id = cc_p.CC_Id
go