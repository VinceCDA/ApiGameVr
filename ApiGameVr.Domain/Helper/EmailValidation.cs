using System.Globalization;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace ApiGameVr.Domain.Helper
{
    public class EmailValidation()
    {
        public static bool IsValidEmailWithIdn(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Split local and domain parts
                int atIndex = email.LastIndexOf('@');
                if (atIndex < 0) return false;

                string local = email.Substring(0, atIndex);
                string domain = email.Substring(atIndex + 1);

                var idn = new IdnMapping();
                domain = idn.GetAscii(domain); // convert to punycode if needed

                string normalized = local + "@" + domain;

                // Use balanced regex
                string pattern = "^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}$";
                return Regex.IsMatch(normalized, pattern, RegexOptions.IgnoreCase);
            }
            catch
            {
                return false;
            }
        }

    }

}
