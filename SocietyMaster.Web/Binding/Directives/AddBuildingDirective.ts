((): void => {
    'use strict';

    angular
        .module('app.widgets', []);
})();

module SocietyMaster {

    var app = angular.module('app.widgets');

    export class AddBuilding implements ng.IDirective {
        public templateUrl: string = '/Templates/AddBuilding.html';
        public controller: string = 'addbuildingctrl';
        public controllerAs: string = 'vm';
       }
    
   app.directive("addBuilding", [() => new SocietyMaster.AddBuilding()]);
      
    export interface IBuildingModel {
        Name: string;
        //Todo: Add other properties as needed
    }

    export class BuildingModel implements IBuildingModel {
        Name: string;     

        constructor() {
            this.Name = '';
            
        }
    }


    export class addbuildingctrl {
        static $inject = ['$scope', 'societyRegisterService'];
        buildingModel: SocietyMaster.BuildingModel;
        constructor(protected $scope: ng.IScope,
            protected societyRegisterService: SocietyMaster.SocietyRegisterService ) {
            // todo
            var vm = this;
            vm.buildingModel = new SocietyMaster.BuildingModel();
        }
        public add(): void {
           //ToDO: Add the building by calling the societyRegisterSerice-- And populate the in memory buiding model.
            //Close the modal
            
           // this.$scope.$close();
            
        }
    }
    app.controller('addbuildingctrl', SocietyMaster.addbuildingctrl);
}