FROM ubuntu:21.04
ARG DEBIAN_FRONTEND=noninteractive
WORKDIR /root
RUN apt update && \
  apt upgrade -y && \
  apt install nginx net-tools vim && \
  apt clean
CMD ["/root/init.py"]