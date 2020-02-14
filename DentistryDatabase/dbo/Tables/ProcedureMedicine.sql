CREATE TABLE [dbo].[ProcedureMedicine] (
    [MedicineId]  INT NOT NULL,
    [ProcedureId] INT NOT NULL,
    [Count]       INT NULL,
    CONSTRAINT [MedicineId_PK] PRIMARY KEY CLUSTERED ([MedicineId] ASC, [ProcedureId] ASC),
    FOREIGN KEY ([MedicineId]) REFERENCES [dbo].[Medicine] ([MedicineId]),
    FOREIGN KEY ([ProcedureId]) REFERENCES [dbo].[Procedure] ([ProcedureId]),
    UNIQUE NONCLUSTERED ([MedicineId] ASC, [ProcedureId] ASC)
);



