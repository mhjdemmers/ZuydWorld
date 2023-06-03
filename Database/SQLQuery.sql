CREATE TABLE Gebruikers (
GebruikerID int NOT NULL PRIMARY KEY,
Gebruikersnaam varchar(50) NOT NULL,
Email varchar(50) NOT NULL),
Profielfoto varchar(50) NOT NULL)

CREATE TABLE Scores (
ScoreID INT  NOT NULL PRIMARY KEY,
GebruikerID INT  FOREIGN KEY REFERENCES Gebruikers(GebruikerID))
