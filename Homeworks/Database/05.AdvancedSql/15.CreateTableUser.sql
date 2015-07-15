CREATE TABLE Users(
	Id int IDENTITY,
	Username nvarchar(50) NOT NULL, 
	PasswordUser nvarchar(50) NOT NULL,
	FullName nvarchar(50) NOT NULL,
	LastTimeLogin DATETIME NOT NULL, 
	CONSTRAINT PK_Users PRIMARY KEY(Id),
	CONSTRAINT UQ_Username UNIQUE(Username),
	CONSTRAINT CH_PasswordLen CHECK (LEN(PasswordUser) >= 5)
)