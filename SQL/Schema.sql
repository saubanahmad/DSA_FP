-- 1. Create the Database
CREATE DATABASE IF NOT EXISTS FlightBookingDB;
USE FlightBookingDB;

-- ==========================================
-- 2. Table: Airports
-- Data Structure Mapping: Used to populate the 'Trie' (Autocomplete) and 'Graph' (Connectivity)
-- ==========================================
CREATE TABLE IF NOT EXISTS Airports (
    AirportCode VARCHAR(3) NOT NULL,
    AirportName VARCHAR(100) NOT NULL,
    City VARCHAR(50) NOT NULL,
    Country VARCHAR(50) NOT NULL,
    PRIMARY KEY (AirportCode)
);

-- ==========================================
-- 3. Table: Flights
-- Data Structure Mapping: Loaded into 'BST' (search by Date) and 'MinHeap' (sort by Price)
-- ==========================================
CREATE TABLE IF NOT EXISTS Flights (
    FlightID INT AUTO_INCREMENT NOT NULL,
    OriginCode VARCHAR(3) NOT NULL,
    DestinationCode VARCHAR(3) NOT NULL,
    FlightDate DATETIME NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    DurationMinutes INT NOT NULL,
    SeatsAvailable INT NOT NULL,
    TotalSeats INT NOT NULL,
    PRIMARY KEY (FlightID),
    FOREIGN KEY (OriginCode) REFERENCES Airports(AirportCode) ON DELETE CASCADE,
    FOREIGN KEY (DestinationCode) REFERENCES Airports(AirportCode) ON DELETE CASCADE,
    INDEX idx_flight_date (FlightDate),
    INDEX idx_price (Price)
);

-- ==========================================
-- 4. Table: Passengers
-- Data Structure Mapping: Managed via 'LinkedList' inside a Booking object
-- ==========================================
CREATE TABLE IF NOT EXISTS Passengers (
    PassengerID INT AUTO_INCREMENT NOT NULL,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Age INT NOT NULL,
    PassportNumber VARCHAR(20),
    Email VARCHAR(100),
    PRIMARY KEY (PassengerID)
);

-- ==========================================
-- 5. Table: Bookings
-- Data Structure Mapping: Loaded into 'HashTable' for O(1) PNR lookup
-- ==========================================
CREATE TABLE IF NOT EXISTS Bookings (
    BookingID INT AUTO_INCREMENT NOT NULL,
    PNR VARCHAR(10) NOT NULL UNIQUE, -- The key for the HashTable
    FlightID INT NOT NULL,
    BookingDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    Status ENUM('Confirmed', 'Cancelled', 'Pending') DEFAULT 'Pending',
    PRIMARY KEY (BookingID),
    FOREIGN KEY (FlightID) REFERENCES Flights(FlightID) ON DELETE CASCADE
);

-- ==========================================
-- 6. Table: Tickets
-- Data Structure Mapping: The final output object, often generated via 'TicketGenerator'
-- This table links Bookings to specific Passengers and Seats.
-- ==========================================
CREATE TABLE IF NOT EXISTS Tickets (
    TicketID INT AUTO_INCREMENT NOT NULL,
    TicketNumber VARCHAR(20) NOT NULL UNIQUE,
    BookingID INT NOT NULL,
    PassengerID INT NOT NULL,
    SeatNumber VARCHAR(5) NOT NULL, -- e.g., "12A"
    PRIMARY KEY (TicketID),
    FOREIGN KEY (BookingID) REFERENCES Bookings(BookingID) ON DELETE CASCADE,
    FOREIGN KEY (PassengerID) REFERENCES Passengers(PassengerID) ON DELETE CASCADE,
    -- Ensure a passenger cannot be double-booked on the same booking
    UNIQUE KEY unique_passenger_booking (BookingID, PassengerID)
);

CREATE TABLE IF NOT EXISTS Routes (
    RouteID INT AUTO_INCREMENT NOT NULL,
    OriginCode VARCHAR(3) NOT NULL,
    DestinationCode VARCHAR(3) NOT NULL,
    Distance INT NOT NULL, -- in km or miles
    PRIMARY KEY (RouteID),
    FOREIGN KEY (OriginCode) REFERENCES Airports(AirportCode) ON DELETE CASCADE,
    FOREIGN KEY (DestinationCode) REFERENCES Airports(AirportCode) ON DELETE CASCADE
);

-- ==========================================
-- 7. Seed Data (Optional - For Testing)
-- ==========================================

-- Insert Airports
INSERT INTO Airports (AirportCode, AirportName, City, Country) VALUES 
('LHE', 'Allama Iqbal International', 'Lahore', 'Pakistan'),
('KHI', 'Jinnah International', 'Karachi', 'Pakistan'),
('ISB', 'Islamabad International', 'Islamabad', 'Pakistan'),
('DXB', 'Dubai International', 'Dubai', 'UAE'),
('JFK', 'John F. Kennedy', 'New York', 'USA');

-- Insert a Flight (Lahore to Karachi)
INSERT INTO Flights (OriginCode, DestinationCode, FlightDate, Price, DurationMinutes, SeatsAvailable, TotalSeats) VALUES 
('LHE', 'KHI', '2025-12-30 14:00:00', 15000.00, 110, 60, 60),
('KHI', 'ISB', '2025-12-31 09:00:00', 18000.00, 120, 50, 60);
