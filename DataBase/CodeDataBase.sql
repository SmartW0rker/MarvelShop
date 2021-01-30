create table Covek(
    EMBG integer,
    ime varchar(20),
    prezime varchar(20),
    adresa varchar(50),
    constraint pk_covek primary key (EMBG)  );


select * from Covek;

create table Prodavnica(
    id_prodavnica integer,
    broj_vraboteni integer,
    ime_prodavnica varchar(20),
    grad_otvorena varchar(20),
    constraint pk_prodavnica primary key (id_prodavnica)
);

create table Vraboten(
    EMBG integer,
    id_prodavnica integer,
    pozicija varchar(20),
    datum_vrabotuvajne date,
    constraint pk_vraboten primary key (EMBG,id_prodavnica),
    constraint fk_vraboten_to_prodavnica foreign key (id_prodavnica) references Prodavnica(id_prodavnica),
    constraint fk_vraboten_to_covek foreign key (EMBG) references Covek(EMBG)
);

select * from Vraboten;

create table Klient(
    EMBG char(13),
    klub_karticka boolean,
    constraint pk_klient primary key (EMBG),
    constraint fk_klient foreign key (EMBG) references Covek(EMBG)
);
create table Kosnicka(
    id_kosnicka integer,
    broj_proizvodi integer,
    status boolean,
    EMBG integer,
    constraint pk_kosnicka primary key (id_kosnicka),
    constraint fk_kosnicka foreign key (EMBG) references Klient(EMBG)
);
create table Proizvod(
    id_proizvod integer,
    legenda varchar(200),
    cena_proizvod integer,
    kolicina integer,
    constraint pk_proizvod primary key (id_proizvod)
);
create table E_vo(
    id_proizvod integer,
    id_kosnicka integer,
    constraint pk_e_vo primary key (id_proizvod,id_kosnicka),
    constraint fk_e_vo_to_proizvod foreign key (id_proizvod) references Proizvod(id_proizvod),
    constraint fk_e_vo_to_kosnicka foreign key (id_kosnicka) references Kosnicka(id_kosnicka)
);
select * from E_vo;

create table Se_naogja_vo(
    id_proizvod integer,
    id_prodavnica integer,
    constraint pk_se_naogja_vo primary key (id_proizvod,id_prodavnica),
    constraint fk_se_naogja_vo_to_proizvod foreign key (id_proizvod) references Proizvod(id_proizvod),
    constraint fk_se_naogja_vo_to_prodavnoca foreign key (id_prodavnica) references Prodavnica(id_prodavnica)
);

create table Telefonski_broj(
    EMBG char(13),
    broj integer,
    constraint pk_telefonski_broj primary key (EMBG),
    constraint fk_telefonski_broj foreign key (EMBG) references Klient(EMBG)
);

insert into Covek(EMBG, ime, prezime, adresa)
values (1,'Hristijan','Cocevski','Dimitar pop gorgiev'),
       (2,'Darko','Ruskovski','Partizanski odredi'),
       (3,'Nikola','Serafimov','Ilindenska'),
       (4,'Marija','Vodenicarska','Karpos 3'),
       (5,'Bojana','Nikolova','Karpos 2');
select * from Covek;
insert into Prodavnica(id_prodavnica, broj_vraboteni, ime_prodavnica, grad_otvorena)
values (1,2,'Mervel Berovo','Berovo'),
       (2,4,'Marvel Stip','Stip'),
       (3,3,'Marvel Bitola','Bitola'),
       (4,5,'Marvel Skopje','Skopje');

select * from Prodavnica;

alter table Proizvod add column ime_proizvod varchar(20);
alter table Proizvod alter column ime_proizvod type varchar(50);

insert into Proizvod(id_proizvod,ime_proizvod, legenda, cena_proizvod, kolicina)
values (1,'Time Stone',
        'Time Stone e eden od 5te kameni koi do drzat univerzumot vo harmonija,' ||
        ' kamenot e poseduvan od Dr.Strange i so nego moze da go kontrolira vremeto',
         500,100),
        (2,'Cekanot na Thor',
        'Oruzje na Thor bog od planetata Asgard',2500,50),
        (3,'Spider-man toy',
        'Spider-man e covek kasnat od genetski modificiran pajak. So kasnuvajneto ja prensesuva DNKta' ||
           ' na covekot i so toa toj stanuva polovina covek polovina pajak',250,500),
       (4,'Rakavicata na Toni Stark',
        'Toni Stark e visoko intelegenten naucnik koj go pravi Iron Man.Rakavicata ja pravi za da moze' ||
        ' da ja apsorbira energijata na site 5 Infinity stones',1000,200),
       (5,'Hulk igracka',
        'Hulk e covek koj vo genite ima mutirani geni preseseni od tatko mu so eksperiment i koga' ||
        ' mu se zgolemi adrenalinot se pretvara vo cudoviste',300,400);

select * from proizvod;

