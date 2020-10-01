namespace DDD.Sales.Application.Services.Interfaces
{
    public interface IUsuarioAppService
    {
        void VerificarLogin(int? id);
        
        bool ValidarLogin(string email, string senha);
    }
}