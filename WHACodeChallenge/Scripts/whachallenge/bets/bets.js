(function () {
    'use strict';

    angular
       .module('whachallenge.bets')
       .controller('betsController', betsController);

    function betsController($scope, FileUploader, betsService) {
        var uploader = $scope.uploader = new FileUploader({ url: '/fileupload', autoUpload: true });
        var uploadeFileName;

        uploader.filters.push({
            name: 'csvFilter',
            fn: function (item /*{File|FileLikeObject}*/, options) {
                var type = '|' + item.type.slice(item.type.lastIndexOf('/') + 1) + '|';
                return '|csv|'.indexOf(type) !== -1;
            }
        });

        uploader.onSuccessItem = function (fileItem, response, status, headers) {
            console.info('onSuccessItem', fileItem, response, status, headers);
            uploadeFileName = response;
            $scope.fileUploaded = true;
        };

        $scope.fileUploaded = false;
        $scope.data = {
            betType: null,
            option: '1'
        };
        $scope.processFile = function () {
            console.info('ProcessFile', uploadeFileName, $scope.data);
            betsService
                .processFile({ fileURL: uploadeFileName, betType: $scope.data.betType })
                .then(function () {
                    $scope.checkStatus();
                    $scope.fileUploaded = false;
                });
        };
        $scope.totalSettledBets = 0;
        $scope.totalUnsettledBets = 0;

        $scope.checkStatus = function () {
            betsService.getStatus().then(function (response) {
                $scope.totalSettledBets = response.data.TotalSettledBets;
                $scope.totalUnsettledBets = response.data.TotalUnsettledBets;
            });
        };

        $scope.historicsCustomers = [];
        $scope.showHistoric = false;

        $scope.showCustomersWithWinnings = function () {
            betsService.getCustomersAccordingWinnings(60).then(function (response) {
                $scope.historicsCustomers = response.data;
                $scope.showHistoric = true;
                $scope.showUnsettled = false;
            });
        };

        $scope.unsettledBets = [];
        $scope.showUnsettled = false;

        $scope.showUnsettledBetsFromWinners = function () {
            betsService.getUnsettledFromWinners().then(function (response) {
                $scope.unsettledBets = response.data;
                $scope.showHistoric = false;
                $scope.showUnsettled = true;
            });
        };

        $scope.showUnsettledOver = function (times) {
            betsService.getUnsettledOver(times).then(function (response) {
                $scope.unsettledBets = response.data;
                $scope.showHistoric = false;
                $scope.showUnsettled = true;
            });
        };

        $scope.showUnsettledWouldWinOver = function (toWin) {
            betsService.getUnsettledWouldWinOver(toWin).then(function (response) {
                $scope.unsettledBets = response.data;
                $scope.showHistoric = false;
                $scope.showUnsettled = true;
            });
        };

        $scope.checkStatus();
    } 
})();