USE [DB1-FirstProject]
--Estas son como opciones default que trae el server pero para que esten igual mejor las pongo
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT

--Create tables
BEGIN TRANSACTION
GO

DROP TABLE IF EXISTS dbo.DB1P_Percentage_CC;
CREATE TABLE dbo.DB1P_Percentage_CC
	(
	Id int NOT NULL,
	PercentageValue REAL NOT NULL
	)  ON [PRIMARY]

DROP TABLE IF EXISTS dbo.DB1P_MoratoryInterest_CC;
CREATE TABLE dbo.DB1P_MoratoryInterest_CC
	(
	Id int NOT NULL,
	Amount money NOT NULL
	)  ON [PRIMARY]

DROP TABLE IF EXISTS dbo.DB1P_Consumption_CC;
DROP TABLE IF EXISTS dbo.DB1P_Comsumption_CC;
CREATE TABLE dbo.DB1P_Consumption_CC
	(
	Id int NOT NULL,
	ConsumptionM3 MONEY NOT NULL
	)  ON [PRIMARY]

DROP TABLE IF EXISTS dbo.DB1P_Fixed_CC;
CREATE TABLE dbo.DB1P_Fixed_CC
	(
	Id int NOT NULL,
	Amount money NOT NULL
	)  ON [PRIMARY]

DROP TABLE IF EXISTS dbo.DB1P_CC_onProperties;
CREATE TABLE dbo.DB1P_CC_onProperties
	(
	Id int NOT NULL IDENTITY (1, 1),
	Property_Id int NOT NULL,
	ChargeConcept_Id int NOT NULL,
	BeginDate date NOT NULL,
	EndDate date  NULL,
	Active bit NOT NULL
	)  ON [PRIMARY]

DROP TABLE IF EXISTS dbo.DB1P_PropertiesUsers;
CREATE TABLE dbo.DB1P_PropertiesUsers
	(
	Id int NOT NULL IDENTITY (1, 1),
	Property_Id int NOT NULL,
	User_Id int NOT NULL,
	Active bit NOT NULL
	)  ON [PRIMARY]

DROP TABLE IF EXISTS dbo.DB1P_PropertyOwners;
CREATE TABLE dbo.DB1P_PropertyOwners
	(
	Id int NOT NULL IDENTITY (1, 1),
	Property_Id int NOT NULL,
	Owner_Id int NOT NULL,
	CONSTRAINT AK_PropertyOwnersIDs UNIQUE(Property_Id,Owner_Id),
	Active bit NOT NULL
	)  ON [PRIMARY]

DROP TABLE IF EXISTS dbo.DB1P_LegalOwners;
CREATE TABLE dbo.DB1P_LegalOwners
	(
	Id int NOT NULL,
	ResponsibleName varchar(50) NOT NULL,
	Resp_DocType_Id int NOT NULL,
	Resp_DocValue int NOT NULL,
	CONSTRAINT AK_Resp_DocValue UNIQUE(Resp_DocValue,Resp_DocType_Id),
	Active bit NOT NULL
	)  ON [PRIMARY]

DROP TABLE IF EXISTS dbo.DB1P_Owners;
CREATE TABLE dbo.DB1P_Owners
	(
	Id int NOT NULL IDENTITY (1, 1),
	Name varchar(50) NOT NULL,
	DocType_Id int NOT NULL,
	DocValue int NOT NULL,
	CONSTRAINT AK_DocValue UNIQUE(DocValue,DocType_Id),
	Active bit NOT NULL
	)  ON [PRIMARY]

DROP TABLE IF EXISTS dbo.DB1P_ChargeConcepts;
CREATE TABLE dbo.DB1P_ChargeConcepts
	(
	Id int NOT NULL,
	Name varchar(50) NOT NULL,
	MoratoryInterestRate real NOT NULL,
	ReciptEmisionDay tinyint NOT NULL,
	ExpirationDays tinyint NOT NULL,
	)  ON [PRIMARY]

