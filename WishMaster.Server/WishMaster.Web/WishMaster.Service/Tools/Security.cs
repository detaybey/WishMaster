using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WishMaster.Service.Tools
{
    public static class Security
    {
        public static X509Certificate2 GetCertificate()
        {
            var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);

            foreach (var cert in store.Certificates)
            {
                if (cert.HasPrivateKey && cert.Issuer.Contains("MasterCard"))
                {
                    return cert;
                }
            }
            return null;
        }

    }
}
