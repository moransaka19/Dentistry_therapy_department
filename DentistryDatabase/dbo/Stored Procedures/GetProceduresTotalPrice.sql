CREATE procedure [dbo].[GetProceduresTotalPrice]
as
begin
	select 
		p.ProcedureId,
		sum(m.Price * pm.[Count]) as Price
	into #procedureCost
	from [Procedure] p
	inner join ProcedureMedicine pm on p.ProcedureId = pm.ProcedureId
	inner join Medicine m on m.MedicineId = pm.MedicineId
	group by p.ProcedureId

	select pc.Price, p.ProcedureId, p.[Name], mr.* from [Procedure] p
	inner join #procedureCost pc on p.ProcedureId = pc.ProcedureId
	inner join Journal j on j.ProcedureId = p.ProcedureId
	inner join MedRecord mr on mr.MedRecordId = j.MedRecordId
end