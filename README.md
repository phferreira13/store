# Online Store Microservices

## Project Description

The Online Store Microservices project is a sample implementation of an e-commerce platform using microservices architecture. The project aims to demonstrate how to build, deploy, and manage a set of loosely coupled services that work together to provide a complete online store experience. The main features of the project include order processing, payment handling, warehouse management, and delivery tracking.

## Prerequisites

Before you begin, ensure you have met the following requirements:
- Docker and Docker Compose installed
- .NET SDK 8.0 or later
- A code editor or IDE, such as Visual Studio or Visual Studio Code

## Installation

To set up the project locally, follow these steps:

1. Clone the repository:
   ```sh
   git clone https://github.com/phferreira13/store.git
   cd store
   ```

2. Build and run the services using Docker Compose:
   ```sh
   docker-compose up --build
   ```

## Usage

Once the services are up and running, you can interact with them using their respective APIs. The following services are available:

- **Order Service**: Handles order creation, updates, and retrieval.
- **Payment Service**: Manages payment processing and transactions.
- **Warehouse Service**: Manages inventory and stock levels.
- **Delivery Service**: Tracks and updates delivery status.

Each service exposes a set of RESTful endpoints that can be accessed using tools like Postman or cURL.

## Contributing

Contributions are welcome! To contribute to the project, follow these steps:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature/your-feature`).
3. Make your changes and commit them (`git commit -m 'Add some feature'`).
4. Push to the branch (`git push origin feature/your-feature`).
5. Create a pull request.

## Documentation and Resources

For more information about the project and its components, refer to the following resources:

- [Docker Documentation](https://docs.docker.com/)
- [ASP.NET Core Documentation](https://docs.microsoft.com/en-us/aspnet/core/)
- [RabbitMQ Documentation](https://www.rabbitmq.com/documentation.html)

