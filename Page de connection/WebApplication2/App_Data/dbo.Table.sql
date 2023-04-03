CREATE TABLE [dbo].[User]
(
	[Id_Utilisateur] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Utilisateur] NVARCHAR(50) NULL, 
    [Mot_de_Passe] NVARCHAR(50) NULL
);
