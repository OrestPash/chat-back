
using System.Collections.Generic;

namespace IdentityServer4Demo.Models
{
    public class SignupResult
    {
        public string Id { get; set; }
        public List<string> Errors { get; set; }
        public bool IsSuccess{ get; set; }
    }
}
