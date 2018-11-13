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


SET @from_date = '2017-01-01';
SET @to_date = '2017-05-11';

SELECT CONCAT("Get project activity from ", @from_date, " to ", @to_date);

SELECT projects.title as `Project title`,
        projects.from_date,
        projects.to_date,
        COUNT(contributions.id) as count_of_contributions
FROM projects
JOIN contributions ON 
        contributions.project_id = projects.id AND 
        (contributions.from_date >= @from_date AND contributions.to_date <= @to_date) 
WHERE project_id = 1;          


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
        (@value = YEAR(contributions.to_date) AND @value = YEAR(contributions.from_date))
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
        (@value = YEAR(contributions.to_date) AND @value = YEAR(contributions.from_date))
JOIN employees ON 
        employees.id = contributions.employee_id        
GROUP BY (projects.id)
ORDER BY count_of_employees DESC
LIMIT 3; 

