use master;
GO
IF EXISTS(select * from sys.databases where name='ExerciseLibrary')
	drop database ExerciseLibrary;
GO
create database ExerciseLibrary;
GO
use ExerciseLibrary;
GO
if exists(select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Authors')
	drop table Authors;

create table Authors (
	ID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Name varchar(128) NOT NULL
);

if exists(select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Books')
	drop table Books;
create table Books (
	ISBN int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Title varchar(128) NOT NULL
);

if exists(select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'BookAuthors')
	drop table BookAuthors;
create table BookAuthors (
	BookISBN int NOT NULL FOREIGN KEY REFERENCES Books(ISBN),
	AuthorID int NOT NULL FOREIGN KEY REFERENCES Authors(ID),
	CONSTRAINT BookAuthorsID PRIMARY KEY (BookISBN, AuthorID)
);

if exists(select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Libraries')
	drop table Libraries;
create table Libraries (
	ID int NOT NULL IDENTITY(1,1) PRIMARY KEY
);

if exists(select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'LibraryBooks')
	drop table LibraryBooks;
create table LibraryBooks (
	LibraryID int NOT NULL FOREIGN KEY REFERENCES Libraries(ID),
	BookISBN int NOT NULL FOREIGN KEY REFERENCES Books(ISBN),
	PhysicalCopies int NOT NULL DEFAULT 0,
	AvailableCopies int NOT NULL DEFAULT 0,
	CONSTRAINT LibraryBooksID PRIMARY KEY (LibraryID, BookISBN)
);

if exists(select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Users')
	drop table Users;
create table Users (
	ID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Name varchar(128) NOT NULL
);

if exists(select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'LibraryUsers')
	drop table LibraryUsers;
create table LibraryUsers (
	LibraryID int NOT NULL FOREIGN KEY REFERENCES Libraries(ID),
	UserID int NOT NULL FOREIGN KEY REFERENCES Users(ID),
	CONSTRAINT LibraryUsersID PRIMARY KEY (LibraryID, UserID)
);

if exists(select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Librarians')
	drop table Librarians;
create table Librarians (
	ID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Name varchar(128) NOT NULL,
	ManagedLibraryID int NOT NULL FOREIGN KEY REFERENCES Libraries(ID)
);

if exists(select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Rents')
	drop table Rents;
create table Rents (
	ID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	UserID int NOT NULL FOREIGN KEY REFERENCES Users(ID),
	BookISBN int NOT NULL FOREIGN KEY REFERENCES Books(ISBN),
	LibraryID int NOT NULL FOREIGN KEY REFERENCES Libraries(ID),
	AuthorizedBy int NOT NULL FOREIGN KEY REFERENCES Librarians(ID),
	RentDate date NOT NULL DEFAULT GETDATE()
)

INSERT INTO Authors (Name) VALUES ('Tom Robbins');
INSERT INTO Authors (Name) VALUES ('Fyodor Dostoyevsky');

INSERT INTO Books (Title) VALUES ('Even Cowgirls Get the Blues');
INSERT INTO Books (Title) VALUES ('Half Asleep in Frog Pijamas');
INSERT INTO Books (Title) VALUES ('Villa Incognito');

INSERT INTO BookAuthors VALUES(1, 1);
INSERT INTO BookAuthors VALUES(2, 1);
INSERT INTO BookAuthors VALUES(3, 1);