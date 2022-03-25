-- ÇáÊÕİíå ÇáÔåÑíå áæÍÏå ãÚíäå İí İÊÑå ãÚíä 
select mo.value from tbl_units un 
join tbl_monthlyFiltring mo 
on un.id = mo.unit_id
where un.name = 'a1'
and MONTH(mo.date) = '3'

-- ÊÕİíå ÇáæÍÏå ÎáÇá ÇáÓäå 
select Sum(mo.value) from tbl_units un 
join tbl_monthlyFiltring mo 
on un.id = mo.unit_id
where un.name = 'a1'
and YEAR(mo.date) = '2022'

-- ÇáÊÕİíå ÎáÇá İÊÑå ãÚíäå áãÓÇåã 
select sum(mo.value) from tbl_userShares_units usu 
join tbl_shares s 
on usu.shares_id = s.id 
join tbl_units u 
on usu.unit_id = u.id
join tbl_userShares us 
on us.id = s.userShares_id
join tbl_monthlyFiltring mo 
on mo.unit_id = u.id 
where us.id = 1 
and s.shareType = 1


select s.userCash, u.name, sum(mo.value), rx.itemValue, it.name from tbl_userShares_units usu 
join tbl_shares s 
on usu.shares_id = s.id 
join tbl_units u 
on usu.unit_id = u.id
join tbl_userShares us 
on us.id = s.userShares_id
join tbl_monthlyFiltring mo 
on mo.unit_id = u.id 
join tbl_rentExpenses rx 
on rx.unit_id = u.id
join tbl_item it 
on it.id = rx.item_id
where us.id = 1 
and s.shareType = 1
and rx.Shares_id = s.id
group by s.userCash, u.name, rx.itemValue, it.name,rx.date

select * from tbl_userShares_units usu 
join tbl_shares s 
on usu.shares_id = s.id 
join tbl_units u 
on usu.unit_id = u.id
join tbl_userShares us 
on us.id = s.userShares_id
join tbl_monthlyFiltring mo 
on mo.unit_id = u.id 
join tbl_rentExpenses rx 
on rx.unit_id = u.id
join tbl_item it 
on it.id = rx.item_id
where us.id = 1 
and s.shareType = 1
and rx.Shares_id = s.id


select u.id,u.name,mf.value,mf.date from 
tbl_units u join tbl_monthlyFiltring mf on u.id = mf.unit_id
where u.name = 'a1'

select u.id,u.name,re.itemValue,re.date from 
tbl_units u join tbl_rentExpenses re on u.id = re.unit_id
where u.name = 'a1'

