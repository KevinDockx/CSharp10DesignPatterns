using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    /// <summary>
    /// ConcreteComponent1
    /// </summary>
    public class CloudMailService : IMailService
    {
        public bool SendMail(string message)
        {
            Console.WriteLine($"Message \"{message}\" sent via {nameof(CloudMailService)}.");
            return true;
        }
    }

    /// <summary>
    /// ConcreteComponent2
    /// </summary>
    public class OnPremiseMailService : IMailService
    {
        public bool SendMail(string message)
        {
            Console.WriteLine($"Message \"{message}\" sent via {nameof(OnPremiseMailService)}.");
            return true;
        }
    }

    /// <summary>
    /// Component (as interface)
    /// </summary>
    public interface IMailService
    {
        bool SendMail(string message);
    }


    /// <summary>
    /// Decorator (as abstract base class)
    /// </summary>
    public abstract class MailServiceDecoratorBase : IMailService
    {
        private readonly IMailService _mailService;
        public MailServiceDecoratorBase(IMailService mailService)
        {
            _mailService = mailService;
        }

        public virtual bool SendMail(string message)
        {
            return _mailService.SendMail(message);
        }
    }

    /// <summary>
    /// ConcreteDecorator1
    /// </summary>
    public class StatisticsDecorator : MailServiceDecoratorBase
    {
        public StatisticsDecorator(IMailService mailService) 
            : base(mailService)
        {
        }

        public override bool SendMail(string message)
        {
            // Fake collecting statistics 
            Console.WriteLine($"Collecting statistics in {nameof(StatisticsDecorator)}.");
            return base.SendMail(message);
        }
    }

    /// <summary>
    /// ConcreteDecorator2
    /// </summary>
    public class MessageDatabaseDecorator : MailServiceDecoratorBase
    {
        /// <summary>
        /// A list of sent messages - a "fake" database
        /// </summary>
        public List<string> SentMessages { get; private set; } = new List<string>();

        public MessageDatabaseDecorator(IMailService mailService)
            : base(mailService)
        {
        }

        public override bool SendMail(string message)
        {
            if (base.SendMail(message))
            {
                // store sent message
                SentMessages.Add(message);
                return true;
            };

            return false;
        }
    }
}