insert into Vraboten(embg, id_prodavnica, pozicija, datum_vrabotuvajne)
values (1,1,'prodavac','2020-3-14'),
       (2,2,'menadzer','2018-6-24'),
       (3,3,'sef','2015-4-13'),
       (4,4,'prodavac','2019-12-11'),
       (5,4,'sef','2017-1-1');
select * from Vraboten;

insert into Covek(EMBG, ime, prezime, adresa)
values (6,'Nikola','Nikolov','Aco Ruskovski'),
       (7,'Trajko','Trajcev','Partizanski odredi'),
       (8,'Marko','Parmacki','Ilindenska'),
       (9,'Marija','Markova','Karpos 1'),
       (10,'Bojana','Trajceva','Kisela Voda');

select * from Covek;

insert into Klient(embg, klub_karticka)
values ('1000000000006',true),
       ('1000000000007',false),
       ('1000000000008',true),
       ('1000000000009',false),
       ('1000000000010',false);

select * from Klient;

alter table Telefonski_broj alter column broj type varchar(15);

insert into Telefonski_broj(embg, broj)
values ('1000000000006','077 765 532'),
       (7, '071 654 321'),
       (8, '077 453 123'),
       (9,'070 231 432'),
       (10,'070 324 321');

select * from Telefonski_broj;

insert into Kosnicka(id_kosnicka, broj_proizvodi, status, EMBG)
values (1,0,false,6),
       (2,0,false,7),
       (3,0,false,8),
       (4,0,false,9),
       (5,0,false,10);

select * from Kosnicka;

insert into E_vo(id_proizvod, id_kosnicka)
values (1,1),
       (2,2),
       (3,3),
       (4,4),
       (5,5);
select * from E_vo;

insert into Se_naogja_vo(id_proizvod, id_prodavnica)
values (1,1),
       (2,2),
       (3,3),
       (4,4),
       (5,4);
select * from Se_naogja_vo;
alter table Telefonski_broj drop embg;
alter  table Telefonski_broj add column EMBG varchar(20);
select * from Telefonski_broj;

alter table Kosnicka drop EMBG;
alter table Kosnicka add column EMBG varchar(20);
select * from Kosnicka;

alter table Klient drop embg;
alter table Klient add column EMBG varchar(20);
select * from Klient;

alter table Vraboten drop embg;
alter table Vraboten add column EMBG varchar(20);
select * from Vraboten;

alter table Covek drop EMBG;
alter table Covek add column EMBG varchar(20);
select * from Covek;

alter table Covek add constraint pk_Covek primary key (EMBG);
insert into Covek(EMBG)
values ('1000000000001'),
       ('1000000000002'),
       ('1000000000003'),
       ('1000000000004'),
       ('1000000000005'),
       ('1000000000006'),
       ('1000000000007'),
       ('1000000000008'),
       ('1000000000009'),
       ('10000000000010');
select * from Covek;
delete from Covek
where ime IS NULL;
update Covek set embg='1000000000006'
where ime='Marija' and prezime='Markova';
alter table Covek alter column embg type char(13);

select * from vraboten;
update Vraboten set embg='1000000000005'
where id_prodavnica=4 and  pozicija='sef';
alter table Vraboten add
     constraint pk_vraboten primary key (EMBG,id_prodavnica);
alter table Vraboten add
     constraint fk_vraboten_to_covek foreign key (EMBG) references Covek(EMBG);
alter table Vraboten alter column embg type char(13);

drop table Klient;
drop table Telefonski_broj;

select * from kosnicka;
update Kosnicka set embg='1000000000010'
where id_kosnicka=5;
alter table kosnicka add
    constraint fk_kosnicka foreign key (EMBG) references Klient(EMBG);

update kosnicka set broj_proizvodi=1
where id_kosnicka is not null ;

--Forma : Forma za dodavajne vo kosnicka
--Primerot e za korisnik sto saka da kupi Time Stone

--Proveruvam dali postoi proizvodot i go dobivam idto na proizvodot

select id_proizvod,Proizvod.ime_proizvod,kolicina from Proizvod
where ime_proizvod='Time Stone' and kolicina>0;

--Ja naogjam id_kosnickata na klintot koj naracal
select ime,prezime,id_kosnicka from kosnicka
join Klient  on Klient.EMBG = Kosnicka.EMBG
join Covek C on C.EMBG = Klient.EMBG
    where ime='Nikola' and prezime='Nikolov';

--Go zgolemuvam brojot na proizvodi vo kosnickata za 1
update kosnicka set broj_proizvodi=broj_proizvodi+1
 where id_kosnicka=2;

--Na kraj go dodavam vo e_vo tabelata za relacija
insert into e_vo(id_proizvod, id_kosnicka)
values (1,2);

--Pogled za proizvodi koi se naogaat vo dadena kosnicka
create view Proizvodi_kosnicka as
select  K.id_kosnicka,Proizvod.id_proizvod,Proizvod.ime_proizvod,kolicina from proizvod
join E_vo Ev on Proizvod.id_proizvod = Ev.id_proizvod
join Kosnicka K on K.id_kosnicka = Ev.id_kosnicka;

drop view proizvodi_kosnicka;

