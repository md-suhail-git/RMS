select * from tblMain m
 inner join tblDetails d on m.MainID=d.MainID
 inner join products p on p.pID=d.proID
 where m.aDate between '2024-12-08' and '2024-12-11'