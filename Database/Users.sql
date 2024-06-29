

create table Users(
Id number GENERATED ALWAYS AS IDENTITY,
Username varchar2(100),
Firstname varchar2(400),
Lastname varchar2(400),
Email varchar2(100),
Password varchar2(100),
LastLogin DATE
);