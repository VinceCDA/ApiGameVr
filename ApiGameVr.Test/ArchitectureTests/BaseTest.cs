using ApiGameVr.Application.Interfaces.Repositories;
using ApiGameVr.Domain.Entities;
using ApiGameVr.Infrastructure.Data;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ApiGameVr.Test.ArchitectureTests
{
    public abstract class BaseTest
    {
        protected static readonly Assembly DomainAssembly = typeof(ApplicationUser).Assembly;
        protected static readonly Assembly ApplicationAssembly = typeof(IApplicationUserRepository).Assembly;
        protected static readonly Assembly InfrastructureAssembly = typeof(UserRepository).Assembly;
        protected static readonly Assembly PresentationAssembly = typeof(Program).Assembly;
    }
}
