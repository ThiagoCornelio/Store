using Store.Domain.Command.Interfaces;

namespace Store.Domain.Command
{
    public class GenericCommandResult :ICommandResult
    {
        public GenericCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public object Erros { get; set; }

        //Sempre padronizar os retornos, assim o Front irá ter uma ideia do retorno.
    }
}
