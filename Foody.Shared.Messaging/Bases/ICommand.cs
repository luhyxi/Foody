namespace Foody.Shared.Messaging.Bases;

public interface ICommand : IBaseCommand
{
    
}

public interface ICommand<TResponse> : IBaseCommand
{
    
}

public interface IBaseCommand
{
    
}