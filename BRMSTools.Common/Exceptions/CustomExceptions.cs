using System;


namespace BRMSTools.Common.Exceptions
{
    public class CustomerNotFoundException : Exception
    {
        public CustomerNotFoundException(string message)
            : base(message)
        {
        }
    }


    public class SecurityAccessDeniedException : Exception
    {
        public SecurityAccessDeniedException(string message)
            : base(message)
        {
        }
    }
}
