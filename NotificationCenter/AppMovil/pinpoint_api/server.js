var express = require('express');
var path = require('path');
var bodyParser = require('body-parser');
var mongo = require('mongoose');

var db = mongo.connect('mongodb://jaimecuellar14:narutovssasuke14@ds251284.mlab.com:51284/notificationcenter',function(err,response){
  if(err){
    console.log(err);
  }
  else{
    console.log("connected to " + db + " , " , response);
  }
});

var app = express()
app.use(bodyParser());
app.use(bodyParser.json({limit: '5mb'}));
app.use(bodyParser.urlencoded({extended:true}));

app.use(function(req,res,next){
  res.setHeader('Access-Control-Allow-Origin','http://localhost:4200');
  res.setHeader('Access-Control-Allow-Methods','GET,POST,OPTIONS,PUT,PATCH,DELETE');
  res.setHeader('Access-Control-Allow-Headers','X-Requested-With, content-type');
  res.setHeader('Access-Control-Allow-Credentials',true);
  next();
});
