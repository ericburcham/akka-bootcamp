using System;
using Akka.Actor;
using WinTail.Messages;

namespace WinTail.Actors
{
    internal class ValidationActor : UntypedActor
    {
        private readonly IActorRef _consoleWriterActor;

        public ValidationActor(IActorRef consoleWriterActor)
        {
            _consoleWriterActor = consoleWriterActor;
        }

        protected override void OnReceive(object message)
        {
            var msg = message as string;

            if (string.IsNullOrEmpty(msg))
            {
                _consoleWriterActor.Tell(new NullInputError("No input received."));
            }
            else
            {
                var valid = IsValid(msg);
                if (valid)
                {
                    _consoleWriterActor.Tell(new InputSuccess("Thank you!  Message was valid."));
                }
                else
                {
                    _consoleWriterActor.Tell(new ValidationError("Invalid:  input had an odd number of characters."));
                }
            }

            Sender.Tell(new ContinueProcessing());
        }

        private bool IsValid(string msg)
        {
            return msg.Length % 2 == 0;
        }
    }
}
