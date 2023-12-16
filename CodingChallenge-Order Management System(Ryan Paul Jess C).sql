--CREATING DATABASE
create database  Order_Management_System

--CREATING TABLE:
create table Product(
productId int identity(101,1) primary key,
productName varchar(80),
description varchar(max),
price decimal(8,2) check (price > 0),
quantityInStock int,
type varchar(40) check (type IN ('Electronics', 'Clothing'))
)

create table Users(
userId int identity(1,1) primary key,
username varchar(80),
password varchar(80),
role varchar(40) check (role IN ('Admin', 'User'))
)

create table Orders(
orderId int identity(1001,1) primary key,
userId int,
productId int
constraint Orders_Users foreign key(userId) references Users(userId) on delete cascade,
constraint Orders_Product foreign key(productId) references Product(productId) on delete cascade,
)

alter table Product
add constraint CK_price
check(price > 0)

alter table Product
add constraint CK_quantityInStock
check(quantityInStock > 0)

--INSERTING VALUES:
insert into Product
values
('Cotton Saree','Kanchipuram Type',1400,100,'Clothing'),
('Iphone 8','New Apple Product',80000,70,'Electronics'),
('Sony Camera','Sony New Model',1400,100,'Electronics'),
('Silk Saree','Kanchipuram Type',3400,120,'Clothing')

insert into Users
values
('Hema','dadh45!','User'),
('Nivetha','aadh45!','User'),
('Arun','cadh45!','User'),
('Ryan','fadh45!','Admin')

insert into Orders
values
(1,101),
(2,105),
(3,102),
(3,103),
(1,105)


insert into Orders values (1,101)
insert into Product values ('Cotton Saree','Kanchipuram Type',1400,100,'Clothing')
insert into Users values ('Hema','dadh45!','User')

select Product.productId,productName,description,price,quantityInStock,type from Orders inner join Users on Orders.userId = Users.userId inner join Product on Orders.productId = Product.productId where Orders.userId = 1