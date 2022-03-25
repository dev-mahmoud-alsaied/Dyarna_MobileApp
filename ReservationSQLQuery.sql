
select u.name [unit],us.name [user],rd.start_date,rd.end_date from tbl_units u inner join tbl_reservation r on u.id = r.unit_id
inner join tbl_users us on us.id = r.user_id inner join tbl_reservationDate rd on
rd.id = r.date_id

select u.name [unit],us.name [user],rd.start_date,rd.end_date from tbl_units u inner join tbl_reservation r on u.id = r.unit_id
inner join tbl_users us on us.id = r.user_id inner join tbl_reservationDate rd on
rd.id = r.date_id where u.name = 'a1'

select u.name [unit],us.name [user],rd.start_date,rd.end_date from tbl_units u inner join tbl_reservation r on u.id = r.unit_id
inner join tbl_users us on us.id = r.user_id inner join tbl_reservationDate rd on
rd.id = r.date_id where us.name = 'x'

select u.name [unit],us.name [user],rd.start_date,rd.end_date from tbl_units u inner join tbl_reservation r on u.id = r.unit_id
inner join tbl_users us on us.id = r.user_id inner join tbl_reservationDate rd on
rd.id = r.date_id where MONTH(rd.start_date) = '4'

select u.name [unit],us.name [user],rd.start_date,rd.end_date from tbl_units u inner join tbl_reservation r on u.id = r.unit_id
inner join tbl_users us on us.id = r.user_id inner join tbl_reservationDate rd on
rd.id = r.date_id where year(rd.start_date) = '2021'