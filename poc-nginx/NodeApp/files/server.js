const express = require('express')
const bodyparser = require('body-parser');

const app = express()

app.use(express.static('public'));

app.use(bodyparser.json())

let items = []

let id = 1

app.get('/api/items', (req, res) => {
    res.json(items)
})

app.get('/api/add-item', (req, res) => {
    if ((req.query || {}).description)
        items.push({ id: id++, description: req.query.description })
    res.end()
})

app.get('/api/remove-item/:id', (req, res) => {
    if ((req.params || {}).id)
        items = items.filter(p => p.id != req.params.id)
    res.end()
})

const PORT = process.env.NODE_PORT || 3001

app.listen(PORT, () => console.log(`Linten in port ${PORT}.`))