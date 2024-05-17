
using FluentValidation;
using DomainEntity = crm.Project.Domain.domain.entities;
using crm.Project.Domain.domain.enums;
namespace crm.Project.Domain.domain.validations;

public class ProjectValidator : AbstractValidator<DomainEntity.Project>
{
    public ProjectValidator()
    {
        const string message = "The property {PropertyName} is required";
        RuleFor(x => x.ProjectName)
                .NotEmpty()
                .WithMessage(message);

        RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage(message);

        RuleFor(x => x.StartDate)
                .NotEmpty()
                .WithMessage(message);

        RuleFor(x => x.Deadline)
                .NotEmpty()
                .WithMessage(message);

        RuleFor(x => x.Priority)
                .Must(BeAValidPriority)
                .WithMessage("Invalid priority");

        RuleFor(x => x.Status)
                .Must(BeAValidStatus)
                .WithMessage("Invalid status");
    }

    private bool BeAValidPriority(ProjectPriority priority)
    {
        return Enum.IsDefined(typeof(ProjectPriority), priority);
    }

    private bool BeAValidStatus(ProjectStatus status)
    {
        return Enum.IsDefined(typeof(ProjectStatus), status);
    }

}
