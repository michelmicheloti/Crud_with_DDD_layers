FROM node:lts-alpine as build-stage

ARG VUE_APP_API_URL
ENV VUE_APP_API_URL ${VUE_APP_API_URL}

WORKDIR /app
COPY ./frontend/package*.json ./
RUN npm install

COPY ./frontend/ ./
RUN npm run build

# production stage
FROM nginx:stable-alpine as production-stage

COPY --from=build-stage /app/dist /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]

# # stage1 as builder
# FROM node:14-alpine as develop-stage
# WORKDIR /app
# # Copy the package.json and install dependencies
# COPY ./frontend/package*.json ./
# RUN npm install
# # Copy rest of the files
# COPY ./frontend/ ./
# # build stage
# FROM develop-stage as build-stage
# # Build the project
# RUN npm run build

# FROM nginx:alpine as production-stage
# COPY ./nginx/nginx.conf /etc/nginx/nginx.conf
# ## Remove default nginx index page
# RUN rm -rf /usr/share/nginx/html/*
# # Copy from the stahg 1
# COPY --from=build-stage /app/dist /usr/share/nginx/html
# EXPOSE 80
# ENTRYPOINT ["nginx", "-g", "daemon off;"]