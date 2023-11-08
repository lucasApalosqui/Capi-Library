CREATE TABLE [Address_Table] (
	[Id] INT NOT NULL IDENTITY(1,1),
	[Street] VARCHAR(80) NOT NULL,
	[District] VARCHAR(80) NOT NULL,
	[State] VARCHAR(80) NOT NULL,
	[Number] INT NOT NULL,
	[Complement] VARCHAR(80) NULL,
	[IdUser] INT NOT NULL,

CONSTRAINT [Pk_Address] PRIMARY KEY([Id]),
CONSTRAINT [Fk_AddresUser] FOREIGN KEY([IdUser]) REFERENCES [User_Table]([Id])
)