﻿using System.Collections.Generic;
using System.Web.Http;
using Impulse.Common.Components;
using Impulse.Common.Models;
using Impulse.Common.Models.Entities;
using Impulse.Presenter.WebServices.Filters;
using Impulse.Presenter.WebServices.Models.Application;

namespace Impulse.Presenter.WebServices.Controllers.Application
{
	[RoutePrefix("api/contacts/emails")]
	public class EmailsController : BaseApiController
	{
		protected IEmailManager DataManager;

		public EmailsController(IEmailManager dataManager)
			: base(dataManager)
		{
			DataManager = dataManager;
		}

		[HttpPost]
		[Route("")]
		[ModelCheck]
		public IHttpActionResult Create(EmailViewModel vm)
		{
			Email newItem = Mapper.Mapp<EmailViewModel, Email>(vm);
			Email createdItem = DataManager.Create(newItem);

			var response = Mapper.Mapp<Email, EmailViewModel>(createdItem);

			return Created("api/contacts/emails/" + response.Id, response);
		}

		[HttpGet]
		[Route("")]
		public IHttpActionResult GetAll()
		{
			var items = DataManager.GetAll();

			var response = Mapper.MappCollection<Email, EmailViewModel>(items);

			return Ok(response);
		}

		[HttpGet]
		[Route("{id:int}")]
		public IHttpActionResult GetById(int id)
		{
			var item = DataManager.GetById(id);

			if (item == null)
			{
				return NotFound();
			}

			var response = Mapper.Mapp<Email, EmailViewModel>(item);

			return Ok(response);
		}

		[HttpPut]
		[Route("")]
		[ModelCheck]
		public IHttpActionResult Update(List<EmailViewModel> vms)
		{
			IEnumerable<Email> items = Mapper.MappCollection<EmailViewModel, Email>(vms);
			IEnumerable<Email> updatedItems = DataManager.Update(items);

			var response = Mapper.MappCollection<Email, EmailViewModel>(updatedItems);

			return Ok(response);
		}

		[HttpDelete]
		[Route("{id:int}")]
		public IHttpActionResult Delete(int id)
		{
			var item = DataManager.Delete(id);

			if (item == null)
			{
				return NotFound();
			}

			var response = Mapper.Mapp<Email, EmailViewModel>(item);

			return Ok(response);
		}
	}
}