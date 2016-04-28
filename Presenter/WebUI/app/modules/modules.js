'use strict';

define([

	'./home/index',
	'./advertisements/index',
	'./services/index',
	'./stends/index',
	'./souvenirs/index',
	'./tipographies/index',
	'./photography/index',
	'./shop/index',
	'./our-works/index',
	'./contacts/index',
	'./test/index'

], function(home, advertisements, services, stends, souvenirs, tipographies, photography, shop, ourWorks, contacts, test) {

	return {
		home: home,
		advertisements: advertisements,
		services: services,
		stends: stends,
		souvenirs: souvenirs,
		tipographies: tipographies,
		photography: photography,
		shop: shop,
		ourWorks: ourWorks,
		contacts: contacts,
		test: test
	}

});