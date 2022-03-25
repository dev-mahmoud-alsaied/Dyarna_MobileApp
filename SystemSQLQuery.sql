
select * from tbl_contractingExpnses where userShares_id = 1
select * from tbl_rentExpenses where userShares_id = 1
select * from tbl_shares
select * from tbl_reservation where unit_id = 1

select  re.totalValue - rex.itemValue - sh.userCash - 12 * sh.userMinProfit 
- (sh.managePercent * (re.totalValue - rex.itemValue - sh.userCash - 12 * sh.userMinProfit ) / 100)
from tbl_reservation re 
join tbl_rentExpenses rex on re.unit_id = rex.unit_id  
join tbl_reservationDate red on re.date_id = red.id
join tbl_item it on rex.item_id = it.id
join tbl_shares sh on sh.id = rex.userShares_id
where rex.userShares_id = 1
and Year(red.start_date) in('2022')


select sum(value) from tbl_monthlyFiltring
where unit_id = 1 and year(date) = '2022' and month(date) in ('1', '2', '3', '4', '5', '6')

alter proc spCalcPeriodFiltering
@userShares_id int,
@period nvarchar(50)
as
begin
declare @val decimal(18,2)

select @val = sum(mo.value) from tbl_rentExpenses rex
join tbl_monthlyFiltring mo on rex.unit_id = mo.unit_id
where rex.userShares_id = 1 and YEAR(mo.date) = '2021'

select @val - (12 * userMinProfit ) 
from tbl_shares 
end

exec spCalcPeriodFiltering 1,'2022'