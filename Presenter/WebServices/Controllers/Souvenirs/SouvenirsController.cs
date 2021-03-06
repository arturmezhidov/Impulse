﻿using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.Presenter.WebServices.Models.Souvenirs;

namespace Impulse.Presenter.WebServices.Controllers.Souvenirs
{
	public class SouvenirsController : BaseApiController<Souvenir, SouvenirViewModel>
	{
		protected ISouvenirService BusinessService;

		protected override string FileDirectory
		{
			get { return base.FileDirectory + "Souvenirs/"; }
		}

		public SouvenirsController(ISouvenirService service)
			: base(service)
		{
			BusinessService = service;
		}
	}
}