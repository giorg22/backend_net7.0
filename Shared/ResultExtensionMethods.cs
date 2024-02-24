using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public static class ResultExtensionMethods
    {
        //command
        public static Task<CommandResponse> Fail(ErrorCode erorrCode, string ErrorMeessage) =>
            Task.FromResult(new CommandResponse()
            {
                Success = false,
                Errors = new List<Error>() { new Error() { ErrorCode = erorrCode, ErrorMessage = ErrorMeessage } }
            });
        public static Task<CommandResponse> Fail(ErrorCode erorrCode) =>
            Task.FromResult(new CommandResponse()
            {
                Success = false,
                Errors = new List<Error>() { new Error() { ErrorCode = erorrCode } }
            }); 
        public static Task<CommandResponse> Fail(string errorMessage) =>
            Task.FromResult(new CommandResponse()
            {
                Success = false,
                Errors = new List<Error>() { new Error() { ErrorMessage = errorMessage } }
            }); 
        public static Task<CommandResponse> Fail() =>
            Task.FromResult(new CommandResponse()
            {
                Success = false,
            });
        public static Task<CommandResponse> Fail(IEnumerable<IdentityError> identityErrors) =>
            Task.FromResult(new CommandResponse()
            {
                Success = false,
                Errors = identityErrors.Select(x => new Error() { ErrorMessage = x.Description })
            });
        public static Task<CommandResponse> Ok() =>
            Task.FromResult(new CommandResponse()
            {
                Success = true
            }); 
        public static Task<CommandResponse> Ok(string resultId) =>
            Task.FromResult(new CommandResponse()
            {
                Success = true,
                ResultId = resultId
            }); 
        //query
        public static Task<QueryResponse<T>> Ok<T>(T data) =>
            Task.FromResult(new QueryResponse<T>()
            {
                Success = true,
                Data = data
            });
    }
}
