USE ex_table_relations1;

CREATE TABLE exams(
exam_id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
name VARCHAR(50) NOT NULL
);

CREATE TABLE students(
student_id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
name VARCHAR(200) NOT NULL
);

CREATE TABLE students_exams(
student_id INT,
exam_id INT,
PRIMARY KEY (student_id, exam_id),
FOREIGN KEY (student_id) REFERENCES students(student_id),
FOREIGN KEY (exam_id) REFERENCES exams(exam_id)
);

INSERT INTO students
( -- Columns to insert data into
    name
)
VALUES
( -- First row: values for the columns in the list below
    'Mila'
),
( -- Second row: values for the columns in the list below
    'Toni'
),
( -- Third row: values for the colums in the list below
    'Ron'
);



-- Insert rows into table 'Exams' in schema '[dbo]'
INSERT INTO exams
( -- Columns to insert data into
    name
)
VALUES
( -- First row: values for the columns in the list below
    'SpringMVC'
),
( -- Second row: values for the columns in the list below
    'Neo4j'
),
( -- Third row: values for the colums in the list below
    'Oracle 11g'
);



-- Insert rows into table 'StudentsExams' in schema '[dbo]'
INSERT INTO students_exams
( -- Columns to insert data into
    student_id
    , exam_id
)
VALUES
( -- First row: values for the columns in the list below
    1
    , 101
),
( -- Second row: values for the columns in the list below
    1
    , 102
),
( -- Third row: values for the colums in the list below
    2
    , 101
),
( -- Fourth row: values for the colums in the list below
    3
    , 103
),
( -- Fifth row: values for the colums in the list below
    2
    , 102
),
( -- Sixth row: values for the colums in the list below
    2
    , 103
);