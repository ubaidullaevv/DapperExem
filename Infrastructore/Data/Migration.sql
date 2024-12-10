--MY Data Base

create table schools(
schoolId serial primary key,
school_title varchar(50),
level_count int,
is_active bool default true,
created_at date ,
updated_at date
);


create table students(
studentId serial primary key,
student_code varchar(12),
fullname varchar(50),
gender varchar(6),
dob date,
email varchar(75),
phone varchar(15),
schoolId int references schools(schoolId),
stage int ,
section varchar(2),
is_active bool,
join_date date,
created_at date,
updated_date date 
);



create table parents(
parentId serial primary key,
parent_code varchar(12),
fullname varchar(50),
email varchar(75),
phone varchar(15),
created_at date,
updated_at date
);


create table schoolparents(
schoolparentId serial primary key,
studentId int references students(studentId) unique,
parentId int references parents(parentId) unique,
relationship int
);



create table subjects(
subjectId serial primary key,
title varchar(20),
schoolId int references schools(schoolId),
stage int,
term int,
carry_mark int,
created_at date,
updated_at date
);



create table teachers(
teacherId serial primary key,
teacher_code varchar(12),
fullname varchar(50),
gender char(6),
dob date,
email varchar(75),
phone varchar(15),
is_active bool,
join_date date default current_date,
working_days int,
created_at date,
updated_date date
);



create table classrooms(
classroomId serial primary key,
capacity int,
room_type int,
description varchar(100),
created_at date,
updated_at date
);




create table classes(
classId serial primary key,
name varchar(50),
subjectId int references subjects(subjectId),
teacherId int references teachers(teacherId),
classroomId int references classrooms(classroomId),
section varchar(2),
created_at date,
updated_at date
);