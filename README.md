# About
TechnoShop is an educational project simulating an online store for computer components.
Users can browse hardware parts, compare them, build their own custom PC, add items to the shopping cart, and place orders seamlessly.

Technologies used:
- ASP.NET for building the web application
- Entity Framework for efficient data access and management
- PostgreSQL as the database backend
- Docker for containerization and easy deployment

# Install
Clone the project:
```bash
git clone https://github.com/Tenshi-AL/TechnoShop.git
```
Use docker-compose file like this:
```yaml
networks:
  technoShopNetwork:
    driver: bridge
    
services:
  technoShop:
    image: technoshop
    ports:
      - 8080:8080
    networks:
        - technoShopNetwork
    depends_on:
      - postgres
    build:
      context: .
      dockerfile: TechnoShop/Dockerfile
  
  postgres:
    image: postgres:12.19
    ports:
      - 5432:5432
    networks:
      - technoShopNetwork
    environment:
      POSTGRES_DB: shopDb
      POSTGRES_USER: admin
      POSTGRES_PASSWORD: root
```
