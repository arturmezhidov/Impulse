define(['./module'], function (module) {

	module.service('dataContext', dataContext);

	dataContext.$inject = ['config', 'dataServicesFactory'];

	function dataContext(config, dataServicesFactory) {

		this.types = dataServicesFactory.createAPIService(config.TYPES_URL);
		this.adverts = dataServicesFactory.createAPIService(config.ADVERTS_URL);
		this.materials = dataServicesFactory.createAPIService(config.MATERIALS_URL);
	}

});