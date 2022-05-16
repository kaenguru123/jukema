-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 16, 2022 at 08:14 PM
-- Server version: 10.4.19-MariaDB
-- PHP Version: 8.0.7

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `jukema`
--

-- --------------------------------------------------------

--
-- Table structure for table `department`
--

CREATE TABLE `department` (
  `ID` tinyint(4) NOT NULL,
  `Name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `department`
--

INSERT INTO `department` (`ID`, `Name`) VALUES
(1, 'Vertrieb'),
(2, 'Buchhaltung'),
(3, 'IT'),
(4, 'Personalwesen'),
(5, 'Geschäftsführungen');

-- --------------------------------------------------------

--
-- Table structure for table `employee`
--

CREATE TABLE `employee` (
  `NTUser` varchar(6) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Address` varchar(255) NOT NULL,
  `HireDate` date NOT NULL,
  `Birthday` date NOT NULL,
  `Department` tinyint(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `employee`
--

INSERT INTO `employee` (`NTUser`, `Name`, `Address`, `HireDate`, `Birthday`, `Department`) VALUES
('AMS4RT', 'Amina Rush', 'Eichhoernchenweg 96\r\n75933 Diez am Natz', '2013-03-20', '1989-01-17', 3),
('BDE3VT', 'Bernhard Diener', 'Ahornweg 13\r\n72636 Frickenhausen', '2017-12-03', '1983-05-12', 1),
('CAN7BA', 'Cyu Agen', 'Fassanenstraße 5\r\n69420 Ligma', '2012-11-11', '1994-01-20', 3),
('JAB4TR', 'Juli A. n\'Beque', 'In-adae-quat 40\r\n92763 Sug-Madig', '2013-09-13', '2000-01-01', 1),
('JSO2DR', 'Jay son D\'rull', 'Thalk-Dir-Tee-Tume-Allee 23\r\n75933 Dietz am Natz', '2010-08-18', '1987-10-08', 5),
('KFW4SI', 'Klara Fall', 'Beethovenstraße 19\r\n0711 Stuttgart', '1999-06-09', '1963-09-06', 5),
('KND6FX', 'Ken D\'rique', 'In der Tat 30\r\n92763 Sug-Madig', '2015-02-18', '1968-11-12', 4),
('MOS9TR', 'Mark O\' Sattler', 'In der Zest 20\r\n92763 Sug-Madig', '1983-05-11', '1952-02-29', 2),
('RCL9LW', 'Rainer Zufall', 'Christoph-Maria-Herbst-Straße 3\r\n86453 An der See', '2019-02-06', '1980-08-14', 4);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `department`
--
ALTER TABLE `department`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `employee`
--
ALTER TABLE `employee`
  ADD PRIMARY KEY (`NTUser`),
  ADD KEY `FK_Abteilung` (`Department`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `department`
--
ALTER TABLE `department`
  MODIFY `ID` tinyint(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `employee`
--
ALTER TABLE `employee`
  ADD CONSTRAINT `FK_Abteilung` FOREIGN KEY (`Department`) REFERENCES `department` (`ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
