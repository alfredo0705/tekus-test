--  DATOS INICIALES PARA LA BASE DE DATOS TEKUS

-- Limpiar datos previos
DELETE FROM ProviderCustomFields;
DELETE FROM Services;
DELETE FROM Providers;
GO

--Reiniciar los contadores de identidad
DBCC CHECKIDENT ('Services', RESEED, 0);
DBCC CHECKIDENT ('Providers', RESEED, 0);
GO

--INSERTAR PROVEEDORES
INSERT INTO Providers (NIT, Name, Email, CreatedBy, CreatedAt)
VALUES
('900100100-1', 'TransAndes Logistics', 'contacto@transandes.com', 'admin', GETDATE()),
('900200200-2', 'Viajes del Sol', 'info@viajesdelsol.com', 'admin', GETDATE()),
('900300300-3', 'ExpressCar SAS', 'reservas@expresscar.com', 'admin', GETDATE()),
('900400400-4', 'Rutas del Norte', 'soporte@rutasnorte.com', 'admin', GETDATE()),
('900500500-5', 'Andina Tours', 'contact@andinatours.com', 'admin', GETDATE()),
('900600600-6', 'Servicios del Valle', 'ventas@serviciosvalle.com', 'admin', GETDATE()),
('900700700-7', 'Elite Transport', 'elite@transport.com', 'admin', GETDATE()),
('900800800-8', 'TurisColombia', 'contacto@turiscolombia.com', 'admin', GETDATE()),
('900900900-9', 'Viajes Caribe', 'info@viajescaribe.com', 'admin', GETDATE()),
('901000000-0', 'Logística Total', 'admin@logisticatotal.com', 'admin', GETDATE());
GO

-- ===========================================
--INSERTAR SERVICIOS
-- ===========================================
INSERT INTO Services (Name, HourlyRate, ProviderId, CreatedBy, CreatedAt, Countries)
VALUES
('City Tour Bogotá', 35.50, 1, 'admin', GETDATE(), '["CO"]'),
('Traslado Aeropuerto Medellín', 45.00, 2, 'admin', GETDATE(), '["CO"]'),
('Tour Cafetero', 50.00, 3, 'admin', GETDATE(), '["CO","PE"]'),
('Excursión a la Sierra Nevada', 70.00, 4, 'admin', GETDATE(), '["CO","CL"]'),
('Tour Histórico Lima', 60.00, 5, 'admin', GETDATE(), '["PE"]'),
('Ruta del Vino', 80.00, 6, 'admin', GETDATE(), '["AR","CL"]'),
('Tour de las Cataratas', 90.00, 7, 'admin', GETDATE(), '["AR","BR"]'),
('Excursión al Desierto de Atacama', 100.00, 8, 'admin', GETDATE(), '["CL"]'),
('Tour Gastronómico Ciudad de México', 55.00, 9, 'admin', GETDATE(), '["MX"]'),
('Recorrido Colonial Quito', 65.00, 10, 'admin', GETDATE(), '["EC"]');
GO

-- ===========================================
-- INSERTAR CAMPOS PERSONALIZADOS DE PROVEEDORES
-- ===========================================
INSERT INTO ProviderCustomFields (ProviderId, FieldName, FieldValue)
VALUES
(1, 'TipoVehiculo', 'Van'),
(1, 'Capacidad', '12'),
(2, 'Idioma', 'Español'),
(2, 'LicenciaTurismo', 'Sí'),
(3, 'CertificadoCalidad', 'ISO 9001'),
(4, 'ZonaCobertura', 'Costa Atlántica'),
(5, 'Soporte24H', 'Sí'),
(6, 'AñosExperiencia', '8'),
(7, 'CertificadoAmbiental', 'Sí'),
(8, 'TipoVehiculo', 'Bus'),
(9, 'Capacidad', '20'),
(10, 'Idioma', 'Inglés');
GO
