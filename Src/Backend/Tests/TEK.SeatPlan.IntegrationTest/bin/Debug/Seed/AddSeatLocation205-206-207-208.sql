DECLARE @UserCreated VARCHAR(10) = 'seed'

UPDATE [dbo].[Seat] SET [Col] = 20, [Row] = 1793  WHERE [Number] = 201
UPDATE [dbo].[Seat] SET [Col] = 87, [Row] = 1793 WHERE [Number] = 202
UPDATE [dbo].[Seat] SET [Col] = 154, [Row] = 1793 WHERE [Number] = 204
UPDATE [dbo].[Seat] SET [Col] = 221, [Row] = 1793  WHERE [Number] = 203

INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 205, @UserCreated, 33, 288, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 206, @UserCreated, 143, 288, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 207, @UserCreated, 33, 221, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 208, @UserCreated, 143, 221, null);


