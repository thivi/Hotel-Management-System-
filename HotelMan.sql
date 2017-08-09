create table Customers(
	CustomerID int IDENTITY(1,1),
	FirstName varchar(255),
	LastName varchar(255),
	ContactNo varchar(255),
	NICno varchar(255) UNIQUE,
	DOB date,
	RegDate date,
	uname varchar(255) UNIQUE,
	pwd varchar(255)

	PRIMARY KEY(CustomerID),
);

create table Rooms(
	RoomID int IDENTITY(1,1),
	RoomType varchar(255),
	Price float,
	RoomNo varchar(255)

	PRIMARY KEY(RoomID)
)

create table Halls(
	HallID int IDENTITY(1,1),
	Capacity int,
	HallNo varchar(255),
	PriceMorn float,
	PriceEven float,
	PriceNight float,
	PricePerPerson float

	PRIMARY KEY(HallID)
)

create table MealPackage(
	MealID int IDENTITY(1,1),
	UnitPrice float,
	MealName varchar(255),
	MealDescription varchar(255)

	PRIMARY KEY(MealID)
)

create table FunctionPack(
	FuncID int IDENTITY (1,1),
	FuncType varchar(255),
	FunctionName varchar(255),
	Price float

	PRIMARY KEY (FuncID),
	CONSTRAINT FN check (FunctionName='Birthday' OR FunctionName='Meeting' OR FunctionName='Wedding' OR FunctionName='Reception' OR FunctionName='Other')
)

create table RoomBooking(
	BookingID int IDENTITY(1,1),
	BookFrom date,
	BookTo date, 
	CustID int,
	NoPersons int,
	BookDate date
	RoomID int

	PRIMARY KEY(BookingID)
	FOREIGN KEY (CustID) references Customers (CustomerID)
	FOREIGN KEY (RoomID) references Rooms(RoomID)
)


create table HallBooking(
	HallBookingID int IDENTITY(1,1),
	HallID int,
	BookTime varchar(255),
	BookDate date,
	FunctionPack int,
	MealPackID int,
	NoOfAtendees int,
	CustID int

	PRIMARY KEY (HallBookingID),
	FOREIGN KEY (HallID) REFERENCES Halls(HallID),
	FOREIGN KEY (FunctionPack) References FunctionPack(FuncID),
	FOREIGN KEY (CustID) REFERENCES Customers (CustomerID),
	FOREIGN KEY (MealPackID) REFERENCES MealPackage (MealID),
	CONSTRAINT BT check (BookTime='Morning' OR BookTime='Evening' OR BookTime='Night') 

)



create table AdvanceBill(
	BillID int IDENTITY(1,1),
	BillDate date,
	CustID int,
	TotalAmount float,
	AdvanceAmount float

	PRIMARY KEY (BillID),
	FOREIGN KEY (CustID) REFERENCES Customers(CustomerID)
)
create table AdvanceBillRooms(
	ABillRoomID int IDENTITY(1,1),
	BillID int,
	RoomBookingID int

	PRIMARY KEY(ABillRoomID),
	FOREIGN KEY (BillID) REFERENCES AdvanceBill(BillID),
	FOREIGN KEY (RoomBookingID) REFERENCES RoomBooking(BookingID)
)

create table AdvanceBillHalls(
	ABillHallID int IDENTITY(1,1),
	BillID int,
	HallBookingID int

	PRIMARY KEY(ABillHallID),
	FOREIGN KEY (BillID) REFERENCES AdvanceBill(BillID),
	FOREIGN KEY (HallBookingID) REFERENCES HallBooking(HallBookingID)
)



insert into Rooms values('Luxury', 20000, 'L002')
insert into Rooms values('Luxury', 20000, 'L003')
insert into Rooms values('Luxury', 20000, 'L004')
insert into Rooms values('Luxury', 20000, 'L005')
insert into Rooms values('Luxury', 20000, 'L006')
insert into Rooms values('Luxury', 20000, 'L007')
insert into Rooms values('Luxury', 20000, 'L008')
insert into Rooms values('Luxury', 20000, 'L009')
insert into Rooms values('Luxury', 20000, 'L010')
insert into Rooms values('Luxury', 20000, 'L011')
insert into Rooms values('Luxury', 20000, 'L012')
insert into Rooms values('Luxury', 20000, 'L013')
insert into Rooms values('Luxury', 20000, 'L014')
insert into Rooms values('Luxury', 20000, 'L015')
insert into Rooms values('Luxury', 20000, 'L016')
insert into Rooms values('Luxury', 20000, 'L017')
insert into Rooms values('Luxury', 20000, 'L018')
insert into Rooms values('Luxury', 20000, 'L019')
insert into Rooms values('Luxury', 20000, 'L020')
insert into Rooms values('Luxury', 20000, 'L001')

