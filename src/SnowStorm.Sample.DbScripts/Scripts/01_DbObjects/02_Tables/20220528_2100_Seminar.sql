
If Not Exists(Select 1 From sys.tables Where name = 'Seminar')
Begin

	CREATE TABLE [Seminars].[Seminar](
		[Id] [bigint] IDENTITY(1,1) NOT NULL,

		CreatedOn		dateTime NOT NULL,
		ModifiedOn		dateTime NOT NULL,
		
		Subject			varchar(128) NOT NULL,
		EventDate		datetime NOT NULL,

		CONSTRAINT [PK_Seminar] PRIMARY KEY CLUSTERED
		(
			[Id] ASC
		)
	)

End
GO