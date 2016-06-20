using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web.Configuration;
using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components
{
	public class FeedbackService : DataService<Feedback>, IFeedbackService
	{
		private readonly string smtpServer = WebConfigurationManager.AppSettings["smtpServer"];
		private readonly int port = Int32.Parse(WebConfigurationManager.AppSettings["smtpPort"]);
		private readonly string caption = WebConfigurationManager.AppSettings["caption"];
		private readonly string mailto = WebConfigurationManager.AppSettings["mailto"];
		private readonly string from = WebConfigurationManager.AppSettings["from"];
		private readonly string password = WebConfigurationManager.AppSettings["password"];

		public FeedbackService(IUnitOfWork uow)
			: base(uow)
		{
		}

		public override IQueryable<Feedback> GetAll()
		{
			return base.GetAll().OrderByDescending(i => i.CreatedDate);
		}

		public Feedback Approve(int feedbackId)
		{
			Feedback feedback = UnitOfWork.Feedbacks.GetById(feedbackId);

			if (feedback == null)
			{
				return null;
			}

			feedback.ApprovedDate = DateTime.Now;
			feedback.IsApprove = true;

			feedback = UnitOfWork.Feedbacks.Update(feedback);

			return feedback;
		}

		public override Feedback Create(Feedback newItem)
		{
			if (newItem != null)
			{
				newItem.CreatedDate = DateTime.Now;
				newItem.ApprovedDate = DateTime.Now;
				newItem.IsApprove = false;
			}

			Send(newItem);

			return base.Create(newItem);
		}

		public void Send(Feedback feedback)
		{
			try
			{
				MailMessage mail = new MailMessage()
				{
					From = new MailAddress(from),
					To = { new MailAddress(mailto) },
					Subject = caption,
					Body = createMessage(feedback)
				};

				SmtpClient client = new SmtpClient()
				{
					Host = smtpServer,
					Port = port,
					EnableSsl = true,
					Credentials = new NetworkCredential(from.Split('@')[0], password),
					DeliveryMethod = SmtpDeliveryMethod.Network
				};

				client.Send(mail);

				mail.Dispose();
			}
			catch (Exception e)
			{
				throw new Exception("Mail.Send: " + e.Message);
			}
		}

		private string createMessage(Feedback feedback)
		{
			string messageBody = String.Format("Имя пользователя: {1}{0}Контакты: {2}{0}Сообщение: {3}", 
				Environment.NewLine, feedback.Name, feedback.Contacts, feedback.Message);

			return messageBody;
		}
	}
}