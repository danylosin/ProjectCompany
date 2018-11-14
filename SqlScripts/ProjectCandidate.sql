SET @countOfNeededSkills = 5;

SELECT emp.id,
       emp.name,
       COUNT(s.id) / @countOfNeededSkills as 'Skill coverage'
FROM employees emp  
JOIN employees_skills emp_sk 
    ON emp_sk.employee_id = emp.id 
JOIN skills s 
    ON s.id = emp_sk.skill_id 
    AND 
    (s.id = 5 OR s.id = 9 OR s.id = 10 OR s.id = 2 OR s.id = 1)
GROUP BY (emp.id);

SET @countOfNeededSkills = 2;

SELECT emp.id,
       emp.name,
        COUNT(DISTINCT emp_sk.skill_id) as count_of_skills_employee,
        COUNT(DISTINCT emp_sk.skill_id) / @countOfNeededSkills  as skill_coverage
FROM employees emp
JOIN skills s ON (s.id = 5 OR s.id = 9) 
JOIN employees_skills emp_sk ON emp_sk.employee_id = emp.id
GROUP BY (emp.id)
ORDER BY (skill_coverage) DESC


