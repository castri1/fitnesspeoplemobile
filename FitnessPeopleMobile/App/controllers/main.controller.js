(function () {
    'use strict';

    angular
        .module('app')
        .controller('main', main);

    main.$inject = ['$scope', 'auth', '$location', 'store'];

    function main($scope, auth, $location, store) {
        $scope.logout = function () {
            auth.signout();
            store.remove('profile');
            store.remove('token');
            $location.path('/');
        }
    }
})();