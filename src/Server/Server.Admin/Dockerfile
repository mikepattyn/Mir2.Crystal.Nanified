# Use an official Node runtime as a parent image
FROM node:14-alpine3.14 AS builder

# Set the working directory to /app
WORKDIR /app

# Copy the package.json and package-lock.json to the working directory
COPY package*.json ./

# Install the dependencies
RUN npm install

# Copy the rest of the application code to the working directory
COPY . .

# Build the application
RUN npm run build --prod

FROM nginx:mainline-alpine-perl

COPY ./src/Server/Server.Admin/docker/nginx.conf /etc/nginx/nginx.conf

COPY ./src/Server/Server.Admin/docker/default.conf /etc/nginx/conf.d/default.conf

COPY --from=builder /app/dist/server.admin /usr/share/nginx/html

EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]
