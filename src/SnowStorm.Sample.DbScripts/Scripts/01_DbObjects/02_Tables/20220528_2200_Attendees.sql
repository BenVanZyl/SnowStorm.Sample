If Not Exists(Select 1 From sys.tables Where name = 'Atendee')
Begin

	CREATE TABLE [Seminars].[Atendee](
		[Id] [bigint] IDENTITY(1,1) NOT NULL,

		CreatedOn		dateTime NOT NULL,
		ModifiedOn		dateTime NOT NULL,
		
		SeminarId		bigint NOT NULL, --FK

		AttendeeName	varchar(128) NOT NULL, --UX

		CONSTRAINT [PK_Atendee] PRIMARY KEY CLUSTERED
		(
			[Id] ASC
		)
	)

End
GO

--Create Index
If Not Exists (Select * From sys.indexes where name = 'UI_Seminars_Atendee')
Begin
	CREATE UNIQUE INDEX UI_Seminars_Atendee
		ON Seminars.Atendee (SeminarId, AttendeeName);
End
Go

--FK
If Not Exists(Select * From sys.foreign_keys  Where name = 'FK_Seminars_Atendee_Seminar')
Begin
	ALTER TABLE Seminars.Atendee
		WITH CHECK
		ADD  CONSTRAINT [FK_Seminars_Atendee_Seminar]
		FOREIGN KEY(SeminarId) REFERENCES Seminars.Seminar (Id)
End
Go