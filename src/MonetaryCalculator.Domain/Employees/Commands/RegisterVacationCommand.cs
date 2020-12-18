﻿using MediatR;
using System;

namespace MonetaryCalculator.Domain.Employees.Commands
{
    public class RegisterVacationCommand : ICommand, IRequest<Vacation>
    {
        public int EmployeeId { get; init; }
        public DateTime StartDate { get; init; }
        public DateTime EndDate { get; init; }

        public bool IsValid()
        {
            return EmployeeId != default &&
                StartDate != default &&
                EndDate != default &&
                StartDate > DateTime.Today &&
                EndDate > StartDate;
        }
    }
}
