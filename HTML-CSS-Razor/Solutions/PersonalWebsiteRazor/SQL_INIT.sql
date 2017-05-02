create database Blog;
go
use Blog;
go
create table Categories
(
	Id int Identity(1,1) PRIMARY KEY,
	Name varchar(50)
);
go
create table Posts 
(
	Id int IDENTITY(1,1) PRIMARY KEY,
	Title varchar(100),
	Content varchar(max),
	CategoryId int FOREIGN KEY REFERENCES Categories(Id),
	PostedOn DateTime
);
go
