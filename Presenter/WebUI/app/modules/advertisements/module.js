'use strict';

define(['angular'], function (angular) {

	return angular
			.module('advertisements', [])
			.constant('advertisements.config', {
				TYPES_URL: 'http://localhost:11190/api/advertisements/types',
				ADVERTS_URL: 'http://localhost:11190/api/advertisements/adverts',
				MATERIALS_URL: 'http://localhost:11190/api/advertisements/materials'
			});

});