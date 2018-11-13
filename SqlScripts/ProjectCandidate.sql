CREATE TEMPORARY TABLE candidates_with_skill_coverage
SELECT emp.id,
       emp.name 
FROM employees emp