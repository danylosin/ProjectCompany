SELECT "Info about employee";

SELECT employees.name, 
        contributions.title as `Contribution title`, 
        projects.title as `Project title`,
        skills.title as `Skill title` 
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