--INSERT INTO [User] (Username, Name,Lastname) VALUES ('dmolinag', 'Daniel', 'Molina')

--SELECT * FROM [User]

--INSERT INTO [Role] VALUES ('Configurator', 'Devices configurator')

--SELECT * FROM Role

--INSERT INTO [UserRole] VALUES (1, 1)

--SELECT * FROM UserRole

--SELECT [User].Username, [User].Name, [User].Lastname, Role.Role, Role.RoleDescription FROM [User]
--INNER JOIN UserRole ON [User].UserID = UserRole.UserRoleID
--INNER JOIN Role ON Role.RoleID = UserRole.UserRoleID





SELECT Room.RoomName, Device.Device, Unit.Unit, Topic.TopicName, Device.TimeOn FROM Room
INNER JOIN RoomDevice ON Room.RoomID = RoomDevice.RoomID
INNER JOIN Device ON RoomDevice.DeviceID = Device.DeviceID
Full outER JOIN Unit ON Device.UnitID = Unit.UnitID
INNER JOIN DeviceTopic ON Device.DeviceID = DeviceTopic.DeviceID
INNER JOIN Topic ON DeviceTopic.TopicID = Topic.TopicID