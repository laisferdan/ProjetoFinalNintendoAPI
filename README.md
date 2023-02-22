# Nintendo API Final Project

<img src="https://upload.wikimedia.org/wikipedia/commons/thumb/0/0d/Nintendo.svg/1200px-Nintendo.svg.png" alt="exemplo imagem">

> Final Project from Let's Code by ADA Bootcamp of Web Programming III Module.

You can check the detailed instructions (pt-br) on [final_project_web_III_instructions.md](https://github.com/laisferdan/ProjetoFinalNintendoAPI/blob/master/final_project_web_III_instructions.md)

This project is a .NET Web-API application in C#. The data source was the Nintendo Games data from 2008 to 2021.
<br/>

## 👩‍💻 Applied concepts
* API REST
* Controllers
* Model Binding
* Filters (Action, Result, Exception, Logger)
* Authentication and Authorization
* JWT (Bearer Token)
* CORS
* Middleware
* Environment variables
* Extension Methods
* Working with files
* SOLID Principles
* Repository Pattern
* Entity Framework Core

<br/>

## 💻 Getting Started
Before you begin, make sure you meet the following requirements:
* You have version of `<.NET 6.0>`;
* You have a `<Windows / Linux / Mac>` machine.

<br/>

## In-Memory Database

- Clone the repository:

```
$ git clone https://github.com/laisferdan/ProjetoFinalNintendoAPI.git
```

* Navigate to `ProjetoFinalNintendoAPI` directory:

```
$ cd ProjetoFinalNintendoAPI
```

- Start the solution `ProjetoFinalNintendoAPI.sln`

```
$ start ProjetoFinalNintendoAPI.sln
```

* **Run the application.** (`Ctrl + F5` in Visual Studio Commnunity)

<br/>

## Endpoints Tests

You can test the endpoints using **Swagger**.

### Swagger

* After running the app, access the URL: http://localhost:5000/swagger/index.html

<br/>

## Base URL
Users must prepend all resources calls with this base URL:

```
http://localhost:5000
```

<br/>

## Authentication
* Only the <strong>POST/login</strong> endpoint can be accessed without any Authentication.
* To access all other endpoints, you will need to generate a token using the <strong>POST/login</strong>, with the following request body:
```
{
  "username": "usuario",
  "password": "m1nh@s3nh@"
}
```
* Copy the created token.
* In Swagger, click on `Authorize` button at the top right and paste the token.
* Now you will have access to all the other endpoints.

<br/>

## Endpoints
### Login
| **Method**    | **Authentication?** | **Description**  |
| ------------- | ------------------- | ---------------- |
| `POST /login` | No                  | Generate a token |

### NintendoGames
|    **Method**                | **Authentication?**    |                      **Description**                     |
| ---------------------------- | ---------------------- | -------------------------------------------------------- |
| `GET /NintendoGames/query`   | Yes                    | Search and filter Nintendo Games records with pagination |
| `GET /NintendoGames`         | Yes                    | Search all Nintendo Games records with pagination        |
| `GET /NintendoGames/{id} `   | Yes                    | Search a Nintendo Games record by its id                 |
| `POST /NintendoGames`        | Yes                    | Create a new Nintendo Game record                        |
| `PUT /NintendoGames/{id} `   | Yes                    | Update an existing record or Create a new record         |
| `PATCH /NintendoGames/{id} ` | Yes                    | Update the platform string of an existing record         |
| `DELETE /NintendoGames/{id} `| Yes                    | Delete an existing record                                |
