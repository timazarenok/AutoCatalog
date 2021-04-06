--create database [AutoCatalog];
--use master;
--drop database AutoCatalog;
use AutoCatalog;

create table [Users] (
id int IDENTITY(1,1) primary key,
[login] varchar(15),
[password] varchar(20)
)

create table AutoTypes (
id int IDENTITY(1,1) primary key,
[name] varchar(50)
)

create table AutoOils (
id int IDENTITY(1,1) primary key,
[name] varchar(30)
)

create table AutoBrands (
id int IDENTITY(1,1) primary key,
[name] varchar(30)
)

create table AutoPrivods (
id int IDENTITY(1,1) primary key,
[name] varchar(30)
)

create table KPPTypes(
id int IDENTITY(1,1) primary key,
[name] varchar(30)
)

create table TypeBodies(
id int IDENTITY(1,1) primary key,
[name] varchar(30)
)

create table Articles (
id int IDENTITY(1,1) primary key,
iduser int references Users(id) on delete cascade,
idtype int references AutoTypes(id) on delete cascade,
idoiltype int references AutoOils(id) on delete cascade,
idbrand int references AutoBrands(id) on delete cascade,
idprivod int references AutoPrivods(id) on delete cascade,
idkpp int references KPPTypes(id) on delete cascade,
idbody int references TypeBodies(id) on delete cascade,
[year] int,
[name] varchar(50),
[description] varchar(300),
price decimal(10,2)
)

insert into Articles values (1,1,'Продажа','gkjnjrnigrnijgrgrrggrgrrggrgr', 500.00)