select *from Proizvodi_kosnicka;

--Forma za naracka od kosnicka

--ja naogjam kosnickata na klientot koj naracal

select ime,prezime,id_kosnicka from kosnicka
join Klient  on Klient.EMBG = Kosnicka.EMBG
join Covek C on C.EMBG = Klient.EMBG
    where ime='Nikola' and prezime='Nikolov';

--Sega imame transakcija za dadena kosnicka

begin ;
--Go naogjam proizvodite vo dadena kosnicka
select ime_proizvod from Proizvodi_kosnicka
where id_kosnicka=2;

--Sega za sekoj naracan proizvod treba vo proizvodi da odzememe od kolicina 1
update proizvod set kolicina=kolicina-1
where ime_proizvod='Time Stone';

update proizvod set kolicina=kolicina-1
where ime_proizvod='Cekanot na Thor';

--Postavuva status na false deka kosnickata e kupena

update kosnicka set status=false
where id_kosnicka=1;

select * from proizvod;
select * from kosnicka;

select * from Klient
join Covek C on C.EMBG = Klient.EMBG
join Kosnicka K on Klient.EMBG = K.EMBG;


select * from E_vo;
commit ;

--Pogled za cena na kosnicka

create view cena_kosnicka as
select Kosnicka.id_kosnicka,sum(cena_proizvod),broj_proizvodi from kosnicka
join E_vo Ev on Kosnicka.id_kosnicka = Ev.id_kosnicka
join Proizvod P on P.id_proizvod = Ev.id_proizvod
group by Kosnicka.id_kosnicka;

select * from cena_kosnicka;

--Pogled za pari potroseni od daden klient


create view Promet_od_klient as
select ime,prezime,sum(cena_proizvod) from klient
join Covek C on Klient.EMBG = C.EMBG
join Kosnicka K on Klient.EMBG = K.EMBG
join e_vo ev on K.id_kosnicka = ev.id_kosnicka
join Proizvod P on ev.id_proizvod = P.id_proizvod
where status=false
group by ime, prezime;

select * from Promet_od_klient;

--Pogled kade listam se sto ima kupeno daden klient

create view Proizvodi_kupeni_od_klient as
select ime,prezime,ime_proizvod,P.id_proizvod from Klient
join Covek C on Klient.EMBG = C.EMBG
join Kosnicka K on Klient.EMBG = K.EMBG
join E_vo Ev on K.id_kosnicka = Ev.id_kosnicka
join Proizvod P on Ev.id_proizvod = P.id_proizvod
where status=false;

select * from Proizvodi_kupeni_od_klient;

--izvestai:
--Proizvod koj najmnogu pari donel za prodavnicite

/*select * from(
select Proizvod.ime_proizvod,cena_proizvod,sum(cena_proizvod) as suma from Proizvod
join E_vo Ev on Proizvod.id_proizvod = Ev.id_proizvod
join Kosnicka K on K.id_kosnicka = Ev.id_kosnicka
where status=false
group by Ev.id_proizvod,Proizvod.ime_proizvod,cena_proizvod
order by cena_proizvod
 ) as profit_proizvodi
where suma=(select max(suma) from profit_proizvodi);
  */

--Mnogu ne optimalnop resenie.....

select * from(
select Proizvod.ime_proizvod,cena_proizvod,sum(cena_proizvod) as suma from Proizvod
join E_vo Ev on Proizvod.id_proizvod = Ev.id_proizvod
join Kosnicka K on K.id_kosnicka = Ev.id_kosnicka
where status=false
group by Ev.id_proizvod,Proizvod.ime_proizvod,cena_proizvod
order by cena_proizvod
 ) as profit_proizvodi

where suma=(select max(suma) from(
select Proizvod.ime_proizvod,cena_proizvod,sum(cena_proizvod) as suma from Proizvod
join E_vo Ev on Proizvod.id_proizvod = Ev.id_proizvod
join Kosnicka K on K.id_kosnicka = Ev.id_kosnicka
where status=false
group by Ev.id_proizvod,Proizvod.ime_proizvod,cena_proizvod
order by cena_proizvod
 ) as profit_proizvodi);


--Broj na prodadenni parcinja od sekoj proizvod i broj na parcija od tie proivodi
select ime_proizvod,kolicina,count(ime_proizvod) as count from Klient
join Kosnicka K on Klient.EMBG = K.EMBG
join e_vo ev on K.id_kosnicka = ev.id_kosnicka
join proizvod p on ev.id_proizvod = p.id_proizvod
where status=false
group by ime_proizvod,kolicina
order by count desc;


--Profit na sekoja od prodavnicite

select ime_prodavnica,sum(cena_proizvod) as profit from Prodavnica
join Se_naogja_vo Snv on Prodavnica.id_prodavnica = Snv.id_prodavnica
join Proizvod P on P.id_proizvod = Snv.id_proizvod
join e_vo ev on Snv.id_proizvod = ev.id_proizvod
join Kosnicka K on K.id_kosnicka = ev.id_kosnicka
where status=false
group by ime_prodavnica
order by profit desc;


