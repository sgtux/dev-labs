FROM alpine:latest
COPY files /root/app
WORKDIR /root/app
RUN apk add --update nodejs npm && \
  npm install && \
  rm -rf /root/.npm/
ENV PORT 80
ENV NODE_ENV test
ENV SECRET 1234567890
EXPOSE 80
CMD [ "npm", "start" ]