    
var newSocietyModule = angular.module('newSociety', ['common']);

newSocietyModule.controller('NewSocietyViewModel', function ($scope, $window, viewModelHelper) {
    $scope.viewModelHelper = viewModelHelper;
    $scope.newSocietyModel = new SocietyMaster.NewSocietyModel();

    $scope.previous = function () {
        $window.history.back();
    }
});