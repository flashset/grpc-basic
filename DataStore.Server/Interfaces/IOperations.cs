using DataStore.DataModel;

namespace DataStore.Server.Interfaces
{    
    public interface IOperations
    { 
        RegisterResponseModel Register(RegisterRequestModel data); 
    }
}
