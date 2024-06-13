using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    public class PasswordModel
    {
        public string? Url { get; set; }
        public string? Username { get; set; }
        public string? PasswordValue { get; set; }
        public string? HttpRealm { get; set; } // Made nullable
        public string? FormActionOrigin { get; set; } // Made nullable
        public string? Guid { get; set; }
        public long? TimeCreated { get; set; }
        public long? TimeLastUsed { get; set; }
        public long? TimePasswordChanged { get; set; }
        public PasswordModel() { } // Parameterless constructor

        public PasswordModel(string url, string username, string password, string? httpRealm, string? formActionOrigin, string guid, string timeCreated, string timeLastUsed, string timePasswordChanged)
        {
            Url = url;
            Username = username;
            PasswordValue = password;
            HttpRealm = httpRealm;
            FormActionOrigin = formActionOrigin;
            Guid = guid;
            TimeCreated = ParseLongValue(timeCreated);
            TimeLastUsed = ParseLongValue(timeLastUsed);
            TimePasswordChanged = ParseLongValue(timePasswordChanged);
        }

        private long? ParseLongValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            if (long.TryParse(value, out long result))
                return result;

            return null;
        }
    }
}
