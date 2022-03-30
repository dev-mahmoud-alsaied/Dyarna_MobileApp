use Diarna

select * from tbl_reservation
select * from tbl_reservationDate
select * from tbl_units

-- get units which is free in specific date 
-- ãáÇÍÙå ÈÓÈÈ æÌæÏ ÈÚÖ ÇáæÍÏÇÊ ÇáÊí áã íÊã ÍÌÒåÇ áĞÇß áã ÊäÌÍ ÇÓÊÎÏÇã ÇáÌæíä ÈÏæä ÇÓÊÎÏÇã äíÓÊÏ áæÈ  
select * from tbl_units where id not in (
select u.id from tbl_units u   
join tbl_reservation rs
	on rs.unit_id = u.id
join tbl_reservationDate rd 
	on rs.date_id  = rd.id
where rd.start_date != '03-09-2022')