CREATE TABLE [UserBook_Table] (
	[IdUser] INT NOT NULL,
	[IdBook] INT NOT NULL,
	[GetDate] DATETIME NOT NULL,
	[ReturnDate] DATETIME NOT NULL,
CONSTRAINT [Pk_UserBook] PRIMARY KEY([IdUser], [IdBook])
)