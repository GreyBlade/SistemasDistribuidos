import { Component } from '@angular/core';
import { Platform, Nav, AlertController } from 'ionic-angular';
import { StatusBar } from '@ionic-native/status-bar';
import { SplashScreen } from '@ionic-native/splash-screen';
import { Push, PushObject, PushOptions } from '@ionic-native/push';
import { Storage } from '@ionic/storage';
import { Observable } from "rxjs/Observable";
import { HttpClient } from "@angular/common/http";
import { Injectable } from '@angular/core';
import { HttpHeaders } from '@angular/common/http';
import { TabsPage } from '../pages/tabs/tabs';

@Component({
  templateUrl: 'app.html'
})
export class MyApp {
  rootPage:any = TabsPage;

  constructor(platform: Platform, statusBar: StatusBar, splashScreen: SplashScreen,public push: Push,
              public alertCtrl: AlertController,private storage: Storage,private httpClient:HttpClient) {
    platform.ready().then(() => {
      // Okay, so the platform is ready and our plugins are available.
      // Here you can do any higher level native things you might need.
      statusBar.styleDefault();
      splashScreen.hide();
      this.initPushNotification();
      this.showPrompt();
    });
    this.push.hasPermission()
      .then((res: any) => {

        if (res.isEnabled) {
          console.log('We have permission to send push notifications');
        } else {
          console.log('We do not have permission to send push notifications');
        }

      });
  }

  createUser(token){
    console.log(token);
  }



  mandarDatos(token){
    const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json'
    })
};

let objeto: Object = {
  nombre: "Nombre base",
  token: token
}


      this.httpClient.post("http://172.27.14.118/Notificaciones/insertuser.php", objeto,httpOptions)
      .subscribe(data=>{
        console.log("exito");
      },
      error => {console.log("error" , error);});
  }


  showPrompt(){
    const promp = this.alertCtrl.create({
      title:"Notification Center",
      message: "Bienvenido a Notification Center",
      inputs: [
        {
          name: "Nombre",
          placeholder: "Ingresa tu nombre"
        }
      ],
      buttons:[
        {
          text: "OK",
          handler: data => {
            console.log(data.name);
          }
        }
      ]
    });
    promp.present();
  }
  initPushNotification(){

  const options: PushOptions = {
    android: {
      senderID: "notificationcenterbeta"
    }
  };

  const pushObject: PushObject = this.push.init(options);

    pushObject.on('registration').subscribe((data: any) => {
    //  console.log("device token:", data.registrationId);

      let alert = this.alertCtrl.create({
                  title: 'device token',
                  subTitle: data.registrationId,
                  buttons: ['OK']
                });
              //  alert.present();
              this.createUser(data.registrationId);
              this.mandarDatos(data.registrationId);

    });

    pushObject.on('notification').subscribe((data: any) => {
      console.log(" " , data);
      let data1 = data.additionalData;
      let titulo;
      let mensaje;
      console.log(this.storage.set(data.title,data.message));

      this.storage.get('Reunion').then((val)=>{
        console.log(val);
      });
      for (let key of Object.keys(data1))
      {
        let value = data1[key];
        if (key=="pinpoint.notification.title")
        {
          titulo = value;
        }
        if (key=="pinpoint.notification.body")
        {
          mensaje=value;
        }
        //console.log(titulo);
        //console.log(mensaje);
      }

    //  console.log(data1);
      if (data.additionalData.foreground) {
        let confirmAlert = this.alertCtrl.create({
          title: data.title,
          message: data.message,
          buttons: [{
            text: 'Ignore',
            role: 'cancel'
          }, {
            text: 'View',
            handler: () => {
              //TODO: Your logic here
            }
          }]
        });
        confirmAlert.present();
      } else {
      let alert = this.alertCtrl.create({
                  title: data.title,
                  subTitle: data.message,
                 buttons: ['OK']
                });
                alert.present();
        console.log("Push notification clicked");
      }
   });

    pushObject.on('error').subscribe(error => console.error('Error with Push plugin', error));
  }

}
