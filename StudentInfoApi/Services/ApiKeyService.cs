using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StudentInfoAPI.Data;
using static StudentInfoAPI.Entities.UserApiKeys;

namespace StudentInfoAPI.Services
{
    public class ApiKeyService
    {
        private readonly StudentInfoDbContext _studentInfoDbContext;

        public ApiKeyService(StudentInfoDbContext studentInfoDbContext)
        {
            _studentInfoDbContext = studentInfoDbContext;
        }

        public UserApiKey CreateApiKey(IdentityUser user)
        {
            var newApiKey = new UserApiKey
            {
                User = user,
                Value = GenerateApiKeyValue()
            };

            _studentInfoDbContext.UserApiKeys.Add(newApiKey);
            _studentInfoDbContext.SaveChanges();

            return newApiKey;
        }

        private string GenerateApiKeyValue() =>
            $"{Guid.NewGuid().ToString()}-{Guid.NewGuid().ToString()}";
    }
}
