(function () {

	'use strict';

	angular
		.module('dataAccess')
		.service('dataContext', dataContext);

	dataContext.$inject = ['config', 'dataServicesFactory'];

	function dataContext(config, dataServicesFactory) {
		this.advertsCategories = dataServicesFactory.createApiService(config.CTRL_ADVERTSCATEGORY);
		this.adverts = dataServicesFactory.createApiService(config.CTRL_ADVERTS);
		this.advertsGuestOrders = dataServicesFactory.createApiService(config.CTRL_ADVERTSGUESTORDERS);
		this.advertsOrders = dataServicesFactory.createApiService(config.CTRL_ADVERTSORDERS);
		this.addresses = dataServicesFactory.createApiService(config.CTRL_ADDRESSES);
		this.emails = dataServicesFactory.createApiService(config.CTRL_EMAILS);
		this.phones = dataServicesFactory.createApiService(config.CTRL_PHONES);
		this.socials = dataServicesFactory.createApiService(config.CTRL_SOCIALS);
		this.slides = dataServicesFactory.createApiService(config.CTRL_SLIDES);
		this.feedback = dataServicesFactory.createApiService(config.CTRL_FEEDBACK);
		this.ourWorksFolders = dataServicesFactory.createApiService(config.CTRL_OURWORKSFOLDERS);
		this.ourWorksItems = dataServicesFactory.createApiService(config.CTRL_OURWORKSITEMS);
		this.photoServices = dataServicesFactory.createApiService(config.CTRL_PHOTOSERVICES);
		this.serviceCategories = dataServicesFactory.createApiService(config.CTRL_SERVICECATEGORIES);
		this.services = dataServicesFactory.createApiService(config.CTRL_SERVICES);
		this.servicesGuestOrders = dataServicesFactory.createApiService(config.CTRL_SERVICESGUESTORDERS);
		this.servicesOrders = dataServicesFactory.createApiService(config.CTRL_SERVICESORDERS);
		this.souvenirsCategories = dataServicesFactory.createApiService(config.CTRL_SOUVENIRSCATEGORIES);
		this.souvenirs = dataServicesFactory.createApiService(config.CTRL_SOUVENIRS);
		this.souvenirsGuestOrders = dataServicesFactory.createApiService(config.CTRL_SOUVENIRSGUESTORDERS);
		this.souvenirsOrders = dataServicesFactory.createApiService(config.CTRL_SOUVENIRSORDERS);
		this.stendsCategories = dataServicesFactory.createApiService(config.CTRL_STENDSCATEGORIES);
		this.stends = dataServicesFactory.createApiService(config.CTRL_STENDS);
		this.stendsGuestOrders = dataServicesFactory.createApiService(config.CTRL_STENDSGUESTORDERS);
		this.stendsOrders = dataServicesFactory.createApiService(config.CTRL_STENDSORDERS);
		this.tipographiesCategories = dataServicesFactory.createApiService(config.CTRL_TIPOGRAPHIESCATEGORIES);
		this.tipographies = dataServicesFactory.createApiService(config.CTRL_TIPOGRAPHIES);
	}
})();