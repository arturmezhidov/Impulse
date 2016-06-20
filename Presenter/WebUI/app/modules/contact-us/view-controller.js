(function () {

	'use strict';

	angular
		.module('aboutUs')
		.controller('contactusController', contactusController);

	contactusController.$inject = ['$scope', 'dataContext', 'NgTableParams'];

	function contactusController($scope, dataContext, NgTableParams) {

		$scope.remove = remove;
		$scope.approve = approve;
		$scope.send = send;
		$scope.openForm = openForm;
		$scope.openMessages = openMessages;
		$scope.newMessagesCount = newMessagesCount;
		$scope.initControls = initControls;

		openForm();
		updateMessages();


		function remove(row) {
			dataContext.feedback.remove(row.Id, function () {
				$scope.tableParams.settings().dataset.remove(row);
				$scope.tableParams.reload();
			});
		}
		function approve(row) {
			dataContext.feedback.update(row, function (response) {
				angular.extend(row, response.data);
			});
		}
		function send(feedbackForm) {
			$scope.submiting = true;
			if (feedbackForm.$valid) {
				var data = {
					Name: $scope.name,
					Contacts: $scope.contacts,
					Message: $scope.feedbackMessage
				}
				dataContext.feedback.create(data, function (response) {
					$scope.name = '';
					$scope.contacts = '';
					$scope.feedbackMessage = '';
					console.log(response);
					updateMessages();
					$scope.submiting = false;
					alert('Сообщение отправлно');
				}, function (e) {
					console.log(e);
				});
			}
		}
		function openForm() {
			$scope.contactUsState = "form";
		}
		function openMessages() {
			updateMessages();
			$scope.contactUsState = "messages";
		}
		function newMessagesCount() {
			if (!$scope.tableParams) {
				return 0;
			}
			var items = $scope.tableParams.settings().dataset;
			var count = 0;
			for (var i = 0; i < items.length; i++) {
				if (!items[i].IsApprove) {
					count++;
				}
			}
			return count;
		}
		function updateMessages() {
			dataContext.feedback.getAll(function (response) {
				$scope.tableParams = new NgTableParams({
					count: 5
				}, {
					counts: [5, 10, 20],
					dataset: response.data
				});
			});
		}

		function initControls() {
			if (!String.prototype.trim) {
				(function () {
					// Make sure we trim BOM and NBSP
					var rtrim = /^[\s\uFEFF\xA0]+|[\s\uFEFF\xA0]+$/g;
					String.prototype.trim = function () {
						return this.replace(rtrim, '');
					};
				})();
			}

			[].slice.call(document.querySelectorAll('input.input__field, textarea.input__field')).forEach(function (inputEl) {
				// in case the input is already filled..
				if (inputEl.value.trim() !== '') {
					classie.add(inputEl.parentNode, 'input--filled');
				}
				// events:
				inputEl.addEventListener('focus', onInputFocus);
				inputEl.addEventListener('blur', onInputBlur);
			});

			function onInputFocus(ev) {
				classie.add(ev.target.parentNode, 'input--filled');
			}

			function onInputBlur(ev) {
				if (ev.target.value.trim() === '') {
					classie.remove(ev.target.parentNode, 'input--filled');
				}
			}
		}
	}

})();