(function () {

	'use strict';

	angular.module('app')
		.constant('config', {
			BASE_URL: '/api/',
			CTRL_ADVERTSCATEGORY: '/api/AdvertsCategory',
			CTRL_ADVERTS: '/api/Adverts',
			CTRL_ADVERTSGUESTORDERS: '/api/AdvertsGuestOrders',
			CTRL_ADVERTSORDERS: '/api/AdvertsOrders',
			CTRL_ADDRESSES: '/api/Addresses',
			CTRL_EMAILS: '/api/Emails',
			CTRL_PHONES: '/api/Phones',
			CTRL_SOCIALS: '/api/Socials',
			CTRL_SLIDES: '/api/Slides',
			CTRL_FEEDBACK: '/api/Feedback',
			CTRL_ACCOUNT_LOGIN: '/api/Token',
			CTRL_ACCOUNT_LOGOUT: '/api/Account/Logout',
			CTRL_ACCOUNT_REGISTER: '/api/Account/Register',
			AUTH_TOKEN: 'auth_token',
			CTRL_OURWORKSFOLDERS: '/api/OurWorksFolders',
			CTRL_OURWORKSITEMS: '/api/OurWorksItems',
			CTRL_PHOTOSERVICES: '/api/PhotoServices',
			CTRL_SERVICECATEGORIES: '/api/ServiceCategories',
			CTRL_SERVICES: '/api/Services',
			CTRL_SERVICESGUESTORDERS: '/api/ServicesGuestOrders',
			CTRL_SERVICESORDERS: '/api/ServicesOrders',
			CTRL_SOUVENIRSCATEGORIES: '/api/SouvenirsCategories',
			CTRL_SOUVENIRS: '/api/Souvenirs',
			CTRL_SOUVENIRSGUESTORDERS: '/api/SouvenirsGuestOrders',
			CTRL_SOUVENIRSORDERS: '/api/SouvenirsOrders',
			CTRL_STENDSCATEGORIES: '/api/StendsCategories',
			CTRL_STENDS: '/api/Stends',
			CTRL_STENDSGUESTORDERS: '/api/StendsGuestOrders',
			CTRL_STENDSORDERS: '/api/StendsOrders',
			CTRL_TIPOGRAPHIESCATEGORIES: '/api/TipographiesCategories',
			CTRL_TIPOGRAPHIES: '/api/Tipographies'
		});
})();
