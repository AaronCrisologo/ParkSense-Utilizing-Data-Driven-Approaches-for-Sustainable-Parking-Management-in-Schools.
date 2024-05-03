-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 03, 2024 at 03:46 AM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `parkinglot1`
--

-- --------------------------------------------------------

--
-- Table structure for table `ceafa`
--

CREATE TABLE `ceafa` (
  `parkingSlot` int(11) NOT NULL,
  `isOccupied` tinyint(1) DEFAULT NULL,
  `fullName` varchar(255) DEFAULT NULL,
  `vehicleType` varchar(255) DEFAULT NULL,
  `vehicleNumber` varchar(255) DEFAULT NULL,
  `entryTime` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `ceafa`
--

INSERT INTO `ceafa` (`parkingSlot`, `isOccupied`, `fullName`, `vehicleType`, `vehicleNumber`, `entryTime`) VALUES
(1, NULL, NULL, NULL, NULL, NULL),
(2, NULL, NULL, NULL, NULL, NULL),
(3, NULL, NULL, NULL, NULL, NULL),
(4, NULL, NULL, NULL, NULL, NULL),
(5, NULL, NULL, NULL, NULL, NULL),
(6, NULL, NULL, NULL, NULL, NULL),
(7, NULL, NULL, NULL, NULL, NULL),
(8, NULL, NULL, NULL, NULL, NULL),
(9, NULL, NULL, NULL, NULL, NULL),
(10, NULL, NULL, NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `cics`
--

CREATE TABLE `cics` (
  `parkingSlot` int(11) NOT NULL,
  `isOccupied` tinyint(1) DEFAULT NULL,
  `fullName` varchar(255) DEFAULT NULL,
  `vehicleType` varchar(255) DEFAULT NULL,
  `vehicleNumber` varchar(255) DEFAULT NULL,
  `entryTime` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `cics`
--

INSERT INTO `cics` (`parkingSlot`, `isOccupied`, `fullName`, `vehicleType`, `vehicleNumber`, `entryTime`) VALUES
(1, NULL, NULL, NULL, NULL, NULL),
(2, NULL, NULL, NULL, NULL, NULL),
(3, NULL, NULL, NULL, NULL, NULL),
(4, NULL, NULL, NULL, NULL, NULL),
(5, NULL, NULL, NULL, NULL, NULL),
(6, NULL, NULL, NULL, NULL, NULL),
(7, NULL, NULL, NULL, NULL, NULL),
(8, NULL, NULL, NULL, NULL, NULL),
(9, NULL, NULL, NULL, NULL, NULL),
(10, NULL, NULL, NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `cit`
--

CREATE TABLE `cit` (
  `parkingSlot` int(11) NOT NULL,
  `isOccupied` tinyint(1) DEFAULT NULL,
  `fullName` varchar(255) DEFAULT NULL,
  `vehicleType` varchar(255) DEFAULT NULL,
  `vehicleNumber` varchar(255) DEFAULT NULL,
  `entryTime` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `cit`
--

INSERT INTO `cit` (`parkingSlot`, `isOccupied`, `fullName`, `vehicleType`, `vehicleNumber`, `entryTime`) VALUES
(1, NULL, NULL, NULL, NULL, NULL),
(2, NULL, NULL, NULL, NULL, NULL),
(3, NULL, NULL, NULL, NULL, NULL),
(4, NULL, NULL, NULL, NULL, NULL),
(5, NULL, NULL, NULL, NULL, NULL),
(6, NULL, NULL, NULL, NULL, NULL),
(7, NULL, NULL, NULL, NULL, NULL),
(8, NULL, NULL, NULL, NULL, NULL),
(9, NULL, NULL, NULL, NULL, NULL),
(10, NULL, NULL, NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `coe`
--

CREATE TABLE `coe` (
  `parkingSlot` int(11) NOT NULL,
  `isOccupied` tinyint(1) DEFAULT NULL,
  `fullName` varchar(255) DEFAULT NULL,
  `vehicleType` varchar(255) DEFAULT NULL,
  `vehicleNumber` varchar(255) DEFAULT NULL,
  `entryTime` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `coe`
--

INSERT INTO `coe` (`parkingSlot`, `isOccupied`, `fullName`, `vehicleType`, `vehicleNumber`, `entryTime`) VALUES
(1, NULL, NULL, NULL, NULL, NULL),
(2, NULL, NULL, NULL, NULL, NULL),
(3, NULL, NULL, NULL, NULL, NULL),
(4, NULL, NULL, NULL, NULL, NULL),
(5, NULL, NULL, NULL, NULL, NULL),
(6, NULL, NULL, NULL, NULL, NULL),
(7, NULL, NULL, NULL, NULL, NULL),
(8, NULL, NULL, NULL, NULL, NULL),
(9, NULL, NULL, NULL, NULL, NULL),
(10, NULL, NULL, NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `parkingcost`
--

CREATE TABLE `parkingcost` (
  `vehicletype` varchar(15) NOT NULL,
  `fee` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `parkingcost`
--

INSERT INTO `parkingcost` (`vehicletype`, `fee`) VALUES
('4 Wheels', 30),
('E-bike', 100),
('Large Vehicle', 40),
('Motorcycle', 15);

-- --------------------------------------------------------

--
-- Table structure for table `parkingreceipts`
--

CREATE TABLE `parkingreceipts` (
  `receiptId` int(11) NOT NULL,
  `parkingSlot` int(11) DEFAULT NULL,
  `fullName` varchar(255) DEFAULT NULL,
  `vehicleType` varchar(255) DEFAULT NULL,
  `vehicleNumber` varchar(255) DEFAULT NULL,
  `entryTime` datetime DEFAULT NULL,
  `exitTime` datetime DEFAULT NULL,
  `duration` time DEFAULT NULL,
  `totalCost` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `ceafa`
--
ALTER TABLE `ceafa`
  ADD PRIMARY KEY (`parkingSlot`),
  ADD UNIQUE KEY `vehicleNumber` (`vehicleNumber`);

--
-- Indexes for table `cics`
--
ALTER TABLE `cics`
  ADD PRIMARY KEY (`parkingSlot`),
  ADD UNIQUE KEY `vehicleNumber` (`vehicleNumber`);

--
-- Indexes for table `cit`
--
ALTER TABLE `cit`
  ADD PRIMARY KEY (`parkingSlot`),
  ADD UNIQUE KEY `vehicleNumber` (`vehicleNumber`);

--
-- Indexes for table `coe`
--
ALTER TABLE `coe`
  ADD PRIMARY KEY (`parkingSlot`),
  ADD UNIQUE KEY `vehicleNumber` (`vehicleNumber`);

--
-- Indexes for table `parkingcost`
--
ALTER TABLE `parkingcost`
  ADD PRIMARY KEY (`vehicletype`);

--
-- Indexes for table `parkingreceipts`
--
ALTER TABLE `parkingreceipts`
  ADD PRIMARY KEY (`receiptId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `ceafa`
--
ALTER TABLE `ceafa`
  MODIFY `parkingSlot` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `cics`
--
ALTER TABLE `cics`
  MODIFY `parkingSlot` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `cit`
--
ALTER TABLE `cit`
  MODIFY `parkingSlot` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `coe`
--
ALTER TABLE `coe`
  MODIFY `parkingSlot` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `parkingreceipts`
--
ALTER TABLE `parkingreceipts`
  MODIFY `receiptId` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
