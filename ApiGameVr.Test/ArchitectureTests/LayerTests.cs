using ApiGameVr.Application.Features.Users.Commands.Create;
using NetArchTest.Rules;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ApiGameVr.Test.ArchitectureTests
{
    public sealed class LayerTests : BaseTest
    {
        [Fact]
        public void DomainLayer_Should_NotHaveDependencyOnApplication()
        {
            var result = Types.InAssembly(DomainAssembly)
                .Should()
                .NotHaveDependencyOn(ApplicationAssembly.GetName().Name)
                .GetResult();
            Assert.True(result.IsSuccessful);
        }

        [Fact]
        public void DomainLayer_ShouldNotHaveDependencyOn_InfrastructureLayer()
        {
            var result = Types.InAssembly(DomainAssembly)
                .Should()
                .NotHaveDependencyOn(InfrastructureAssembly.GetName().Name)
                .GetResult();
            Assert.True(result.IsSuccessful);
        }

        [Fact]
        public void ApplicationLayer_ShouldNotHaveDependencyOn_InfrastructureLayer()
        {
            var result = Types.InAssembly(ApplicationAssembly)
                .Should()
                .NotHaveDependencyOn(InfrastructureAssembly.GetName().Name)
                .GetResult();
            Assert.True(result.IsSuccessful);
        }

        [Fact]
        public void InfrastructureLayer_ShouldNotHaveDependencyOn_PresentationLayer()
        {
            var result = Types.InAssembly(InfrastructureAssembly)
                .Should()
                .NotHaveDependencyOn(PresentationAssembly.GetName().Name)
                .GetResult();
            Assert.True(result.IsSuccessful);
        }
    }
}
