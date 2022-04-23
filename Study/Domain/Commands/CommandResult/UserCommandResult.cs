namespace Study.Domain.Commands.CommandResult
{
    public class UserCommandResult
    {
        public Code TypeCode { get; private set; }
        public string Message { get; private set; }
        public object Data { get; private set; }


        public static UserCommandResult IsSuccess(string message, object data)
        {


            return new UserCommandResult
            {
                TypeCode = Code.Success,
                Message = message,
                Data = data,
            };

        }

        public static UserCommandResult IsFailure(string message, object data)
        {


            return new UserCommandResult
            {
                TypeCode = Code.BadRequest,
                Message = message,
                Data = data,
            };

        }

        public static UserCommandResult IsFailure(string message)
        {


            return new UserCommandResult
            {
                TypeCode = Code.BadRequest,
                Message = message,
            };

        }
    }
}
