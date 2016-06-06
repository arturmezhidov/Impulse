(function () {

	'use strict';

	angular.module('dataAccess', ['ngFileUpload']);
	angular.module('components', []);
	angular.module('adverts', []);
	angular.module('feedback', []);
	angular.module('map', []);
	angular.module('ourWorks', []);
	angular.module('photography', []);
	angular.module('services', []);
	angular.module('slider', []);
	angular.module('souvenirs', []);
	angular.module('stends', []);
	angular.module('tipographies', []);
	angular.module('aboutUs', []);

	angular.module('app',
	[
		'ngRoute',
		'ngAnimate',
		'ngMessages',
		'ngTable',
		'dataAccess',
		'components',
		'adverts',
		'feedback',
		'map',
		'ourWorks',
		'photography',
		'services',
		'slider',
		'souvenirs',
		'stends',
		'tipographies',
		'aboutUs'
	]);

})();