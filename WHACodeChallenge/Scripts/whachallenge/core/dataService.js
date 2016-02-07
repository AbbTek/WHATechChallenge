(function () {
    'use strict';

    angular
        .module('whachallenge.core')
        .factory('betsService', betsService);

    function betsService($http) {

        return {

            processFile: function (fileProcessRequest) {
                return $http.post('/api/bets/processfile', fileProcessRequest);
            },

            getStatus: function () {
                return $http.get('/api/bets/getstatus');
            },

            getCustomersAccordingWinnings: function (value) {
                return $http.get('/api/bets/getcustomersaccordingwinnings', { params: { greaterThan: value } });
            },

            getUnsettledFromWinners: function () {
                return $http.get('/api/bets/getunsettledfromwinners');
            },

            getUnsettledOver: function (value) {
                return $http.get('/api/bets/getunsettledover', { params: {times: value} });
            },

            getUnsettledWouldWinOver: function (value) {
                return $http.get('/api/bets/getunsettledwouldwinOver', { params: { toWin: value } });
            }
        };
    }
})();