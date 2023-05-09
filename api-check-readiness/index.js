const http = require('http')
const express = require('express')
const path = require('path')

const { startSocket, notifyClients } = require('./src/socket')
const { startCheckReadiness } = require('./src/readiness')
const jsonFile = path.join(__dirname, 'requests.json')

const app = express()
const callback = data => notifyClients(data)

app.use(express.static('public'))

app.use('/users', (req, res) => res.json([{}, {}]))
const server = http.createServer(app)
startSocket(server)
startCheckReadiness(jsonFile, callback, 30)
server.listen(process.env.PORT || 3000)