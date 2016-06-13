(function () {
    'use strict';

    angular
        .module('productService', ['ngResource'])
        .factory('Product', Product);

    Product.$inject = ['$resource'];

    function Product($resource) {

        var rootUrl = 'http://www.api.fitnesspeople.com.co/api/products/'

        return $resource(rootUrl + ':id', { id: '@id' }, {
            get: { method: 'Get'},
            query: { method: 'Get', params: {}, isArray: false },
            byCategory: { method: 'Get', params: { categoryId: '@categoryId' }, isArray: true, url: rootUrl + 'category/:categoryId' }
        });
    }
})();