-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 06-01-2019 a las 20:18:47
-- Versión del servidor: 10.1.37-MariaDB
-- Versión de PHP: 7.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `notificaciones`
--

-- --------------------------------------------------------

--
-- Estructura Stand-in para la vista `alldata`
-- (Véase abajo para la vista actual)
--
CREATE TABLE `alldata` (
`id` int(11)
,`nombre` text
,`token` varchar(255)
,`zona` text
);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `notificaciones`
--

CREATE TABLE `notificaciones` (
  `id` int(11) NOT NULL,
  `titulo` varchar(50) NOT NULL,
  `contenido` varchar(255) NOT NULL,
  `usuarios` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `notificaciones`
--

INSERT INTO `notificaciones` (`id`, `titulo`, `contenido`, `usuarios`) VALUES
(9, 'reunion', 'mañana', '2,4,3,null'),
(10, 'ds', 'ds', '2,4,3'),
(11, 'ds', 'ds', '2,4,3'),
(12, 'Reunion mañana', 'Por la mañana perros \nno faltes', '2,1,5');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

CREATE TABLE `usuarios` (
  `id` int(11) NOT NULL,
  `nombre` text NOT NULL,
  `token` varchar(255) NOT NULL,
  `zona_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `usuarios`
--

INSERT INTO `usuarios` (`id`, `nombre`, `token`, `zona_id`) VALUES
(1, 'Carlos', '123a', 1),
(2, 'Efrain', '1234s', 2),
(3, 'Jaime', '12345d', 3),
(4, 'Villa', '123456s', 2),
(5, 'Humberto', '1234567ss', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `zona`
--

CREATE TABLE `zona` (
  `id` int(11) NOT NULL,
  `zona` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `zona`
--

INSERT INTO `zona` (`id`, `zona`) VALUES
(1, 'programadores'),
(2, 'coordinadores'),
(3, 'lideres');

-- --------------------------------------------------------

--
-- Estructura para la vista `alldata`
--
DROP TABLE IF EXISTS `alldata`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `alldata`  AS  select `usuarios`.`id` AS `id`,`usuarios`.`nombre` AS `nombre`,`usuarios`.`token` AS `token`,`zona`.`zona` AS `zona` from (`usuarios` join `zona`) where (`usuarios`.`zona_id` = `zona`.`id`) ;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `notificaciones`
--
ALTER TABLE `notificaciones`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `zona`
--
ALTER TABLE `zona`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `notificaciones`
--
ALTER TABLE `notificaciones`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de la tabla `zona`
--
ALTER TABLE `zona`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
