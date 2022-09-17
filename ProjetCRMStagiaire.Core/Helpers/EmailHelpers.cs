using System.Net.Mail;

namespace ProjetCRMStagiaire.Core.Helpers
{
    public static class EmailHelpers
    {
        public static string AssoConstante { get; set; } = "arfp.asso.fr";
        public static bool IsValidEmail(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }


        public static bool IsValidEmail(string email, string displayName)
        {
            try
            {
                MailAddress m = new MailAddress(email, displayName);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static bool IsValidEmailforAsso(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);

                if (!m.Host.Contains(AssoConstante, StringComparison.InvariantCultureIgnoreCase))
                {
                    return false;
                }

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
