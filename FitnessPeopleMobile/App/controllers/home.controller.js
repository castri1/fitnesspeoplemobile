(function () {
    'use strict';

    angular
        .module('app')
        .controller('home', home);

    home.$inject = ['$scope', 'auth', '$location', 'Product']; 

    function home($scope, auth, $location, Product) {
        
        $scope.categoryItems = [
            { name: 'Proteínas', id: 14, url: '/img/proteina.png' },
            { name: 'Quemadores', id: 15, url: '/img/quemadores.png' },
            { name: 'Aminoácidos', id: 16, url: '/img/aminos.png' },
            { name: 'PreWorkouts', id: 17, url: '/img/preworkouts.png' },
            { name: 'Snacks', id: 18, url: '/img/snacks.png' },
            { name: 'Ganadores', id: 31, url: '/img/ganadores.png' },
            { name: 'Multivitamínicos', id: 44, url: '/img/multivitaminicos.png' },
            { name: 'Pro Hormonales', id: 19, url: '/img/prohormonales.png' },
            { name: 'Creatinas', id: 25, url: '/img/creatina.png' }
        ];
    }
})();
