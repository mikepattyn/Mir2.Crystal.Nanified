FROM givt/base-nginx-image

COPY docker/nginx.conf /etc/nginx/nginx.conf
COPY docker/default.conf /etc/nginx/conf.d/default.conf

COPY ./ /usr/share/nginx/html

EXPOSE 80
