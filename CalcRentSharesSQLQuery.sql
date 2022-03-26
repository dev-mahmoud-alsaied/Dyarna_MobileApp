--start [ãÚÑİÉ ÇÓåã ÔÎÕ ãÚíä ÎáÇá İÊÑå ãÚíäå]
select  ush.name,sh.startDate,sh.endDate,sh.userCash from tbl_shares sh join tbl_userShares ush
on sh.userShares_id = ush.id where sh.shareType = 1
--start [ÊİÇÕíá ÇÓåã ÇáæÍÏÇÊ áßá ÇáãÓÇåãíä]
select * from tbl_shares sh 
join tbl_userShares ush on sh.userShares_id = ush.id
join tbl_units_Shares unsh on unsh.shares_id = sh.id
join tbl_units u on u.id = unsh.unit_id
where sh.shareType = 1
--start [ÍÓÇÈ æÇÑÏÇÊ æãÕÑæİÇÊ æÍÏå ãÚíäå áÔÎÕ ãÚíä]
select u.name,rex.date,rex.itemValue from tbl_units u 
 join tbl_rentExpenses rex on u.id = rex.unit_id
 join tbl_item i on i.id = rex.item_id
where u.name = 'a1' and MONTH(rex.date) = '3'

select u.name,mf.date,mf.value from tbl_units u 
 join tbl_monthlyFiltring mf on mf.unit_id = u.id
where u.name = 'a1' and MONTH(mf.date) = '3'

select  ush.name,sh.startDate,sh.endDate,sh.userCash,u.name from tbl_shares sh 
join tbl_userShares ush on sh.userShares_id = ush.id
join tbl_units_Shares unsh on unsh.shares_id = sh.id
join tbl_units u on u.id = unsh.unit_id
where sh.shareType = 1 and u.name = 'a1'
--start [ÌæÈÇíÉ áÍÓÇÈ ÇáÊÕİíÉ ÇáÔåÑíÉ áßá æÍÏÉ]
insert into tbl_monthlyFiltring (unit_id, date, value) ( select u.id, rd.end_date, sum( r.totalValue ) from tbl_reservation r
join tbl_units  u 
	on r.unit_id = u.id
join tbl_reservationDate rd 
	on rd.id = r.date_id
where month(rd.end_date) = MONTH(CURRENT_TIMESTAMP) - 1 
group by u.id, rd.end_date)

--start  [ÑÈÍ æÍÏå ãÚíäå ßá ÔåÑ ]
declare @uId int = 1 
select u.id, rd.end_date,  sum( r.totalValue) -( select sum(itemValue) from tbl_rentExpenses 
	where unit_id = @uId 
) 
from tbl_reservation r
join tbl_units  u 
	on r.unit_id = u.id
join tbl_reservationDate rd 
	on rd.id = r.date_id
where month(rd.end_date) = MONTH(CURRENT_TIMESTAMP) - 1 and u.id = @uId
group by u.id, rd.end_date
-------------------------------------
