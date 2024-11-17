select * from UserDetails;

    delete from UserDetails;

select * from UserVaccineDetails;

    delete from UserVaccineDetails;

select * from BookingDetails;

    delete from BookingDetails;

select * from AspNetUserRoles;

    delete from AspNetUserRoles;

select * from AspNetRoles;

    delete from AspNetRoles;

select * from AspNetUsers;

    delete from AspNetUsers;
    
select * from AspNetUserTokens;

INSERT INTO HospitalDetailsModel (HospitalId, HospitalName, HospitalAvailableSlots) VALUES ('H001', 'City Hospital', 25);
INSERT INTO HospitalDetailsModel (HospitalId, HospitalName, HospitalAvailableSlots) VALUES ('H002', 'Green Valley Clinic', 15);
INSERT INTO HospitalDetailsModel (HospitalId, HospitalName, HospitalAvailableSlots) VALUES ('H003', 'Sunrise Medical Center', 30);
INSERT INTO HospitalDetailsModel (HospitalId, HospitalName, HospitalAvailableSlots) VALUES ('H004', 'Lakeside Hospital', 20);
INSERT INTO HospitalDetailsModel (HospitalId, HospitalName, HospitalAvailableSlots) VALUES ('H005', 'Mountain View Hospital', 10);

INSERT INTO UserDetails (UserId, UserPassword, UserName, UserUid, UserBirthDate, UserGender, UserPhone, UserRole) VALUES
('user1', 'password123', 'Alice Johnson', 'UID001', '1990-01-15', 'Female', '123-456-7890', 'Admin'),
('user2', 'password456', 'Bob Smith', 'UID002', '1985-05-20', 'Male', '234-567-8901', 'User'),
('user3', 'password789', 'Charlie Brown', 'UID003', '1992-07-30', 'Male', '345-678-9012', 'User'),
('user4', 'password321', 'Diana Prince', 'UID004', '1988-11-25', 'Female', '456-789-0123', 'User'),
('user5', 'password654', 'Eve Adams', 'UID005', '1995-03-10', 'Female', '567-890-1234', 'User');

-- {
--     "UserId": "user6",
--     "UserPassword": "Abc!123",
--     "UserName": "Jeff Clinton",
--     "UserUid": "UID015",
--     "UserBirthDate": "1999-09-10",
--     "UserGender": "Male",
--     "UserPhone": "777-891-1434",
--     "UserRole": "User"
-- }


INSERT INTO UserVaccineDetails (UserVaccinationId, UserVaccinationStatus, BookingId, UserId) VALUES
('VACC001', 'Completed', 'BOOK001', 'user1'),
('VACC002', 'Pending', 'BOOK002', 'user2'),
('VACC003', 'Completed', 'BOOK003', 'user3'),
('VACC004', 'Pending', 'BOOK004', 'user4'),
('VACC005', 'Completed', 'BOOK005', 'user5');


INSERT INTO BookingDetails (BookingId, Dose1Date, D1HospitalName, D1SlotNumber, Dose2Date, D2HospitalName, D2SlotNumber, UserVaccinationId) VALUES
('BOOK001', '2023-01-10', 'City Hospital', 'Slot1', '2023-02-10', 'City Hospital', 'Slot2', 'VACC001'),
('BOOK002', '2023-03-15', 'County Hospital', 'Slot3', '2023-04-15', 'County Hospital', 'Slot4', 'VACC002'),
('BOOK003', '2023-05-20', 'General Hospital', 'Slot5', '2023-06-20', 'General Hospital', 'Slot6', 'VACC003'),
('BOOK004', '2023-07-25', 'Community Hospital', 'Slot7', '2023-08-25', 'Community Hospital', 'Slot8', 'VACC004'),
('BOOK005', '2023-09-30', 'Regional Hospital', 'Slot9', '2023-10-30', 'Regional Hospital', 'Slot10', 'VACC005');