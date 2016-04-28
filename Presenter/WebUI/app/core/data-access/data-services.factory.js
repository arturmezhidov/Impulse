define(['app'], function (app) {

	app.factory('dataServicesFactory', dataServicesFactory);

	dataServicesFactory.$inject = ['$http'];

	function dataServicesFactory($http) {

		$http.defaults.cache = false;

		var facory = {
			createAPIService: createAPIService
		}

		function createAPIService(baseUrl) {
			return new BaseApiService(baseUrl);
		}

		function BaseApiService(baseUrl) {

			var self = this;
			this.baseUrl = baseUrl;
			this.getAll = getAll;
			this.getById = getById;
			this.create = create;
			this.update = update;
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
				//return $http
				//	.delete(self.baseUrl + '/' + id)
				//	.then(successCallback, errorCallback);

				return $http({
					method: 'delete',
					url: self.baseUrl + '/' + id

				}).then(successCallback, errorCallback);;
			}
		}

		return facory;
	}

});