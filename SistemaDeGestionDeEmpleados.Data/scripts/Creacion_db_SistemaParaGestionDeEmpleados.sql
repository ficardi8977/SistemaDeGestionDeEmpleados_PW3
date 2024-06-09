--a) Crear en SQL Server las siguientes tablas:
--- Empleado: con los campos (IdEmpleado int NOT NULL, NombreCompleto nvarchar(100) NOT NULL, IdSucursal int
--NOT NULL)
--- Sucursal: con los campos (IdSucursal int, Direccion nvarchar(100) NOT NULL, Eliminada bit NOT NULL)
--Recordar agregar la relación para que un Empleado esté relacionado a una Sucursal a través de IdSucursal. Establecer
--las claves primarias como identity


create table Sucursal
(
IdSucursal int Primary key identity not null,
Direccion nvarchar(100) NOT NULL, 
Eliminada bit NOT NULL
)


create table Empleado
(
IdEmpleado int Primary key identity not null, 
NombreCompleto nvarchar(100) NOT NULL, 
IdSucursal int NOT NULL,
CONSTRAINT FK_Empleado_Sucursal FOREIGN KEY (IdSucursal) REFERENCES Sucursal(IdSucursal)
)



--d) Generar script para creación de base de datos, tablas e insert de 2 Sucursales no eliminadas y 1 Sucursal Eliminada
--para que puedan crearse Empleados. (Eliminada = 1 quiere decir que esta eliminada la sucursal y Eliminada = 0 quiere
--decir que no esta eliminada la Sucursal).

insert into Sucursal(Direccion, Eliminada)
values('Cordoba 586', 0),
('Don Bosco 1240', 0),
('Florencio Varela 983', 1)


--- script de ejecucion Scaffold
--Scaffold-DbContext "Server=.\SQLEXPRESS;Database=SistemaDeGestionDeEmpleados;Trusted_Connection=True;;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir EF