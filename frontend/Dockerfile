# stage1 as builder
FROM node:14-alpine as develop-stage
WORKDIR /app
# Copy the package.json and install dependencies
COPY package*.json ./
RUN npm install
# Copy rest of the files
COPY . .
# build stage
FROM develop-stage as build-stage
# Build the project
RUN npm run build

FROM nginx:alpine as production-stage
COPY ./nginx/nginx.conf /etc/nginx/nginx.conf
## Remove default nginx index page
RUN rm -rf /usr/share/nginx/html/*
# Copy from the stahg 1
COPY --from=build-stage /app/dist /usr/share/nginx/html
EXPOSE 80
ENTRYPOINT ["nginx", "-g", "daemon off;"]