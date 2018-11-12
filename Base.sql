DROP DATABASE IF EXISTS ProjectCompany;

CREATE DATABASE ProjectCompany;

USE ProjectCompany;

CREATE TABLE projects (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    title VARCHAR(32) NOT NULL
);

INSERT INTO projects(title) VALUES
        ("Project #1"), ("Project #2"), ("Project #3"), ("Project #4"), ("Project #5");

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
        ("Ruby"), ("Python"), ("Project Management");

CREATE TABLE contributions (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    title VARCHAR(32) NOT NULL,
    employee_id INT,
    project_id INT,
    FOREIGN KEY (employee_id)
        REFERENCES employees(id),
    FOREIGN KEY (project_id)
        REFERENCES projects(id)        
);

INSERT INTO contributions(title, employee_id, project_id) VALUES
        ("Writing backend on c#", 1, 1), 
        ("Writing frontend on Angular", 2, 1), 
        ("Writing backend on Java", 1, 2), 
        ("Writing frontend", 2, 2), 
        ("Writing userstories", 3, 2);

CREATE TABLE employees_skills (
    employee_id INT NOT NULL,
    skill_id INT NOT NULL,
    FOREIGN KEY (employee_id)
        REFERENCES employees(id),
    FOREIGN KEY (skill_id)
        REFERENCES skills(id)
);

INSERT INTO employees_skills VALUES (1, 3), (2, 1), (3, 8), (1, 5);

CREATE TABLE contributions_skills (
    contribution_id INT NOT NULL,
    skill_id INT NOT NULL,
    FOREIGN KEY (contribution_id)
        REFERENCES contributions(id),
    FOREIGN KEY (skill_id)
        REFERENCES skills(id)
);

INSERT INTO contributions_skills VALUES(1, 3), (2, 1), (3, 5);