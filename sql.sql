CREATE DATABASE CoreSystem
GO
USE CoreSystem

CREATE TABLE Member (
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	FullName VARCHAR(25),
	Address VARCHAR(250),
	FatherName VARCHAR(25),
	MotherName VARCHAR(25),
	GrandFatherName VARCHAR(25),
	Gender VARCHAR(25),
	Number VARCHAR(10),
	DateOfBirth DATETIME,
	CreatedAt DATETIME,
	RecStatus CHAR(1)
);

GO

CREATE TABLE SharePurchase(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    MemberId INT FOREIGN KEY REFERENCES Member(Id),
	ShareNo INT,
	ShareAmount INT,
	Remarks VARCHAR(200),
	PurchaseDate DATETIME,
	RecStatus CHAR(1)
);

GO
CREATE TABLE ShareReturn(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    MemberId INT FOREIGN KEY REFERENCES Member(Id),
	ShareNo INT,
	Amount INT,
	Remarks VARCHAR(200),
	ReturnDate DATETIME,
	RecStatus CHAR(1)
);