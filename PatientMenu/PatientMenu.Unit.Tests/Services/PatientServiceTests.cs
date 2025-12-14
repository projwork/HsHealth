using Moq;
using PatientMenu.Api.Interface;
using PatientMenu.Api.Models;
using PatientMenu.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientMenu.Unit.Tests.Services
{
    public class PatientServiceTests
    {
        private readonly Mock<IPatientRepository> _mockRepository;
        private readonly PatientService _service;

        public PatientServiceTests()
        {
            _mockRepository = new Mock<IPatientRepository>();
            _service = new PatientService(_mockRepository.Object);
        }

        [Fact]
        public async Task GetAllowedMenuAsync_ReturnsRepositoryResult()
        {
            int patientId = 1;
            string tenantId = "tenant1";

            var repoResult = new List<MenuItem>
            {
                new MenuItem { Id = 1, Name = "GF Oatmeal", IsGlutenFree = true, TenantId = tenantId }
            };

            _mockRepository.Setup(r => r.GetAllowedMenuAsync(patientId, tenantId))
                .ReturnsAsync(repoResult);

            var result = await _service.GetAllowedMenuAsync(patientId, tenantId);

            Assert.Single(result);
            Assert.Equal("GF Oatmeal", result.First().Name);
            _mockRepository.Verify(r => r.GetAllowedMenuAsync(patientId, tenantId), Times.Once);
        }
    }
}
