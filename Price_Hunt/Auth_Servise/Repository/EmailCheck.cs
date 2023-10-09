using Auth_Servise.IntefaceRepository;
using System.Net.Sockets;
using System.Net;
using System.Text.RegularExpressions;

namespace Auth_Servise.Repository
{
    public class EmailCheck : IEmailCheck
    {
        public bool CheckExist(string email)
        {
            string[] host = (email.Split('@'));
            string hostname = host[1];

            IPHostEntry IPhst = Dns.Resolve(hostname);
            IPEndPoint endPt = new IPEndPoint(IPhst.AddressList[0], 25);
            Socket s = new Socket(endPt.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

            try
            {
                s.Connect(endPt);
            }
            catch (Exception)
            {
                return false;
            }
            finally 
            {
                s.Close(); 
            }

            return true;
        }

        public bool CorrectSyntax(string email)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);

            return re.IsMatch(email);
        }
    }
}
