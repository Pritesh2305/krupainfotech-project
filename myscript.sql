CREATE TABLE mstusertype(
	[rid] [bigint] IDENTITY(1,1) primary key,
	[utcode] [nvarchar](50) NULL,
	[utname] [nvarchar](500) NULL,
	[utdesc] [nvarchar](max) NULL,
	[arid] [bigint] NULL,
	[adatetime] [datetime] NULL,
	[erid] [bigint] NULL,
	[edatetime] [datetime] NULL,
	[drid] [bigint] NULL,
	[ddatetime] [datetime] NULL,
	[delflg] [bit] NULL,
)
GO
CREATE TABLE mstusers(
	[rid] [bigint] IDENTITY(1,1) primary key,
	[usercode] [nvarchar](50) NULL,
	[firstname] [nvarchar](50) NULL,
	[lastname] [nvarchar](50) NULL,
	[username] [nvarchar](500) NULL,
	[userpassword] [nvarchar](500) NULL,
	[usertyperid] [bigint] NULL,
	[arid] [bigint] NULL,
	[adatetime] [datetime] NULL,
	[erid] [bigint] NULL,
	[edatetime] [datetime] NULL,
	[drid] [bigint] NULL,
	[ddatetime] [datetime] NULL,
	[delflg] [bit] NULL,
)
GO

create procedure usp_getlogininfo(@p_username nvarchar(500),@p_userpassword nvarchar(500))
as begin

if exists (select * from mstusers where isnull(mstusers.delflg,0)=0 and mstusers.username=@p_username and mstusers.userpassword=@p_userpassword)
	begin
	select mstusers.rid,mstusers.usercode,firstname,lastname,username,mstusers.usertyperid, 	
			usertype=(select utname from mstusertype where mstusertype.rid=mstusers.usertyperid),
	'' as token
	from mstusers 
	where isnull(mstusers.delflg,0)=0 and mstusers.username=@p_username and mstusers.userpassword=@p_userpassword
	end
	else
	begin
	select rid,usercode,firstname,lastname,username,usertyperid,'' as usertype,'' as token
	from mstusers where 1=2
	end
end
GO
drop procedure usp_mstuserslist
GO
create procedure usp_mstuserslist
as begin
select mstusers.rid,mstusers.usercode,mstusers.firstname,mstusers.lastname,mstusers.username,
mstusers.userpassword,
mstusers.usertyperid,
mstusers.arid,mstusers.adatetime,mstusers.erid,mstusers.edatetime,mstusers.drid,mstusers.ddatetime,mstusers.delflg
from mstusers
end
GO
drop procedure usp_get_mstuser
GO
create procedure usp_get_mstuser(@p_rid bigint)
as begin
select mstusers.rid,mstusers.usercode,mstusers.firstname,mstusers.lastname,mstusers.username,mstusers.userpassword,mstusers.usertyperid,
mstusers.arid,mstusers.adatetime,mstusers.erid,mstusers.edatetime,mstusers.drid,mstusers.ddatetime,mstusers.delflg
from mstusers where mstusers.rid=@p_rid
end
GO
create table mstcity(
rid bigint IDENTITY(1,1) primary key,
citycode nvarchar(50),
cityname nvarchar(500),
cityremark1 nvarchar(max),
cityremark2 nvarchar(max),	
[arid] [bigint] NULL,
[adatetime] [datetime] NULL,
[erid] [bigint] NULL,
[edatetime] [datetime] NULL,
[drid] [bigint] NULL,
[ddatetime] [datetime] NULL,
[delflg] [bit] NULL
)
GO
create table mststate(
rid bigint IDENTITY(1,1) primary key,
statecode nvarchar(50),
statename nvarchar(500),
stateremark1 nvarchar(max),
stateremark2 nvarchar(max),	
[arid] [bigint] NULL,
[adatetime] [datetime] NULL,
[erid] [bigint] NULL,
[edatetime] [datetime] NULL,
[drid] [bigint] NULL,
[ddatetime] [datetime] NULL,
[delflg] [bit] NULL
)
GO
create table mstcountry(
rid bigint IDENTITY(1,1) primary key,
countrycode nvarchar(50),
countryname nvarchar(500),
countryremark1 nvarchar(max),
countryremark2 nvarchar(max),	
[arid] [bigint] NULL,
[adatetime] [datetime] NULL,
[erid] [bigint] NULL,
[edatetime] [datetime] NULL,
[drid] [bigint] NULL,
[ddatetime] [datetime] NULL,
[delflg] [bit] NULL
)
GO
drop procedure usp_mstcity_add
GO
create PROCEDURE usp_mstcity_add
(
@p_json NVARCHAR(MAX),
@p_retrid BIGINT out,
@p_retval bit out,
@p_reterr NVARCHAR(MAX) out
)
AS
BEGIN
BEGIN TRY
declare @rid bigint
declare @citycode nvarchar(50)
declare @cityname nvarchar(500)
declare @cityremark1 nvarchar(max)
declare @cityremark2 nvarchar(max)
declare @urid bigint

