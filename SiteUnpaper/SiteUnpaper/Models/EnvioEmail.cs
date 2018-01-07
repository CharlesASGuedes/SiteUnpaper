using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace SiteUnpaper.Models
{
    public class EnvioEmail
    {
        public static bool EnviaMensagemEmail(Contato model)
        {
            try
            {
                //email do SITE
                var emailEnvio = "noreply@unpaper.com.br";
                var senhaEnvio = "Unpaper@2019!";
                var porta = 8889;
                var host = "mail.unpaper.com.br";

                //MX Record Address: igw5002.site4now.net
                //SMTP Host: mail.unpaper.com.br
                //SMTP Port: 25 or 8889(if your isp blocks port 25)
                //SSL Ports:    SMTP: 465, POP3: 995, IMAP: 993

                if (!ValidaEnderecoEmail(model.Email)) { return false; }

                using (MailMessage email = new MailMessage())
                {

                    email.From = new MailAddress(emailEnvio);

                    if (!string.IsNullOrWhiteSpace(model.Email))
                    {
                        email.ReplyTo = new MailAddress(emailEnvio);

                        //prioridade do email
                        email.Priority = MailPriority.Normal;
                        //utilize true pra ativar html no conteúdo do email, ou false, para somente texto
                        email.IsBodyHtml = true;

                        var enviar = string.Empty;
                        if (!model.Cliente)
                        {
                            enviar = "<em>" + "Email de Contato do Site" + "</em>" +
                            " </br>- Olá Equipe Unpaper, tudo bem? " +
                            " </br>" +
                                " </br>- Sr(a) " + model.Nome + " deseja alguma coisa que podemos oferecer, vamos ajudar!" +
                            " </br>" +
                            " </br>- Email do cliente: " + model.Email +
                            " </br>" +
                            " </br>- Telefone do cliente: " + model.Telefone +
                            " </br>" +
                            " </br>- Assunto do cliente: " + model.Assunto +
                            " </br>- E-mail automático, não responder.";
                            email.Subject = model.Assunto;
                            email.To.Add(new MailAddress(model.Email));
                        }

                        if (model.Cliente)
                        {
                            enviar = "<em>" + "Email de Contato do Site" + "</em>" +
                            " </br>- Olá " + model.Nome + ", tudo bem? " +
                            " </br>" +
                            " </br>- Obrigado por entrar em contato conosco" +
                            " </br>" +
                            " </br>- Em breve retornaremos " +
                            " </br>" +
                            " </br>- Nosso Telefone: (12) 3206-1898" +
                            " </br>" +
                            " </br>- Assunto: Retorno Contato Unpaper" +
                            " </br>- E-mail automático, não responder.";
                            email.Subject = "Contato Unpaper";
                            email.To.Add(new MailAddress(model.Email));
                        }

                        //corpo do email a ser enviado// Conteúdo do email. Se ativar html, pode utilizar cores, fontes, etc.
                        email.Body = enviar;
                        //codificação do assunto do email para que os caracteres acentuados serem reconhecidos. 
                        email.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
                        //codificação do corpo do emailpara que os caracteres acentuados serem reconhecidos.
                        email.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");
                    }

                    using (SmtpClient smtp = new SmtpClient(host, porta))
                    {
                        try
                        {
                            smtp.Host = host;
                            smtp.Port = porta;
                            smtp.EnableSsl = false;
                            smtp.UseDefaultCredentials = false;
                            smtp.Credentials = new System.Net.NetworkCredential(emailEnvio, senhaEnvio);
                            smtp.Send(email);
                        }
                        catch (Exception ex)
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool ValidaEnderecoEmail(string enderecoEmail)
        {
            try
            {
                //define a expressão regulara para validar o email
                var texto_Validar = enderecoEmail;
                var expressaoRegex = new Regex(@"\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}");

                // testa o email com a expressão
                return expressaoRegex.IsMatch(texto_Validar);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}