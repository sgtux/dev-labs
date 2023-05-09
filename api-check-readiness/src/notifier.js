const path = require('path')
const notifier = require('node-notifier')
const opn = require('opn')

const notifyError = message => {
  notifier.notify({
    title: 'Check readiness',
    message: message,
    icon: path.join(__dirname, 'icons', 'error.png'),
    wait: true,
    sound: true
  });
}

const notifySuccess = message => {
  notifier.notify({
    title: 'Check readiness',
    message: message,
    icon: path.join(__dirname, 'icons', 'success.png'),
    wait: true,
    sound: false
  });
}

notifier.on('click', () => opn('http://localhost'))

module.exports = {
  notifyError,
  notifySuccess
}