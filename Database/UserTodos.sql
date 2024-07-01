--------------------------------------------------------
--  File created - Monday-July-01-2024   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Table USERTODOS
--------------------------------------------------------

  CREATE TABLE "SYSTEM"."USERTODOS" 
   (	"ID" NUMBER(*,0) GENERATED ALWAYS AS IDENTITY MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE  NOKEEP  NOSCALE , 
	"USERID" NUMBER(*,0), 
	"TASK" VARCHAR2(200 BYTE), 
	"DESCRIPTION" VARCHAR2(400 BYTE), 
	"ISDONE" NUMBER(1,0)
   ) PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
REM INSERTING into SYSTEM.USERTODOS
SET DEFINE OFF;
Insert into SYSTEM.USERTODOS (ID,USERID,TASK,DESCRIPTION,ISDONE) values (1,2,'Tomar curso de inicializacion','Tomar curso de inicializacion en la inteligencia artificial',0);
Insert into SYSTEM.USERTODOS (ID,USERID,TASK,DESCRIPTION,ISDONE) values (2,0,'sample','demo',0);
Insert into SYSTEM.USERTODOS (ID,USERID,TASK,DESCRIPTION,ISDONE) values (3,2,'Charlar con los empleados','Charlar con los empleados de simetrica consulting',0);
Insert into SYSTEM.USERTODOS (ID,USERID,TASK,DESCRIPTION,ISDONE) values (4,2,'Crear calendario de actividades','Necesario para la planificacion',0);
--------------------------------------------------------
--  Constraints for Table USERTODOS
--------------------------------------------------------

  ALTER TABLE "SYSTEM"."USERTODOS" MODIFY ("ID" NOT NULL ENABLE);
