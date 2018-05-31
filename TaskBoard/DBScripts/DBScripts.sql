-- Table Creation and Data Scripts 

Create Table Users 
(
  Id int Primary key Identity(1,1), 
  Name varchar(100) not null,
  Email varchar(150) constraint Email_Unique Unique
)

--Drop Table Users 

Insert into Users Values('UserA','UserAEmail@gmail.com'),
('UserB','UserBEmail@gmail.com'),
('UserC','UserDEmail@gmail.com'),
('UserD','UserEEmail@gmail.com'),
('UserE','UserFEmail@gmail.com'),
('UserF','UserGEmail@gmail.com'),
('UserG','UserHEmail@gmail.com'),
('UserH','UserIEmail@gmail.com'),
('UserI','UserJEmail@gmail.com'),
('UserJ','UserKEmail@gmail.com')


Create Table TaskStatus
(
 Id int Primary key Identity(1,1), 
 Status varchar(50) not null Constraint Status_Unique Unique  
)

Insert into TaskStatus Values ('New'),('InProgress'),('Closed')


--Drop Table TaskStatus 

Create Table TaskType 
(
Id int Primary key Identity(1,1) , 
Type varchar(50)not null constraint Type_Unique Unique
)
--Drop Table TaskType

Insert into TaskType Values('Bug'),('Feature'),('Enhancement')

Create Table Task
(
Id int Primary key Identity(1,1) ,
Description nvarchar(max) not null,
Status int not null Constraint FK_TaskStatusId Foreign Key References TaskStatus(Id),
Type int not null Constraint FK_TaskTypeId Foreign Key References TaskType(Id),
DateCreated Date not null, 
NextActionDate Date
)

Create Table TaskAssignment 
(
TaskId int not null, 
UserId int, 
Constraint PK_TaskIdUserId Primary Key (TaskId, UserId)
)

Create Table Comments
(
Id int Primary key Identity(1,1) ,
TaskId int not null Constraint FK_TaskId Foreign Key References Task(Id),
Description nvarchar(max) not null, 
DateAdded Date not null, 
NextActionDate Date 
)
