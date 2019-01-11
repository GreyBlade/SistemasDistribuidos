<?php
	include_once('conexion.php');


		$sql = "INSERT INTO notificaciones(titulo,contenido,usuarios)VALUES('". $_POST['title'] . "','". $_POST['content'] . "','". $_POST['array'] . "')";
		echo($sql);
		$saved = $con->query($sql) or die("Error de obtenencion de datos");

		$res = array();

		if ($saved) {
			$res[] = array(
			  'state' => 1);
			
		}

	mysqli_close($con);
	echo json_encode($res);
	
?>   