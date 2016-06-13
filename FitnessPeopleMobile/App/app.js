(function () {
    'use strict';

    var app = angular.module('app', [
        'auth0',
        'ngSanitize',
        'ngRoute',
        'angular-loading-bar',
        'ngAnimate',
        //'ui.bootstrap',
        'productService',
        'angular-storage',
        'angular-jwt',
    ]);

    app.config(config);
    app.run(run);
    app.factory('authInterceptor', authInterceptor);

    config.$inject = ['$routeProvider', '$locationProvider', 'authProvider', 'jwtInterceptorProvider', '$httpProvider', 'cfpLoadingBarProvider'];
    run.$inject = ['$rootScope', 'auth', 'store', 'jwtHelper', '$location'];
    authInterceptor.$inject = ['$rootScope', '$q', 'store'];

    function authInterceptor($rootScope, $q, store) {
        return {
            request: function (config) {
                config.headers = config.headers || {};
                var token = store.get('token');
                if (token) {
                    config.headers.Authorization = 'Bearer ' + token;;
                }
                return config;
            },
            response: function (response) {
                if (response.status === 401) {
                    //Handle
                }
                return response || $q.when(response);
            }
        };
    }
    function config($routeProvider, $locationProvider, authProvider, jwtInterceptorProvider, $httpProvider, cfpLoadingBarProvider) {

        //$locationProvider.html5Mode(true);
        cfpLoadingBarProvider.includeSpinner = false;

        authProvider.init({
            domain: 'fitnesspeople.auth0.com',
            clientID: 'OJOx2SneRRrb9u52QLQVq4Tcp3T7WokL',
            loginUrl: '/login'
        });

        $routeProvider
                .when('/login', {
                    templateUrl: '/views/login.html',
                    controller: 'login',
                })
                .when('/home', {
                    templateUrl: '/views/home.html',
                    controller: 'home',
                    requiresLogin: true
                })
                .when('/info', {
                    templateUrl: '/views/info.html',
                    requiresLogin: true
                })
                .when('/category/:categoryId', {
                    templateUrl: '/views/product.list.html',
                    controller: 'product.list',
                    requiresLogin: true
                })
                .when('/product/:id', {
                    templateUrl: '/views/product.details.html',
                    controller: 'details',
                    requiresLogin: true
                })
                .otherwise({ redirectTo: '/login' });
        
        jwtInterceptorProvider.tokenGetter = function (store) {
            return store.get('token');
        }

        $httpProvider.interceptors.push('authInterceptor');
    }
    function run($rootScope, auth, store, jwtHelper, $location) {
        $rootScope.$on("$locationChangeStart", function () {
            if (!auth.isAuthenticated) {
                var token = store.get('token');
                if (token) {
                    if (!jwtHelper.isTokenExpired(token)) {
                        auth.authenticate(store.get('profile'), token);
                        $location.path('/home');
                    }
                    else {
                        $location.path('/login');
                    }
                }
            }
        });
        auth.hookEvents();
    }

})();