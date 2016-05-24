define(['../module'], function (module) {

	module.controller('slidesListController', slidesListController);

	slidesListController.$inject = ['$scope', 'dataContext'];

	function slidesListController($scope, dataContext) {

		dataContext.slides.getAll(function (response) {
			$scope.slides = response.data;
		});

	}
});