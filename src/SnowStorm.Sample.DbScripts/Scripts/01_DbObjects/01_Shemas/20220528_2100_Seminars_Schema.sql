
If Not Exists(Select 1 From sys.schemas Where name = 'Seminars')
Begin
	Execute('Create Schema Seminars')
End
GO