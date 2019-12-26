CREATE PROCEDURE [dbo].[GetJournal] AS
BEGIN
SELECT 
	j.JournalId,
    j.CreatedOn,
    j.ExecutingDate,
    d.*,
    p.*,
    md.*

from 
    Journal as j
left join 
    Doctor as d on j.DoctorId = d.DoctorId
 left JOIN
    [Procedure] as p on j.ProcedureId = p.ProcedureId
left JOIN
    MedRecord as md on j.MedRecordId = md.MedRecordId
END;

-- EXEC GetJournal