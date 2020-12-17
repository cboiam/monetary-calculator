CREATE DATABASE monetary_calculation;

CREATE TABLE public.employee (
    id SERIAL,
    name VARCHAR(100) NOT NULL,
    hiringDate TIMESTAMP NOT NULL,
    leaveDate TIMESTAMP,
    paymentUnit SMALLINT NOT NULL,
    paymentAmount DECIMAL NOT NULL,
    CONSTRAINT pk_employee_id
        PRIMARY KEY(id)
);

CREATE TABLE public.vacation (
    id SERIAL,
    startDate TIMESTAMP NOT NULL,
    endDate TIMESTAMP NOT NULL,
    employeeId INT,
    CONSTRAINT pk_vacation_id
        PRIMARY KEY(id),
    CONSTRAINT fk_employee
        FOREIGN KEY(employeeId) 
	        REFERENCES employee(id)
);
