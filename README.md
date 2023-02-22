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

<br />

## Search a Nintendo Game record
This endpoint returns information about a specific Nintendo Game record.

### Endpoint
`GET /NintendoGames/{id}`

### Request
Request body is not necessary

### Authentication <a name="Authentication"></a>
You need to append a token on header's request. <br/>
See more details in the [Authentication](#Authentication) topic.

### Responses
<table>
  <tr>
    <td> <strong>Status</strong> </td>
    <td> <strong>Description</strong> </td>
    <td> <strong>Example</strong> </td>
  </tr>
  <tr>
    <td> 200 - OK </td>
    <td> A single record is returned </td>
    <td>

```json
{
  "id": 1,
  "title": "Super Mario 3D World + Bowser's Fury",
  "platform": "Switch",
  "release_date": "Feb 12, 2021",
  "user_score": "",
  "link": "/game/switch/super-mario-3d-world-+-bowsers-fury",
  "developers": "['Nintendo']"
}
```

</td>
  </tr>
<tr>
<td> 404 - Not Found </td>
<td> Invalid URL or ID not found </td>
<td>

```json
{
  "message": "Error message"
}
```

<tr>
<td> 500 - Internal Server Error </td>
<td> General error message </td>
<td>

```json
{
  "message": "An unexpected error has occurred!"
}
```

</td>
</tr>

</td>
</tr>
</table>

<br/>

## Search all Nintendo Games records with pagination
This endpoint returns information about all Nintendo Games records with pagination.

### Endpoint
`GET/ NintendoGames`

### Query Parameters
|  **Name**  | **Type** | **Required?** | Example |
| ---------- | -------- | ------------- | ------- |
| page       | integer  | Yes           | 1       |
| limit      | integer  | Yes           | 15      |

### Request Body
Request body is not necessary.

### Authentication <a name="Authentication"></a>
You need to append a token on header's request. <br/>
See more details in the [Authentication](#Authentication) topic.

### Responses
<table>
  <tr>
    <td> <strong>Status</strong> </td>
    <td> <strong>Description</strong> </td>
    <td> <strong>Example</strong> </td>
  </tr>
  <tr>
    <td> 200 - OK </td>
    <td> An array of records and a pagination info are returned </td>
    <td>

```json
[
  {
    "id": 1,
    "title": "Super Mario 3D World + Bowser's Fury",
    "platform": "Switch",
    "release_date": "Feb 12, 2021",
    "user_score": "",
    "link": "/game/switch/super-mario-3d-world-+-bowsers-fury",
    "developers": "['Nintendo']"
  },
  {
    "id": 2,
    "title": "Super Smash Bros. Ultimate: Sephiroth",
    "platform": "Switch",
    "release_date": "Dec 22, 2020",
    "user_score": "",
    "link": "/game/switch/super-smash-bros-ultimate-sephiroth",
    "developers": "['Nintendo']"
  }
]
```

</td>
  </tr>
<tr>
<td> 400 – Bad Request </td>
<td> Invalid Query parameters </td>
<td>

```json
{
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "traceId": "00-305fc97c9374fd546a5b481e509d88e3-8a02025c8e61facf-00",
  "errors": {
    "page": [
      "The value '695846122121' is not valid."
    ]
  }
}
```
<tr>
<td> 404 – Not Found </td>
<td> Invalid URL </td>
<td>

```json
{
  "message": "An unexpected error has occurred!"
}
```

</td>
</tr>

<tr>
<td> 500 - Internal Server Error </td>
<td> General error message </td>
<td>

```json
{
  "message": "An unexpected error has occurred!"
}
```

</td>
</tr>

</td>
</tr>
</table>

<br/>
