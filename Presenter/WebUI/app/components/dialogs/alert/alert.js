(function () {

	angular.module('components').directive('alert', function () {
		return {
			restrict: 'E',
			scope: {
				title: '=title',
				content: '=content'
			},
			templateUrl: '/app/components/alert/alert.html',
			link: function (scope, element, attr) {



			}
		};
	});

})();