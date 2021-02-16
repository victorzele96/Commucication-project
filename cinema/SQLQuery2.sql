USE cinemaDB
GO


--DROP TABLE tblAdmin;
--DROP TABLE tblUser;
--DROP TABLE tblOrder;
--DROP TABLE tblOrderView;
--DROP TABLE tblProduct;


CREATE TABLE tblAdmin(
	AdminID nchar(4),
	AdminName nvarchar(20),
	AdminPassword nvarchar(12)
	PRIMARY KEY(AdminID)
);

CREATE TABLE tblUser(
	FirstName nvarchar(20),
	LastName nvarchar(20),
	Username nvarchar(40),
	Email nvarchar(50),
	UserNumber nvarchar(10),
	UserPassword nvarchar(12)
	PRIMARY KEY(Username)
);

CREATE TABLE tblOrder(
	OrderId int not null identity ,
	Hall int,
	Seat nvarchar(100),
	MovieName nvarchar(30),
	MovieDatePlay DateTime2,
	FirstName nvarchar(20),
	LastName nvarchar(20),
	Price int,

	PRIMARY KEY(Hall, Seat, MovieDatePlay)
);

CREATE TABLE tblOrderView(
	OrderId nvarchar(20),




	PRIMARY KEY(OrderId)
);

CREATE TABLE tblProduct(
	ProductId nvarchar(50),
	MovieName nvarchar(30),
	MovieDescription nvarchar(300),
	MovieGenre nvarchar(40),
	MovieAgeLimit int, 
	RelaseYear int,
	MovieImg nvarchar(100),
	MoviePrice int,
	HallNum int,
	SeatsNum int,
	MovieDayPlay DateTime2,
	PRIMARY KEY(ProductId)
);

SET DateFormat DMY

INSERT INTO tblProduct Values('1', 'Godzilla', 'King of the monsters', 'action monsters fantasy',10 , 2019, 's-1.jpg', 45, 1, 120, '24-01-21 18:30');
INSERT INTO tblProduct Values('2', 'Star Wars', 'The rise of skywalker', 'action fantasy Space-Opera',10 , 2019, 's-2.jpg', 50, 2, 120, '24-01-21 18:30');
INSERT INTO tblProduct Values('3', 'Beauty and the beast', 'American musical romantic fantasy', 'fantasy',8 , 2017, 's-3.jpg', 50, 3, 120, '24-01-21 18:30');
INSERT INTO tblProduct Values('4', 'Ready player one', 'When the creator of a virtual reality called the OASIS dies, he makes a posthumous challenge to all OASIS users to find his Easter Egg, which will give the finder his fortune and control of his world.', 'science-fiction action-adventure',13 , 2018, 's-4.jpg', 55, 4, 120, '24-01-21 18:30');
INSERT INTO tblProduct Values('5', 'Mad max fury road', 'Australian post-apocalyptic action film', 'action',15 , 2015, 's-5.jpg', 60, 1, 120, '24-01-21 21:30');
INSERT INTO tblProduct Values('6', 'Kin', 'Kin doesnt seem to know what it wants to be', 'science-fiction action', 15, 2018, 'm-1.jpg', 65, 2, 120, '24-01-21 21:30');
INSERT INTO tblProduct Values('7', 'Peninsuela', 'It is a standalone sequel to the 2016 film Train to Busan and follows a soldier', 'action', 14, 2020, 'm-2.jpg', 70, 3, 120, '24-01-21 21:30');
INSERT INTO tblProduct Values('8', 'Inception', 'The film stars Leonardo DiCaprio as a professional thief', 'action', 8, 2010, 'm-3.jpg', 60, 4, 120, '24-01-21 21:30');
INSERT INTO tblProduct Values('9', 'Iron Man-3', 'Marvels "Iron Man 3" pits brash-but-brilliant industrialist Tony Stark/Iron Man', 'action', 13, 2013, 'm-4.jpg', 65, 1, 120, '25-01-21 18:30');
INSERT INTO tblProduct Values('10', 'Venom', 'Venom is a 2018 American superhero film based on the Marvel Comics character of the same name', 'action', 13, 2018, 'm-5.jpg', 70, 2, 120, '25-01-21 18:30');
INSERT INTO tblProduct Values('11', 'Aquaman', 'It stars Jason Momoa as Aquaman', 'action', 13, 2018, 'm-6.jpg', 75, 3, 120, '25-01-21 18:30');
INSERT INTO tblProduct Values('12', 'Jungle Cruise', 'Set during the early 20th century, a riverboat captain named Frank takes a scientist and her brother on a mission into a jungle', 'action', 18, 2021, 'm-7.jpeg', 70, 4, 120, '25-01-21 18:30');
INSERT INTO tblProduct Values('13', 'Into darkness', 'With a personal score to settle, Capt. James T. Kirk (Chris Pine) leads his people', 'science-fiction action', 13, 2013, 'l-1.jpg', 60, 1, 120, '25-01-21 21:30');
INSERT INTO tblProduct Values('14', 'Fantastic beasts', 'While a strange dark force terrorises New York City, British magizoologist Newt Scamander enlists a non-magical Jacobs help to round up some escaped magical creatures', 'fantasy', 12, 2016, 'l-2.jpg', 60, 2, 120, '25-01-21 21:30');
INSERT INTO tblProduct Values('15', 'Les croods', 'A cave family called the Croods survives a natural disaster, due to the overprotective nature of their stubborn patriarch Grug', 'animated', 5, 2013, 'l-3.jpg', 65, 3, 120, '25-01-21 21:30');
INSERT INTO tblProduct Values('16', 'Toy Story 3', 'Woody, Buzz Lightyear, and Andys other remaining toys accidentally being donated to a day care center', 'animated', 10, 2010, 'l-4.jpg', 65, 4, 120, '25-01-21 21:30');
INSERT INTO tblProduct Values('17', 'Coco', '"Coco" is the sprightly story of a young boy who wants to be a musician and somehow finds himself communing with talking skeletons in the land of the dead', 'animated-fantasy', 10, 2017, 'l-5.jpg', 60, 1, 120, '26-01-21 18:30');
INSERT INTO tblProduct Values('18', 'Star Wars', 'The rise of skywalker', 'action fantasy Space-Opera', 10, 2019, 'l-6.jpg', 55, 2, 120, '26-01-21 18:30');
INSERT INTO tblProduct Values('19', 'Rogue one', 'Jyns father is forcibly taken by the Galactic Empire to help them complete the Death Star. When she grows up', 'space-opera', 13, 2016, 'l-7.jpg', 65, 3, 120, '26-01-21 18:30');
INSERT INTO tblProduct Values('20', 'Venom', 'Venom is a 2018 American superhero film based on the Marvel Comics character of the same name', 'action', 13, 2018, 'l-8.jpg', 70, 4, 120, '26-01-21 18:30');

INSERT INTO [cinemaDB].[dbo].[webpages_Roles] Values('Admin');
INSERT INTO [cinemaDB].[dbo].[webpages_UsersInRoles] Values(1, 1);

insert into tblOrder values(2, 'D4', 'Venom', '25-01-21 18:30', 'victor', 'torovsky', 70)
insert into tblOrder values(2, 'D4', 'Venom', '25-01-21 18:30', 'victor', 'torovsky', 70)

INSERT INTO tblAdmin values(1, 'victor', 2);

SELECT * FROM tblUser 
SELECT * FROM tblAdmin
SELECT * FROM tblOrder
SELECT * FROM tblOrderView
SELECT * FROM tblProduct


--INSERT INTO tblAdmin Values(2, 'victor', 2)