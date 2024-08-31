# API Documentation for Restaurant Booking System

Welcome to the API documentation for the Restaurant Booking System. This document provides detailed information on the available API endpoints, including example requests and responses for various scenarios.

## Table of Contents

1. [Base URL](#base-url)
2. [Customer API](#customer-api)
   - [Get All Customers](#get-all-customers)
   - [Create Customer](#create-customer)
   - [Update Customer](#update-customer)
   - [Delete Customer](#delete-customer)
3. [Food Menu API](#food-menu-api)
   - [Get Single Menu Item](#get-single-menu-item)
   - [Get All Menu Items](#get-all-menu-items)
   - [Create Menu Item](#create-menu-item)
   - [Update Menu Item](#update-menu-item)
   - [Delete Menu Item](#delete-menu-item)
4. [Table API](#table-api)
   - [Get Single Table](#get-single-table)
   - [Get All Tables](#get-all-tables)
   - [Create Table](#create-table)
   - [Update Table](#update-table)
   - [Delete Table](#delete-table)
5. [Booking API](#booking-api)
   - [Get Single Booking](#get-single-booking)
   - [Get All Bookings](#get-all-bookings)
   - [Create Booking](#create-booking)
   - [Update Booking](#update-booking)
   - [Delete Booking](#delete-booking)

## Base URL

All API requests are made to the base URL:

https://localhost:7232

markdown
Copy code

## Customer API

### Get All Customers

- **Endpoint:** `GET /api/Customer/GetAllCustomers`
- **Description:** Retrieve a list of all customers.

**Request:**
GET /api/Customer/GetAllCustomers

sql
Copy code

**Response:**

- **Success (200):**
    ```json
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
    ```

### Create Customer

- **Endpoint:** `POST /api/Customer/CreateCustomer`
- **Description:** Create a new customer.

**Request:**
POST /api/Customer/CreateCustomer?FirstName=yohannes&LasttName=girma&Email=tensaeg%40yahoo.com&Phone=0764525651

markdown
Copy code

**Response:**

- **Success (200):**
    ```json
    {
      "message": "Customer created successfully"
    }
    ```

### Update Customer

- **Endpoint:** `PUT /api/Customer/UpdateCustomer`
- **Description:** Update an existing customer.

**Request:**
PUT /api/Customer/UpdateCustomer?Id=8&FirstName=mariza&LasttName=roberto&Email=mariza%40yahoo.com&Phone=111111111111

markdown
Copy code

**Response:**

- **Success (200):**
    ```json
    {
      "message": "Customer updated successfully"
    }
    ```

- **Error (404):**
    ```json
    {
      "message": "No Data Found"
    }
    ```

### Delete Customer

- **Endpoint:** `DELETE /api/Customer/DeleteCustomer`
- **Description:** Delete a customer by their ID.

**Request:**
DELETE /api/Customer/DeleteCustomer?id=12

ruby
Copy code

**Response:**

- **Success (200):**
    ```json
    {
      "message": "Entry deleted successfully"
    }
    ```

- **Error (404):**
    ```json
    {
      "message": "No Data Found"
    }
    ```

## Food Menu API

### Get Single Menu Item

- **Endpoint:** `GET /api/FoodMenu/GetSingleMenu`
- **Description:** Retrieve a single food menu item by its ID.

**Request:**
GET /api/FoodMenu/GetSingleMenu?id=3

sql
Copy code

**Response:**

- **Success (200):**
    ```json
    {
      "success": true,
      "data": {
        "id": 3,
        "title": "spagettie",
        "price": 200,
        "isAvailable": true,
        "imageUrl": "https://europe.stripes.com/lifestyle/99177148_s.jpg/alternates/LANDSCAPE_910/europe-70895"
      }
    }
    ```

- **Error (404):**
    ```json
    {
      "message": "No Data Found"
    }
    ```

### Get All Menu Items

- **Endpoint:** `GET /api/FoodMenu/GetAllMenues`
- **Description:** Retrieve all food menu items.

**Request:**
GET /api/FoodMenu/GetAllMenues

sql
Copy code

**Response:**

- **Success (200):**
    ```json
    {
      "success": true,
      "data": [
        {
          "id": 3,
          "title": "spagettie",
          "price": 200,
          "isAvailable": true,
          "imageUrl": "https://europe.stripes.com/lifestyle/99177148_s.jpg/alternates/LANDSCAPE_910/europe-70895"
        }
      ],
      "message": null
    }
    ```

- **Error (404):**
    ```json
    {
      "message": "No Data Found"
    }
    ```

### Create Menu Item

- **Endpoint:** `POST /api/FoodMenu/CreateMenue`
- **Description:** Create a new food menu item.

**Request:**
POST /api/FoodMenu/CreateMenue?Title=enjera&price=500&IsAvailable=true&ImageUrl=https%3A%2F%2Flp-cms-production.imgix.net%2F2020-11%2FInjera.jpg%3Fauto%3Dformat%26fit%3Dcrop%26sharp%3D10%26vib%3D20%26ixlib%3Dreact-8.6.4%26w%3D850%26q%3D20%26dpr%3D5

mathematica
Copy code

**Response:**

- **Success (200):**
    ```json
    {
      "message": "Menu created successfully"
    }
    ```

- **Error (400):**
    ```json
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
    ```

### Update Menu Item

- **Endpoint:** `PUT /api/FoodMenu/UpdateMenu`
- **Description:** Update an existing food menu item.

**Request:**
PUT /api/FoodMenu/UpdateMenu?Id=3&Title=areke&price=455&IsAvailable=true

markdown
Copy code

**Response:**

- **Success (200):**
    ```json
    {
      "success": true,
      "message": "Menu updated successfully"
    }
    ```

- **Error (404):**
    ```json
    {
      "message": "No Data Found"
    }
    ```

### Delete Menu Item

- **Endpoint:** `DELETE /api/FoodMenu/DeleteMenu`
- **Description:** Delete a food menu item by its ID.

**Request:**
DELETE /api/FoodMenu/DeleteMenu?id=4

markdown
Copy code

**Response:**

- **Success (200):**
    ```json
    {
      "message": "Entry Deleted Successfully"
    }
    ```

- **Error (404):**
    ```json
    {
      "message": "No Data Found"
    }
    ```

## Table API

### Get Single Table

- **Endpoint:** `GET /api/Table/GetSingleTable`
- **Description:** Retrieve a single table by its ID.

**Request:**
GET /api/Table/GetSingleTable?id=3

sql
Copy code

**Response:**

- **Success (200):**
    ```json
    {
      "success": true,
      "data": {
        "id": 3,
        "tableNumber": 10,
        "numberOfSeats": 6,
        "isAvialable": false
      },
      "message": "Table Retrieved Successfully"
    }
    ```

- **Error (404):**
    ```json
    {
      "message": "No Data Found"
    }
    ```

### Get All Tables

- **Endpoint:** `GET /api/Table/GetAllTables`
- **Description:** Retrieve all tables.

**Request:**
GET /api/Table/GetAllTables

sql
Copy code

**Response:**

- **Success (200):**
    ```json
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
    ```

- **Error (404):**
    ```json
    {
      "message": "No Data Found"
    }
    ```

### Create Table

- **Endpoint:** `POST /api/Table/CreateTable`
- **Description:** Create a new table.

**Request:**
POST /api/Table/CreateTable?TableNumber=33&NumberOfSeats=5&isAvialable=true

markdown
Copy code

**Response:**

- **Success (200):**
    ```json
    {
      "message": "Table created successfully"
    }
    ```

### Update Table

- **Endpoint:** `PUT /api/Table/UpdateTable`
- **Description:** Update an existing table.

**Request:**
PUT /api/Table/UpdateTable?Id=6&TableNumber=10&NumberOfSeats=6&isAvialable=true

markdown
Copy code

**Response:**

- **Success (200):**
    ```json
    {
      "message": "Table updated successfully"
    }
    ```

- **Error (400):**
    ```json
    {
      "message": "Failed To Update Table"
    }
    ```

### Delete Table

- **Endpoint:** `DELETE /api/Table/DeleteTable`
- **Description:** Delete a table by its ID.

**Request:**
DELETE /api/Table/DeleteTable?id=6

markdown
Copy code

**Response:**

- **Success (200):**
    ```json
    {
      "message": "Entry Deleted Successfully"
    }
    ```

- **Error (400):**
    ```json
    {
      "message": "Failed To Delete Entry"
    }
    ```

## Booking API

### Get Single Booking

- **Endpoint:** `GET /api/Booking/GetSingleBooking`
- **Description:** Retrieve a single booking by its ID.

**Request:**
GET /api/Booking/GetSingleBooking?id=6

sql
Copy code

**Response:**

- **Success (200):**
    ```json
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
      "message": "Booking Retrieved Successfully"
    }
    ```

- **Error (404):**
    ```json
    {
      "message": "No Data Found"
    }
    ```

### Get All Bookings

- **Endpoint:** `GET /api/Booking/GetAllBookings`
- **Description:** Retrieve a list of all bookings.

**Request:**
GET /api/Booking/GetAllBookings

sql
Copy code

**Response:**

- **Success (200):**
    ```json
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
    ```

- **Error (404):**
    ```json
    {
      "message": "No Data Found"
    }
    ```

### Create Booking

- **Endpoint:** `POST /api/Booking/CreateBooking`
- **Description:** Create a new booking.

**Request:**
POST /api/Booking/CreateBooking?BookingDate=2024-08-25%2014%3A30%3A00.0000000&NumberOfGuests=4&CustomerId=2&TablesId=4&FoodMenuId=3

ruby
Copy code

**Response:**

- **Success (200):**
    ```json
    {
      "message": "Booking created successfully"
    }
    ```

- **Error (400):**
    ```json
    {
      "message": "Table is Already Booked, Please choose another Table"
    }
    ```

- **Error (400):**
    ```json
    {
      "message": "Table Can Not Accommodate the Number of Guests"
    }
    ```

### Update Booking

- **Endpoint:** `PUT /api/Booking/UpdateBooking`
- **Description:** Update an existing booking.

**Request:**
PUT /api/Booking/UpdateBooking?Id=11&BookingDate=2024-08-25%2014%3A30%3A00.0000000&NumberOfGuests=6&CustomerId=8&TablesId=3&FoodMenuId=3

markdown
Copy code

**Response:**

- **Success (200):**
    ```json
    {
      "message": "Booking updated successfully"
    }
    ```

- **Error (404):**
    ```json
    {
      "message": "No Data Found"
    }
    ```

### Delete Booking

- **Endpoint:** `DELETE /api/Booking/DeleteBooking`
- **Description:** Delete a booking by its ID.

**Request:**
DELETE /api/Booking/DeleteBooking?id=103

ruby
Copy code

**Response:**

- **Success (200):**
    ```json
    {
      "success": true,
      "message": "Entry Deleted Successfully"
    }
    ```

- **Error (404):**
    ```json
    {
      "message": "No Data Found"
    }
    ```








