﻿using BusinessLayer.Model.Interfaces;
using System.Collections.Generic;
using AutoMapper;
using BusinessLayer.Model.Models;
using DataAccessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CompanyInfo>> GetAllCompaniesAsync()
        {
            var res = await _companyRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CompanyInfo>>(res);
        }

        public async Task<CompanyInfo> GetCompanyByCodeAsync(string companyCode)
        {
            var result = await _companyRepository.GetByCodeAsync(companyCode);
            return _mapper.Map<CompanyInfo>(result);
        }

        public async Task<bool> SaveCompanyAsync(CompanyInfo companyInfo)
        {
            var company = _mapper.Map<Company>(companyInfo);
            bool result = await _companyRepository.SaveCompanyAsync(company);
            return result;
        }

        public async Task<bool> DeleteCompanyByCodeAsync(string companyCode)
        {
            bool result = await _companyRepository.DeleteCompanyAsync(companyCode);
            return result;
        }
    }
}
