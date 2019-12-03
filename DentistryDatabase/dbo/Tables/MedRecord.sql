CREATE TABLE [dbo].[MedRecord] (
    [MedRecordId] INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]   NVARCHAR (100) NULL,
    [SecondName]  NVARCHAR (100) NULL,
    [DOB]         DATE           NULL,
    PRIMARY KEY CLUSTERED ([MedRecordId] ASC)
);

