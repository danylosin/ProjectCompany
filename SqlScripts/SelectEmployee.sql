SELECT "Info about employee";

SELECT employees.name, 
        contributions.title as `Contribution title`, 
        projects.title as `Project title`,
        skills.title as `Contribution skill` 
FROM employees 
JOIN contributions ON employees.id = contributions.employee_id 
JOIN projects ON contributions.project_id = projects.id
JOIN contributions_skills ON contributions.id = contributions_skills.contribution_id
JOIN skills ON contributions_skills.skill_id = skills.id  
WHERE employees.id = 1;


SELECT "Info about employees without contribution";

SELECT employees.name
FROM employees 
LEFT JOIN contributions ON  employees.id = contributions.employee_id WHERE contributions.employee_id is null;


SET @from_date = '2017-03-01';
SET @to_date = '2017-10-01';

SELECT CONCAT("Get employee activity from ", @from_date, " to ", @to_date);

SELECT employees.name, 
        contributions.title as `Contribution title`, 
        projects.title as `Project title`,
        skills.title as `Contribution skill`,
        contributions.from_date,
        contributions.to_date  
FROM employees 
JOIN contributions ON 
        employees.id = contributions.employee_id 
        AND 
        (contributions.from_date >= @from_date AND contributions.to_date <= @to_date)
JOIN projects ON contributions.project_id = projects.id
JOIN contributions_skills ON contributions.id = contributions_skills.contribution_id
JOIN skills ON contributions_skills.skill_id = skills.id  
WHERE employees.id = 1;