<?php
    $Servidor = "localhost";
    $Usuario = "root";
    $Pass = "";
    $Bd="notificaciones";
	
	
	$con = mysqli_connect($Servidor,$Usuario,$Pass, $Bd);
	mysqli_set_charset($con, "utf8");
	
	if(mysqli_connect_errno()) return "Error al iniciar";

?>