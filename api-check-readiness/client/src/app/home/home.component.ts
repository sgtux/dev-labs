import { Component } from '@angular/core'
import openSocket from 'socket.io-client'

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  public requests = []
  private socket

  constructor() {
    this.socket = openSocket()
    this.socket.on('receiveData', (data) => {
      this.requests = data.map(p => {
        p.request.online = !p.error
        return p.request
      })
    })
  }

  getClass(s: any) {
    return `ripple ${s.enabled ? s.online ? 'green' : 'red' : 'gray'}`
  }
}
