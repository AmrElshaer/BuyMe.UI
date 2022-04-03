using AutoMapper;
using BuyMe.Application.Company.Queries;
using BuyMe.Application.CustomField.Queries.GetCustomFields;
using BuyMe.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace BuyMe.UnitTests.Mappings;

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
        result.Should().NotBeNull();
    }

    [Fact]
    public void ShouldMapCustomFieldToCustomFieldDto()
    {
        var entity = new CustomField();
        var result = _mapper.Map<CustomFieldDto>(entity);
        result.Should().NotBeNull();
    }
}