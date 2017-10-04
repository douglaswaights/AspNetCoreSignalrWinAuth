import { Component } from '@angular/core';
import { HubConnection} from '@aspnet/signalr-client';

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent {

  constructor() {
    var connection = new HubConnection('/MyHub');
    connection.on('send', (message: string) => {
      console.log(message);
    });

   

    connection.start()
      .then(() => {
        console.log('Hub connection started')
      })
      .catch(err => {
        console.log('Error while establishing connection')
      });
  }
}
