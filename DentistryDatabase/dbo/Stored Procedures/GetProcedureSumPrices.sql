go
create procedure GetProcedureSumPrices as
Begin
select SUM(m.Price) as SumPrices, p.* from [Procedure] p
left join ProcedureMedicine pm on pm.ProcedureId = p.ProcedureId
left join Medicine m on m.MedicineId = pm.MedicineId
group by p.ProcedureId, p.[Name]
end;