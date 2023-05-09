const secketio = require('socket.io')

const sockets = []
let endpoitsData = null

module.exports = {
  startSocket: server => {
    const io = secketio(server)
    io.on('connection', socket => {
      sockets.push(socket)
      if (endpoitsData)
        socket.emit('receiveData', endpoitsData)
    })
  },
  notifyClients: data => {
    endpoitsData = data
    sockets.forEach(p => p.emit('receiveData', data))
  }
}