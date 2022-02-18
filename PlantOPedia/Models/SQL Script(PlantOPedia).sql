INSERT INTO Roles (RoleId, RoleType, IsDeleted) 
		VALUES (Newid(),0, 'False'),
		(Newid(),1, 'False');

INSERT INTO Categories (CategoryId, CategoryType, IsDeleted) 
		VALUES (Newid(),0, 'False'),
		(Newid(),1, 'False'),
		(Newid(),2, 'False');

INSERT INTO ProductTypes(ProductTypeId, ProductSubType, CategoryId, IsDeleted) 
		VALUES (Newid(), 0, (SELECT CategoryId FROM Categories WHERE CategoryType = 0), 'False'),
		 (Newid(), 1, (SELECT CategoryId FROM Categories WHERE CategoryType = 0), 'False'),
		 (Newid(), 2, (SELECT CategoryId FROM Categories WHERE CategoryType = 0), 'False'),
		 (Newid(), 3, (SELECT CategoryId FROM Categories WHERE CategoryType = 0), 'False'),
		 (Newid(), 4, (SELECT CategoryId FROM Categories WHERE CategoryType = 2), 'False'),
		 (Newid(), 5, (SELECT CategoryId FROM Categories WHERE CategoryType = 2), 'False'),
		 (Newid(), 6, (SELECT CategoryId FROM Categories WHERE CategoryType = 1), 'False'),
		 (Newid(), 7, (SELECT CategoryId FROM Categories WHERE CategoryType = 1), 'False'),
		 (Newid(), 8, (SELECT CategoryId FROM Categories WHERE CategoryType = 1), 'False'),
		 (Newid(), 9, (SELECT CategoryId FROM Categories WHERE CategoryType = 1), 'False'),
		 (Newid(), 10, (SELECT CategoryId FROM Categories WHERE CategoryType = 1), 'False');