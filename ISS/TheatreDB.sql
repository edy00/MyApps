create database ISS
-----------------------------------------------
use ISS
-----------------------------------------------
if exists (select * from sysobjects where name = 'Play' and xtype ='U')
drop table Play
go
create table Play (id int not null, nameP nvarchar(50), data nvarchar(10), L int, ocp int, constraint pkplays primary key (id))
insert into play (id,nameP,data,L,ocp) values (1,'Hamlet','12/06/2015',300,0)
insert into play (id,nameP,data,L,ocp) values (2,'Ultima noapte de dragoste...','19/06/2015',250,0)
insert into play (id,nameP,data,L,ocp) values (3,'12 Angry Men','22/08/2015',250,0)
insert into play (id,nameP,data,L,ocp) values (4,'Zbor deasupra unui cuib de cuci','13/07/2015',400,0)
-------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'Res' and xtype = 'U')
drop table Res
go
create table Res (id int not null, name nvarchar(50), nameP nvarchar(50), places int, constraint pkresv primary key (id))
---------------------------------------------------------------------------------------------------------------------------
alter table resv add constraint fkresv foreign key (nameP) references plays(nameP)
---------------------------------------------------------------------------------------------------------------------------

select * from play