<?php
$_POST = json_decode(file_get_contents("php://input"), true);
  header('Access-Control-Allow-Origin: *');
  header('Content-Type: application/json');
  header("Access-Control-Allow-Headers: *");
  header("Access-Control-Allow-Methods: POST,OPTIONS,GET");
  include_once('conexion.php');
  //echo($_POST); 
    if($_POST){
      echo "se envio algo chido";
    }
    if($_POST['nombre'] && $_POST['token']){

      $_POST['rol']=rand(1,3);

    $sql = "INSERT INTO usuarios(nombre,token,zona_id)VALUES('". $_POST['nombre'] . "','". $_POST['token'] . "','". $_POST['rol'] . "')";
    //echo($sql);
    $saved = $con->query($sql) or die("Error de obtenencion de datos");

    $res = array();

    if ($saved) {
      $res[] = array(
        'state' => 1);
      
    }

    mysqli_close($con);
    echo ("si funciona");
    }
    else{
    //echo $_POST[0];
    echo ("FALLO EN EL SERVIDOR DE BD");
    }

  
?>   