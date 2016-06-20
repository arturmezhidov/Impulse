(function () {

	'use strict';

	angular
		.module('ourWorks')
		.controller('ourWorksFoldersViewController', ourWorksFoldersViewController);

	ourWorksFoldersViewController.$inject = ['$scope', 'dataContext'];

	function ourWorksFoldersViewController($scope, dataContext) {

		init();

		function init() {

			dataContext.ourWorksFolders.getAll(function (response) {
				$scope.folders = response.data;
			});

			var $grid = $('#tp-grid'),
				$name = $('#ourWorksName'),
				$close = $('#close'),
				$loader = $('<div class="loader"><i></i><i></i><i></i><i></i><i></i><i></i><span>Loading...</span></div>').insertBefore($grid),
				stapel = $grid.stapel({
					randomAngle: true,
					delay: 50,
					gutter: 70,
					pileAngles: 5,
					onLoad: function () {
						$loader.remove();
					},
					onBeforeOpen: function (pileName) {
						$name.html(pileName);
					},
					onAfterOpen: function (pileName) {
						$close.show();
					}
				});

			$close.on('click', function () {
				$close.hide();
				$name.empty();
				stapel.closePile();
			});
		}
	}

})();

