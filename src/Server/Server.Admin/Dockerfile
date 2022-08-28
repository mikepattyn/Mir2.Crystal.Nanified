FROM givt/base-nginx-image

WORKDIR /app

COPY src/Server/Server.Admin/package.json .

RUN npm install

COPY ./dist /usr/share/nginx/html

EXPOSE 80
