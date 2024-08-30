API Documentation
Welcome to the API documentation for Restaurant Booking System. This README provides detailed 
information on the available API endpoints, including example requests and responses for various scenarios.
Table of Contents
1. Base URL
2. Customer API
o Get All Customers
o Create Customer
o Update Customer
o Delete Customer
3. Food Menu API
o Get Single Menu Item
o Get All Menu Items
o Create Menu Item
o Update Menu Item
o Delete Menu Item
4. Table API
o Get Single Table
o Get All Tables
o Create Table
o Update Table
o Delete Table
5. Booking API
o Get Single Booking
o Get All Bookings
o Create Booking
o Update Booking
o Delete Booking
Base URL
All API requests are made to the base URL:
https://localhost:7232
Customer API
Get All Customers
Endpoint: GET /api/Customer/GetAllCustomers
Description: Retrieve a list of all customers.
Request:
http
GET /api/Customer/GetAllCustomers
Response:
Success (200):
{
 "success": true,
 "data": [ 
 {
 "id": 2,
 "firstName": "azerbajan",
 "lasttName": "Girma",
 "email": "tensaeg@yahoo.com",
 "phone": "0764525651"
 },
 {
 "id": 3,
 "firstName": "ethiopia",
 "lasttName": "Girma",
 "email": "tensaeg@yahoo.com",
 "phone": "0764525651"
 }
 ]
}
Create Customer
Endpoint: POST /api/Customer/CreateCustomer
Description: Create a new customer.
Request:
http
POST 
/api/Customer/CreateCustomer?FirstName=yohannes&LasttName=girma&Email=tensaeg%40yahoo.com&Pho
ne=0764525651'
Response:
Success (200):
{
 "message": "Customer created successfully",
}
Update Customer
Endpoint: PUT /api/Customer/UpdateCustomer
Description: Update an existing customer.
Request:
http
PUT /api/Customer/UpdateCustomer?
Id=8&FirstName=mariza&LasttName=roberto&Email=mariza%40yahoo.com&Phone=111111111111
Response:
Success (200):
{
 "message": "Customer updated successfully"
}
Error (404):
{
 "message": " No Data Found" (if no data for the customer with the given -id)
}
Delete Customer
Endpoint: DELETE /api/Customer/DeleteCustomer
Description: Delete a customer by their ID.
Request:
http
DELETE /api/Customer/DeleteCustomer?id=12
Response:
Success (200):
{
 "message": "Entry deleted successfully"
}
Error (404):
{
 "message": " No Data Found" (if no data for the customer with the given -id)
}
Food Menu API
Get Single Menu Item
Endpoint: GET /api/FoodMenu/GetSingleMenu
Description: Retrieve a single food menu item by its ID.
Request:
http
GET /api/FoodMenu/GetSingleMenu?id=3
Response:
Success (200):
{
 "success": true,
 "data": {
"id": 3,
 "title": "spagettie",
 "price": 200,
 "isAvailable": true,
 "imageUrl": "https://europe.stripes.com/lifestyle/99177148_s.jpg/alternates/LANDSCAPE_910/europe70895"
 }
}
Error (404):
{
 "message": " No Data Found" (if no data for the Food Menu with the given -id)
}
Get All Menu Items
Endpoint: GET /api/FoodMenu/GetAllMenues
Description: Retrieve all food menu items.
Request:
http
GET /api/FoodMenu/GetAllMenues
Response:
Success (200):
{
 "success": true,
 "data": {
 "id": 3,
 "title": "spagettie",
 "price": 200,
 "isAvailable": true,
 "imageUrl": "https://europe.stripes.com/lifestyle/99177148_s.jpg/alternates/LANDSCAPE_910/europe70895"
 },
 "message": null
}
Error (404):
{
 "message": " No Data Found" (if no data for the Food Menu found In The DB)
}
Create Menu Item
Endpoint: POST /api/FoodMenu/CreateMenue
Description: Create a new food menu item.
Request:
http
POST 
/api/FoodMenu/CreateMenue?Title=enjera&price=500&IsAvailable=true&ImageUrl=https%3A%2F%2Flpcms-production.imgix.net%2F2020-
11%2FInjera.jpg%3Fauto%3Dformat%26fit%3Dcrop%26sharp%3D10%26vib%3D20%26ixlib%3Dreact8.6.4%26w%3D850%26q%3D20%26dpr%3D5
Response:
Success (200):
{
 "message": "Menu created successfully",
}
Error (400):
{
 "type": "https://tools.ietf.org/html/rfc9110#section-15.5.1",
 "title": "One or more validation errors occurred.",
 "status": 400,
 "errors": {
 "Title": [
 "The Title field is required."
 ]
 },
 "traceId": "00-6f593dafab3eadec83f1123970458e81-1b558cb0b009b6c1-00"
}
Update Menu Item
Endpoint: PUT /api/FoodMenu/UpdateMenu
Description: Update an existing food menu item.
Request:
http
PUT /api/FoodMenu/UpdateMenu?Id=3&Title=areke&price=455&IsAvailable=true
Response:
Success (200):
{
 "success": true,
 "message": "Menu updated successfully"
}
Error (404):
{
 "message": "No Data Found"
}
Delete Menu Item
Endpoint: DELETE /api/FoodMenu/DeleteMenu
Description: Delete a food menu item by its ID.
Request:
http
DELETE /api/FoodMenu/DeleteMenu?id=4
Response:
Success (200):
{
 "message": " Entry Deleted Succesfully"
}
Error (404):
{
"message": "No Data Found"
}
Table API
Get Single Table
Endpoint: GET /api/Table/GetSingleTable
Description: Retrieve a single table by its ID.
Request:
GET /api/Table/GetSingleTable?id=3
Response:
Success (200):
{
 "success": true,
 "data": {
 "id": 3,
 "tableNumber": 10,
 "numberOfSeats": 6,
 "isAvialable": false
 },
 "message": "Table Retreaved Successfully"
}
Error (404):
{
"message": "No Data Found"
}
Get All Tables
Endpoint: GET /api/Table/GetAllTables
Description: Retrieve all tables.
Request:
http
GET /api/Table/GetAllTables
Response:
Success (200):
{
 "success": true,
 "data": [
 {
 "id": 3,
 "tableNumber": 10,
 "numberOfSeats": 6,
 "isAvialable": false
 },
 {
 "id": 4,
 "tableNumber": 15,
 "numberOfSeats": 7,
 "isAvialable": false
 },
 {
 "id": 5,
 "tableNumber": 20,
 "numberOfSeats": 20,
 "isAvialable": false
 }
 ],
 "message": null
}
Error (404):
{
"message": "No Data Found"
}
Create Table
Endpoint: POST /api/Table/CreateTable
Description: Create a new table.
Request:
http
POST api/Table/CreateTable?TableNumber=33&NumberOfSeats=5&isAvialable=true
Response:
Success (200):
{
 "message": "Table created successfully",
}
Update Table
Endpoint: PUT /api/Table/UpdateTable
Description: Update an existing table.
Request:
http
PUT /api/Table/UpdateTable?Id=6&TableNumber=10&NumberOfSeats=6&isAvialable=true
Response:
Success (200):
Copy code
{
 "message": "Table updated successfully"
}
Error (400):
{
 "message": " Faild To Update Table" (Wrong Id )
}
Delete Table
Endpoint: DELETE /api/Table/DeleteTable
Description: Delete a table by its ID.
Request:
http
DELETE /api/Table/DeleteTable?id=6
Response:
Success (200):
{
 "message": " Entry Deleted Succesfully"
}
Error (400):
{
 "message": " Failed To Delete Entry"
}
Booking API
Get Single Booking
Endpoint: GET /api/Booking/GetSingleBooking
Description: Retrieve a single booking by its ID.
Request:
http
GET /api/Booking/GetSingleBooking?id=6
Response:
Success (200):
{
 "success": true,
 "data": {
 "id": 6,
 "bookingDate": "2024-08-20T21:52:16.23",
 "numberOfGuests": 4,
 "customerId": 2,
 "tablesId": 3,
 "foodMenuId": 0,
 "customer": {
 "id": 2,
 "firstName": "azerbajan",
 "lasttName": "Girma",
 "email": "tensaeg@yahoo.com",
 "phone": "0764525651"
 },
 "foodMenu": {
 "id": 3,
 "title": "areke",
 "price": 455,
 "isAvailable": true,
 "imageUrl": null
 },
 "tables": {
 "id": 3,
 "tableNumber": 10,
 "numberOfSeats": 6,
 "isAvialable": false
 }
 },
 "message": "Booking Retreved Sucessfully"
}
Error (404):
{
 "message": "No Data Found"
}
Get All Bookings
Endpoint: GET /api/Booking/GetAllBookings
Description: Retrieve a list of all bookings.
Request:
http
GET /api/Booking/GetAllBookings
Response:
Success (200):
[
 {
 "id": 3,
 "bookingDate": "2024-08-25T14:30:00",
 "numberOfGuests": 5,
 "customerId": 2,
 "tablesId": 3,
 "foodMenuId": 3,
 "customer": {
 "id": 2,
 "firstName": "azerbajan",
 "lasttName": "Girma",
 "email": "tensaeg@yahoo.com",
 "phone": "0764525651"
 },
 "foodMenu": {
 "id": 3,
 "title": "areke",
 "price": 0,
 "isAvailable": true,
 "imageUrl": null
 },
 "tables": {
 "id": 3,
 "tableNumber": 10,
 "numberOfSeats": 6,
 "isAvialable": false
 }
 },
 {
 "id": 4,
 "bookingDate": "2024-08-25T14:30:00",
 "numberOfGuests": 6,
 "customerId": 10,
 "tablesId": 3,
 "foodMenuId": 3,
 "customer": {
 "id": 10,
 "firstName": "mamadu",
 "lasttName": "selamawit",
 "email": "selamawit10@yahoo.com",
 "phone": "5465456464"
 },
 "foodMenu": {
 "id": 3,
 "title": "areke",
 "price": 0,
 "isAvailable": true,
 "imageUrl": null
 },
 "tables": {
 "id": 3,
 "tableNumber": 10,
 "numberOfSeats": 6,
 "isAvialable": false
 }
 }
]
Error (404):
{
 "message": "No Data Found"
}
Create Booking
Endpoint: POST /api/Booking/CreateBooking
Description: Create a new booking.
Request:
http
POST /api/Booking/CreateBooking?BookingDate=2024-08-
25%2014%3A30%3A00.0000000&NumberOfGuests=4&CustomerId=2&TablesId=4&FoodMenuId=3
Response:
Success (200):
{
 "message": "Booking created successfully",
}
Error (400):
/api/Booking/CreateBooking?BookingDate=2024-08-
25%2014%3A30%3A00.0000000&NumberOfGuests=9&CustomerId=2&TablesId=3&FoodMenuId=4
{
 "message": " Table is Already Booked,Please choose another Table"
}
Error (400):
/api/Booking/CreateBooking?BookingDate=2024-08-
25%2014%3A30%3A00.0000000&NumberOfGuests=9&CustomerId=2&TablesId=99&FoodMenuId=4
{
 "message": " Table is Already Booked,Please choose another Table"
}
Error (400):
/api/Booking/CreateBooking?BookingDate=2024-08-
25%2014%3A30%3A00.0000000&NumberOfGuests=9&CustomerId=2&TablesId=4&FoodMenuId=4
{
 "message": " Table Can Not Accomodate the Number of Guests"
}
Update Booking
Endpoint: PUT /api/Booking/UpdateBooking
Description: Update an existing booking.
Request:
http
PUT /api/Booking/UpdateBooking?Id=11&BookingDate=2024-08-
25%2014%3A30%3A00.0000000&NumberOfGuests=6&CustomerId=8&TablesId=3&FoodMenuId=3
Response:
Success (200):
{
 "message": "Booking updated successfully"
}
Error (404):
{
 "message": "No Data Found"
(if Id not found all parameters id will be validated and response will be the same)
}
Delete Booking
Endpoint: DELETE /api/Booking/DeleteBooking
Description: Delete a booking by its ID.
Request:
http
DELETE /api/Booking/DeleteBooking?id=103
Response:
Success (200):
{
 "success": true,
 "message": " Entry Deleted Succesfully"
}
Error (404):
{
 "message": " No Data Found"
}
