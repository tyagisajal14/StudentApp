CREATE DATABASE StudentDatabase;

Go
Create Table dbo.Students
(
StudentId bigint NOT NULL Primary key,
FirstName varchar(50) NOT NULL,
LastName varchar(50) NOT NULL,
Class varchar(50) NULL,
)
Go
--Create Table dbo.Subjects
--(
--SubjectId bigint IDENTITY(1,1) NOT NULL Primary key,
--SubjectName varchar(50) NOT NULL
--)
Go
Create Table dbo.StudentResults
(
ResultId bigint IDENTITY(1,1) NOT NULL Primary key,
StudentId bigint FOREIGN KEY REFERENCES dbo.Students (StudentId),
SubjectName varchar(50) NOT NULL,
Marks int
)