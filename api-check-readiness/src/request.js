const axios = require('axios')

const runRequest = request => {
  return new Promise((resolve, reject) => {
    try {
      const {
        url,
        body,
        method,
        headers
      } = request

      axios({ method, headers, url, data: body })
        .then(() => resolve({ request }))
        .catch(err => reject({ request, error: { message: err.message } }))

    } catch (ex) {
      console.log(ex)
      reject({ request, error: { ex, code: -1, message: 'Exception error.' } })
    }
  })
}

module.exports = {
  runRequest
}