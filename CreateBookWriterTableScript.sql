CREATE TABLE [BookWriter_Table] (
	[IdBook] INT NOT NULL,
	[IdWriter] INT NOT NULL,
CONSTRAINT [Pk_BookWriter] PRIMARY KEY([IdBook],[IdWriter])
)