'use strict';

define(['angular'], function (angular) {

	return angular
			.module('advertisements', [])
			.constant('advertisements.config', {
				TYPES_URL: '/api/advertisements/types',
				ADVERTS_URL: '/api/advertisements/adverts',
				MATERIALS_URL: '/api/advertisements/materials'
			});

});