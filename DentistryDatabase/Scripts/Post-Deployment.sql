insert into [Procedure] (Name)
values
('Procedure 1'),
('Procedure 2'),
('Procedure 3')

insert into [Medicine] (Name, Price)
values
('Medicine 1', 100),
('Medicine 2', 200),
('Medicine 3', 300)

insert into ProcedureMedicine (ProcedureId, MedicineId, [Count])
values
(1, 1, 1),
(1, 3, 2),

(2, 1, 4),
(2, 2, 1),
(2, 3, 3),

(3, 2, 5)

insert into Sick (Name)
values
('Sick 1'),
('Sick 2'),
('Sick 3')

insert into MedRecord (FirstName, SecondName, DOB)
values
('First name 1', 'Second name 1', '01-06-1998'),
('First name 2', 'Second name 2', '01-06-1999'),
('First name 3', 'Second name 3', '01-06-2000')

insert into MedRecordSick (MedRecordId, SickId)
values
(1, 1),
(1, 3),

(2, 1),
(2, 2),
(2, 3),

(3, 2)

insert into Doctor (FirstName, SecondName)
values
('Doctor First name 1', 'Doctor Second name 1'),
('Doctor First name 2', 'Doctor Second name 2'),
('Doctor First name 3', 'Doctor Second name 3')

insert into Journal (ExecutingDate, DoctorId, MedRecordId, ProcedureId)
values
('2019-12-28 10:00:00 AM',1, 1, 1),
('2019-12-26 9:30:00 AM',2, 2, 2),
('2019-12-27 8:30:00 AM',3, 3, 3)