-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Erstellungszeit: 04. Mai 2022 um 12:57
-- Server-Version: 10.4.18-MariaDB
-- PHP-Version: 8.0.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Datenbank: `jukema`
--

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `abteilung`
--

CREATE TABLE `abteilung` (
  `ID` tinyint(4) NOT NULL,
  `Name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `abteilung`
--

INSERT INTO `abteilung` (`ID`, `Name`) VALUES
(1, 'Vertrieb'),
(2, 'Buchhaltung'),
(3, 'IT'),
(4, 'Personalwesen'),
(5, 'Geschäftsführungen');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `mitarbeiter`
--

CREATE TABLE `mitarbeiter` (
  `NTUser` varchar(6) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Anschrift` varchar(255) NOT NULL,
  `Einstellungsdatum` date NOT NULL,
  `Geburtstag` date NOT NULL,
  `Abteilung` tinyint(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `mitarbeiter`
--

INSERT INTO `mitarbeiter` (`NTUser`, `Name`, `Anschrift`, `Einstellungsdatum`, `Geburtstag`, `Abteilung`) VALUES
('AMS4RT', 'Amina Rush', 'Eichhoernchenweg 96\r\n75933 Diez am Natz', '2013-03-20', '1989-01-17', 3),
('BDE3VT', 'Bernhard Diener', 'Ahornweg 13\r\n72636 Frickenhausen', '2017-12-03', '1983-05-12', 1),
('CAN7BA', 'Cyu Agen', 'Fassanenstraße 5\r\n69420 Ligma', '2012-11-11', '1994-01-20', 3),
('JAB4TR', 'Juli A. n\'Beque', 'In-adae-quat 40\r\n92763 Sug-Madig', '2013-09-13', '2000-01-01', 1),
('KFW4SI', 'Klara Fall', 'Beethovenstraße 19\r\n0711 Stuttgart', '1999-06-09', '1963-09-06', 5),
('KND6FX', 'Ken D\'rique', 'In der Tat 30\r\n92763 Sug-Madig', '2015-02-18', '1968-11-12', 4),
('MOS9TR', 'Mark O\' Sattler', 'In der Zest 20\r\n92763 Sug-Madig', '1983-05-11', '1952-02-29', 2),
('RCL9LW', 'Rainer Zufall', 'Christoph-Maria-Herbst-Straße 3\r\n86453 An der See', '2019-02-06', '1980-08-14', 4);

--
-- Indizes der exportierten Tabellen
--

--
-- Indizes für die Tabelle `abteilung`
--
ALTER TABLE `abteilung`
  ADD PRIMARY KEY (`ID`);

--
-- Indizes für die Tabelle `mitarbeiter`
--
ALTER TABLE `mitarbeiter`
  ADD PRIMARY KEY (`NTUser`),
  ADD KEY `FK_Abteilung` (`Abteilung`);

--
-- AUTO_INCREMENT für exportierte Tabellen
--

--
-- AUTO_INCREMENT für Tabelle `abteilung`
--
ALTER TABLE `abteilung`
  MODIFY `ID` tinyint(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Constraints der exportierten Tabellen
--

--
-- Constraints der Tabelle `mitarbeiter`
--
ALTER TABLE `mitarbeiter`
  ADD CONSTRAINT `FK_Abteilung` FOREIGN KEY (`Abteilung`) REFERENCES `abteilung` (`ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
