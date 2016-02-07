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
            betsService.processFile({ fileURL: uploadeFileName, betType: $scope.data.betType });
        };
    } 
})();