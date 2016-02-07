(function () {
    'use strict';

    angular
       .module('whachallenge.bets')
       .controller('betsController', betsController);

    function betsController($scope, FileUploader) {
        $scope.uploader = new FileUploader({ url: '/fileupload'});
        
        //$scope.test = function() {
        //    alert("Hola..");
        //};

    } 
})();