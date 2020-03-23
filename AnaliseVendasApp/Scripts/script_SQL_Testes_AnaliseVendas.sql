delete Cliente
delete Vendedor
delete Item
delete Venda
delete VendaItem


insert into Vendedor values ('1234567891234','Pedro',50000)
insert into Vendedor values ('3245678865434','Paulo',40000.99)

insert into Cliente values ('2345675434544345','Jose da Silva','Rural')
insert into Cliente values ('2345675433444345','Eduardo Pereira','Rural')

insert into Item values (1)
insert into Item values (2)
insert into Item values (3)

insert into Venda values (10,'1234567891234')

insert into VendaItem values (10,1,10,100)
insert into VendaItem values (10,2,30,2.50)
insert into VendaItem values (10,3,40,3.10)

insert into Venda values (8,'3245678865434')

insert into VendaItem values (8,1,34,10)
insert into VendaItem values (8,2,33,1.50)
insert into VendaItem values (8,3,40,0.10)


select * from Cliente
select * from Vendedor
select * from Item
select * from Venda
select * from VendaItem


select count(*) as qtdClientes from Cliente

select count(*) as qtdVendedores from Vendedor

select TOP(1) va.Id, Sum(vi.quantity*vi.price) as vendaTotal from VendaItem vi
inner join Venda va on vi.vendaId = va.Id
group by va.Id
order by Sum(vi.quantity*vi.price) DESC

select TOP(1) vo.name from Venda va
inner join Vendedor vo on vo.Id = va.vendedorId
INNER JOIN VendaItem vi ON va.Id = vi.vendaId
INNER JOIN Item i on vi.itemId = i.id 
group by va.Id, vo.name
order by Sum(vi.quantity*vi.price) ASC

