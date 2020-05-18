# E-Commerce

## Andrew and Ally's Alchemical Auguries
---
### We are deployed on Azure!

Deployed: https://magicalgoodsstore.azurewebsites.net/

Vulnerability Report: [Report](/MagicalGoods/vulnerability-report.md)

---
## Web Application
Our E-Commerce C# web application allows users to browse and purchase magical items. The app sends users an email on account creation as well as sending a receipt when checking out. On our register page, using Identity, we are grabbing our claims for our first name and last name to used to display it across our pages as well as having better security.  Administrators can access an administrator panel, product overview, and pages to add, edit, and delete products.  

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


---
## Getting Started

**Get access:**  
Email areyes986@gmail.com or andrewbc.dev@outlook.com to ask for an invite to the azure organization.  

Clone this repository to your local machine.

```
$ git clone https://AndrewAllyOrg@dev.azure.com/AndrewAllyOrg/E-Commerce/_git/MagicalGoods
```
Once downloaded, you can either use the dotnet CLI utilities or Visual Studio 2017 (or greater) to build the web application. The solution file is located in the MagicalGoods subdirectory at the root of the repository.
```
cd MagicalGoods/MagicalGoods
dotnet build
```
The dotnet tools will automatically restore any NuGet dependencies. Before running the application, the provided code-first migration will need to be applied to the SQL server of your choice configured in a /MagicalGoods/MagicalGoods/appsettings.json file. This requires the Microsoft.EntityFrameworkCore.Tools NuGet package and can be run from the NuGet Package Manager Console:
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
![Home Page](\MagicalGoods\wwwroot\img\home-page.png)

### Shop Page
![Shop Page](\MagicalGoods\wwwroot\img\shop.png)

### Product By ID
![Register](\MagicalGoods\wwwroot\img\product-page.png)

### Login
![Login](\MagicalGoods\wwwroot\img\login.png)

### Register
![Register](\MagicalGoods\wwwroot\img\register.png)

### Cart Page
![Cart](\MagicalGoods\wwwroot\img\cart.png)

### Checkout
![Checkout](\MagicalGoods\wwwroot\img\checkout.png)

### Receipt 
![Register](\MagicalGoods\wwwroot\img\receipt.png)

### Admin
![Register](\MagicalGoods\wwwroot\img\admin.png)

### Admin Overview
![Register](\MagicalGoods\wwwroot\img\admin-overview.png)

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