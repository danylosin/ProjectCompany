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

SELECT "Info about project";

SELECT projects.title as `Project title`,
    contributions.title as `Contribution title`,
    skills.title as `Techonology used`,
    employees.name as `Contributior name`
FROM projects 
JOIN contributions ON contributions.project_id = projects.id
JOIN contributions_skills ON contributions_skills.contribution_id = contributions.id
JOIN skills ON contributions_skills.skill_id = skills.id
JOIN employees ON contributions.employee_id = employees.id
WHERE projects.id = 1;

/*



SELECT projects.title as `Project title`,
        projects.from_date,
        projects.to_date,
        COUNT(contributions.id) as count_of_contributions
FROM projects
JOIN contributions ON 
        contributions.project_id = projects.id AND 
        (contributions.from_date between '2017-01-01' AND '2017-05-11') 
GROUP BY (projects.id)
ORDER BY count_of_contributions DESC
LIMIT 3;  
*/

SET @value = '2017';
SELECT CONCAT("Top 3 projects by count of contribution by ", @value) AS concated_string;

SELECT projects.id as 'Project id',
        projects.title as `Project title`,
        projects.from_date,
        projects.to_date,
        COUNT(contributions.id) as count_of_contributions
FROM projects
JOIN contributions ON 
        contributions.project_id = projects.id      
        AND
        @value = YEAR(contributions.to_date)
GROUP BY (projects.id)
ORDER BY count_of_contributions DESC
LIMIT 3;    

SET @value = '2017';
SELECT CONCAT("Top 3 projects by count of employee by ", @value) AS concated_string;

SELECT projects.id as 'Project id',
        projects.title as `Project title`,
        projects.from_date,
        projects.to_date,
        COUNT(DISTINCT employees.id) as count_of_employees
FROM projects
JOIN contributions ON 
        contributions.project_id = projects.id      
        AND
        @value = YEAR(contributions.to_date)
JOIN employees ON 
        employees.id = contributions.employee_id        
GROUP BY (projects.id)
ORDER BY count_of_employees DESC
LIMIT 3; 


SET @from_date = '2017-03-01';
SET @to_date = '2017-10-01';

SET @string = CONCAT("Get activity of employee from ", @from_date, " to ", @to_date);
SELECT @string as 'Activity of employee';

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