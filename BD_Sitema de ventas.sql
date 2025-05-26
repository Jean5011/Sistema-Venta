create database sistema go

use sistema 
create table Clientes(
	id_cliente int,
	nombre_cliente NVARCHAR(50),
	apellido_cliente NVARCHAR(50)
);

create table Articulos(
	id_producto int,
	nombre_producto NVARCHAR(50),
	precio float
);

create table Usuarios
(
id_usuario int,
username nvarchar(50),
account nvarchar(50),
password nvarchar(50),
validar_admin bit
)

insert into Usuarios(id_usuario,username,account,password,validar_admin)
select 1,'admin','admin123',123, 1 union
select 2,'admin2','admin3',1234, 0 



