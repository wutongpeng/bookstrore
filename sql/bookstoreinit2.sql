/*
SQLyog Ultimate v11.11 (64 bit)
MySQL - 5.6.31 : Database - bookstore
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`bookstore` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `bookstore`;

/*Table structure for table `book` */

DROP TABLE IF EXISTS `book`;

CREATE TABLE `book` (
  `F_BID` varchar(10) NOT NULL COMMENT '图书编号',
  `F_BNAME` varchar(20) DEFAULT NULL COMMENT '图书名称',
  `F_BAUTHOR` varchar(20) DEFAULT NULL COMMENT '作者',
  `F_BHOUSE` varchar(20) DEFAULT NULL COMMENT '出版社',
  `F_BTYPE` varchar(10) DEFAULT NULL COMMENT '种类',
  `F_BPRICE` double DEFAULT '0' COMMENT '价格',
  `F_BTIME` varchar(20) DEFAULT NULL COMMENT '出版时间',
  `F_BDISCOUNT` int(3) DEFAULT '0' COMMENT '折扣',
  `F_BNUMBER` int(10) DEFAULT '0' COMMENT '库存',
  PRIMARY KEY (`F_BID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `book` */

insert  into `book`(`F_BID`,`F_BNAME`,`F_BAUTHOR`,`F_BHOUSE`,`F_BTYPE`,`F_BPRICE`,`F_BTIME`,`F_BDISCOUNT`,`F_BNUMBER`) values ('90001','水浒传','吴承恩','人民出版社','小说',103.45,'2016-12-11',0,2323),('90002','西游记','曹雪芹','人民出版社','小说',103.45,'2016-12-11',0,43234),('90003','红楼梦','罗贯中','人民出版社','小说',103.45,'2016-12-11',0,45),('90004','三国演义','施耐庵','人民出版社','小说',103.45,'2016-12-11',0,123),('90005','诛仙','萧鼎','北京新时空出版社','仙侠',34,'2016-12-11',0,566);

/*Table structure for table `sell` */

DROP TABLE IF EXISTS `sell`;

CREATE TABLE `sell` (
  `F_ID` int(10) NOT NULL AUTO_INCREMENT COMMENT '交易编号',
  `F_BID` varchar(10) NOT NULL COMMENT '书编号',
  `F_UID` varchar(10) DEFAULT NULL COMMENT '会员编号',
  `F_PRICE` double DEFAULT '0' COMMENT '实际出售价格',
  `F_DATA` varchar(20) DEFAULT NULL COMMENT '出售日期',
  `F_SID` varchar(10) DEFAULT NULL COMMENT '售货员',
  PRIMARY KEY (`F_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

/*Data for the table `sell` */

insert  into `sell`(`F_ID`,`F_BID`,`F_UID`,`F_PRICE`,`F_DATA`,`F_SID`) values (1,'90003','3001',103.45,'2016/12/11 16:36:44','2001'),(2,'90004','3001',232,'2016/12/11 16:36:44','2001'),(3,'90003','3001',103.45,'2016/12/13 21:20:33','2001'),(4,'90003','3001',103.45,'2016/12/13 21:20:33','2001'),(5,'90003','3001',103.45,'2016/12/13 21:20:33','2001'),(6,'90003','3001',103.45,'2016/12/13 21:20:33','2001');

/*Table structure for table `user` */

DROP TABLE IF EXISTS `user`;

CREATE TABLE `user` (
  `F_UID` varchar(10) NOT NULL COMMENT '用户编号',
  `F_NAME` varchar(20) NOT NULL COMMENT '姓名',
  `F_SEX` varchar(5) DEFAULT NULL COMMENT '性别',
  `F_INSTITU` varchar(20) DEFAULT NULL COMMENT '单位',
  `F_BIRTHDAY` varchar(20) DEFAULT NULL COMMENT '生日',
  `F_PASSWORD` varchar(10) DEFAULT NULL COMMENT '密码',
  `F_POWER` varchar(10) NOT NULL COMMENT '角色',
  PRIMARY KEY (`F_UID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `user` */

insert  into `user`(`F_UID`,`F_NAME`,`F_SEX`,`F_INSTITU`,`F_BIRTHDAY`,`F_PASSWORD`,`F_POWER`) values ('1001','王健林1','男','旧时光书店','2016-12-10','123','店长'),('2001','李翼瑶','女','旧时光书店','2016-12-10','123','售货员'),('2002','赵慧敏','女','旧时光书店','2016-12-10','123','售货员'),('3001','张德意','男','济南热电厂','2016-12-10',NULL,'会员');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
