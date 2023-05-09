window.onload = async () => {
    let response = await fetch('http://172.30.30.10/NodeApp/api/items')
    let items = JSON.parse(await response.text());

    const tBody = document.getElementById('tBody')
    let html = ''
    for (const i of items) {
        html += `<tr><td>${i.id}</td><td>${i.description}</td><td><button onclick="del(${i.id})" type="button">Deletar</button></td></tr>`
        console.log(i)
    }
    tBody.innerHTML = html
}

function add() {
    fetch('http://172.30.30.10/NodeApp/api/add-item?description=' + document.getElementById('txtDescription').value)
    setTimeout(() => location.href = location.href, 300)
}

function del(id) {
    fetch('http://172.30.30.10/NodeApp/api/remove-item/' + id)
    setTimeout(() => location.href = location.href, 300)
}