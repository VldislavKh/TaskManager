namespace TaskManager_API.Exceptions.CustomExceptions
{
    public class NotUniqueLoginException : Exception
    {
        public NotUniqueLoginException(string name, object key)
            : base($"object with login {key} already exists in {name}!")
        {
            Detail = "Login already exist";
        }
        public string Detail { get; }
    }
}
