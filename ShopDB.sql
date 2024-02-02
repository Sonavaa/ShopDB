Create Database ShopDB

Use ShopDB

Create Table Category(
Id int identity primary key,
[Name] nvarchar(50),
IsDeleted bit not null,
CreatedAt nvarchar(50) not null,
UpdatedAt nvarchar(50)
)

Alter table Category alter column [Name] nvarchar(50) not null

Create table Product(
Id int identity primary key,
[Name] nvarchar(140) not null,
Price int not null,
CategoryId int Foreign key references Category(Id),
IsDeleted bit not null,
CreatedAt nvarchar(50) not null,
UpdatedAt nvarchar(50) 
)

Insert Into Category
Values
('Sweaters and Cardigans',0,'28-01-2024 17:06','30-01-2024 13:27'),
('Jeans',0,'28-01-2024 17:20','30-01-2024 14:00'),
('Dresses',0,'28-01-2024 17:36','30-01-2024 16:08'),
('Shoes',0,'28-01-2024 17:49','02-02-2024 18:42')

Insert Into Product
Values 
('Polo collar cardigan with buttons and gathered side',55,1,0,'04-02-2024 12:04','05-02-2024 13:22'),
('Ribbed boat neck sweater',49,1,0,'04-02-2024 12:21','05-02-2024 13:30'),
('Faded-effect skater fit jeans',59,2,0,'04-02-2024 12:34','05-02-2024 13:42'),
('Comfort mom jeans',62,2,0,'04-02-2024 12:45','05-02-2024 14:07'),
('Long bandeau rib dress',79,3,0,'04-02-2024 12:58','05-02-2024 14:26'),
('Mini dress with knot',85,3,0,'04-02-2024 13:17','06-02-2024 10:20'),
('Mary Jane slingback block heel shoes',87,4,0,'04-02-2024 13:33','06-02-2024 10:43'),
('Vinyl heeled ankle strap shoes',85,4,0,'04-02-2024 13:52','06-02-2024 11:24')


SELECT GETDATE();

EXEC sp_rename 'Category', 'Categories';
EXEC sp_rename 'Product', 'Products';

select * from categories
DELETE FROM Categories WHERE Id=8
