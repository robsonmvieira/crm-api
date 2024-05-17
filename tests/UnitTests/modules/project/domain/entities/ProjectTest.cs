using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crm.Project.Domain.domain.entities;
using crm.Project.Domain.domain.enums;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace UnitTests.modules.project.domain.entities;

public class ProjectTest
{
    [Fact(DisplayName = nameof(InstantiateWithCreateStaticMethodTest))]
    [Trait("Domain", "Project")]
    public void InstantiateWithCreateStaticMethodTest()
    {
        var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
        });
        var logger = loggerFactory.CreateLogger<Project>();
        var project = Project.Create(
            "New ProjectName",
            "Test",
            DateTime.Now,
            DateTime.Now,
            ProjectPriority.Low,
            ProjectStatus.Active);
        Assert.NotNull(project);
        Assert.Equal("New ProjectName", project.ProjectName);
        Assert.Equal(ProjectStatus.Active, project.Status);
        logger.LogInformation("InstantiateWithCreateStaticMethodTest: {project}", project.Id);

    }

    [Fact(DisplayName = nameof(ShouldCreateProjectUsingConstructor))]
    [Trait("Domain", "Project")]
    public void ShouldCreateProjectUsingConstructor()
    {
        var loggerFactory = LoggerFactory.Create(builder =>
      {
          builder.AddConsole();
      });
        var logger = loggerFactory.CreateLogger<Project>();
        var project = new Project(
            "New ProjectName",
            "Test",
            DateTime.Now,
            DateTime.Now,
            "09dbf74f-9869-43a7-935c-bff670af8ce5"
            );
        Assert.NotNull(project);
        Assert.Equal("New ProjectName", project.ProjectName);
        Assert.Equal(ProjectPriority.Low, project.Priority);
        Assert.Equal(ProjectStatus.Active, project.Status);
        logger.LogInformation("ShouldCreateProjectUsingConstructor: {project}", project.Id);
    }
}
