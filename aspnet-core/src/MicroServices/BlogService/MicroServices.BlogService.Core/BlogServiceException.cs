using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MicroServices.BlogService
{
    /// <summary>
    /// Base class for BlogService Exceptions
    /// </summary>
    public class BlogServiceException : ApplicationException
    {
        public BlogServiceException()
        {
        }

        public BlogServiceException(string message) 
            : base(message)
        {
        }

        public BlogServiceException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        protected BlogServiceException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}