insert into Rooms values('Semi-Luxury', 20000, 'SL002')
insert into Rooms values('Semi-Luxury', 20000, 'SL003')
insert into Rooms values('Semi-Luxury', 20000, 'SL004')
insert into Rooms values('Semi-Luxury', 20000, 'SL005')
insert into Rooms values('Semi-Luxury', 20000, 'SL006')
insert into Rooms values('Semi-Luxury', 20000, 'SL007')
insert into Rooms values('Semi-Luxury', 20000, 'SL008')
insert into Rooms values('Semi-Luxury', 20000, 'SL009')
insert into Rooms values('Semi-Luxury', 20000, 'SL010')
insert into Rooms values('Semi-Luxury', 20000, 'SL011')
insert into Rooms values('Semi-Luxury', 20000, 'SL012')
insert into Rooms values('Semi-Luxury', 20000, 'SL013')
insert into Rooms values('Semi-Luxury', 20000, 'SL014')
insert into Rooms values('Semi-Luxury', 20000, 'SL015')
insert into Rooms values('Semi-Luxury', 20000, 'SL016')
insert into Rooms values('Semi-Luxury', 20000, 'SL017')
insert into Rooms values('Semi-Luxury', 20000, 'SL018')
insert into Rooms values('Semi-Luxury', 20000, 'SL019')
insert into Rooms values('Semi-Luxury', 20000, 'SL020')
insert into Rooms values('Semi-Luxury', 20000, 'SL001')

insert into Rooms values('Ordinary', 20000, 'O002')
insert into Rooms values('Ordinary', 20000, 'O003')
insert into Rooms values('Ordinary', 20000, 'O004')
insert into Rooms values('Ordinary', 20000, 'O005')
insert into Rooms values('Ordinary', 20000, 'O006')
insert into Rooms values('Ordinary', 20000, 'O007')
insert into Rooms values('Ordinary', 20000, 'O008')
insert into Rooms values('Ordinary', 20000, 'O009')
insert into Rooms values('Ordinary', 20000, 'O010')
insert into Rooms values('Ordinary', 20000, 'O011')
insert into Rooms values('Ordinary', 20000, 'O012')
insert into Rooms values('Ordinary', 20000, 'O013')
insert into Rooms values('Ordinary', 20000, 'O014')
insert into Rooms values('Ordinary', 20000, 'O015')
insert into Rooms values('Ordinary', 20000, 'O016')
insert into Rooms values('Ordinary', 20000, 'O017')
insert into Rooms values('Ordinary', 20000, 'O018')
insert into Rooms values('Ordinary', 20000, 'O019')
insert into Rooms values('Ordinary', 20000, 'O020')
insert into Rooms values('Ordinary', 20000, 'O001')



insert into Halls values(2000,'HA001', 25000,20000,30000,100)
insert into Halls values(3000,'HA002', 20000,10000,40000,200)
insert into Halls values(500,'HA003', 10000,5000,15000,50)
insert into Halls values(300,'HA004', 5000,4000,10000,50)



insert into FunctionPack values('Birthday', 'Birthday', 25000)
insert into FunctionPack values('Wedding', 'Wedding', 100000)
insert into FunctionPack values('Reception', 'Reception', 50000)
insert into FunctionPack values('Meeting', 'Meeting', 75000)
insert into FunctionPack values ('Other', 'Other', 15000)



insert into MealPackage values(200, 'Short-eats','Rolls, Snacks,etc.')
insert into MealPackage values(500, 'Light Meals','Burgher, Submarine etc.')
insert into MealPackage values(800, 'Heavy Meals','Fried Rice, Buriyani etc.')
insert into MealPackage values(1500, 'Exotic Traditional ','Sri Lankan Cusine')







