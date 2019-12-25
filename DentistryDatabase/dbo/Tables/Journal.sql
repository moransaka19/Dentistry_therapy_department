CREATE TABLE [dbo].[Journal] (
    [JournalId]     INT      IDENTITY (1, 1) NOT NULL,
    [CreatedOn]     DATETIME CONSTRAINT [Date_DefaultValue] DEFAULT (getdate()) NOT NULL,
    [DoctorId]      INT      NULL,
    [ProcedureId]   INT      NULL,
    [MedRecordId]   INT      NULL,
    [ExecutingDate] DATETIME NULL,
    PRIMARY KEY CLUSTERED ([JournalId] ASC),
    FOREIGN KEY ([DoctorId]) REFERENCES [dbo].[Doctor] ([DoctorId]),
    FOREIGN KEY ([MedRecordId]) REFERENCES [dbo].[MedRecord] ([MedRecordId]),
    FOREIGN KEY ([ProcedureId]) REFERENCES [dbo].[Procedure] ([ProcedureId])
);




GO

GO

GO

GO
