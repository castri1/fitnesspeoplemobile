(function () {
    'use strict';

    angular
        .module('app')
        .controller('product.list', productListCtrl);

    productListCtrl.$inject = ['$scope', '$rootScope', 'Product', '$routeParams', '$location'];

    function productListCtrl($scope, $rootScope, Product, $routeParams, $location) {
        $scope.previousUrl = 'home';
        $rootScope.categoryId = $routeParams.categoryId;

        $scope.productList = Product.byCategory({ categoryId: $routeParams.categoryId });

        $scope.viewProduct = function (id, url) {
            $rootScope.productUrl = url;
            $location.path('/product/' + id);
        }
    }
})();
