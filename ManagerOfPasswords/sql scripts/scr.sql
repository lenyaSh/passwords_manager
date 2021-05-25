-- Database: pswd_manager

-- DROP DATABASE pswd_manager;

-- CREATE DATABASE pswd_manager
--     WITH 
--     OWNER = postgres
--     ENCODING = 'UTF8'
--     LC_COLLATE = 'Russian_Russia.1251'
--     LC_CTYPE = 'Russian_Russia.1251'
--     TABLESPACE = pg_default
--     CONNECTION LIMIT = -1;
	
	
-- CREATE table users(
-- 	id  serial UNIQUE  primary key,
-- 	login varchar(50) not null,
-- 	password varchar(50) not null
-- )

create table sites(
	id serial UNIQUE  primary key,
	url varchar(100) not null unique
);

create table accounts(
	id_user integer not null,
	id_site integer not null,
	login varchar(50) not null,
	password varchar(100) not null
)

