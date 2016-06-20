(function () {

	'use strict';

	angular
		.module('dataAccess')
		.factory('dataServicesFactory', dataServicesFactory);
 
	dataServicesFactory.$inject = ['$http', 'Upload', 'userService'];

	function dataServicesFactory($http, Upload, userService) {

		$http.defaults.cache = false;

		var facory = {
			createApiService: createApiService
		}

		function createApiService(baseUrl) {
			return new BaseApiService(baseUrl);
		}

		function BaseApiService(baseUrl) {

			var self = this;
			this.baseUrl = baseUrl;
			this.getAll = getAll;
			this.getById = getById;
			this.create = create;
			this.update = update;
			this.upload = upload;
			this.remove = remove;

			function getAll(successCallback, errorCallback) {
				return $http
					.get(self.baseUrl)
					.then(successCallback, errorCallback);
			}
			function getById(id, successCallback, errorCallback) {
				return $http
					.get(self.baseUrl + '/' + id)
					.then(successCallback, errorCallback);
			}
			function create(item, successCallback, errorCallback) {
				return $http
					.post(self.baseUrl, item)
					.then(successCallback, errorCallback);
			}
			function update(item, successCallback, errorCallback) {
				return $http
					.put(self.baseUrl, item)
					.then(successCallback, errorCallback);
			}
			function remove(id, successCallback, errorCallback) {
				return $http({
					method: 'delete',
					url: self.baseUrl + '/' + id

				}).then(successCallback, errorCallback);;
			}
			function upload(file, data, success, progress, error) {
				if (!file.$error) {
					Upload.upload({
						url: self.baseUrl,
						data: data,
						file: file,
						xsrfHeaderName: 'Authorization',
						headers: {
							'Authorization': userService.tokenType()+ ' ' + userService.token()
						}
					})
					.progress(progress || function (){})
					.success(success || function () { })
					.error(error || function(q, w) {
							console.log(q);
							console.log(w);
						});
				}
			}
		}

		return facory;
	}
})();