FROM nginx:mainline-alpine-perl

COPY ./src/Server/Server.Admin/docker/nginx.conf /etc/nginx/nginx.conf
COPY ./src/Server/Server.Admin/docker/default.conf /etc/nginx/conf.d/default.conf

COPY ./src/Server/Server.Admin/dist/server.admin /usr/share/nginx/html

EXPOSE 80
