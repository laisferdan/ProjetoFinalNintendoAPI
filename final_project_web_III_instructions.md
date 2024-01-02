# ProjetoFinalNintendoAPI (in english, FinalProjectNintendoAPI)
Create a REST API according to the requirements listed below:
- [x] The system must have a login mechanism using JWT, with an endpoint that receives `{ "login":"usuario", "password":"m1nh@s3nh@"}` and generates a token;
- [x] The JWT must have the following claims:
* iss - developer name;
* exp - 2 hours;
* sub - name of the api;
* aud - "ada";
* module - "Web III .net".
- [x] The system must have middleware that validates that the token is correct, valid and not expired, before allowing access to any other endpoint. If not, return status 401;
- [x] The login and password provided must be in environment variables and have a version for the development environment coming from a .NET configuration file. This file should not be uploaded to GIT, but rather an example file without the actual values. The same goes for any system "secret", like the JWT key;
- [x] Application endpoints must use port 5000 and be:
* (POST)      http://0.0.0.0:5000/login/
* (POST)      http://0.0.0.0:5000/api_controller/query    Note: It must be possible to filter the data by entering a body, and it must be paginated
* (GET)       http://0.0.0.0:5000/api_controller/         Note: Queries must be paged
* (GET)       http://0.0.0.0:5000/api_controller/{id}
* (POST)      http://0.0.0.0:5000/api_controller/
* (PUT)       http://0.0.0.0:5000/api_controller/{id}
* (PATCH)     http://0.0.0.0:5000/api_controller/{id}
* (DELETE)    http://0.0.0.0:5000/api_controller/{id}
- [x] To insert a record, the ID must not be entered;
- [x] To update data with PATCH, only the fields that will be changed (except the Id) must be sent;
- [x] To update the data with PUT, all fields in the body (except the Id) must be sent;
- [x] Pagination and search filters can be done both in the repository and using lambda functions in the controller;
- [x] All controllers and endpoints must define valid and invalid responses and the type of object that returns (model);
- [x] Some form of persistence must be used. You can use the Entity Framework (in-memory), text file, json, dictionary, etc.;
- [ ] If you prefer to choose to use a "real" database, add a docker-compose in your repository that puts the application and the database running, when run docker-compose up in the root. The connection string and bank password must be set by configuration file in this file;
- [x] Make a filter, and create a specific class to record logs, which writes to the console whenever the change (put, patch) or removal (delete) endpoints are used, indicating the time formatted as the following datetime: `01/01 /2021 13:45:00`. The log line must have the following format (if the request is valid): `<datetime> - Game <id> - <title> - <Remove|Change (and describe the change)>`;
- [x] The application must be configured to accept requests only from the "localhost" url;
- [x] The project must be placed in a GITHUB repository or equivalent, be public, and contain a readme.md that explains in detail any commands or configuration necessary to make the project run. For example, how to configure environment variables, how to run migrations (if they were used);
- [x] Delivery will be the URL of the repository or zipped file;
- [x] Delivery until 09/18/2022, at 00:00, via Class.
