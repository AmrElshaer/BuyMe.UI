using AutoMapper;
using BuyMe.Application.Company.Queries;
using BuyMe.Application.CustomField.Queries.GetCustomFields;
using BuyMe.Domain.Entities;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BuyMe.UnitTests.Mappings
{
    public class MappingTests : IClassFixture<MappingTestsFixture>
    {
        private readonly IMapper _mapper;

        public MappingTests(MappingTestsFixture fixture)
        {
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void ShouldMapCompanyToCompanyDto()
        {
            var entity = new Company();
            var result = _mapper.Map<CompanyDto>(entity);
            result.ShouldNotBeNull();
            result.ShouldBeOfType<CompanyDto>();
        }

        [Fact]
        public void ShouldMapCustomFieldToCustomFieldDto()
        {
            var entity = new CustomField();
            var result = _mapper.Map<CustomFieldDto>(entity);
            result.ShouldNotBeNull();
            result.ShouldBeOfType<CustomFieldDto>();
        }
    }
}