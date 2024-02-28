MyEntity API Documentation
Table of Contents
Introduction
Requirements
Installation
Running the API
Testing with Swagger
API Endpoints
Create Entity
Get Entities
Update Entity
Delete Entity
Get Entity by ID
Searching Entities
Advanced Filtering
Pagination and Sorting
Logic Behind Each API
Retry and Backoff Mechanism
1. Introduction
MyEntity API is a .NET 8 web application that provides CRUD operations for managing entities. This documentation provides comprehensive information about the API, including installation instructions, API endpoints, and the logic behind each API.

2. Requirements
.NET 8 SDK
Code editor (e.g., Visual Studio Code)
3. Installation
Clone the repository.
Open the project folder in your code editor.
Run the following command to build the project:
dotnet build
Ensure there are no build errors.
4. Running the API
Run the following command to start the API:
dotnet run
The API will be available at http://localhost:5069. Ensure the console shows "Now listening on..."
5. Testing with Swagger
Open a web browser and navigate to https://localhost:5069/swagger.
Use the Swagger UI to test the API endpoints interactively.
6. API Endpoints
1. Create Entity
Endpoint:

POST /api/entities
Description:

Creates a new entity with the provided details.
Request Body Example:

{
  "Names": [
    {
      "FirstName": "John",
      "MiddleName": "Doe",
      "Surname": "Smith"
    }
  ],
  "Addresses": [
    {
      "Country": "United States",
      "AddressLine": "123 Main St"
    }
  ],
  "Dates": [
    {
      "DateType": "Birth",
      "DateValue": "1990-01-01"
    }
  ],
  "Gender": "Male",
  "Deceased": false
}
Response:

Returns the created entity with a unique ID.
2. Get Entities
Endpoint:

GET /api/entities
Description:

Retrieves a list of entities based on provided filters, pagination, and sorting.
Query Parameters:

search, gender, startDate, endDate, countries, pageNumber, pageSize, sortBy, sortOrder.
Example:

/api/entities?search=John&gender=Male&countries=United States&pageSize=10&pageNumber=1&sortBy=FirstName&sortOrder=asc
Response:

Returns a paginated and sorted list of entities based on the provided criteria.
3. Update Entity
Endpoint:

PUT /api/entities/{id}
Description:

Updates an existing entity with new information.
Request Body Example:

json
Copy code
{
  "Names": [
    {
      "FirstName": "UpdatedFirstName",
      "MiddleName": "UpdatedMiddleName",
      "Surname": "UpdatedSurname"
    }
  ]
}
Response:

Returns the updated entity.
4. Delete Entity
Endpoint:

DELETE /api/entities/{id}
Description:

Deletes the entity with the specified ID.
Example:

/api/entities/123
Response:

Returns a success status upon successful deletion.
5. Get Entity by ID
Endpoint:

GET /api/entities/{id}
Description:

Retrieves detailed information about the entity with the specified ID.
Example:

/api/entities/123
Response:

Returns detailed information about the specified entity.
6. Searching Entities
Endpoint:

GET /api/entities
Description:

Allows searching across entities using various fields.
Query Parameters:

search: Search term.
Example:

/api/entities?search=John
Response:

Returns entities matching the search term.
7. Advanced Filtering
Endpoint:

GET /api/entities
Description:

Supports advanced filtering using parameters like gender, date range, and countries.
Query Parameters:

gender, startDate, endDate, countries.
Example:

/api/entities?gender=Male&startDate=1990-01-01&endDate=2022-01-01&countries=United States,Canada
Response:

Returns entities filtered based on the specified criteria.
8. Pagination and Sorting
Endpoint:

GET /api/entities
Description:

Implements pagination and sorting for efficient data retrieval.
Query Parameters:

pageNumber, pageSize, sortBy, sortOrder.
Example:

/api/entities?pageNumber=1&pageSize=10&sortBy=FirstName&sortOrder=asc
Response:

Returns a paginated and sorted list of entities based on the provided criteria.
7. Logic Behind Each API
Create Entity
Logic:
The API creates a new entity with the provided details and assigns a unique ID. It supports complex structures such as names, addresses, dates, gender, and deceased status.
Get Entities
Logic:
Retrieves a list of entities based on various criteria like search term, gender, date range, countries, pagination, and sorting.
Update Entity
Logic:
Updates an existing entity with new information, supporting partial updates for fields like names, addresses, etc.
Delete Entity
Logic:
Deletes the entity with the specified ID. It returns success if the deletion is successful.
Get Entity by ID
Logic:
Retrieves detailed information about the entity with the specified ID.
Searching Entities
Logic:
Provides a simple search functionality across various fields of entities.
Advanced Filtering
Logic:
Supports advanced filtering based on parameters like gender, date range, and countries.
Pagination and Sorting
Logic:
Implements efficient pagination and sorting to handle large datasets.
