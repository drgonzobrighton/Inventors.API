using Inventors.API.Domain;
using System.Collections.Generic;

namespace Inventors.API.Contracts.V1.Responses
{
    public class ApiResponse<T> where T : IEntity
    {
        public bool Success { get; set; }
        public List<string> Messages { get; set; } = new();

        public T Entity { get; set; }

        public ApiResponse(T entity) : this(true, new List<string>(), entity)
        {

        }

        public ApiResponse(List<string> messages) : this(false, messages, default)
        {

        }

        private ApiResponse(bool success, List<string> messages, T entity)
        {
            Success = success;
            Messages = messages;
            Entity = entity;
        }
    }
}
