FROM redis:6.0-alpine

# RUN apt-get update && apt-get install -y \
#     vim

COPY redis.slave.conf /config/redis.conf