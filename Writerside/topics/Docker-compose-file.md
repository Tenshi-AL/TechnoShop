# Docker-compose file

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