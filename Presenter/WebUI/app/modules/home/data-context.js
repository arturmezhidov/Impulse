define(['./module'], function (module) {

	module.service('dataContext', dataContext);

	dataContext.$inject = ['config', 'dataServicesFactory'];

	function dataContext(config, dataServicesFactory) {

		this.slides = dataServicesFactory.createAPIService(config.SLIDES_URL);
	}

});