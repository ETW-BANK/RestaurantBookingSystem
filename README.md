markdown
Copy code
# API Documentation

Welcome to the API documentation for the Restaurant Booking System. This README provides detailed information on the available API endpoints, including example requests and responses for various scenarios.

## Table of Contents

1. [Base URL](#base-url)
2. [Customer API](#customer-api)
   - [Get Single Customer](#get-single-customers)
   - [Get All Customers](#get-all-customers)
   - [Create Customer](#create-customer)
   - [Update Customer](#update-customer)
   - [Delete Customer](#delete-customer)
4. [Food Menu API](#food-menu-api)
   - [Get Single Menu Item](#get-single-menu-item)
   - [Get All Menu Items](#get-all-menu-items)
   - [Create Menu Item](#create-menu-item)
   - [Update Menu Item](#update-menu-item)
   - [Delete Menu Item](#delete-menu-item)
5. [Table API](#table-api)
   - [Get Single Table](#get-single-table)
   - [Get All Tables](#get-all-tables)
   - [Create Table](#create-table)
   - [Update Table](#update-table)
   - [Delete Table](#delete-table)
6. [Booking API](#booking-api)
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

json
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
        "lastName": "Girma",
        "email": "tensaeg@yahoo.com",
        "phone": "0764525651"
      },
      {
        "id": 3,
        "firstName": "ethiopia",
        "lastName": "Girma",
        "email": "tensaeg@yahoo.com",
        "phone": "0764525651"
      }
    ]
  }


### Create Customer

- **Endpoint:** Endpoint: POST /api/Customer/CreateCustomer
- **Description:** Create a new customer.

**Request:**

POST 
/api/Customer/CreateCustomer?FirstName=yohannes&LasttName=girma&Email=tensaeg%40yahoo.com&Pho
ne=0764525651'

json
Copy code

**Response:**

- **Success (200):**

  ```json
  {
   "message": "Customer created successfully",
  }
