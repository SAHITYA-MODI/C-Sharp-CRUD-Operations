# MyEntityApi

Welcome to MyEntityApi! This API provides functionality for managing entities, allowing users to perform various operations like creating, updating, deleting, and searching entities. The project is built using .NET 8 and designed to be scalable, with features such as pagination, sorting, and advanced filtering.

## Installation

### Requirements
Before you start, ensure you have the following installed:
- .NET 8

### Steps
1. Clone the repository:
    ```bash
    git clone https://github.com/your-username/MyEntityApi.git
    ```

2. Navigate to the project directory:
    ```bash
    cd MyEntityApi
    ```

3. Run the application:
    ```bash
    dotnet run
    ```

The application will start, and you can access it at [https://localhost:5001](https://localhost:5001) in your browser.

## API Documentation

### 1. Get Entities
**Endpoint:** `/api/entities`  
**Method:** `GET`  
**Description:** Retrieve a list of entities based on specified parameters.  

**Query Parameters:**
- `search`: Search term for filtering entities.
- `gender`: Gender filter.
- `startDate`, `endDate`: Date range filter.
- `countries`: List of countries for filtering.
- `pageNumber`: Page number for pagination.
- `pageSize`: Page size for pagination.
- `sortBy`: Field to sort entities by.
- `sortOrder`: Sorting order (asc or desc).

**Example Request:**
```http
GET /api/entities?search=bob&gender=male&pageNumber=1&pageSize=10&sortBy=Id&sortOrder=asc
```
**Example Response:**
```json
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
```

### 2. Get Entity by ID
**Endpoint:** `/api/entities/{id}`
**Method:** `GET`
**Description:** Retrieve an entity by its ID.

### 3. Create Entity
**Endpoint:** `/api/entities`
**Method:** `POST`
**Description:** Create a new entity.

**Request Body:**

```json
{
  "addresses": [
    {
      "addressLine": "string",
      "city": "string",
      "country": "string"
    }
  ],
  "dates": [
    {
      "dateType": "string",
      "dateValue": "2024-02-28T08:58:17.737Z"
    }
  ],
  "deceased": true,
  "gender": "string",
  "id": "string",
  "names": [
    {
      "firstName": "string",
      "middleName": "string",
      "surname": "string"
    }
  ]
}
```

### 4. Update Entity
**Endpoint:** `/api/entities/{id}`
**Method:** `PUT`
**Description:** Update an existing entity.

**Request Body:**
```json
{
  "addresses": [
    {
      "addressLine": "string",
      "city": "string",
      "country": "string"
    }
  ],
  "dates": [
    {
      "dateType": "string",
      "dateValue": "2024-02-28T08:58:53.209Z"
    }
  ],
  "deceased": true,
  "gender": "string",
  "id": "string",
  "names": [
    {
      "firstName": "string",
      "middleName": "string",
      "surname": "string"
    }
  ]
}
```

### 5. Delete Entity
**Endpoint:** `/api/entities/{id}`
**Method:** `DELETE`
**Description:** Delete an entity by its ID.

# Logic Behind Each API

## 1. Get Entities
The logic behind retrieving entities involves applying filters, pagination, and sorting. The API utilizes a flexible querying mechanism that allows users to filter entities based on parameters such as search terms, gender, date ranges, and countries. Pagination is implemented to limit the number of results returned, and users can specify the page number and page size. Sorting is also supported, allowing users to define the field and order for sorting the results.

## 2. Get Entity by ID
This API retrieves a single entity by its unique identifier (ID). The logic involves searching the collection of entities for the specified ID and returning the corresponding entity if found. If the ID is not present, the API returns a "Not Found" response.

## 3. Create Entity
The logic behind creating a new entity involves receiving a request with the details of the entity to be created. The API generates a unique identifier for the new entity, adds it to the collection, and returns a response indicating success. If validation fails or there are issues with the request, appropriate error responses are returned.

## 4. Update Entity
Updating an existing entity involves finding the entity by its ID and applying the changes provided in the request. The API checks for the existence of the entity, and if found, updates the relevant fields. The response includes the updated entity. If the entity is not found, a "Not Found" response is returned.

## 5. Delete Entity
The logic behind deleting an entity is straightforward. The API searches for the entity by its ID, removes it from the collection, and returns a success response. If the entity is not found, a "Not Found" response is returned.

## 6. Sorting, Pagination, and Advanced Filtering Logic
### a. Sorting:
Takes the sortBy and sortOrder parameters from the query.
Utilizes LINQ to dynamically order the result set based on the specified field and order.
### b. Pagination:
Takes the pageNumber and pageSize parameters from the query.
Uses LINQ to skip the appropriate number of records based on the page number and take the specified number of records.
### c. Advanced Filtering:
Extends the logic of basic filtering to accommodate additional parameters.
Incorporates more complex criteria for filtering based on user requirements.

# Contributing
Contributions are welcome! If you'd like to contribute, please follow these steps:
1. Fork the repository.
2. Create a new branch (`git checkout -b feature/new-feature`).
3. Make your changes.
4. Commit your changes (`git commit -am 'Add new feature'`).
5. Push to the branch (`git push origin feature/new-feature`).
6. Create a new Pull Request.

# Credits
This project was created by Sahitya Modi. Feel free to contact me at sahityamodi0 for any questions or feedback.