set @p_retrid=0
set @p_reterr=''
set @p_retval=1

SELECT * INTO #temptbl FROM OPENJSON(@p_json)
WITH
(rid bigint '$.rid',citycode nvarchar(50) '$.citycode',cityname nvarchar(500) '$.cityname',
cityremark1 nvarchar(max) '$.cityremark1',cityremark2 nvarchar(max) '$.cityremark2',
urid bigint '$.urid'
)
set @rid = (select rid from #temptbl)
set @citycode = (select citycode from #temptbl)
set @cityname = (select cityname from #temptbl)
set @cityremark1 = (select cityremark1 from #temptbl)
set @cityremark2 = (select cityremark2 from #temptbl)
set @urid = (select urid from #temptbl)

IF EXISTS (SELECT mstcity.citycode FROM mstcity WHERE mstcity.citycode = @citycode and isnull(mstcity.delflg,0)=0)
BEGIN    
    SET @p_retrid=0
	set @p_reterr='PLEASE CHECK, CITYCODE ALREADY EXITS.'
	set @p_retval=0 
	RAISERROR('PLEASE CHECK CITYCODE ALREADY EXITS.',16,1,@citycode);
	
END
ELSE IF EXISTS (SELECT mstcity.cityname FROM mstcity WHERE mstcity.cityname = @cityname and isnull(mstcity.delflg,0)=0)
	BEGIN   
    SET @p_retrid=0
	set @p_reterr='PLEASE CHECK, CITYNAME ALREADY EXITS.'
	set @p_retval=0    
	RAISERROR('PLEASE CHECK CITYNAME ALREADY EXITS.',16,1,@cityname);
END
ELSE
begin
	insert into mstcity (citycode,cityname,cityremark1,cityremark2,arid,adatetime,DELFLG)
	values (@citycode,@cityname,@cityremark1,@cityremark2,@urid,GETDATE(),0)
	set @p_retrid = SCOPE_IDENTITY()
end
set @p_reterr=''
DROP TABLE #temptbl
END TRY
BEGIN CATCH 
	SET @p_retrid=0 
	set @p_reterr=(SELECT ERROR_MESSAGE())
	set @p_retval=0
	DROP TABLE #temptbl
	RETURN
END CATCH
END
GO
drop procedure usp_mstcity_update
GO
CREATE PROCEDURE usp_mstcity_update
(
@p_json NVARCHAR(MAX),
@p_retrid BIGINT out,
@p_retval bit out,
@p_reterr NVARCHAR(MAX) out
)
AS
BEGIN
BEGIN TRY
declare @rid bigint
declare @citycode nvarchar(50)
declare @cityname nvarchar(500)
declare @cityremark1 nvarchar(max)
declare @cityremark2 nvarchar(max)
declare @urid bigint

set @p_retrid=0
set @p_reterr=''
set @p_retval=1

SELECT * INTO #temptbl FROM OPENJSON(@p_json)
WITH
(rid bigint '$.rid',citycode nvarchar(50) '$.citycode',cityname nvarchar(500) '$.cityname',
cityremark1 nvarchar(max) '$.cityremark1',cityremark2 nvarchar(max) '$.cityremark2',
urid bigint '$.urid'
)
set @rid = (select rid from #temptbl)
set @citycode = (select citycode from #temptbl)
set @cityname = (select cityname from #temptbl)
set @cityremark1 = (select cityremark1 from #temptbl)
set @cityremark2 = (select cityremark2 from #temptbl)
set @urid = (select urid from #temptbl)

IF NOT EXISTS (SELECT mstcity.rid FROM mstcity WHERE mstcity.rid = @rid and isnull(mstcity.delflg,0)=0)
BEGIN
	set @p_retrid=0
	set @p_reterr='PLEASE CHECK RECORD NOT EXITS FOR UPDATE.'
	set @p_retval=0    
	RAISERROR('PLEASE CHECK RECORD NOT EXITS FOR UPDATE.',16,1,@cityname);
END
ELSE IF EXISTS (SELECT mstcity.citycode FROM mstcity WHERE mstcity.citycode = @citycode and isnull(mstcity.delflg,0)=0 and isnull(mstcity.rid,0)!=@rid)
BEGIN    
    set @p_retrid=0
	set @p_reterr='PLEASE CHECK, CITYCODE ALREADY EXITS.'
	set @p_retval=0   
	RAISERROR('PLEASE CHECK CITYCODE ALREADY EXITS.',16,1,@citycode);
END
ELSE IF EXISTS (SELECT mstcity.cityname FROM mstcity WHERE mstcity.cityname = @cityname and isnull(mstcity.delflg,0)=0 and isnull(mstcity.rid,0)!=@rid)
BEGIN   
    set @p_retrid=0
	set @p_reterr='PLEASE CHECK, CITYNAME ALREADY EXITS.'
	set @p_retval=0    
	RAISERROR('PLEASE CHECK CITYNAME ALREADY EXITS.',16,1,@cityname);
END
ELSE
begin
	update mstcity 
	set citycode=@citycode,cityname=@cityname,cityremark1=@cityremark1,cityremark2=@cityremark2,
	erid=@urid,edatetime=GETDATE() where rid=@rid	
	set @p_retrid = @rid
end
set @p_reterr=''
DROP TABLE #temptbl
END TRY
BEGIN CATCH 
	set @p_retrid=0 
	set @p_reterr=(SELECT ERROR_MESSAGE())
	set @p_retval=0
	DROP TABLE #temptbl
	RETURN
END CATCH
END
GO
drop procedure usp_mstcity_delete
GO
CREATE PROCEDURE usp_mstcity_delete
(
@p_json NVARCHAR(MAX),
@p_retrid BIGINT out,
@p_retval bit out,
@p_reterr NVARCHAR(MAX) out
)
AS
BEGIN
BEGIN TRY
declare @rid bigint
declare @urid bigint

set @p_retrid=0
set @p_reterr=''
set @p_retval=1

SELECT * INTO #temptbl FROM OPENJSON(@p_json)
WITH
(rid bigint '$.rid',urid bigint '$.urid'
)
set @rid = (select rid from #temptbl)
set @urid = (select urid from #temptbl)
begin
	update mstcity set mstcity.delflg=1,drid=@urid,ddatetime=GETDATE() where mstcity.rid=@rid	
end
set @p_reterr=''
set @p_retrid=@rid
DROP TABLE #temptbl
END TRY
BEGIN CATCH 
	SET @p_retrid=0 
	set @p_reterr=(SELECT ERROR_MESSAGE())
	set @p_retval=0
	DROP TABLE #temptbl
	RETURN
END CATCH
END
GO
create procedure usp_mstcitydetail_list as
begin
select mstcity.rid,mstcity.citycode,mstcity.cityname,mstcity.cityremark1,mstcity.cityremark2,
mstcity.arid,mstcity.adatetime,mstcity.erid,mstcity.edatetime,mstcity.drid,mstcity.ddatetime,mstcity.delflg
from mstcity where isnull(mstcity.delflg,0)=0
order by mstcity.cityname,mstcity.rid
end
GO
create procedure usp_mstcitydetail_all as
begin
select mstcity.rid,mstcity.citycode,mstcity.cityname,mstcity.cityremark1,mstcity.cityremark2,
mstcity.arid,mstcity.adatetime,mstcity.erid,mstcity.edatetime,mstcity.drid,mstcity.ddatetime,mstcity.delflg
from mstcity 
order by mstcity.cityname,mstcity.rid
end
create procedure usp_mstcity_list as
begin
select mstcity.rid,mstcity.citycode,mstcity.cityname,mstcity.cityremark1,mstcity.cityremark2
from mstcity where isnull(mstcity.delflg,0)=0
order by mstcity.cityname,mstcity.rid
end
GO
create procedure usp_mstcity_all as
begin
select mstcity.rid,mstcity.citycode,mstcity.cityname,mstcity.cityremark1,mstcity.cityremark2
from mstcity 
order by mstcity.cityname,mstcity.rid
end
GO
create procedure usp_mstcity_select(@p_rid bigint)
as begin
select 
mstcity.rid,mstcity.citycode,mstcity.cityname,mstcity.cityremark1,mstcity.cityremark2
from mstcity where mstcity.rid=@p_rid and isnull(mstcity.delflg,0)=0
end
GO
drop procedure usp_mststate_add
GO
create PROCEDURE usp_mststate_add
(
@p_json NVARCHAR(MAX),
@p_retrid BIGINT out,
@p_retval bit out,
@p_reterr NVARCHAR(MAX) out
)
AS
BEGIN
BEGIN TRY
declare @rid bigint
declare @statecode nvarchar(50)
declare @statename nvarchar(500)
declare @stateremark1 nvarchar(max)
declare @stateremark2 nvarchar(max)
declare @urid bigint

set @p_retrid=0
set @p_reterr=''
set @p_retval=1

SELECT * INTO #temptbl FROM OPENJSON(@p_json)
WITH
(rid bigint '$.rid',statecode nvarchar(50) '$.statecode',statename nvarchar(500) '$.statename',
stateremark1 nvarchar(max) '$.stateremark1',stateremark2 nvarchar(max) '$.stateremark2',
urid bigint '$.urid'
)
set @rid = (select rid from #temptbl)
set @statecode = (select statecode from #temptbl)
set @statename = (select statename from #temptbl)
set @stateremark1 = (select stateremark1 from #temptbl)
set @stateremark2 = (select stateremark2 from #temptbl)
set @urid = (select urid from #temptbl)

IF EXISTS (SELECT mststate.statecode FROM mststate WHERE mststate.statecode = @statecode and isnull(mststate.delflg,0)=0)
BEGIN    
    SET @p_retrid=0
	set @p_reterr='PLEASE CHECK STATECODE ALREADY EXITS.'
	set @p_retval=0 
	RAISERROR('PLEASE CHECK STATECODE ALREADY EXITS.',16,1,@statecode);
	
END
ELSE IF EXISTS (SELECT mststate.statename FROM mststate WHERE mststate.statename = @statename and isnull(mststate.delflg,0)=0)
	BEGIN   
    SET @p_retrid=0
	set @p_reterr='PLEASE CHECK STATENAME ALREADY EXITS.'
	set @p_retval=0    
	RAISERROR('PLEASE CHECK STATENAME ALREADY EXITS.',16,1,@statename);
END
ELSE
begin
	insert into mststate (statecode,statename,stateremark1,stateremark2,arid,adatetime,DELFLG)
	values (@statecode,@statename,@stateremark1,@stateremark2,@urid,GETDATE(),0)
	set @p_retrid = SCOPE_IDENTITY()
end
set @p_reterr=''
DROP TABLE #temptbl
END TRY
BEGIN CATCH 
	SET @p_retrid=0 
	set @p_reterr=(SELECT ERROR_MESSAGE())
	set @p_retval=0
	DROP TABLE #temptbl
	RETURN
END CATCH
END
GO
drop procedure usp_mststate_update
GO
CREATE PROCEDURE usp_mststate_update
(
@p_json NVARCHAR(MAX),
@p_retrid BIGINT out,
@p_retval bit out,
@p_reterr NVARCHAR(MAX) out
)
AS
BEGIN
BEGIN TRY
declare @rid bigint
declare @statecode nvarchar(50)
declare @statename nvarchar(500)
declare @stateremark1 nvarchar(max)
declare @stateremark2 nvarchar(max)
declare @urid bigint

set @p_retrid=0
set @p_reterr=''
set @p_retval=1

SELECT * INTO #temptbl FROM OPENJSON(@p_json)
WITH
(rid bigint '$.rid',statecode nvarchar(50) '$.statecode',statename nvarchar(500) '$.statename',
stateremark1 nvarchar(max) '$.stateremark1',stateremark2 nvarchar(max) '$.stateremark2',
urid bigint '$.urid'
)
set @rid = (select rid from #temptbl)
set @statecode = (select statecode from #temptbl)
set @statename = (select statename from #temptbl)
set @stateremark1 = (select stateremark1 from #temptbl)
set @stateremark2 = (select stateremark2 from #temptbl)
set @urid = (select urid from #temptbl)

IF NOT EXISTS (SELECT mststate.rid FROM mststate WHERE mststate.rid = @rid and isnull(mststate.delflg,0)=0)
BEGIN
	set @p_retrid=0
	set @p_reterr='PLEASE CHECK RECORD NOT EXITS FOR UPDATE.'
	set @p_retval=0    
	RAISERROR('PLEASE CHECK RECORD NOT EXITS FOR UPDATE.',16,1,@statename);
END
ELSE IF EXISTS (SELECT mststate.statecode FROM mststate WHERE mststate.statecode = @statecode and isnull(mststate.delflg,0)=0 and isnull(mststate.rid,0)!=@rid)
BEGIN    
    set @p_retrid=0
	set @p_reterr='PLEASE CHECK, stateCODE ALREADY EXITS.'
	set @p_retval=0   
	RAISERROR('PLEASE CHECK stateCODE ALREADY EXITS.',16,1,@statecode);
END
ELSE IF EXISTS (SELECT mststate.statename FROM mststate WHERE mststate.statename = @statename and isnull(mststate.delflg,0)=0 and isnull(mststate.rid,0)!=@rid)
BEGIN   
    set @p_retrid=0
	set @p_reterr='PLEASE CHECK, stateNAME ALREADY EXITS.'
	set @p_retval=0    
	RAISERROR('PLEASE CHECK stateNAME ALREADY EXITS.',16,1,@statename);
END
ELSE
begin
	update mststate 
	set statecode=@statecode,statename=@statename,stateremark1=@stateremark1,stateremark2=@stateremark2,
	erid=@urid,edatetime=GETDATE() where rid=@rid	
	set @p_retrid = @rid
end
set @p_reterr=''
DROP TABLE #temptbl
END TRY
BEGIN CATCH 
	set @p_retrid=0 
	set @p_reterr=(SELECT ERROR_MESSAGE())
	set @p_retval=0
	DROP TABLE #temptbl
	RETURN
END CATCH
END
GO
drop procedure usp_mststate_delete
GO
CREATE PROCEDURE usp_mststate_delete
(
@p_json NVARCHAR(MAX),
@p_retrid BIGINT out,
@p_retval bit out,
@p_reterr NVARCHAR(MAX) out
)
AS
BEGIN
BEGIN TRY
declare @rid bigint
declare @urid bigint

set @p_retrid=0
set @p_reterr=''
set @p_retval=1

SELECT * INTO #temptbl FROM OPENJSON(@p_json)
WITH
(rid bigint '$.rid',urid bigint '$.urid'
)
set @rid = (select rid from #temptbl)
set @urid = (select urid from #temptbl)
begin
	update mststate set mststate.delflg=1,drid=@urid,ddatetime=GETDATE() where mststate.rid=@rid	
end
set @p_reterr=''
set @p_retrid=@rid
DROP TABLE #temptbl
END TRY
BEGIN CATCH 
	SET @p_retrid=0 
	set @p_reterr=(SELECT ERROR_MESSAGE())
	set @p_retval=0
	DROP TABLE #temptbl
	RETURN
END CATCH
END
GO
drop procedure usp_mststate_getalldetails
GO
create procedure usp_mststate_getalldetails as
begin
select mststate.rid,mststate.statecode,mststate.statename,mststate.stateremark1,mststate.stateremark2,
mststate.arid,mststate.adatetime,mststate.erid,mststate.edatetime,mststate.drid,mststate.ddatetime,mststate.delflg
from mststate
order by mststate.statename,mststate.rid
end
GO
drop procedure usp_mststate_getlist
GO
create procedure usp_mststate_getlist as
begin
select mststate.rid,mststate.statecode,mststate.statename,mststate.stateremark1,mststate.stateremark2
from mststate where isnull(mststate.delflg,0)=0
order by mststate.statename,mststate.rid
end
GO
drop procedure usp_mststate_getbyid(@p_rid bigint)
GO
create procedure usp_mststate_getbyid(@p_rid bigint) as
begin
select mststate.rid,mststate.statecode,mststate.statename,mststate.stateremark1,mststate.stateremark2,
mststate.arid,mststate.adatetime,mststate.erid,mststate.edatetime,mststate.drid,mststate.ddatetime,mststate.delflg
from mststate where mststate.rid=@p_rid and isnull(mststate.delflg,0)=0
end
GO
drop procedure usp_mstcountry_add
GO
create PROCEDURE usp_mstcountry_add
(
@p_json NVARCHAR(MAX),
@p_retrid BIGINT out,
@p_retval bit out,
@p_reterr NVARCHAR(MAX) out
)
AS
BEGIN
BEGIN TRY
declare @rid bigint
declare @countrycode nvarchar(50)
declare @countryname nvarchar(500)
declare @countryremark1 nvarchar(max)
declare @countryremark2 nvarchar(max)
declare @urid bigint

set @p_retrid=0
set @p_reterr=''
set @p_retval=1

SELECT * INTO #temptbl FROM OPENJSON(@p_json)
WITH
(rid bigint '$.rid',countrycode nvarchar(50) '$.countrycode',countryname nvarchar(500) '$.countryname',
countryremark1 nvarchar(max) '$.countryremark1',countryremark2 nvarchar(max) '$.countryremark2',
urid bigint '$.urid'
)
set @rid = (select rid from #temptbl)
set @countrycode = (select countrycode from #temptbl)
set @countryname = (select countryname from #temptbl)
set @countryremark1 = (select countryremark1 from #temptbl)
set @countryremark2 = (select countryremark2 from #temptbl)
set @urid = (select urid from #temptbl)

IF EXISTS (SELECT mstcountry.countrycode FROM mstcountry WHERE mstcountry.countrycode = @countrycode and isnull(mstcountry.delflg,0)=0)
BEGIN    
    SET @p_retrid=0
	set @p_reterr='PLEASE CHECK countryCODE ALREADY EXITS.'
	set @p_retval=0 
	RAISERROR('PLEASE CHECK countryCODE ALREADY EXITS.',16,1,@countrycode);
	
END
ELSE IF EXISTS (SELECT mstcountry.countryname FROM mstcountry WHERE mstcountry.countryname = @countryname and isnull(mstcountry.delflg,0)=0)
	BEGIN   
    SET @p_retrid=0
	set @p_reterr='PLEASE CHECK countryNAME ALREADY EXITS.'
	set @p_retval=0    
	RAISERROR('PLEASE CHECK countryNAME ALREADY EXITS.',16,1,@countryname);
END
ELSE
begin
	insert into mstcountry (countrycode,countryname,countryremark1,countryremark2,arid,adatetime,DELFLG)
	values (@countrycode,@countryname,@countryremark1,@countryremark2,@urid,GETDATE(),0)
	set @p_retrid = SCOPE_IDENTITY()
end
set @p_reterr=''
DROP TABLE #temptbl
END TRY
BEGIN CATCH 
	SET @p_retrid=0 
	set @p_reterr=(SELECT ERROR_MESSAGE())
	set @p_retval=0
	DROP TABLE #temptbl
	RETURN
END CATCH
END
GO
drop procedure usp_mstcountry_update
GO
CREATE PROCEDURE usp_mstcountry_update
(
@p_json NVARCHAR(MAX),
@p_retrid BIGINT out,
@p_retval bit out,
@p_reterr NVARCHAR(MAX) out
)
AS
BEGIN
BEGIN TRY
declare @rid bigint
declare @countrycode nvarchar(50)
declare @countryname nvarchar(500)
declare @countryremark1 nvarchar(max)
declare @countryremark2 nvarchar(max)
declare @urid bigint

set @p_retrid=0
set @p_reterr=''
set @p_retval=1

SELECT * INTO #temptbl FROM OPENJSON(@p_json)
WITH
(rid bigint '$.rid',countrycode nvarchar(50) '$.countrycode',countryname nvarchar(500) '$.countryname',
countryremark1 nvarchar(max) '$.countryremark1',countryremark2 nvarchar(max) '$.countryremark2',
urid bigint '$.urid'
)
set @rid = (select rid from #temptbl)
set @countrycode = (select countrycode from #temptbl)
set @countryname = (select countryname from #temptbl)
set @countryremark1 = (select countryremark1 from #temptbl)
set @countryremark2 = (select countryremark2 from #temptbl)
set @urid = (select urid from #temptbl)

IF NOT EXISTS (SELECT mstcountry.rid FROM mstcountry WHERE mstcountry.rid = @rid and isnull(mstcountry.delflg,0)=0)
BEGIN
	set @p_retrid=0
	set @p_reterr='PLEASE CHECK RECORD NOT EXITS FOR UPDATE.'
	set @p_retval=0    
	RAISERROR('PLEASE CHECK RECORD NOT EXITS FOR UPDATE.',16,1,@countryname);
END
ELSE IF EXISTS (SELECT mstcountry.countrycode FROM mstcountry WHERE mstcountry.countrycode = @countrycode and isnull(mstcountry.delflg,0)=0 and isnull(mstcountry.rid,0)!=@rid)
BEGIN    
    set @p_retrid=0
	set @p_reterr='PLEASE CHECK, countryCODE ALREADY EXITS.'
	set @p_retval=0   
	RAISERROR('PLEASE CHECK countryCODE ALREADY EXITS.',16,1,@countrycode);
END
ELSE IF EXISTS (SELECT mstcountry.countryname FROM mstcountry WHERE mstcountry.countryname = @countryname and isnull(mstcountry.delflg,0)=0 and isnull(mstcountry.rid,0)!=@rid)
BEGIN   
    set @p_retrid=0
	set @p_reterr='PLEASE CHECK, countryNAME ALREADY EXITS.'
	set @p_retval=0    
	RAISERROR('PLEASE CHECK countryNAME ALREADY EXITS.',16,1,@countryname);
END
ELSE
begin
	update mstcountry 
	set countrycode=@countrycode,countryname=@countryname,countryremark1=@countryremark1,countryremark2=@countryremark2,
	erid=@urid,edatetime=GETDATE() where rid=@rid	
	set @p_retrid = @rid
end
set @p_reterr=''
DROP TABLE #temptbl
END TRY
BEGIN CATCH 
	set @p_retrid=0 
	set @p_reterr=(SELECT ERROR_MESSAGE())
	set @p_retval=0
	DROP TABLE #temptbl
	RETURN
END CATCH
END
GO
drop procedure usp_mstcountry_delete
GO
CREATE PROCEDURE usp_mstcountry_delete
(
@p_json NVARCHAR(MAX),
@p_retrid BIGINT out,
@p_retval bit out,
@p_reterr NVARCHAR(MAX) out
)
AS
BEGIN
BEGIN TRY
declare @rid bigint
declare @urid bigint

set @p_retrid=0
set @p_reterr=''
set @p_retval=1

SELECT * INTO #temptbl FROM OPENJSON(@p_json)
WITH
(rid bigint '$.rid',urid bigint '$.urid'
)
set @rid = (select rid from #temptbl)
set @urid = (select urid from #temptbl)
begin
	update mstcountry set mstcountry.delflg=1,drid=@urid,ddatetime=GETDATE() where mstcountry.rid=@rid	
end
set @p_reterr=''
set @p_retrid=@rid
DROP TABLE #temptbl
END TRY
BEGIN CATCH 
	SET @p_retrid=0 
	set @p_reterr=(SELECT ERROR_MESSAGE())
	set @p_retval=0
	DROP TABLE #temptbl
	RETURN
END CATCH
END
GO
drop procedure usp_mstcountry_getalldetails
GO
create procedure usp_mstcountry_getalldetails as
begin
select mstcountry.rid,mstcountry.countrycode,mstcountry.countryname,mstcountry.countryremark1,mstcountry.countryremark2,
mstcountry.arid,mstcountry.adatetime,mstcountry.erid,mstcountry.edatetime,mstcountry.drid,mstcountry.ddatetime,mstcountry.delflg
from mstcountry
order by mstcountry.countryname,mstcountry.rid
end
GO
drop procedure usp_mstcountry_getlist
GO
create procedure usp_mstcountry_getlist as
begin
select mstcountry.rid,mstcountry.countrycode,mstcountry.countryname,mstcountry.countryremark1,mstcountry.countryremark2
from mstcountry where isnull(mstcountry.delflg,0)=0
order by mstcountry.countryname,mstcountry.rid
end
GO
drop procedure usp_mstcountry_getbyid(@p_rid bigint)
GO
create procedure usp_mstcountry_getbyid(@p_rid bigint) as
begin
select mstcountry.rid,mstcountry.countrycode,mstcountry.countryname,mstcountry.countryremark1,mstcountry.countryremark2,
mstcountry.arid,mstcountry.adatetime,mstcountry.erid,mstcountry.edatetime,mstcountry.drid,mstcountry.ddatetime,mstcountry.delflg
from mstcountry where mstcountry.rid=@p_rid and isnull(mstcountry.delflg,0)=0
end
GO
create table mstlocation(
[rid] [bigint] IDENTITY(1,1) primary key,
	[loccode] [nvarchar](50) NULL,
	[locname] [nvarchar](500) NULL,
	[locremark1] [nvarchar](max) NULL,
	[locremark2] [nvarchar](max) NULL,
	[arid] [bigint] NULL,
	[adatetime] [datetime] NULL,
	[erid] [bigint] NULL,
	[edatetime] [datetime] NULL,
	[drid] [bigint] NULL,
	[ddatetime] [datetime] NULL,
	[delflg] [bit] NULL,
)
GO
drop procedure usp_mstlocation_add
GO
create PROCEDURE usp_mstlocation_add
(
@p_json NVARCHAR(MAX),
@p_retrid BIGINT out,
@p_retval bit out,
@p_reterr NVARCHAR(MAX) out
)
AS
BEGIN
BEGIN TRY
declare @rid bigint
declare @loccode nvarchar(50)
declare @locname nvarchar(500)
declare @locremark1 nvarchar(max)
declare @locremark2 nvarchar(max)
declare @urid bigint

set @p_retrid=0
set @p_reterr=''
set @p_retval=1

SELECT * INTO #temptbl FROM OPENJSON(@p_json)
WITH
(rid bigint '$.rid',loccode nvarchar(50) '$.loccode',locname nvarchar(500) '$.locname',
locremark1 nvarchar(max) '$.locremark1',locremark2 nvarchar(max) '$.locremark2',
urid bigint '$.urid'
)
set @rid = (select rid from #temptbl)
set @loccode = (select loccode from #temptbl)
set @locname = (select locname from #temptbl)
set @locremark1 = (select locremark1 from #temptbl)
set @locremark2 = (select locremark2 from #temptbl)
set @urid = (select urid from #temptbl)

IF EXISTS (SELECT mstlocation.loccode FROM mstlocation WHERE mstlocation.loccode = @loccode and isnull(mstlocation.delflg,0)=0)
BEGIN    
    SET @p_retrid=0
	set @p_reterr='PLEASE CHECK LOCATION CODE ALREADY EXITS.'
	set @p_retval=0 
	RAISERROR('PLEASE CHECK LOCATION CODE ALREADY EXITS.',16,1,@loccode);
	
END
ELSE IF EXISTS (SELECT mstlocation.locname FROM mstlocation WHERE mstlocation.locname = @locname and isnull(mstlocation.delflg,0)=0)
	BEGIN   
    SET @p_retrid=0
	set @p_reterr='PLEASE CHECK LOCATION NAME ALREADY EXITS.'
	set @p_retval=0    
	RAISERROR('PLEASE CHECK LOCATION NAME ALREADY EXITS.',16,1,@locname);
END
ELSE
begin
	insert into mstlocation (loccode,locname,locremark1,locremark2,arid,adatetime,DELFLG)
	values (@loccode,@locname,@locremark1,@locremark2,@urid,GETDATE(),0)
	set @p_retrid = SCOPE_IDENTITY()
end
set @p_reterr=''
DROP TABLE #temptbl
END TRY
BEGIN CATCH 
	SET @p_retrid=0 
	set @p_reterr=(SELECT ERROR_MESSAGE())
	set @p_retval=0
	DROP TABLE #temptbl
	RETURN
END CATCH
END
GO
drop procedure usp_mstlocation_update
GO
CREATE PROCEDURE usp_mstlocation_update
(
@p_json NVARCHAR(MAX),
@p_retrid BIGINT out,
@p_retval bit out,
@p_reterr NVARCHAR(MAX) out
)
AS
BEGIN
BEGIN TRY
declare @rid bigint
declare @loccode nvarchar(50)
declare @locname nvarchar(500)
declare @locremark1 nvarchar(max)
declare @locremark2 nvarchar(max)
declare @urid bigint

set @p_retrid=0
set @p_reterr=''
set @p_retval=1

SELECT * INTO #temptbl FROM OPENJSON(@p_json)
WITH
(rid bigint '$.rid',loccode nvarchar(50) '$.loccode',locname nvarchar(500) '$.locname',
locremark1 nvarchar(max) '$.locremark1',locremark2 nvarchar(max) '$.locremark2',
urid bigint '$.urid'
)
set @rid = (select rid from #temptbl)
set @loccode = (select loccode from #temptbl)
set @locname = (select locname from #temptbl)
set @locremark1 = (select locremark1 from #temptbl)
set @locremark2 = (select locremark2 from #temptbl)
set @urid = (select urid from #temptbl)

IF NOT EXISTS (SELECT mstloc.rid FROM mstloc WHERE mstloc.rid = @rid and isnull(mstloc.delflg,0)=0)
BEGIN
	set @p_retrid=0
	set @p_reterr='PLEASE CHECK RECORD NOT EXITS FOR UPDATE.'
	set @p_retval=0    
	RAISERROR('PLEASE CHECK RECORD NOT EXITS FOR UPDATE.',16,1,@locname);
END
ELSE IF EXISTS (SELECT mstloc.loccode FROM mstloc WHERE mstloc.loccode = @loccode and isnull(mstloc.delflg,0)=0 and isnull(mstloc.rid,0)!=@rid)
BEGIN    
    set @p_retrid=0
	set @p_reterr='PLEASE CHECK, locCODE ALREADY EXITS.'
	set @p_retval=0   
	RAISERROR('PLEASE CHECK locCODE ALREADY EXITS.',16,1,@loccode);
END
ELSE IF EXISTS (SELECT mstloc.locname FROM mstloc WHERE mstloc.locname = @locname and isnull(mstloc.delflg,0)=0 and isnull(mstloc.rid,0)!=@rid)
BEGIN   
    set @p_retrid=0
	set @p_reterr='PLEASE CHECK LOCATION NAME ALREADY EXITS.'
	set @p_retval=0    
	RAISERROR('PLEASE CHECK LOCATION ALREADY EXITS.',16,1,@locname);
END
ELSE
begin
	update mstloc 
	set loccode=@loccode,locname=@locname,locremark1=@locremark1,locremark2=@locremark2,
	erid=@urid,edatetime=GETDATE() where rid=@rid	
	set @p_retrid = @rid
end
set @p_reterr=''
DROP TABLE #temptbl
END TRY
BEGIN CATCH 
	set @p_retrid=0 
	set @p_reterr=(SELECT ERROR_MESSAGE())
	set @p_retval=0
	DROP TABLE #temptbl
	RETURN
END CATCH
END
GO
drop procedure usp_mstlocation_delete
GO
CREATE PROCEDURE usp_mstlocation_delete
(
@p_json NVARCHAR(MAX),
@p_retrid BIGINT out,
@p_retval bit out,
@p_reterr NVARCHAR(MAX) out
)
AS
BEGIN
BEGIN TRY
declare @rid bigint
declare @urid bigint

set @p_retrid=0
set @p_reterr=''
set @p_retval=1

SELECT * INTO #temptbl FROM OPENJSON(@p_json)
WITH
(rid bigint '$.rid',urid bigint '$.urid'
)
set @rid = (select rid from #temptbl)
set @urid = (select urid from #temptbl)
begin
	update mstlocation set mstlocation.delflg=1,drid=@urid,ddatetime=GETDATE() where mstlocation.rid=@rid	
end
set @p_reterr=''
set @p_retrid=@rid
DROP TABLE #temptbl
END TRY
BEGIN CATCH 
	SET @p_retrid=0 
	set @p_reterr=(SELECT ERROR_MESSAGE())
	set @p_retval=0
	DROP TABLE #temptbl
	RETURN
END CATCH
END
GO
drop procedure usp_mstlocation_getalldetails
GO
create procedure usp_mstlocation_getalldetails as
begin
select mstlocation.rid,mstlocation.loccode,mstlocation.locname,mstlocation.locremark1,mstlocation.locremark2,
mstlocation.arid,mstlocation.adatetime,mstlocation.erid,mstlocation.edatetime,mstlocation.drid,mstlocation.ddatetime,mstlocation.delflg
from mstlocation
order by mstlocation.locname,mstlocation.rid
end
GO
drop procedure usp_mstlocation_getlist
GO
create procedure usp_mstlocation_getlist as
begin
select mstlocation.rid,mstlocation.loccode,mstlocation.locname,mstlocation.locremark1,mstlocation.locremark2
from mstlocation where isnull(mstlocation.delflg,0)=0
order by mstlocation.locname,mstlocation.rid
end
GO
drop procedure usp_mstlocation_getbyid(@p_rid bigint)
GO
create procedure usp_mstlocation_getbyid(@p_rid bigint) as
begin
select mstlocation.rid,mstlocation.loccode,mstlocation.locname,mstlocation.locremark1,mstlocation.locremark2,
mstlocation.arid,mstlocation.adatetime,mstlocation.erid,mstlocation.edatetime,mstlocation.drid,mstlocation.ddatetime,mstlocation.delflg
from mstlocation where mstlocation.rid=@p_rid and isnull(mstlocation.delflg,0)=0
end
GO