using Tasks.Api.Core.Exceptions;
using System.Net;

namespace Tasks.Api.WebHost.Helpers
{
    public static class ExceptionsHelper
    {
        public static Dictionary<Type, HttpStatusCode> ExceptionsHttpStatusCodes => new()
        {
            [typeof(ValidationException)] = HttpStatusCode.UnprocessableEntity,
            [typeof(EntityNotFoundException)] = HttpStatusCode.NotFound
        };
    }
}
