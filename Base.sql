DROP DATABASE IF EXISTS ProjectCompany;

CREATE DATABASE ProjectCompany;

USE ProjectCompany;

CREATE TABLE projects (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    title VARCHAR(32) NOT NULL,
    from_date DATE NOT NULL,
    to_date DATE NOT NULL
);

INSERT INTO projects(title, from_date, to_date) VALUES
        ("Project #1", "2017-01-01", "2018-01-01"), 
        ("Project #2", "2017-01-01", "2017-12-01"), 
        ("Project #3", "2017-01-01", "2018-01-01"), 
        ("Project #4", "2017-01-01", "2018-01-01"), 
        ("Project #5", "2017-01-01", "2018-01-01");

CREATE TABLE employees (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `name` VARCHAR(32) NOT NULL
);

INSERT INTO employees (`name`) VALUES ("Dan"), ("Mike"), ("David"), ("Bob"), ("Intern");

CREATE TABLE skills (
     id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    title VARCHAR(32) NOT NULL
);

INSERT INTO skills(title) VALUES
        ("Angular"), ("React"), ("C#"), ("PhP"), ("Java"), 
        ("Ruby"), ("Python"), ("Project Management"), ("Linux"), ("Mysql");

CREATE TABLE contributions (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    title VARCHAR(32) NOT NULL,
    employee_id INT,
    project_id INT,
    from_date DATE NOT NULL,
    to_date DATE NOT NULL,
    FOREIGN KEY (employee_id)
        REFERENCES employees(id),
    FOREIGN KEY (project_id)
        REFERENCES projects(id)        
);

INSERT INTO contributions(title, employee_id, project_id, from_date, to_date) VALUES
        ("Writing backend on c#", 1, 1, "2017-06-01", "2018-01-01"), 
        ("Writing frontend on Angular", 2, 1, "2017-02-01", "2017-04-01"), 
        ("Writing backend on Java", 1, 2, "2017-05-01", "2017-08-01"), 
        ("Writing frontend", 2, 2, "2017-04-01", "2017-07-01"), 
        ("Writing userstories", 3, 2, "2017-02-01", "2017-03-01"),
        ("Configurating server", 1, 1, "2017-08-01", "2017-08-03"),
        ("Creating database", 1, 1, "2017-08-10", "2017-08-15")
        ;

CREATE TABLE employees_skills (
    employee_id INT NOT NULL,
    skill_id INT NOT NULL,
    FOREIGN KEY (employee_id)
        REFERENCES employees(id),
    FOREIGN KEY (skill_id)
        REFERENCES skills(id)
);

INSERT INTO employees_skills VALUES (1, 3), (2, 1), (3, 8), (1, 5), (1, 9), (1, 10);

CREATE TABLE contributions_skills (
    contribution_id INT NOT NULL,
    skill_id INT NOT NULL,
    FOREIGN KEY (contribution_id)
        REFERENCES contributions(id),
    FOREIGN KEY (skill_id)
        REFERENCES skills(id)
);

INSERT INTO contributions_skills VALUES(1, 3), (2, 1), (3, 5), (4, 2), (5, 8), (6, 9), (7, 10);