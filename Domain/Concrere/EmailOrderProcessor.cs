using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrere
{
    public class EmailSettings
    {
        public string MailToAdress = "orders@example.com";
        public string MailFromAdress = "vapingstore@example.com";
        public bool UseSsl = true;
        public string Username = "MySmptUsername";
        public string Password = "MySmptPassword";
        public string ServerName = "smpt.example.com";
        public int ServerPort = 587;
        public bool WriteAsFile = true;
        public string FileLocation = @"c:\vaping_store_emails";
    }
    public class EmailOrderProcessor : IOrderProcessor
    {
        private EmailSettings emailSettings;
        public EmailOrderProcessor(EmailSettings settings)
        {
            emailSettings = settings;
        }

        public void ProcessOrder(Cart cart, ShopingDetails shopingDetails)
        {
            using (var smptClient = new SmtpClient())
            {
                smptClient.EnableSsl = emailSettings.UseSsl;
                smptClient.Host = emailSettings.ServerName;
                smptClient.Port = emailSettings.ServerPort;
                smptClient.UseDefaultCredentials = false;
                smptClient.Credentials = new NetworkCredential(emailSettings.Username, emailSettings.Password);

                if (emailSettings.WriteAsFile)
                {
                    smptClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smptClient.PickupDirectoryLocation = emailSettings.FileLocation;
                    smptClient.EnableSsl = false;
                }

                StringBuilder body = new StringBuilder()
                    .AppendLine("Новый заказ обработан")
                    .AppendLine("---")
                    .AppendLine("Товары:");
                foreach (var line in cart.Lines)
                {
                    var subtotal = line.ElectronicCigarettes.Price * line.Quantity;
                    body.AppendFormat("{0} x {1} итого: {2:c}", line.Quantity, line.ElectronicCigarettes.Name, subtotal);
                }

                body.AppendFormat("Обащая стоимость: {0:c}", cart.ComputeTotalValue)
                    .AppendLine("---")
                    .AppendLine("Доставка:")
                    .AppendLine(shopingDetails.Name)
                    .AppendLine(shopingDetails.Line1)
                    .AppendLine(shopingDetails.Line2 ?? "")
                    .AppendLine(shopingDetails.Line3 ?? "")
                    .AppendLine(shopingDetails.City)
                    .AppendLine(shopingDetails.Country);

                MailMessage mailMessage = new MailMessage(
                    emailSettings.MailFromAdress,
                    emailSettings.MailToAdress,
                    "Новый заказ отправлен!",
                    body.ToString()
                    );
                if (emailSettings.WriteAsFile)
                {
                    mailMessage.BodyEncoding = Encoding.UTF8;
                }

                smptClient.Send(mailMessage);
            }
        }
    }
}
