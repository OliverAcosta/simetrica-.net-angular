create table UserTodos(
Id INTEGER GENERATED ALWAYS AS IDENTITY,
UserId INTEGER,
Task VARCHAR2(200), 
Description varchar2(400),
IsBool number(1)
);