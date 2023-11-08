CREATE TABLE [BookCategory_Table] (
	[IdBook] INT NOT NULL,
	[IdCategory] INT NOT NULL,
CONSTRAINT [Pk_BookCategory] PRIMARY KEY([IdBook],[IdCategory])
)