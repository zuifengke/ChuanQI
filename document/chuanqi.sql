/*
Navicat MySQL Data Transfer

Source Server         : 43.227.192.236
Source Server Version : 50128
Source Host           : 43.227.192.236:3306
Source Database       : chuanqi

Target Server Type    : MYSQL
Target Server Version : 50128
File Encoding         : 65001

Date: 2015-11-15 09:25:36
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `tab_buy`
-- ----------------------------
DROP TABLE IF EXISTS `tab_buy`;
CREATE TABLE `tab_buy` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `subtime` datetime DEFAULT NULL,
  `name` varchar(255) CHARACTER SET utf8 DEFAULT NULL,
  `product` varchar(255) CHARACTER SET utf8 DEFAULT NULL,
  `price` float DEFAULT NULL,
  `tel` varchar(255) CHARACTER SET utf8 DEFAULT NULL,
  `place` varchar(255) CHARACTER SET utf8 DEFAULT NULL,
  `sitepath` varchar(255) CHARACTER SET utf8 DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=69 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of tab_buy
-- ----------------------------
INSERT INTO `tab_buy` VALUES ('62', '2015-11-08 23:13:35', '天赐的男人', '太古符文', '30', '15024400999', '全服务器', 'jiaoyi.mir238.com');
INSERT INTO `tab_buy` VALUES ('63', '2015-11-08 23:15:10', '天赐的男人', '太古符文', '30', '15024400999', '全服务器', 'jiaoyi.mir238.com');
INSERT INTO `tab_buy` VALUES ('60', '2015-11-08 16:23:12', '专杀SB', '太古符文', '20', '1131757971', '所有分区', 'jiaoyi.mir238.com');

-- ----------------------------
-- Table structure for `tab_sale`
-- ----------------------------
DROP TABLE IF EXISTS `tab_sale`;
CREATE TABLE `tab_sale` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `subtime` datetime DEFAULT NULL,
  `place` varchar(255) CHARACTER SET utf8 DEFAULT NULL COMMENT '所在分区',
  `name` varchar(255) CHARACTER SET utf8 DEFAULT NULL,
  `product` varchar(255) CHARACTER SET utf8 DEFAULT NULL,
  `price` float DEFAULT NULL,
  `tel` varchar(255) CHARACTER SET utf8 DEFAULT NULL,
  `sitepath` varchar(255) CHARACTER SET utf8 DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=27 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of tab_sale
-- ----------------------------
INSERT INTO `tab_sale` VALUES ('24', '2015-11-13 14:38:59', '风调雨顺1—4区', '演绎传奇', '盛世衣服', '300', '13647058832', 'jiaoyi.mir238.com');

-- ----------------------------
-- Procedure structure for `del_data`
-- ----------------------------
DROP PROCEDURE IF EXISTS `del_data`;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `del_data`()
begin
    delete from tab_buy where tab_buy.subtime < date_sub(curdate(),interval 10 day);
    delete from tab_sale where tab_sale.subtime < date_sub(curdate(),interval 10 day);
end
;;
DELIMITER ;

-- ----------------------------
-- Event structure for `del_event`
-- ----------------------------
DROP EVENT IF EXISTS `del_event`;
DELIMITER ;;
CREATE EVENT `del_event` ON SCHEDULE EVERY 60 HOUR STARTS '2014-01-01 16:18:00' ON COMPLETION NOT PRESERVE ENABLE DO call del_data()
;;
DELIMITER ;
