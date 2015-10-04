var societyRegisterModule = angular.module('societyRegister', ['common'])
.config(function ($routeProvider, $locationProvider) {
    $routeProvider.when('society/register/step1', { templateUrl: 'Templates/RegisterSocietyStep1.html', controller: 'SocietyRegisterStep1ViewModel' });
    $routeProvider.when('society/register/step2', { templateUrl: 'Templates/RegisterSocietyStep2.html', controller: 'SocietyRegisterStep2ViewModel' });
    $routeProvider.when('society/register/confirm', { templateUrl: 'Templates/RegisterSocietyConfirm.html', controller: 'SocietyRegisterConfirmViewModel' });

    $routeProvider.otherwise({ redirectTo: 'society/register/step1' });

   // $locationProvider.html5Mode({ enabled: true, requireBase: false });
});

//ToDO: Remove the $Scope and replace with vm later....
societyRegisterModule.controller("SocietyRegisterViewModel", function ($scope,$http,$location,$window,viewModelHelper) {

    $scope.viewModelHelper = viewModelHelper;

    $scope.societyRegisterModeStep1 = new SocietyMaster.SocietyRegisterModeStep1();
    $scope.societyRegisterModeStep2 = new SocietyMaster.SocietyRegisterModeStep2();

    $scope.previous = function () {
        $window.history.back();
    }

});

societyRegisterModule.controller("SocietyRegisterStep1ViewModel", function ($scope, $http, $location, $window,
    viewModelHelper, validator) {

    viewModelHelper.modelIsValid = true;
    viewModelHelper.modelErrors = [];

    var societyModelStep1Rules = [];

    var setupRules = function () {
        societyModelStep1Rules.push(new validator.PropertyRule("Name", {
            required: { message: "Name is required" }
        }));
        societyModelStep1Rules.push(new validator.PropertyRule("Description", {
            required: { message: "Description is required" }
        }));
        societyModelStep1Rules.push(new validator.PropertyRule("Address", {
            required: { message: "Address is required" }
        }));
        societyModelStep1Rules.push(new validator.PropertyRule("Locality", {
            required: { message: "Locality is required" }
        }));
        societyModelStep1Rules.push(new validator.PropertyRule("City", {
            required: { message: "City is required" }
        }));
        societyModelStep1Rules.push(new validator.PropertyRule("State", {
            required: { message: "State is required" }
        }));
        societyModelStep1Rules.push(new validator.PropertyRule("ZipCode", {
            required: { message: "Zip code is required" }
            
        }));
    }

    $scope.step2 = function () {
        validator.ValidateModel($scope.societyRegisterModeStep1, societyModelStep1Rules);
        viewModelHelper.modelIsValid = $scope.societyRegisterModeStep1.isValid;
        viewModelHelper.modelErrors = $scope.societyRegisterModeStep1.errors;
        if (viewModelHelper.modelIsValid) {
            viewModelHelper.apiPost('api/society/register/validate1', $scope.societyRegisterModeStep1,
                function (result) {
                    $scope.societyRegisterModeStep1.Initialized = true;
                    $location.path('society/register/step2');
                });
        }
    }

    setupRules();

});

societyRegisterModule.controller("SocietyRegisterStep2ViewModel", function ($scope, $http, $location, $window,
    viewModelHelper, validator) {

    viewModelHelper.modelIsValid = true;
    viewModelHelper.modelErrors = [];

    $scope.confirm = function () {
        viewModelHelper.apiPost('api/society/register/validate2', $scope.societyRegisterModeStep2,
                function (result) {
                    $scope.societyRegisterModeStep2.Initialized = true;
                    $location.path('society/register/confirm');
                });

    }

});

societyRegisterModule.controller("SocietyRegisterConfirmViewModel", function ($scope, $http, $location, $window,
    viewModelHelper, validator) {

    $scope.createSociety = function () {

        var societyModel;

        societyModel = $.extend(societyModel, $scope.societyRegisterModeStep1);
        //ToDO:Similarly do for the other steps  too
        alert($scope.societyRegisterModeStep1.Name);

        viewModelHelper.apiPost('api/society/register', societyModel,
            function (result) {
                //$window.location.href = SocietyMaster.rootPath;
                $window.location.href ="/";
            });
    }

});

