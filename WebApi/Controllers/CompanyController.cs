using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;
using AutoMapper;
using BusinessLayer.Model.Interfaces;
using BusinessLayer.Model.Models;
using Newtonsoft.Json;
using NLog;
using WebApi.Models;


namespace WebApi.Controllers
{
    public class CompanyController : ApiController
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;   
        private readonly ILogger _logger;

        public CompanyController(ICompanyService companyService, IMapper mapper, ILogger logger)
        {
            _companyService = companyService;
            _mapper = mapper;
            _logger = logger;
        }
        // GET api/<controller>
        public IEnumerable<CompanyDto> GetAll()
        {
            try
            {
                var items = _companyService.GetAllCompaniesAsync();
                return _mapper.Map<IEnumerable<CompanyDto>>(items);
            }
            catch(Exception ex)
            {
                _logger.Error(ex);
                throw (ex);
            }
        }

        // GET api/<controller>/5
        public async Task<CompanyDto> GetAsync(string companyCode)
        {
            try
            {


                var item = await _companyService.GetCompanyByCodeAsync(companyCode);
                return _mapper.Map<CompanyDto>(item);

            }
            catch(Exception ex)
            {
                _logger.Error(ex);
                throw (ex);
            }
         }

        // POST api/<controller>
        public async Task<bool> Post([FromBody]string value)
        {
            try
            {


                CompanyDto companyDto = JsonConvert.DeserializeObject<CompanyDto>(value);
                CompanyInfo companyInfo = _mapper.Map<CompanyInfo>(companyDto);
                var result = await _companyService.SaveCompanyAsync(companyInfo);
                return result;
            }
            catch(Exception ex)
            {
                _logger.Error(ex);
                throw (ex);
            }

        }

        // PUT api/<controller>/5
        public async Task<bool> Put(int id, [FromBody]string value)
        {
            try
            {
                CompanyDto companyDto = JsonConvert.DeserializeObject<CompanyDto>(value);
                CompanyInfo companyInfo = _mapper.Map<CompanyInfo>(companyDto);
                var result = await _companyService.SaveCompanyAsync(companyInfo);
                return result;
            }
            catch(Exception ex)
            {
                _logger.Error(ex);
                throw (ex);
            }
        }

        // DELETE api/<controller>/5
        public async Task<bool> Delete(string companyCode)
        {
            try
            {
                var result = await _companyService.DeleteCompanyByCodeAsync(companyCode);
                return result;
            }
            catch(Exception ex)
            {
                _logger.Error(ex);
                throw (ex);
            }
        }
    }
}