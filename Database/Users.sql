--------------------------------------------------------
--  File created - Monday-July-01-2024   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Table USERS
--------------------------------------------------------

  CREATE TABLE "SYSTEM"."USERS" 
   (	"ID" NUMBER GENERATED ALWAYS AS IDENTITY MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE  NOKEEP  NOSCALE , 
	"USERNAME" VARCHAR2(100 BYTE), 
	"FIRSTNAME" VARCHAR2(400 BYTE), 
	"LASTNAME" VARCHAR2(400 BYTE), 
	"EMAIL" VARCHAR2(100 BYTE), 
	"PASSWORD" VARCHAR2(100 BYTE), 
	"LASTLOGIN" DATE
   ) PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
REM INSERTING into SYSTEM.USERS
SET DEFINE OFF;
Insert into SYSTEM.USERS (ID,USERNAME,FIRSTNAME,LASTNAME,EMAIL,PASSWORD,LASTLOGIN) values (2,'reyazul','Miguel Leonardo','Gutierrez','reyazul@gmail.com','JCNERlNlY3JldEtleSR0dXJleTIx',to_date('28-JUN-24','DD-MON-RR'));
Insert into SYSTEM.USERS (ID,USERNAME,FIRSTNAME,LASTNAME,EMAIL,PASSWORD,LASTLOGIN) values (3,'juliana','Juliana Maria','Celenia','reyna@gmail.com','JCNERlNlY3JldEtleSREdWxjZTEyMzQ1Ng==',to_date('28-JUN-24','DD-MON-RR'));
Insert into SYSTEM.USERS (ID,USERNAME,FIRSTNAME,LASTNAME,EMAIL,PASSWORD,LASTLOGIN) values (4,'josefa','Josefina Maria','Marianita Lahoz','josefina@gmail.com','JCNERlNlY3JldEtleSR0dXJleTIx',to_date('28-JUN-24','DD-MON-RR'));
Insert into SYSTEM.USERS (ID,USERNAME,FIRSTNAME,LASTNAME,EMAIL,PASSWORD,LASTLOGIN) values (5,'jose','Jose Jose','Perez de la rosa','PerezDeLaRosa@gmail.com','JCNERlNlY3JldEtleSRkZWxhcm9zYQ==',to_date('28-JUN-24','DD-MON-RR'));
--------------------------------------------------------
--  Constraints for Table USERS
--------------------------------------------------------

  ALTER TABLE "SYSTEM"."USERS" MODIFY ("ID" NOT NULL ENABLE);
