
using crm.Core.Domain.repositories;
using FluentValidation;
using FluentValidation.Results;

namespace crm.Core.Domain.entities;

public abstract class BaseService
{
    private readonly INotifier _notifier;
    
    protected BaseService(INotifier notifier)
    {
        _notifier = notifier;
    }
    protected void Notify(string message)
    {
        _notifier.Handle(new Notification(message));       
    }
    
    private void Notify(ValidationResult   errors)
    {
        foreach (var error in errors.Errors)
        {
            Notify(error.ErrorMessage);
        }
    }
    

    protected bool ValidateExecution<TE, TV>(TE entity, TV validator) 
        where TE : Entity where TV: AbstractValidator<TE>
    {
        
        var result = validator.Validate(entity);
        if (result.IsValid) return true;
        
        Notify(result);
        return false;
    }
  
}