CREATE TABLE [dbo].[MedRecordSick](
	[MedRecordId] [int] NOT NULL,
	[SickId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MedRecordId] ASC,
	[SickId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[MedRecordSick] ADD FOREIGN KEY([MedRecordId])
REFERENCES [dbo].[MedRecord] ([MedRecordId])
GO
ALTER TABLE [dbo].[MedRecordSick] ADD FOREIGN KEY([SickId])
REFERENCES [dbo].[Sick] ([SickId])