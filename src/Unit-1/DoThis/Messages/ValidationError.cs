namespace WinTail.Messages
{
    internal class ValidationError : InputError
    {
        public ValidationError(string reason) : base(reason)
        {
        }
    }
}