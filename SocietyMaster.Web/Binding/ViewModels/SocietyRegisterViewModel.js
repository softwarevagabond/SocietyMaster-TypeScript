var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
//Create the Society Register Module
(function () {
    angular.
        module('societyRegister', ['common']).config(routeConfig);
    function routeConfig($routeProvider, $locationProvider) {
        $routeProvider.when('/society/register/step1', { templateUrl: '/Templates/RegisterSocietyStep1.html', controller: 'SocietyRegisterStep1ViewModel', controllerAs: "vm" });
        $routeProvider.when('/society/register/step2', { templateUrl: '/Templates/RegisterSocietyStep2.html', controller: 'SocietyRegisterStep2ViewModel', controllerAs: "vm" });
        $routeProvider.when('/society/register/confirm', { templateUrl: '/Templates/RegisterSocietyConfirm.html', controller: 'SocietyRegisterConfirmViewModel', controllerAs: "vm" });
        $routeProvider.otherwise({ redirectTo: '/society/register/step1' });
        $locationProvider.html5Mode({ enabled: true });
    }
})();
var SocietyMaster;
(function (SocietyMaster) {
    var SocietyRegisterViewModel = (function () {
        function SocietyRegisterViewModel($window, viewModelHelper) {
            this.$window = $window;
            this.viewModelHelper = viewModelHelper;
            var vm = this;
            //if (vm.societyRegisterStep1Model == null) {
            //    vm.societyRegisterStep1Model = new SocietyMaster.SocietyRegisterStep1Model();
            //}
            //if (vm.societyRegisterStep2Model == null) {
            //    vm.societyRegisterStep2Model = new SocietyMaster.SocietyRegisterStep2Model();
            //}
            alert("test- base");
            //vm.societyRegisterStep1Model = new SocietyMaster.SocietyRegisterStep1Model();
            //vm.societyRegisterStep2Model = new SocietyMaster.SocietyRegisterStep2Model();
            //Todo: Assign the value to the service -> model1 and model2
        }
        SocietyRegisterViewModel.prototype.previous = function () {
            this.$window.history.back();
        };
        SocietyRegisterViewModel.inject = ['$window', 'viewModelHelper'];
        return SocietyRegisterViewModel;
    })();
    angular.module('societyRegister')
        .controller('SocietyRegisterViewModel', SocietyRegisterViewModel);
    var SocietyRegisterStep1ViewModel = (function (_super) {
        __extends(SocietyRegisterStep1ViewModel, _super);
        function SocietyRegisterStep1ViewModel($window, viewModelHelper, $location) {
            _super.call(this, $window, viewModelHelper);
            this.$window = $window;
            this.viewModelHelper = viewModelHelper;
            this.$location = $location;
            if (this.societyRegisterStep1Model != null) {
                alert(this.societyRegisterStep1Model.Name);
            }
            var vm = this;
            this.societyRegisterStep1Model = new SocietyMaster.SocietyRegisterStep1Model();
        }
        SocietyRegisterStep1ViewModel.prototype.ValidateStep1 = function (societyRegisterStep1Model) {
            this.errors = [];
            if (societyRegisterStep1Model.Name.trim() == '') {
                this.errors.push("Name is required");
            }
            //todo: Add other validations -- Do we need the local variable errors?? can directly use societyRegisterStep1Model.Errors??
            societyRegisterStep1Model.Errors = this.errors;
            societyRegisterStep1Model.IsValid = (this.errors.length == 0);
        };
        SocietyRegisterStep1ViewModel.prototype.step2 = function () {
            //ToDo:Handle Falure and also change the signature for Failure to may be optional...
            var _this = this;
            //todo: For testing only
            //  this.$location.path('/society/register/step2');
            // console.log(this.$location.path());
            alert(this.societyRegisterStep1Model.Name);
            this.ValidateStep1(this.societyRegisterStep1Model);
            this.viewModelHelper.modelIsValid = this.societyRegisterStep1Model.IsValid;
            this.viewModelHelper.modelErrors = this.societyRegisterStep1Model.Errors;
            alert(this.viewModelHelper.modelErrors);
            if (this.viewModelHelper.modelIsValid) {
                this.viewModelHelper.apiPost('api/society/register/validate1', this.societyRegisterStep1Model, function (result) {
                    _this.societyRegisterStep1Model.Initialized = true;
                    alert("afte serve trip" + _this.societyRegisterStep1Model.Name);
                    _this.$location.path('/society/register/step2');
                    //Todo: update the service -> step1 model 
                }, function (result) { }, function (result) { });
            }
        };
        SocietyRegisterStep1ViewModel.inject = ['$window', 'viewModelHelper', '$location'];
        return SocietyRegisterStep1ViewModel;
    })(SocietyRegisterViewModel);
    angular.module('societyRegister')
        .controller('SocietyRegisterStep1ViewModel', SocietyRegisterStep1ViewModel);
    var SocietyRegisterStep2ViewModel = (function (_super) {
        __extends(SocietyRegisterStep2ViewModel, _super);
        function SocietyRegisterStep2ViewModel($window, viewModelHelper, $location) {
            _super.call(this, $window, viewModelHelper);
            this.$window = $window;
            this.viewModelHelper = viewModelHelper;
            this.$location = $location;
            var vm = this;
            this.societyRegisterStep2Model = new SocietyMaster.SocietyRegisterStep2Model();
            // alert(this.societyRegisterStep1Model.Name);
            //ToDO: Like in step1 - assgn the service -> step2
        }
        SocietyRegisterStep2ViewModel.prototype.previous = function () {
            //alert("Back");
            //this.$window.history.back();
            //console.log(this.$location.path());
            _super.prototype.previous.call(this);
        };
        SocietyRegisterStep2ViewModel.prototype.confirm = function () {
            alert("confirm");
            //ToDo:Handle Falure and also change the signature for Failure to may be optional...
            //this.viewModelHelper.apiPost('api/society/register/validate2', this.societyRegisterStep2Model,
            //    (result) => {
            //        alert("Success");
            //        this.societyRegisterStep2Model.Initialized = true;
            //        this.$location.path('society/register/confirm');
            //    }, (result) => { alert("Failure"); }, (result) => { alert("Always")});
        };
        SocietyRegisterStep2ViewModel.inject = ['$window', 'viewModelHelper', '$location'];
        return SocietyRegisterStep2ViewModel;
    })(SocietyRegisterViewModel);
    angular.module('societyRegister')
        .controller('SocietyRegisterStep2ViewModel', SocietyRegisterStep2ViewModel);
    var SocietyRegisterConfirmViewModel = (function (_super) {
        __extends(SocietyRegisterConfirmViewModel, _super);
        function SocietyRegisterConfirmViewModel($window, viewModelHelper, $location) {
            _super.call(this, $window, viewModelHelper);
            this.$window = $window;
            this.viewModelHelper = viewModelHelper;
            this.$location = $location;
        }
        SocietyRegisterConfirmViewModel.prototype.createSociety = function () {
        };
        SocietyRegisterConfirmViewModel.inject = ['$window', 'viewModelHelper', '$location'];
        return SocietyRegisterConfirmViewModel;
    })(SocietyRegisterViewModel);
    angular.module('societyRegister')
        .controller('SocietyRegisterConfirmViewModel', SocietyRegisterConfirmViewModel);
})(SocietyMaster || (SocietyMaster = {}));
//# sourceMappingURL=SocietyRegisterViewModel.js.map