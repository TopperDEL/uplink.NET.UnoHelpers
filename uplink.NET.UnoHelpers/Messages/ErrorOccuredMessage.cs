using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uplink.NET.UnoHelpers.Messages
{
    public class ErrorOccuredMessage
    {
        public ErrorOccuredMessage(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; }
    }
}
