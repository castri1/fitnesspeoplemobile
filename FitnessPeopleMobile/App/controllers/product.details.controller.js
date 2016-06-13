(function () {
    'use strict';

    angular
        .module('app')
        .controller('details', details);

    details.$inject = ['$scope', '$routeParams', '$rootScope', 'Product'];

    function details($scope, $routeParams, $rootScope, Product) {

        $scope.previousUrl = 'category/' + $rootScope.categoryId;

        $scope.productUrl = $rootScope.productUrl;
        $scope.product = Product.get({ id: $routeParams.id });
    }
})();
