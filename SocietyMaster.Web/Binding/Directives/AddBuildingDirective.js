(function () {
    'use strict';
    angular
        .module('app.widgets', []);
})();
var SocietyMaster;
(function (SocietyMaster) {
    var app = angular.module('app.widgets');
    var AddBuilding = (function () {
        function AddBuilding() {
            this.templateUrl = '/Templates/AddBuilding.html';
            this.controller = 'addbuildingctrl';
            this.controllerAs = 'vm';
        }
        return AddBuilding;
    })();
    SocietyMaster.AddBuilding = AddBuilding;
    app.directive("addBuilding", [function () { return new SocietyMaster.AddBuilding(); }]);
    var BuildingModel = (function () {
        function BuildingModel() {
            this.Name = '';
        }
        return BuildingModel;
    })();
    SocietyMaster.BuildingModel = BuildingModel;
    var addbuildingctrl = (function () {
        function addbuildingctrl($scope, societyRegisterService) {
            this.$scope = $scope;
            this.societyRegisterService = societyRegisterService;
            // todo
            var vm = this;
            vm.buildingModel = new SocietyMaster.BuildingModel();
        }
        addbuildingctrl.prototype.add = function () {
            //ToDO: Add the building by calling the societyRegisterSerice-- And populate the in memory buiding model.
            //Close the modal
            // this.$scope.$close();
        };
        addbuildingctrl.$inject = ['$scope', 'societyRegisterService'];
        return addbuildingctrl;
    })();
    SocietyMaster.addbuildingctrl = addbuildingctrl;
    app.controller('addbuildingctrl', SocietyMaster.addbuildingctrl);
})(SocietyMaster || (SocietyMaster = {}));
//# sourceMappingURL=AddBuildingDirective.js.map