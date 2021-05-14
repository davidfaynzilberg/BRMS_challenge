/*
SQLyog Ultimate v8.82 
MySQL - 5.5.5-10.1.30-MariaDB : Database - brmsapp
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`brmsapp` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `brmsapp`;

/*Table structure for table `borrowers` */

DROP TABLE IF EXISTS `borrowers`;

CREATE TABLE `borrowers` (
  `id` varchar(11) NOT NULL,
  `name` varchar(50) DEFAULT NULL,
  `ssn` varchar(9) DEFAULT NULL,
  `date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `status` varchar(20) DEFAULT NULL,
  `crimeid` varchar(11) DEFAULT NULL,
  `score` varchar(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `borrowers` */

insert  into `borrowers`(`id`,`name`,`ssn`,`date`,`status`,`crimeid`,`score`) values ('9b332f3a-b1','David','123456789','2021-05-13 22:36:00','Active','1001','603');