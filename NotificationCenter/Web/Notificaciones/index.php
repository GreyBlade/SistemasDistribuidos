<?php
include_once("conexion.php");
?>     
<!DOCTYPE html>
<html>
<head>
  <!-- Compiled and minified CSS -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/css/materialize.min.css">

    <!-- Compiled and minified JavaScript -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/js/materialize.min.js"></script>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
	<title></title>
</head>
<body>
  <div class="row">
    <div class="col s6 m6 l6">
      <ul class="collection with-header ">
              <?php
                  $sql = 'SELECT * FROM alldata ORDER BY zona';
                  $usuarios = $con->query($sql) or die("Error de obtenencion de datos");
                  $lastZone = "";
                  while($row = mysqli_fetch_array($usuarios)){

                    if($row['zona']!= $lastZone){
                      echo '<li class="collection-header"><h4>'.$row['zona'].'</h4></li><li class="collection-item"><div><label><input type="checkbox" token="'.$row['token'].'" id="'.$row['id'].'" class="filled-in" /><span></span></label>'.$row['nombre'].'</div></li>';
                      $lastZone = $row['zona'];
                         
                    }else{
                       echo '
                        <li class="collection-item"><div> <label><input type="checkbox" token="'.$row['token'].'" id="'.$row['id'].'" class="filled-in"  /><span></span></label>'.$row['nombre'].'</div></li>';
                    } 
                  }
                ?>
      </ul>
    </div>
    <div class="col s6 m6 l6">
        <div>
          <div class="col s12 m12 l12 input-field inline">
            <input id="title" type="text" class="validate" required="">
            <label for="title">Title</label>
          </div>
          <div class="col s12 m12 l12 input-field inline">
            <textarea placeholder="Message us..." id="content" class="materialize-textarea" required=""></textarea>
          </div>
          <button class="btn waves-effect waves-light" type="submit" id="send">Submit
            <i class="material-icons right">send</i>
          </button>
        </div>
    </div>
  </div>
            
</body>
<script type="text/javascript">
  var dataSend = [];
  
  $(".filled-in").change(function() {
    var token = this.getAttribute("token");
    if(this.checked) {
      dataSend[token] = this.getAttribute("id");
    }else{
      delete dataSend[token]; 
    }
     console.log(dataSend);
  });


  $('#send').on('click', function(event){

        if($('#title').val()!= "" && $('#content').val()!= "" && dataSend!= []){
          var stringJSON = ""
             for (var key in dataSend) {
              stringJSON = stringJSON +dataSend[key]+",";
            }
            stringJSON = stringJSON.slice(0,-1);                                        
           var parametros = {"array" : stringJSON , "title" : $('#title').val() , "content" : $('#content').val()};
            
            console.log(parametros);
            $.ajax({
              type: 'post',
              url: 'save.php',
              data: parametros,
              dataType: 'json',         
              success: function(response){
                console.log(response);
                if((response[0].state==1)){ //Chequear envio de datos al comprobar codigo de estado   
                 console.log("guardado completo");
                }           
              },    
               error: function (obj, error, objError){
               // console.log(error);
                      //avisar que ocurrió un error
                //console.log("Algo salio mal");
                  }       
            }); //Fin AjaX   */
        }else{
          console.log("datos incompletos");
        }
                              
      
    });
</script>
</html>