DROP TABLE IF EXISTS dbo.DB1P_Users;
CREATE TABLE dbo.DB1P_Users
	(
	Id int NOT NULL IDENTITY (1, 1),
	Username varchar(50) NOT NULL,
	CONSTRAINT AK_Username UNIQUE(Username),
	Password varchar(50) NOT NULL,
	UserType bit NOT NULL,
	Active bit NOT NULL
	)  ON [PRIMARY]

DROP TABLE IF EXISTS dbo.DB1P_Properties;
CREATE TABLE dbo.DB1P_Properties
	(
	Id int NOT NULL IDENTITY (1, 1),
	Name varchar(50) NOT NULL,
	Value money NOT NULL,
	Address varchar(100) NOT NULL,
	PropertyNumber int NOT NULL,
	CONSTRAINT AK_PropertyNumber UNIQUE(PropertyNumber),
	Active bit NOT NULL
	)  ON [PRIMARY]

DROP TABLE IF EXISTS dbo.DB1P_Doc_Id_Types;
CREATE TABLE dbo.DB1P_Doc_Id_Types
	(
	Id int NOT NULL,
	Name varchar(50) NOT NULL
	)  ON [PRIMARY]
GO
COMMIT
--Adds foreing keys
BEGIN TRANSACTION
GO

ALTER TABLE dbo.DB1P_Users ADD CONSTRAINT
	PK_DB1P_Users PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

ALTER TABLE dbo.DB1P_Users SET (LOCK_ESCALATION = TABLE) --Cuando hace un querry hace lock a toda la tabla en vez de solo una parte para ser mas eficiente(salia default)

ALTER TABLE dbo.DB1P_Doc_Id_Types ADD CONSTRAINT
	PK_DB1P_Doc_Id_Types PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

ALTER TABLE dbo.DB1P_Doc_Id_Types SET (LOCK_ESCALATION = TABLE)

ALTER TABLE dbo.DB1P_Owners ADD CONSTRAINT
	PK_DB1P_Owners PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

ALTER TABLE dbo.DB1P_Owners ADD CONSTRAINT
	FK_DB1P_Owners_DB1P_Doc_Id_Types FOREIGN KEY
	(
	DocType_Id
	) REFERENCES dbo.DB1P_Doc_Id_Types
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 

ALTER TABLE dbo.DB1P_Owners SET (LOCK_ESCALATION = TABLE)

ALTER TABLE dbo.DB1P_LegalOwners ADD CONSTRAINT
	PK_DB1P_LegalOwners PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

ALTER TABLE dbo.DB1P_LegalOwners ADD CONSTRAINT
	FK_DB1P_LegalOwners_DB1P_Owners FOREIGN KEY
	(
	Id
	) REFERENCES dbo.DB1P_Owners
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
ALTER TABLE dbo.DB1P_LegalOwners ADD CONSTRAINT
	FK_DB1P_LegalOwners_DB1P_Doc_Id_Types FOREIGN KEY
	(
	Resp_DocType_Id
	) REFERENCES dbo.DB1P_Doc_Id_Types
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 

ALTER TABLE dbo.DB1P_LegalOwners SET (LOCK_ESCALATION = TABLE)

ALTER TABLE dbo.DB1P_Properties ADD CONSTRAINT
	PK_DB1P_Properties PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

ALTER TABLE dbo.DB1P_Properties SET (LOCK_ESCALATION = TABLE)

ALTER TABLE dbo.DB1P_PropertiesUsers ADD CONSTRAINT
	PK_DB1P_PropertiesUsers PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

ALTER TABLE dbo.DB1P_PropertiesUsers ADD CONSTRAINT
	FK_DB1P_PropertiesUsers_DB1P_Users FOREIGN KEY
	(
	User_Id
	) REFERENCES dbo.DB1P_Users
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 

ALTER TABLE dbo.DB1P_PropertiesUsers ADD CONSTRAINT
	FK_DB1P_PropertiesUsers_DB1P_Properties FOREIGN KEY
	(
	Property_Id
	) REFERENCES dbo.DB1P_Properties
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 

ALTER TABLE dbo.DB1P_PropertiesUsers SET (LOCK_ESCALATION = TABLE)

