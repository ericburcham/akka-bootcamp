namespace WinTail.Messages
{
    internal class NullInputError : InputError
    {
        public NullInputError(string reason) : base(reason)
        {
        }
    }
}