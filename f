CREATE TABLE Hotels( 
    HID integer Primary Key Not Null,
    Name varchar(25) Not Null,
    City varchar(25) Not Null,
    State CHAR(2) Not Null,
    Luxury Integer Not Null,
    Airport_Distance Integer Not Null,
    Downtown_Distance Integer Not Null );

CREATE TABLE Rooms(
    RID integer Primary Key Not Null,
    NUM integer Not Null,
    HID integer Not Null, Beds integer Not Null,
    Price Float(4, 2) Not Null,
    TV Yes/No Not Null,
    Fridge Yes/No Not Null,
    Foreign Key (HID) REFERENCES Hotels (HID)
    );

CREATE TABLE Reservations(
    SVID integer Primary Key Not Null,
    RID integer Not Null,
    Guest varchar(25) Not Null,
    DateIn Date Not Null,
    Days integer Not Null,
    Num integer Not Null,
    Foreign Key (RID) REFERENCES Rooms (RID)
    );


INSERT INTO Hotels Values(1, 'FourSeasons', 'Dallas', 'TX', 5, 15, 30);
INSERT INTO Hotels Values(2, 'Hilton', 'Dallas', 'TX', 3, 35, 15);
INSERT INTO Hotels Values(3, 'Sheraton', 'Dallas', 'TX', 3, 25, 10);
INSERT INTO Hotels Values(4, 'Holiday Inn', 'Amarillo', 'TX', 3, 35, 25);
INSERT INTO Hotels Values(5, 'Days inn', 'Pampa', 'TX', 1, 50, 10);
INSERT INTO Hotels Values(6, 'Days inn', 'Canyon', 'TX', 1, 30, 3);




INSERT INTO Rooms Values(1, 25, 1, 1, 80.00, T, F);
INSERT INTO Rooms Values(2, 20, 1, 2, 120.00, T, F);
INSERT INTO Rooms Values(3, 100, 2, 2, 200.00, T, T);
INSERT INTO Rooms Values(4, 20, 2, 2, 600.00, T, T);
INSERT INTO Rooms Values(5, 40, 3, 2, 999.00, T, T);
INSERT INTO Rooms Values(6, 120, 4, 2, 150.00, T, T);
INSERT INTO Rooms Values(7, 120, 4, 1, 120.00, T, T);
INSERT INTO Rooms Values(8, 80, 5, 1, 100.00, T, F);
INSERT INTO Rooms Values(9, 90, 6, 2, 140.00, T, F);




INSERT INTO Reservations Values(1, 1, 'A.B.Holmes', 02 / 03 / 2017, 2, 1);
INSERT INTO Reservations Values(2, 3, 'SIGX-conference', 02 / 03 / 2017, 5, 80);
INSERT INTO Reservations Values(3, 4, 'King of Z', 02 / 05 / 2017, 7, 1);
INSERT INTO Reservations Values(4, 3, 'Kings Service', 02 / 05 / 2002, 7, 3);
INSERT INTO Reservations Values(5, 5, 'D.D. A', 02 / 04 / 2017, 3, 1);
INSERT INTO Reservations Values(6, 'D.D. B', 02 / 04 / 2017, 1, 1);
INSERT INTO Reservations Values(7, 'D.D. C', 02 / 03 / 2017, 1, 1);
INSERT INTO Reservations Values(8, 'D.D. D', 02 / 04 / 2017, 1, 1);
INSERT INTO Reservations Values(9, 'D.D. E', 02 / 05 / 2017, 1, 1);
INSERT INTO Reservations Values(10, 'D.D. F', 02 / 06 / 2017, 1, 1);