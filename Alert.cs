using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace Tacografo_DB
{
    public class Alert
    {
        SmtpClient emailClient;
        
        const string SMTP_SERVER = "";
        const string USERNAME = "";
        const string PASSWORD = ""; //AHH, ESTE NIVEL DE SEGURIDAD SÍ SE PUEDE VER!!!

        const string FROM = "";
        const string TO = "";
        
        public Alert()
        {
            emailClient = new SmtpClient(SMTP_SERVER)
            {
                Port = 587,
                Credentials = new NetworkCredential(USERNAME, PASSWORD),
                EnableSsl = true
            };
        }

        public void SendAlert(int deviceID) {
            emailClient.SendAsync(new MailMessage(FROM, TO, "Alerta de combustible", 
                String.Format("Vehículo con ID = {0} presenta nivel de combustible irregular.", deviceID)), null);
        }
    }
}
