(function () {
    'use strict';

    angular
        .module('whachallenge.core')
        .factory('betsService', betsService);

    function betsService($http) {

        return {

            processFile: function (fileProcessRequest) {
                return $http.post('/api/bets/processfile', fileProcessRequest);
            }
        };
    }
})();