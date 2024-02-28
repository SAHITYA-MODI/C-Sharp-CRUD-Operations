# MyEntityApi

## Table of Contents

- [Introduction](#introduction)
- [Installation](#installation)
- [API Documentation](#api-documentation)
  - [1. Get Entities](#1-get-entities)
  - [2. Get Entity by ID](#2-get-entity-by-id)
  - [3. Create Entity](#3-create-entity)
  - [4. Update Entity](#4-update-entity)
  - [5. Delete Entity](#5-delete-entity)
- [Logic Behind Each API](#logic-behind-each-api)
- [Contributing](#contributing)
- [License](#license)
- [Credits](#credits)

## Introduction

Welcome to MyEntityApi! This API provides functionality for managing entities, allowing users to perform various operations like creating, updating, deleting, and searching entities. The project is built using .NET 8 and designed to be scalable, with features such as pagination, sorting, and advanced filtering.

## Installation

### Requirements

Before you start, ensure you have the following installed:

- [.NET 8](https://dotnet.microsoft.com/download/dotnet/8.0)

### Steps

1. **Clone the repository:**

   ```bash
   git clone https://github.com/your-username/MyEntityApi.git
Save to grepper
Navigate to the project directory:

bash
Copy code
cd MyEntityApi
Run the application:

bash
Copy code
dotnet run
The application will start, and you can access it at https://localhost:5001 in your browser.

API Documentation
1. Get Entities
Endpoint: /api/entities
Method: GET
Description: Retrieve a list of entities based on specified parameters.
Query Parameters:
search: Search term for filtering entities.
gender: Gender filter.
startDate, endDate: Date range filter.
countries: List of countries for filtering.
pageNumber: Page number for pagination.
pageSize: Page size for pagination.
sortBy: Field to sort entities by.
sortOrder: Sorting order (asc or desc).
Example Request
http
Copy code
GET /api/entities?search=bob&gender=male&pageNumber=1&pageSize=10&sortBy=Id&sortOrder=asc
Save to grepper
Example Response
json
Copy code
[
  {
    "id": "1",
    "names": [
      {
        "firstName": "John",
        "middleName": null,
        "surname": "Doe"
      }
    ],
    "addresses": [],
    "dates": [],
    "gender": "male",
    "deceased": false
  },
  {
    "id": "2",
    "names": [
      {
        "firstName": "Jane",
        "middleName": null,
        "surname": "Smith"
      }
    ],
    "addresses": [],
    "dates": [],
    "gender": "female",
    "deceased": false
  }
]
Save to grepper
2. Get Entity by ID
Endpoint: /api/entities/{id}
Method: GET
Description: Retrieve an entity by its ID.
3. Create Entity
Endpoint: /api/entities
Method: POST
Description: Create a new entity.
Request Body:
json
Copy code
{
  "names": [
    {
      "firstName": "New",
      "middleName": null,
      "surname": "Entity"
    }
  ],
  "addresses": [],
  "dates": [],
  "gender": "unknown",
  "deceased": false
}
4. Update Entity
Endpoint: /api/entities/{id}
Method: PUT
Description: Update an existing entity.
Request Body:
json
Copy code
{
  "names": [
    {
      "firstName": "Updated",
      "middleName": null,
      "surname": "Entity"
    }
  ],
  "addresses": [],
  "dates": [],
  "gender": "unknown",
  "deceased": false
}
5. Delete Entity
Endpoint: /api/entities/{id}
Method: DELETE
Description: Delete an entity by its ID.
Logic Behind Each API
1. Get Entities
Explain the logic behind retrieving entities with filters, pagination, and sorting.

2. Get Entity by ID
Explain the logic behind retrieving a single entity by its ID.

3. Create Entity
Explain the logic behind creating a new entity.

4. Update Entity
Explain the logic behind updating an existing entity.

5. Delete Entity
Explain the logic behind deleting an entity by its ID.

Contributing
Contributions are welcome! If you'd like to contribute, please follow these steps:

Fork the repository.
Create a new branch (git checkout -b feature/new-feature).
Make your changes.
Commit your changes (git commit -am 'Add new feature').
Push to the branch (git push origin feature/new-feature).
Create a new Pull Request.
License
This project is licensed under the MIT License. See the LICENSE file for details.

Credits
This project was created by [Your Name]. Feel free to contact me at your.email@example.com for any questions or feedback.
