(function () {
    'use strict';

    angular
        .module('app')
        .controller('login', login);

    login.$inject = ['$scope', '$routeParams', 'auth', 'store', '$location'];

    function login($scope, $routeParams, auth, store, $location) {
        $scope.message = {};

        function onLoginSuccess(profile, token) {
            store.set('profile', profile);
            store.set('token', token);
            $location.path('/home');
        }

        function onLoginFailed() {
            $scope.message.text = 'Credenciales inválidas';
        }

        $scope.submit = function () {
            auth.signin({
                connection: 'Username-Password-Authentication',
                username: $scope.user,
                password: $scope.pass,
                authParams: {
                    scope: 'openid name email'
                }
            }, onLoginSuccess, onLoginFailed, 'Auth0');
        };
    }
})();