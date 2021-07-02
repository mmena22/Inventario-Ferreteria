using System;
using System.Net;
using System.Net.Mail;

namespace Utilitarios
{
    public class EmailUtil
    {
        public static void Enviar(object opt)
        {
            try
            {
                OpcionesEmail opciones = (OpcionesEmail)opt;
                SmtpClient smtp = new SmtpClient
                {
                    Host = opciones.Host,
                    Port = opciones.Port,
                    EnableSsl = opciones.EnableSsl,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(opciones.From.Address, opciones.FromPassword)
                };
                using (MailMessage message = new MailMessage(opciones.From, opciones.To)
                {
                    Subject = opciones.Subject,
                    Body = opciones.Body
                })
                {
                    smtp.Send(message);
                } 
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
            }            
        }

        
    }

    public class OpcionesEmail
    {
        public int Port { get; set; }
        public MailAddress From { get; set; }
        public string FromPassword { get; set; }
        public MailAddress To { get; set; }
        public bool EnableSsl { get; set; }
        public string Host { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public OpcionesEmail(string Host, int Port)
        {
            this.EnableSsl = true;
            this.Host = Host;
            this.Port = Port;
        }

    }
}
