using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.Interfaces.Services.Token
{
   public interface ISecurityService
    {
        string GetSha256Hash(string input);
        Guid CreateCryptographicallySecureGuid();
    }
}
