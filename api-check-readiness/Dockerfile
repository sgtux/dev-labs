FROM alpine:latest
RUN mkdir -p /app
WORKDIR /app
COPY . /app
RUN apk add --update nodejs nodejs-npm && npm install --prod
ENV PORT 80
CMD ["npm", "start"]