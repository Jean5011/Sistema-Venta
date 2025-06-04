create database sistema go

/*use sistema */
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
Imagen VARCHAR(999),
validar_admin bit
)

/*
insert into Usuarios(id_usuario,username,account,password,Imagen,validar_admin)
select 1,'admin','admin123',123,'C:\Users\jeanp\Desktop\cursos\cursos\Aprende a programar desde cero con .NET, C# 11, Visual Studio 201922 y Git, conviértete en programador\curso\s22\Proyecto de sistema de ventas\Img User\admin\jp.jpeg', 1 union
select 2,'admin2','admin32',1234,'C:\Users\jeanp\Desktop\cursos\cursos\Aprende a programar desde cero con .NET, C# 11, Visual Studio 201922 y Git, conviértete en programador\curso\s22\Proyecto de sistema de ventas\Img User\user\us.jpeg', 0 union
select 3,'Prueba','p',1234,null,0

select * from Usuarios where id_usuario=1;

DELETE FROM Usuarios
WHERE id_usuario =1 and id_usuario=2;

UPDATE Usuarios
SET username = 'Jean pierre Esquen'
WHERE id_usuario=1

DROP TABLE Usuarios;*/