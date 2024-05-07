﻿using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Service.Contracts;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICompanyService> _companyService;
        private readonly Lazy<IEmployeeService> _employeeService;
        private readonly Lazy<IAuthenticationService> _authenticationService;
        private readonly Lazy<IShiftService> _shiftService;
        private readonly Lazy<IProductService> _productService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper, UserManager<User> userManager, IConfiguration configuration)
        {
            _companyService = new Lazy<ICompanyService>(() => new CompanyService(repositoryManager, logger, mapper));
            _employeeService = new Lazy<IEmployeeService>(() => new EmployeeService(repositoryManager, logger, mapper));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(logger, mapper, userManager, configuration));
            _shiftService = new Lazy<IShiftService>(() => new ShiftService(repositoryManager, mapper, userManager));
            _productService = new Lazy<IProductService>(() => new ProductService(repositoryManager, mapper));
        }
        public ICompanyService CompanyService => _companyService.Value;

        public IEmployeeService EmployeeService => _employeeService.Value;

        public IAuthenticationService AuthenticationService => _authenticationService.Value;

        public IShiftService ShiftService => _shiftService.Value;

        public IProductService ProductService => _productService.Value;
    }
}
