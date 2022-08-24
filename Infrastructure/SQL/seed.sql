-- MariaDB dump 10.19  Distrib 10.8.4-MariaDB, for Linux (x86_64)
--
-- Host: 172.17.0.4    Database: Foryum
-- ------------------------------------------------------
-- Server version	8.0.29

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Dumping data for table `Sessions`
--

LOCK TABLES `Sessions` WRITE;
/*!40000 ALTER TABLE `Sessions` DISABLE KEYS */;
/*!40000 ALTER TABLE `Sessions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `Votes`
--

LOCK TABLES `Votes` WRITE;
/*!40000 ALTER TABLE `Votes` DISABLE KEYS */;
/*!40000 ALTER TABLE `Votes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `CommunityUser`
--

LOCK TABLES `CommunityUser` WRITE;
/*!40000 ALTER TABLE `CommunityUser` DISABLE KEYS */;
INSERT INTO `CommunityUser` VALUES
(17,1),
(2,3),
(15,3),
(8,4),
(7,5),
(8,5),
(13,5),
(13,6),
(13,9),
(15,9),
(17,9),
(1,10),
(3,10),
(15,10),
(15,13),
(8,14),
(18,14),
(8,15),
(13,15),
(15,15),
(20,15),
(3,16),
(13,16),
(15,16),
(3,17),
(8,17),
(7,18),
(17,18),
(8,19),
(1,20),
(19,20),
(7,21),
(15,22),
(19,22),
(20,22),
(6,23),
(15,23),
(17,23),
(1,24),
(8,24),
(15,24),
(8,26),
(8,27),
(13,28),
(8,30),
(15,30);
/*!40000 ALTER TABLE `CommunityUser` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `Posts`
--

LOCK TABLES `Posts` WRITE;
/*!40000 ALTER TABLE `Posts` DISABLE KEYS */;
INSERT INTO `Posts` VALUES
(1,'2022-05-16 15:31:07','Sharable object-oriented analyzer','Donec diam neque, vestibulum eget, vulputate ut, ultrices vel, augue. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec pharetra, magna vestibulum aliquet ultrices, erat tortor sollicitudin mi, sit amet lobortis sapien sapien non mi. Integer ac neque.\n\nDuis bibendum. Morbi non quam nec dui luctus rutrum. Nulla tellus.\n\nIn sagittis dui vel nisl. Duis ac nibh. Fusce lacus purus, aliquet at, feugiat non, pretium quis, lectus.\n\nSuspendisse potenti. In eleifend quam a odio. In hac habitasse platea dictumst.',26,8),
(2,'2021-11-24 11:48:47','Pre-emptive exuding throughput','',14,18),
(3,'2021-08-24 15:52:15','Ergonomic holistic policy','Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Proin risus. Praesent lectus.\n\nVestibulum quam sapien, varius ut, blandit non, interdum in, ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio. Curabitur convallis.\n\nDuis consequat dui nec nisi volutpat eleifend. Donec ut dolor. Morbi vel lectus in quam fringilla rhoncus.\n\nMauris enim leo, rhoncus sed, vestibulum sit amet, cursus id, turpis. Integer aliquet, massa id lobortis convallis, tortor risus dapibus augue, vel accumsan tellus nisi eu orci. Mauris lacinia sapien quis libero.\n\nNullam sit amet turpis elementum ligula vehicula consequat. Morbi a ipsum. Integer a nibh.',24,1),
(4,'2022-05-26 07:45:06','Up-sized systematic encryption','Maecenas leo odio, condimentum id, luctus nec, molestie sed, justo. Pellentesque viverra pede ac diam. Cras pellentesque volutpat dui.\n\nMaecenas tristique, est et tempus semper, est quam pharetra magna, ac consequat metus sapien ut nunc. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Mauris viverra diam vitae quam. Suspendisse potenti.\n\nNullam porttitor lacus at turpis. Donec posuere metus vitae ipsum. Aliquam non mauris.\n\nMorbi non lectus. Aliquam sit amet diam in magna bibendum imperdiet. Nullam orci pede, venenatis non, sodales sed, tincidunt eu, felis.',10,15),
(5,'2021-11-07 06:45:03','Team-oriented incremental moratorium','Curabitur in libero ut massa volutpat convallis. Morbi odio odio, elementum eu, interdum eu, tincidunt in, leo. Maecenas pulvinar lobortis est.\n\nPhasellus sit amet erat. Nulla tempus. Vivamus in felis eu sapien cursus vestibulum.\n\nProin eu mi. Nulla ac enim. In tempor, turpis nec euismod scelerisque, quam turpis adipiscing lorem, vitae mattis nibh ligula nec sem.\n\nDuis aliquam convallis nunc. Proin at turpis a pede posuere nonummy. Integer non velit.',28,13),
(6,'2021-11-28 03:16:00','Phased analyzing superstructure','Curabitur gravida nisi at nibh. In hac habitasse platea dictumst. Aliquam augue quam, sollicitudin vitae, consectetuer eget, rutrum at, lorem.\n\nInteger tincidunt ante vel ipsum. Praesent blandit lacinia erat. Vestibulum sed magna at nunc commodo placerat.\n\nPraesent blandit. Nam nulla. Integer pede justo, lacinia eget, tincidunt eget, tempus vel, pede.\n\nMorbi porttitor lorem id ligula. Suspendisse ornare consequat lectus. In est risus, auctor sed, tristique in, tempus sit amet, sem.',15,13),
(7,'2022-03-18 03:22:11','Right-sized encompassing portal','',16,15),
(8,'2021-11-11 04:22:01','Phased homogeneous matrices','',10,3),
(9,'2022-03-14 16:04:45','Integrated mission-critical structure','Nullam sit amet turpis elementum ligula vehicula consequat. Morbi a ipsum. Integer a nibh.\n\nIn quis justo. Maecenas rhoncus aliquam lacus. Morbi quis tortor id nulla ultrices aliquet.\n\nMaecenas leo odio, condimentum id, luctus nec, molestie sed, justo. Pellentesque viverra pede ac diam. Cras pellentesque volutpat dui.\n\nMaecenas tristique, est et tempus semper, est quam pharetra magna, ac consequat metus sapien ut nunc. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Mauris viverra diam vitae quam. Suspendisse potenti.',23,15),
(10,'2021-12-22 05:56:09','Multi-channelled non-volatile system engine','Aliquam quis turpis eget elit sodales scelerisque. Mauris sit amet eros. Suspendisse accumsan tortor quis turpis.',10,1),
(11,'2021-11-09 09:03:00','Inverse well-modulated definition','Praesent blandit. Nam nulla. Integer pede justo, lacinia eget, tincidunt eget, tempus vel, pede.\n\nMorbi porttitor lorem id ligula. Suspendisse ornare consequat lectus. In est risus, auctor sed, tristique in, tempus sit amet, sem.',21,7),
(12,'2022-02-06 08:39:46','Optional optimizing policy','In sagittis dui vel nisl. Duis ac nibh. Fusce lacus purus, aliquet at, feugiat non, pretium quis, lectus.\n\nSuspendisse potenti. In eleifend quam a odio. In hac habitasse platea dictumst.\n\nMaecenas ut massa quis augue luctus tincidunt. Nulla mollis molestie lorem. Quisque ut erat.\n\nCurabitur gravida nisi at nibh. In hac habitasse platea dictumst. Aliquam augue quam, sollicitudin vitae, consectetuer eget, rutrum at, lorem.',17,3),
(13,'2022-06-25 05:01:31','Decentralized motivating process improvement','Morbi non lectus. Aliquam sit amet diam in magna bibendum imperdiet. Nullam orci pede, venenatis non, sodales sed, tincidunt eu, felis.\n\nFusce posuere felis sed lacus. Morbi sem mauris, laoreet ut, rhoncus aliquet, pulvinar sed, nisl. Nunc rhoncus dui vel sem.\n\nSed sagittis. Nam congue, risus semper porta volutpat, quam pede lobortis ligula, sit amet eleifend pede libero quis orci. Nullam molestie nibh in lectus.\n\nPellentesque at nulla. Suspendisse potenti. Cras in purus eu magna vulputate luctus.',16,13),
(14,'2021-07-15 15:01:45','Re-contextualized eco-centric superstructure','In quis justo. Maecenas rhoncus aliquam lacus. Morbi quis tortor id nulla ultrices aliquet.\n\nMaecenas leo odio, condimentum id, luctus nec, molestie sed, justo. Pellentesque viverra pede ac diam. Cras pellentesque volutpat dui.',23,17),
(15,'2021-09-21 15:12:44','Monitored bandwidth-monitored capability','Nullam porttitor lacus at turpis. Donec posuere metus vitae ipsum. Aliquam non mauris.\n\nMorbi non lectus. Aliquam sit amet diam in magna bibendum imperdiet. Nullam orci pede, venenatis non, sodales sed, tincidunt eu, felis.\n\nFusce posuere felis sed lacus. Morbi sem mauris, laoreet ut, rhoncus aliquet, pulvinar sed, nisl. Nunc rhoncus dui vel sem.\n\nSed sagittis. Nam congue, risus semper porta volutpat, quam pede lobortis ligula, sit amet eleifend pede libero quis orci. Nullam molestie nibh in lectus.\n\nPellentesque at nulla. Suspendisse potenti. Cras in purus eu magna vulputate luctus.',4,8),
(16,'2022-04-21 09:25:23','Robust regional archive','Nulla ut erat id mauris vulputate elementum. Nullam varius. Nulla facilisi.\n\nCras non velit nec nisi vulputate nonummy. Maecenas tincidunt lacus at velit. Vivamus vel nulla eget eros elementum pellentesque.\n\nQuisque porta volutpat erat. Quisque erat eros, viverra eget, congue eget, semper rutrum, nulla. Nunc purus.',24,15),
(17,'2022-06-15 01:24:54','Object-based reciprocal flexibility','Maecenas ut massa quis augue luctus tincidunt. Nulla mollis molestie lorem. Quisque ut erat.\n\nCurabitur gravida nisi at nibh. In hac habitasse platea dictumst. Aliquam augue quam, sollicitudin vitae, consectetuer eget, rutrum at, lorem.\n\nInteger tincidunt ante vel ipsum. Praesent blandit lacinia erat. Vestibulum sed magna at nunc commodo placerat.\n\nPraesent blandit. Nam nulla. Integer pede justo, lacinia eget, tincidunt eget, tempus vel, pede.\n\nMorbi porttitor lorem id ligula. Suspendisse ornare consequat lectus. In est risus, auctor sed, tristique in, tempus sit amet, sem.',1,17),
(18,'2022-07-03 23:19:47','Function-based directional workforce','',13,15),
(19,'2021-08-03 13:55:21','Streamlined neutral portal','',9,17),
(20,'2022-06-30 07:24:46','Streamlined incremental hub','Quisque id justo sit amet sapien dignissim vestibulum. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla dapibus dolor vel est. Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros.\n\nVestibulum ac est lacinia nisi venenatis tristique. Fusce congue, diam id ornare imperdiet, sapien urna pretium nisl, ut volutpat sapien arcu sed augue. Aliquam erat volutpat.',30,8),
(21,'2021-11-23 02:22:55','Object-based multi-tasking local area network','',3,15),
(22,'2021-08-16 14:17:13','Intuitive asymmetric concept','Proin leo odio, porttitor id, consequat in, consequat ut, nulla. Sed accumsan felis. Ut at dolor quis odio consequat varius.',22,19),
(23,'2021-08-27 23:47:17','Mandatory static attitude','Fusce posuere felis sed lacus. Morbi sem mauris, laoreet ut, rhoncus aliquet, pulvinar sed, nisl. Nunc rhoncus dui vel sem.\n\nSed sagittis. Nam congue, risus semper porta volutpat, quam pede lobortis ligula, sit amet eleifend pede libero quis orci. Nullam molestie nibh in lectus.\n\nPellentesque at nulla. Suspendisse potenti. Cras in purus eu magna vulputate luctus.\n\nCum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vivamus vestibulum sagittis sapien. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.',3,2),
(24,'2022-03-27 00:27:35','Persistent incremental superstructure','',27,8),
(25,'2022-07-06 22:35:50','Synergized bandwidth-monitored benchmark','Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vivamus vestibulum sagittis sapien. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.\n\nEtiam vel augue. Vestibulum rutrum rutrum neque. Aenean auctor gravida sem.\n\nPraesent id massa id nisl venenatis lacinia. Aenean sit amet justo. Morbi ut odio.',20,1),
(26,'2021-08-22 00:26:31','Future-proofed transitional utilisation','Nullam porttitor lacus at turpis. Donec posuere metus vitae ipsum. Aliquam non mauris.',5,7),
(27,'2021-08-19 01:07:26','Cross-group asynchronous portal','',5,13),
(28,'2021-08-25 21:04:56','Reverse-engineered zero administration attitude','Quisque porta volutpat erat. Quisque erat eros, viverra eget, congue eget, semper rutrum, nulla. Nunc purus.',16,3),
(29,'2022-07-02 16:23:57','Sharable background service-desk','Fusce posuere felis sed lacus. Morbi sem mauris, laoreet ut, rhoncus aliquet, pulvinar sed, nisl. Nunc rhoncus dui vel sem.\n\nSed sagittis. Nam congue, risus semper porta volutpat, quam pede lobortis ligula, sit amet eleifend pede libero quis orci. Nullam molestie nibh in lectus.\n\nPellentesque at nulla. Suspendisse potenti. Cras in purus eu magna vulputate luctus.\n\nCum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vivamus vestibulum sagittis sapien. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.\n\nEtiam vel augue. Vestibulum rutrum rutrum neque. Aenean auctor gravida sem.',15,20),
(30,'2022-03-15 10:56:34','Front-line mission-critical circuit','',20,19),
(31,'2021-10-15 20:54:51','Networked solution-oriented budgetary management','',18,17),
(32,'2021-12-01 13:44:34','Digitized bandwidth-monitored benchmark','In hac habitasse platea dictumst. Etiam faucibus cursus urna. Ut tellus.\n\nNulla ut erat id mauris vulputate elementum. Nullam varius. Nulla facilisi.\n\nCras non velit nec nisi vulputate nonummy. Maecenas tincidunt lacus at velit. Vivamus vel nulla eget eros elementum pellentesque.\n\nQuisque porta volutpat erat. Quisque erat eros, viverra eget, congue eget, semper rutrum, nulla. Nunc purus.\n\nPhasellus in felis. Donec semper sapien a libero. Nam dui.',30,15),
(33,'2021-09-30 10:14:20','Compatible incremental project','',15,15),
(34,'2022-01-31 19:45:33','Mandatory motivating array','',18,7),
(35,'2021-10-19 09:18:56','Up-sized zero administration attitude','',22,15),
(36,'2022-04-22 07:59:17','Up-sized incremental instruction set','Integer tincidunt ante vel ipsum. Praesent blandit lacinia erat. Vestibulum sed magna at nunc commodo placerat.\n\nPraesent blandit. Nam nulla. Integer pede justo, lacinia eget, tincidunt eget, tempus vel, pede.',9,15),
(37,'2022-07-01 03:18:21','Centralized user-facing standardization','',22,20),
(38,'2022-06-18 22:58:28','Reactive optimal portal','',14,8),
(39,'2021-11-27 09:11:09','Up-sized interactive productivity','Nam ultrices, libero non mattis pulvinar, nulla pede ullamcorper augue, a suscipit nulla elit ac nulla. Sed vel enim sit amet nunc viverra dapibus. Nulla suscipit ligula in lacus.\n\nCurabitur at ipsum ac tellus semper interdum. Mauris ullamcorper purus sit amet nulla. Quisque arcu libero, rutrum ac, lobortis vel, dapibus at, diam.',19,8),
(40,'2021-11-27 22:50:24','Focused eco-centric instruction set','Aenean lectus. Pellentesque eget nunc. Donec quis orci eget orci vehicula condimentum.\n\nCurabitur in libero ut massa volutpat convallis. Morbi odio odio, elementum eu, interdum eu, tincidunt in, leo. Maecenas pulvinar lobortis est.\n\nPhasellus sit amet erat. Nulla tempus. Vivamus in felis eu sapien cursus vestibulum.\n\nProin eu mi. Nulla ac enim. In tempor, turpis nec euismod scelerisque, quam turpis adipiscing lorem, vitae mattis nibh ligula nec sem.\n\nDuis aliquam convallis nunc. Proin at turpis a pede posuere nonummy. Integer non velit.',17,3),
(41,'2022-03-14 11:03:08','User-friendly 5th generation moderator','Pellentesque at nulla. Suspendisse potenti. Cras in purus eu magna vulputate luctus.\n\nCum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vivamus vestibulum sagittis sapien. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.',4,8),
(42,'2021-07-27 05:10:50','Profound solution-oriented matrices','',9,13),
(43,'2021-12-30 20:39:07','Organized coherent service-desk','Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vivamus vestibulum sagittis sapien. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.\n\nEtiam vel augue. Vestibulum rutrum rutrum neque. Aenean auctor gravida sem.\n\nPraesent id massa id nisl venenatis lacinia. Aenean sit amet justo. Morbi ut odio.',24,8),
(44,'2021-11-17 01:05:26','Centralized multimedia frame','',21,7),
(45,'2022-06-20 09:51:05','Versatile empowering capacity','Nam ultrices, libero non mattis pulvinar, nulla pede ullamcorper augue, a suscipit nulla elit ac nulla. Sed vel enim sit amet nunc viverra dapibus. Nulla suscipit ligula in lacus.\n\nCurabitur at ipsum ac tellus semper interdum. Mauris ullamcorper purus sit amet nulla. Quisque arcu libero, rutrum ac, lobortis vel, dapibus at, diam.',17,3),
(46,'2022-01-16 18:24:53','Fundamental value-added flexibility','',23,6),
(47,'2022-01-14 04:32:20','Implemented multi-tasking knowledge user','Cras mi pede, malesuada in, imperdiet et, commodo vulputate, justo. In blandit ultrices enim. Lorem ipsum dolor sit amet, consectetuer adipiscing elit.\n\nProin interdum mauris non ligula pellentesque ultrices. Phasellus id sapien in sapien iaculis congue. Vivamus metus arcu, adipiscing molestie, hendrerit at, vulputate vitae, nisl.\n\nAenean lectus. Pellentesque eget nunc. Donec quis orci eget orci vehicula condimentum.\n\nCurabitur in libero ut massa volutpat convallis. Morbi odio odio, elementum eu, interdum eu, tincidunt in, leo. Maecenas pulvinar lobortis est.\n\nPhasellus sit amet erat. Nulla tempus. Vivamus in felis eu sapien cursus vestibulum.',5,8),
(48,'2022-03-16 05:21:39','Enhanced intermediate installation','',6,13),
(49,'2021-08-16 04:23:14','Profound impactful definition','Curabitur at ipsum ac tellus semper interdum. Mauris ullamcorper purus sit amet nulla. Quisque arcu libero, rutrum ac, lobortis vel, dapibus at, diam.',17,8),
(50,'2022-04-10 11:13:14','Cloned homogeneous encoding','Duis aliquam convallis nunc. Proin at turpis a pede posuere nonummy. Integer non velit.\n\nDonec diam neque, vestibulum eget, vulputate ut, ultrices vel, augue. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec pharetra, magna vestibulum aliquet ultrices, erat tortor sollicitudin mi, sit amet lobortis sapien sapien non mi. Integer ac neque.',15,8);
/*!40000 ALTER TABLE `Posts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `Communities`
--

LOCK TABLES `Communities` WRITE;
/*!40000 ALTER TABLE `Communities` DISABLE KEYS */;
INSERT INTO `Communities` VALUES
(1,'2022-03-29 08:50:04','imperdiet','Compatible scalable forecast',1),
(2,'2022-06-04 03:37:16','aliquet','Team-oriented 24 hour parallelism',2),
(3,'2022-06-15 06:26:17','maecenas','Triple-buffered tangible product',3),
(6,'2021-07-21 12:48:02','libero','Open-source human-resource infrastructure',6),
(7,'2022-05-01 03:19:10','orci','Cross-group bifurcated time-frame',7),
(8,'2021-09-16 15:04:55','id','Stand-alone mission-critical productivity',8),
(13,'2022-04-17 22:27:48','pede','User-centric regional utilisation',13),
(15,'2021-11-12 00:03:01','velit','Devolved analyzing interface',15),
(17,'2022-06-12 09:39:49','suspendisse','Vision-oriented 3rd generation application',17),
(18,'2022-03-25 21:27:53','vulputate','Fundamental next generation challenge',18),
(19,'2022-04-04 05:13:25','integer','Visionary encompassing archive',19),
(20,'2022-03-30 11:12:39','pellentesque','Multi-tiered fault-tolerant help-desk',20),
(21,'2021-08-22 01:00:03','nunc','Compatible mission-critical solution',21),
(24,'2022-05-02 02:08:01','posuere','Cross-group mobile monitoring',24),
(25,'2021-08-25 07:54:04','odio','Profound national ability',25),
(27,'2022-03-29 05:31:37','sit','Synchronised contextually-based system engine',27),
(28,'2021-11-20 12:14:07','nibh','Persevering grid-enabled orchestration',28),
(29,'2022-02-07 10:16:07','amet','Virtual intangible installation',29),
(30,'2022-03-19 17:35:15','enim','Public-key national orchestration',30),
(32,'2022-01-27 14:02:57','mauris','Public-key transitional implementation',32),
(33,'2021-12-26 16:26:49','cursus','Devolved bi-directional success',33),
(34,'2021-12-16 02:54:52','dapibus','Implemented bottom-line neural-net',34),
(35,'2021-12-03 21:59:12','sollicitudin','Decentralized explicit artificial intelligence',35),
(36,'2022-03-11 11:46:04','euismod','Team-oriented web-enabled portal',36),
(37,'2022-06-02 16:21:32','mattis','Total stable middleware',37),
(38,'2022-01-01 09:31:16','erat','Open-architected tangible throughput',38),
(39,'2021-08-05 03:43:31','in','Managed systemic matrix',39),
(40,'2022-02-25 18:32:40','pretium','Function-based fresh-thinking emulation',40),
(41,'2022-04-11 22:32:29','semper','Organic non-volatile pricing structure',41),
(42,'2022-04-08 19:04:19','volutpat','Advanced user-facing interface',42),
(43,'2022-05-25 02:47:36','quisque','Down-sized 24/7 matrices',43),
(44,'2021-12-16 02:02:39','interdum','Right-sized bifurcated moratorium',44),
(45,'2022-06-02 14:55:39','risus','Adaptive directional help-desk',45),
(46,'2021-07-28 12:15:31','bibendum','Exclusive discrete array',46),
(47,'2021-08-18 05:28:36','ultrices','Synergized high-level instruction set',47),
(49,'2022-03-26 11:01:42','habitasse','Realigned clear-thinking open architecture',49),
(50,'2022-02-28 11:45:59','vitae','Vision-oriented national protocol',50);
/*!40000 ALTER TABLE `Communities` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `PostMedias`
--

LOCK TABLES `PostMedias` WRITE;
/*!40000 ALTER TABLE `PostMedias` DISABLE KEYS */;
/*!40000 ALTER TABLE `PostMedias` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `Users`
--

LOCK TABLES `Users` WRITE;
/*!40000 ALTER TABLE `Users` DISABLE KEYS */;
INSERT INTO `Users` VALUES
(1,'2021-09-30 23:42:11','esparshutt0','mdikes0@dropbox.com','qzKtk7AppBrD','Portugal',NULL,'u5mPFVj'),
(2,'2022-01-20 00:25:36','amacsween1','aaffron1@elegantthemes.com','h77qXFgU','Venezuela',NULL,'NvxAJUBY59ha'),
(3,'2021-12-01 15:09:06','tmcinnerny2','kboulstridge2@google.com.hk','TUOElSmpz1k','Serbia',NULL,'97QP3IVtcn'),
(4,'2021-09-28 15:42:23','koffen3','ldelloyd3@scientificamerican.com','mCWdqk','Honduras',NULL,'8jU8iXLrHLSC'),
(5,'2022-07-06 14:49:27','mbarniss4','seustice4@prlog.org','9VYTdnxJ','Argentina',NULL,'3ObZDqw7o'),
(6,'2021-08-01 07:29:37','thallibone5','eminerdo5@meetup.com','YqKn2AuEFi','Argentina',NULL,'PydXMKn4M'),
(7,'2021-11-19 15:09:11','bimrie6','mgouch6@harvard.edu','UXgLCus','China',NULL,'8vT4vDI0lIiO'),
(8,'2021-10-29 15:16:03','gbraunston7','vivers7@accuweather.com','RzTup3','Poland',NULL,'4Aba9Dayp8L'),
(9,'2022-03-19 10:30:53','braybould8','kbroderick8@uol.com.br','XBElH9ym','Mauritius',NULL,'SHy71eM'),
(10,'2021-08-14 17:55:00','kduckhouse9','bprobate9@techcrunch.com','WPvCWH432eC','France',NULL,'YzMqhwX9Z'),
(11,'2022-04-05 02:21:21','dhedylstonea','hpicka@360.cn','SeUt9e2','Indonesia',NULL,'EvsrukEKCc'),
(12,'2022-02-24 05:20:25','aarthanb','kedlyneb@bigcartel.com','Npzvtee','Costa Rica',NULL,'CbVGBmwu'),
(13,'2022-02-09 13:28:30','wfickenc','mpennellsc@homestead.com','kej2EKbjnKZ','Indonesia',NULL,'VC9zJ3ypYF7v'),
(14,'2021-10-18 13:55:47','rdrid','ssolond@utexas.edu','yrSbrGtMW8MH','United States',NULL,'eClIYn5yYy'),
(15,'2021-08-18 00:07:48','kpanimane','mnortherne@si.edu','Hfa6Pa8','Poland',NULL,'hMZHlnEz9dE'),
(16,'2021-12-22 13:13:37','mzapaterof','mwimmerf@wordpress.com','fiyFfas7W','Czech Republic',NULL,'hTpn2x'),
(17,'2022-01-24 14:35:56','cweedong','svicarg@posterous.com','CZC98Uh1','Indonesia',NULL,'M44GA9onV6'),
(18,'2021-08-17 19:37:46','rstrongmanh','cdundridgeh@bluehost.com','Hl8cpvYOSfD','Israel',NULL,'eG7YRu7z'),
(19,'2022-03-03 08:50:18','ctumilsoni','pguarnieri@guardian.co.uk','hMPz9lb2Apn','Iran',NULL,'KQ6SR8'),
(20,'2021-08-13 23:04:49','livakhnoj','fwabbj@cnbc.com','K9tJhj','Philippines',NULL,'iw6Hr3OjhN'),
(21,'2022-04-13 00:17:21','kpeglerk','ghopkinsk@state.gov','veljI3','China',NULL,'TnDdch'),
(22,'2021-08-24 14:33:37','lkinnerleyl','oblampeyl@google.ru','OAsvDvl','Portugal',NULL,'wCYawG045Sd'),
(23,'2022-02-19 01:58:18','rkohnm','kmansfordm@china.com.cn','0pv3saHEVeA','Poland',NULL,'A6BCHC'),
(24,'2021-09-27 15:47:10','jboxen','dstearsn@webmd.com','bnzNt6S','China',NULL,'Kyj5tK5xM'),
(25,'2021-07-25 16:01:57','jgibbenso','lmadelino@google.co.jp','4m2O3NufdR','Montenegro',NULL,'X3z2IM'),
(26,'2022-01-07 18:41:02','cgoodbournp','gchristaeasp@amazon.co.jp','CwN7xhfwvJ','Russia',NULL,'ZToEA7'),
(27,'2022-01-29 17:18:58','ckettlesq','ctayloq@paginegialle.it','dmVzxLBpCn4E','China',NULL,'3YorakH'),
(28,'2021-12-30 07:29:53','rberrisfordr','smacklamr@howstuffworks.com','MbfP6o','China',NULL,'csdidX'),
(29,'2021-07-31 07:48:39','tzottolis','ljoinceys@washingtonpost.com','SeNlBCdzd5','Albania',NULL,'HSH1sWN6D'),
(30,'2021-09-22 01:12:17','pshellcrosst','lglashbyt@nature.com','qYZc7IW7VSA','Pakistan',NULL,'KeqcYlVSQup'),
(31,'2022-01-08 11:10:44','amalcolmu','gcubleyu@privacy.gov.au','FQISKRN1N','Nigeria',NULL,'bVpFp8nQ'),
(32,'2021-09-26 07:36:15','awagstaffev','mpargentv@fda.gov','wuXTfJ04X','Indonesia',NULL,'RoXYTJwb'),
(33,'2021-12-04 03:31:10','respinhaw','chogbenw@unesco.org','w8yO13h95t','Hungary',NULL,'sFvn45'),
(34,'2021-11-22 18:04:50','ihanmorex','lrannaldx@networksolutions.com','y4KLFyy','Indonesia',NULL,'Uvz8idQZAM4h'),
(35,'2021-10-27 17:34:15','dbeathemy','yfoynesy@bigcartel.com','QY1frIuXPY6','Sweden',NULL,'VutAaFm'),
(36,'2021-10-16 23:29:22','twitherupz','psnookz@omniture.com','Y7UqwQo','Ukraine',NULL,'LOoOpZd'),
(37,'2022-05-28 20:53:19','mdiggin10','lspruce10@epa.gov','bJ1LxBdWv','Niger',NULL,'YUSrylNnETD'),
(38,'2022-03-27 15:38:20','sboller11','cgrandison11@wikia.com','Yu8XisA','France',NULL,'4fIljSjJg'),
(39,'2021-12-23 22:12:12','ilopez12','rdashkov12@devhub.com','vfb0badw','China',NULL,'afZNXi3qslM2'),
(40,'2022-03-11 13:08:57','hnutbrown13','cmcreath13@csmonitor.com','Qa51A0','Japan',NULL,'m4rUwx'),
(41,'2021-10-30 19:44:06','rmullender14','cbrearley14@google.com.hk','ONENnwRHFmWs','Mongolia',NULL,'Pt4BSRowL'),
(42,'2021-08-25 23:37:57','gkeattch15','ygellibrand15@unicef.org','qNw0mIxeeV0','Mexico',NULL,'hBtl6mo4'),
(43,'2021-10-27 05:07:41','mkender16','lpossa16@sciencedirect.com','dGxlBdsbo1S','Indonesia',NULL,'EvmykmNlVt'),
(44,'2022-05-22 21:13:44','akrol17','ibasezzi17@cbslocal.com','LJiEmheq','Indonesia',NULL,'mOzKzs1r'),
(45,'2022-06-22 13:10:23','mgudgen18','rgiovannardi18@cyberchimps.com','uWfHPHOWWNv','China',NULL,'u4qVAA2UhQV'),
(46,'2021-12-30 04:18:26','kfilipyev19','clanceley19@deliciousdays.com','BgGZNbKYf','Syria',NULL,'dy3ogJJt5DtD'),
(47,'2021-09-28 07:15:12','mdoble1a','wgebb1a@huffingtonpost.com','KcWf8Ih0','Russia',NULL,'zISRszeu'),
(48,'2022-01-07 11:15:45','spindell1b','ekennett1b@cisco.com','Rm0eE3sGJPD','Indonesia',NULL,'wyQVVs'),
(49,'2022-03-27 08:10:13','smayall1c','kgirvin1c@engadget.com','PPczXdrU','Venezuela',NULL,'sMcJ2VyUmBFv'),
(50,'2021-10-01 00:22:26','nrickett1d','dramsell1d@opensource.org','80Be8PW','Paraguay',NULL,'QAbvnJD2PS'),
(51,'2022-04-09 10:31:28','adecruse1e','esallier1e@fastcompany.com','EfjEsz','Greece',NULL,'dHLXlKNcmQL2'),
(52,'2022-02-21 05:56:50','escrine1f','gsains1f@acquirethisname.com','rajjzzGX','Peru',NULL,'uCZa0wDEBJ'),
(53,'2022-01-15 05:49:13','wmillmore1g','vtomsa1g@soup.io','0vk6pVGV','Russia',NULL,'VXmOSREbhr'),
(54,'2022-04-10 06:54:08','cpeace1h','bmcgraw1h@nyu.edu','g8IG4lUOpxR','Finland',NULL,'Ow68XUp5'),
(55,'2021-08-30 01:09:02','aheadingham1i','ntuxill1i@dropbox.com','Gz4vrqIs48','Brazil',NULL,'KcvPsM1R00MQ'),
(56,'2021-10-06 04:15:37','dpollett1j','dkitchingham1j@ft.com','PG1Ytjf','China',NULL,'l9GBpS4EuqH'),
(57,'2022-01-27 07:54:26','aferney1k','ktweddell1k@jigsy.com','GDYFf1w4IWpd','Philippines',NULL,'GS0DdfjhW7'),
(58,'2022-02-21 03:32:56','nmcaline1l','cesposi1l@indiatimes.com','RVkiVuCLv6','El Salvador',NULL,'4kXSxVIEqkU'),
(59,'2021-09-15 09:47:03','gschirok1m','mgonzales1m@nifty.com','4izDdQoIAB90','Japan',NULL,'6XeAkroQc9IT'),
(60,'2022-01-12 22:13:19','hbysouth1n','bcongdon1n@yelp.com','1jvItCK4NYc','Portugal',NULL,'UZwvyZBgFb'),
(61,'2022-06-27 07:03:55','omundall1o','tcowlin1o@gov.uk','s5gd7x','Russia',NULL,'WKjfRal8bt'),
(62,'2022-01-17 01:28:09','dnewlin1p','sitzcovichch1p@unblog.fr','j2J3qV','Panama',NULL,'bNgAkOzO'),
(63,'2022-01-02 00:32:51','amaidens1q','mwadesworth1q@va.gov','4ac5DldjJdVO','Indonesia',NULL,'8R1m2Ce'),
(64,'2022-07-09 04:57:54','sbeveredge1r','mswanger1r@addthis.com','KU1097','Portugal',NULL,'uj03nj8M'),
(65,'2021-08-27 20:12:49','fsinnott1s','mtuffs1s@creativecommons.org','BdANWG','Croatia',NULL,'A4DHZ2SsSs'),
(66,'2022-05-26 23:33:45','kdeamaya1t','lsoff1t@last.fm','kGjZyWIlS','China',NULL,'VSYf0JT5'),
(67,'2022-01-08 19:17:01','tfrandsen1u','yreadwood1u@reddit.com','xsRHczNA','Malaysia',NULL,'CsbGgcluSnv'),
(68,'2021-11-20 14:47:23','hfernando1v','enewvell1v@spiegel.de','qckHrc','Indonesia',NULL,'gmkT0w7szz'),
(69,'2022-01-10 00:58:56','nsesser1w','cmustin1w@opera.com','GqAolBFGb','Indonesia',NULL,'CCsv33F8560'),
(70,'2021-07-11 07:04:35','hcraigmyle1x','btreske1x@163.com','5teR7r','Poland',NULL,'Mi9pCW'),
(71,'2021-10-18 02:44:13','ldutteridge1y','jlongford1y@nih.gov','1ZR3gf','Taiwan',NULL,'B4k0kHP0g'),
(72,'2021-09-23 16:44:13','eharling1z','pphilpot1z@tripadvisor.com','7pp3ooF','Ukraine',NULL,'kwLnqxHY'),
(73,'2021-11-27 18:29:20','dmatiasek20','eanderton20@prlog.org','h0m9hKK3w','Nepal',NULL,'o2AeMCx'),
(74,'2022-03-05 11:58:56','mshorey21','gmishow21@gnu.org','cDZ8w4PYTP6','Bangladesh',NULL,'NmYiKJQ'),
(75,'2021-09-30 13:20:42','jjobson22','blaterza22@jiathis.com','JRWnts0b','Yemen',NULL,'wkjTYa'),
(76,'2022-04-24 11:17:57','lwigglesworth23','mreddell23@ow.ly','Vqr5PPn','Colombia',NULL,'hu29zqmp'),
(77,'2021-09-22 11:43:16','egabey24','mfindley24@theglobeandmail.com','Q01LhRvo','France',NULL,'yck1lPr8MhUS'),
(78,'2022-02-07 13:16:53','cbrixey25','cgraffham25@vkontakte.ru','hARAM3FKFB','France',NULL,'lMPoG1JEBfES'),
(79,'2021-10-17 00:50:02','rbrewerton26','veykelbosch26@godaddy.com','PphU7IhsRh','China',NULL,'RpZRVMdF41IX'),
(80,'2022-02-06 04:36:28','rboolsen27','mockland27@biblegateway.com','C2ngXp6M4','China',NULL,'vjHuPbHOiF'),
(81,'2022-02-15 15:05:58','aortelt28','tguest28@stumbleupon.com','E7wafVSK','Philippines',NULL,'K5c0ePPk'),
(82,'2021-09-25 09:19:42','asidgwick29','gjaggs29@dailymotion.com','11W1QVmaxH','Vietnam',NULL,'JvqMPZBUft6a'),
(83,'2022-04-14 12:21:59','lcave2a','kluberti2a@weibo.com','TrfWJMGd','China',NULL,'9zluEX'),
(84,'2022-02-18 08:43:21','areedy2b','sodonoghue2b@jigsy.com','U3UtnN9m3dbZ','China',NULL,'wH2FlU'),
(85,'2022-02-08 17:36:11','oglowacki2c','achatelain2c@patch.com','bJAwrSM4S','China',NULL,'9XsxEW'),
(86,'2022-03-09 00:48:53','smclaughlin2d','nblackly2d@cnet.com','fiOqv8h','Indonesia',NULL,'WVmiprWM'),
(87,'2021-11-20 11:56:30','akuna2e','emartensen2e@hostgator.com','h3DVSbWc8Y7','China',NULL,'um9bem9ElQNX'),
(88,'2021-12-06 00:07:26','syerbury2f','ihambidge2f@skype.com','YxPKuO','Sri Lanka',NULL,'hECtCj'),
(89,'2021-10-10 18:34:42','sricarde2g','emorforth2g@smh.com.au','ifAW2Lu8','Philippines',NULL,'aNQT3mBQ'),
(90,'2021-11-05 16:08:25','bmcgourty2h','rmackaile2h@wikispaces.com','7LJdnhM','France',NULL,'h8FnPSx9dh'),
(91,'2021-09-03 17:27:41','balwell2i','wmacilwrick2i@webeden.co.uk','A6evYb49','Tunisia',NULL,'yoXjVsIcmB'),
(92,'2021-07-15 05:58:16','mprewer2j','nbragg2j@mapquest.com','XwbUDJ1az','China',NULL,'kk6JapIBfP'),
(93,'2022-04-05 11:42:24','zmeechan2k','lwild2k@house.gov','6bYvuKKk','Czech Republic',NULL,'KTnBhwj94Q2'),
(94,'2021-12-03 21:20:57','gcaskey2l','kthomazin2l@youku.com','GEfpZHgwjp','Sweden',NULL,'pqFPHTJwhVUx'),
(95,'2021-09-26 03:35:42','kmatura2m','bfreemantle2m@paginegialle.it','rEsjf0INlP','Argentina',NULL,'f9lPBzg5XZ'),
(96,'2022-03-30 00:36:35','rgogerty2n','ehassett2n@miibeian.gov.cn','3Mxq3AfAKeXT','Philippines',NULL,'3BtrLYA'),
(97,'2022-05-14 13:10:33','ajoutapaitis2o','checkner2o@macromedia.com','yw4JiTcXyIxB','China',NULL,'Z0BZc4'),
(98,'2022-06-22 07:52:48','rquinney2p','vgrimme2p@google.es','bSEZ9ohouy','Kuwait',NULL,'SvSw77'),
(99,'2021-09-13 20:59:31','mshortall2q','wsrutton2q@unblog.fr','dLjLPvCI4Ofk','Indonesia',NULL,'byc8ppvvRm68'),
(100,'2021-09-04 14:08:58','aclineck2r','lhugh2r@themeforest.net','lg6JZBG','Barbados',NULL,'PVVYF2YmaICg');
/*!40000 ALTER TABLE `Users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `Comments`
--

LOCK TABLES `Comments` WRITE;
/*!40000 ALTER TABLE `Comments` DISABLE KEYS */;
/*!40000 ALTER TABLE `Comments` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-08-23 21:47:33
