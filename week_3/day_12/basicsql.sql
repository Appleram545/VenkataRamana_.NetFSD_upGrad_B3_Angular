CREATE DATABASE EventDb;

USE EventDb;


-- problem - 1

CREATE TABLE UserInfo
(
    EmailId VARCHAR(100) PRIMARY KEY,

    UserName VARCHAR(50) NOT NULL,

    Role VARCHAR(20) NOT NULL,

    Password VARCHAR(20) NOT NULL,

    CONSTRAINT Check_UserName_Length 
        CHECK (LEN(UserName) BETWEEN 1 AND 50),

    CONSTRAINT Check_Role 
        CHECK (Role IN ('Admin', 'Participant')),

    CONSTRAINT Check_Pswd_Length 
        CHECK (LEN(Password) BETWEEN 6 AND 20)
);

-- PROBLEM - 2

CREATE TABLE EventDetails
(
    EventId INT PRIMARY KEY,

    EventName VARCHAR(50) NOT NULL,

    EventCategory VARCHAR(50) NOT NULL,

    EventDate DATE NOT NULL,

    Description VARCHAR(255),

    Status VARCHAR(10) NOT NULL,

    CONSTRAINT chk_eventname_length
        CHECK (LEN(EventName) BETWEEN 1 AND 50),

    CONSTRAINT chk_eventcategory_length
        CHECK (LEN(EventCategory) BETWEEN 1 AND 50),

    CONSTRAINT chk_status
        CHECK (Status IN ('Active', 'In-Active'))
);

-- PROBLEM - 3

CREATE TABLE SpeakersDetails (
    SpeakerId INT PRIMARY KEY,

    SpeakerName VARCHAR(50) NOT NULL,

    CONSTRAINT chk_speakername_length
        CHECK (LEN(SpeakerName) BETWEEN 1 AND 50)
);

-- PROBLEM - 4

CREATE TABLE SessionInfo (
    SessionId INT PRIMARY KEY,

    EventId INT NOT NULL,

    SessionTitle VARCHAR(50) NOT NULL,

    SpeakerId INT NOT NULL,

    Description VARCHAR(255),

    SessionStart DATETIME NOT NULL,

    SessionEnd DATETIME NOT NULL,

    SessionUrl VARCHAR(255),

    CONSTRAINT chk_sessiontitle_length
        CHECK (LEN(SessionTitle) BETWEEN 1 AND 50),

    CONSTRAINT fk_session_event
        FOREIGN KEY (EventId)
        REFERENCES EventDetails(EventId),

    CONSTRAINT fk_session_speaker
        FOREIGN KEY (SpeakerId)
        REFERENCES SpeakersDetails(SpeakerId)
);

-- PROBLEM - 5

CREATE TABLE ParticipantEventDetails (
    Id INT PRIMARY KEY,

    ParticipantEmailId VARCHAR(100) NOT NULL,

    EventId INT NOT NULL,

    SessionId INT NOT NULL,

    IsAttended BIT NOT NULL,

    CONSTRAINT chk_attendance
        CHECK (IsAttended IN (0,1)),

    CONSTRAINT fk_participant_user
        FOREIGN KEY (ParticipantEmailId)
        REFERENCES UserInfo(EmailId),

    CONSTRAINT fk_participant_event
        FOREIGN KEY (EventId)
        REFERENCES EventDetails(EventId),

    CONSTRAINT fk_participant_session
        FOREIGN KEY (SessionId)
        REFERENCES SessionInfo(SessionId)
);