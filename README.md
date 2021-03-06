# Andrew and Ally's Alchemical Auguries
---
### We are deployed on Azure!

https://magicalgoods.azurewebsites.net/

[Vulnerability Report](vulnerability-report.md)

---
## Web Application
Our E-Commerce ASP.NET MVC web application allows users to browse and purchase magical items. The store page shows each item for sale, displaying an image of the item and a price. Users can click each item to go to a details page, which has a description for the item, as well a button to add the item to their cart. If the user tries to add an item to a cart without logging in, the system will take that user to the registration page. The app sends users an email via sendgrid on account creation as well as sending a receipt when checking out. The registration page creates identity claims for our first name and last name so that the site can show this information across our pages while keeping that data secure.  Users can add items to their cart, review their cart, update item quantities, and perform a mock checkout which via an Authorize.Net sandbox account. The system then sends the user a receipt at their email via sendgrid, and the order details are saved. 

Administrators can access an administrator panel, product overview, and pages to add, edit, and delete products.   Product images are stored in Azure Blob Storage (this feature is currently disabled because blob storage on Azure is expensive). Admins can also see a history of all orders, and can click each order for more details.


---
### Identity Claims
- First Name, Last Name  
- User ID

---

## Tools Used
Microsoft Visual Studio Community 2019 

- C#
- ASP.Net Core
- Entity Framework
- MVC
- xUnit
- Bootstrap
- Azure
- Identity
- Sendgrid
- Authorize.Net
- Azure Blob Storage

---
## Getting Started

**Get access to Azure repo (optional):**  
Email areyes986@gmail.com or andrewbc.dev@outlook.com to ask for an invite to the azure organization.  

Clone this repository to your local machine.

```
$ git clone https://github.com/shifted7/magicalgoodsstore.git
```
Once downloaded, you can either use the dotnet CLI utilities or Visual Studio 2017 (or greater) to build the web application. The solution file is located in the MagicalGoods subdirectory at the root of the repository.
```
cd MagicalGoods
dotnet build
```
The dotnet tools will automatically restore any NuGet dependencies. Before running the application, the provided code-first migration will need to be applied to the SQL server of your choice configured in a /MagicalGoods/appsettings.json file. This requires the Microsoft.EntityFrameworkCore.Tools NuGet package and can be run from the NuGet Package Manager Console:
```
Update-Database
```
Once the database has been created, the application can be run. Options for running and debugging the application using IIS Express or Kestrel are provided within Visual Studio. From the command line, the following will start an instance of the Kestrel server to host the application:
```
cd MagicalGoods/MagicalGoodsTesting
dotnet run
```
Unit testing is included in the MagicalGoods/Magical project using the xUnit test framework. Tests have been provided for models, view models, controllers, and utility classes for the application.

---

## Visuals

### Home Page
![Home Page](/assets/home-page.png)

### Shop Page
![Shop Page](/assets/shop.png)

### Product By ID
![Register](/assets/product-page.png)

### Login
![Login](/assets/login.png)

### Register
![Register](/assets/register.png)

### Cart Page
![Cart](/assets/cart.png)

### Checkout
![Checkout](/assets/checkout.png)

### Receipt 
![Register](/assets/receipt.png)

### Admin
![Register](/assets/admin.png)

### Admin Overview
![Register](/assets/admin-overview.png)

---
## Data Flow (Frontend, Backend, REST API)
The data is inputted in the front-end view by the user, and is posted to a route in that front-end. The front-end then calls the necessary back-end service, and sends it the necessary data for its function. The backend service takes the data and updates the database as necessary.

![Data Flow Diagram](/assets/Flowchart.png)

---
## Data Model

### Overall Project Schema
Our store database has a schema as follows: we have tables for carts, cartproducts, products and orders. The Carts table has columns for ID and the userID. The CartProducts table has columns for ID, CartID, product, and quantity. The Products table has columns for ID, name of the product, price per item, description of the product, and a url for the image of the product. The Orders table has columns for ID, customer name, date of the order, total price, and cart ID. 

Our user database is implemented according to the default schema of Identity.

![Database Schema](/assets/ERD.png)

---
## Model Properties and Requirements

### Cart

| Parameter | Type | Required |
| --- | --- | --- |
| ID  | int | YES |
| UserId | string | YES |
| CartProducts | List<CartProduct> | NO |

### CartProduct

| Parameter | Type | Required |
| --- | --- | --- |
| ID  | int | YES |
| CartID | int | YES |
| ProductID | int | YES |
| Quantity | int | YES |
| Product | Product | NO |

### Product

| Parameter | Type | Required |
| --- | --- | --- |
| ID  | int | YES |
| Name | string | YES |
| Price | decimal | YES |
| Description | int | YES |
| Image | Product | YES |

### Order

| Parameter | Type | Required |
| --- | --- | --- |
| ID  | int | YES |
| CustomerName | string | YES |
| DateOfOrder | DateTime | YES |
| TotalPrice | decimal | YES |
| Cart | Cart | NO |

---

## Change Log  

3.0: *App no longer crashes on startup. Redeployed on Azure. Readme updated.* 26 July 2020

2.1: *Fixed bugs* 17 May 2020

2.0: *Added Authorize.Net for payments, blob storage for images, updated styling and admin orders page for reviewing past orders* 10 May 2020

1.9: *Added administrator functions, receipt page, basket, and reworked styling* - 03 May 2020  

1.7: *Added some CSS for all pages* - 26 April 2020  

1.6: *When user clicks on an item from the shop page, they are redirected to see a page with the details of the clicked product* - 23 April 2020  

1.5: *When user clicks on an item from the shop page, they are redirected to see a page with the details of the clicked product* - 23 April 2020  

1.4: *Created a logout page. When user logs in, they are redirected to the shop page to see a list of all products* - 22 April 2020  

1.3: *Created interface/service for CRUD for our products, seeded the database* - 21 April 2020  

1.2: *Added a register and login page* - 21 April 2020  

1.1: *Scaffolded basic structure for application* - 20 April 2020  

---

## Authors
Andrew Casper  
Allyson Reyes

## Sources

Hero image by Cobro on Unsplash

Cart icon from https://www.dreamstime.com/cart-icon-vector-medieval-items-collection-thin-line-outline-illustration-linear-symbol-use-web-mobile-apps-logo-image166042455