ALTER TABLE dbo.DB1P_PropertyOwners ADD CONSTRAINT
	PK_DB1P_PropertyOwners PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

ALTER TABLE dbo.DB1P_PropertyOwners ADD CONSTRAINT
	FK_DB1P_PropertyOwners_DB1P_Properties FOREIGN KEY
	(
	Property_Id
	) REFERENCES dbo.DB1P_Properties
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 

ALTER TABLE dbo.DB1P_PropertyOwners ADD CONSTRAINT
	FK_DB1P_PropertyOwners_DB1P_Owners FOREIGN KEY
	(
	Owner_Id
	) REFERENCES dbo.DB1P_Owners
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 

ALTER TABLE dbo.DB1P_PropertyOwners SET (LOCK_ESCALATION = TABLE)

ALTER TABLE dbo.DB1P_ChargeConcepts ADD CONSTRAINT
	PK_DB1P_ChargeConcepts PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

ALTER TABLE dbo.DB1P_ChargeConcepts SET (LOCK_ESCALATION = TABLE)

ALTER TABLE dbo.DB1P_CC_onProperties ADD CONSTRAINT
	PK_DB1P_CC_onProperties PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

ALTER TABLE dbo.DB1P_CC_onProperties ADD CONSTRAINT
	FK_DB1P_CC_onProperties_DB1P_ChargeConcepts FOREIGN KEY
	(
	ChargeConcept_Id
	) REFERENCES dbo.DB1P_ChargeConcepts
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
ALTER TABLE dbo.DB1P_CC_onProperties ADD CONSTRAINT
	FK_DB1P_CC_onProperties_DB1P_Properties FOREIGN KEY
	(
	Property_Id
	) REFERENCES dbo.DB1P_Properties
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
ALTER TABLE dbo.DB1P_CC_onProperties SET (LOCK_ESCALATION = TABLE)

ALTER TABLE dbo.DB1P_Percentage_CC ADD CONSTRAINT
	PK_DB1P_Percentage_CC PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

ALTER TABLE dbo.DB1P_Percentage_CC ADD CONSTRAINT
	FK_DB1P_Percentage_CC_DB1P_ChargeConcepts FOREIGN KEY
	(
	Id
	) REFERENCES dbo.DB1P_ChargeConcepts
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
ALTER TABLE dbo.DB1P_Percentage_CC SET (LOCK_ESCALATION = TABLE)

ALTER TABLE dbo.DB1P_MoratoryInterest_CC ADD CONSTRAINT
	PK_DB1P_MoratoryInterest_CC PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

ALTER TABLE dbo.DB1P_MoratoryInterest_CC ADD CONSTRAINT
	FK_DB1P_MoratoryInterest_CC_DB1P_ChargeConcepts FOREIGN KEY
	(
	Id
	) REFERENCES dbo.DB1P_ChargeConcepts
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
ALTER TABLE dbo.DB1P_MoratoryInterest_CC SET (LOCK_ESCALATION = TABLE)

ALTER TABLE dbo.DB1P_Consumption_CC ADD CONSTRAINT
	PK_DB1P_Consumption_CC PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

ALTER TABLE dbo.DB1P_Consumption_CC ADD CONSTRAINT
	FK_DB1P_Consumption_CC_DB1P_ChargeConcepts FOREIGN KEY
	(
	Id
	) REFERENCES dbo.DB1P_ChargeConcepts
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
ALTER TABLE dbo.DB1P_Consumption_CC SET (LOCK_ESCALATION = TABLE)

ALTER TABLE dbo.DB1P_Fixed_CC ADD CONSTRAINT
	PK_DB1P_Fixed_CC PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

ALTER TABLE dbo.DB1P_Fixed_CC ADD CONSTRAINT
	FK_DB1P_Fixed_CC_DB1P_ChargeConcepts FOREIGN KEY
	(
	Id
	) REFERENCES dbo.DB1P_ChargeConcepts
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
ALTER TABLE dbo.DB1P_Fixed_CC SET (LOCK_ESCALATION = TABLE)
GO
COMMIT