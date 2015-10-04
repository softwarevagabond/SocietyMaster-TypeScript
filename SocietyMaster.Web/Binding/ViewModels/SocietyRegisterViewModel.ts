//Create the Society Register Module
((): void => {
    angular.
        module('societyRegister', ['common']).config(routeConfig);

    function routeConfig($routeProvider: ng.route.IRouteProvider, $locationProvider :ng.ILocationProvider):void {

        $routeProvider.when('/society/register/step1', { templateUrl: '/Templates/RegisterSocietyStep1.html', controller: 'SocietyRegisterStep1ViewModel' ,controllerAs:"vm"});
        $routeProvider.when('/society/register/step2', { templateUrl: '/Templates/RegisterSocietyStep2.html', controller: 'SocietyRegisterStep2ViewModel',controllerAs:"vm"});
        $routeProvider.when('/society/register/confirm', { templateUrl: '/Templates/RegisterSocietyConfirm.html', controller: 'SocietyRegisterConfirmViewModel',controllerAs:"vm"});

        $routeProvider.otherwise({ redirectTo: '/society/register/step1' });     

        $locationProvider.html5Mode({enabled:true});
    }
})();  

module SocietyMaster {

    //ToDo: implement previous
    interface ISocietyRegisterViewModel {
        societyRegisterStep1Model: SocietyMaster.ISocietyRegisterStep1Model;
        societyRegisterStep2Model: SocietyMaster.ISocietyRegisterStep2Model;

       previous(): void;
        //For testing only - remove later
      
    }

    class SocietyRegisterViewModel implements ISocietyRegisterViewModel{

        societyRegisterStep1Model: SocietyMaster.ISocietyRegisterStep1Model;
        societyRegisterStep2Model: SocietyMaster.ISocietyRegisterStep2Model;
            
        static inject = ['$window', 'viewModelHelper'];

        constructor(protected $window: ng.IWindowService, public viewModelHelper: SocietyMaster.IViewModelHelper) {
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

        previous(): void {
            this.$window.history.back();          

        }   

    }

    angular.module('societyRegister')
        .controller('SocietyRegisterViewModel', SocietyRegisterViewModel);

    
    interface ISocietyRegisterStep1ViewModel {
        step2(): void;  
    }

    class SocietyRegisterStep1ViewModel extends SocietyRegisterViewModel implements ISocietyRegisterStep1ViewModel {


        private errors: string[];
        static inject = ['$window', 'viewModelHelper','$location']
        constructor(protected $window: ng.IWindowService, public viewModelHelper: SocietyMaster.IViewModelHelper,
            private $location: ng.ILocationService) {
           
            super($window, viewModelHelper);
        
            if (this.societyRegisterStep1Model != null) {
                alert(this.societyRegisterStep1Model.Name);
                
            }
            var vm = this;
            this.societyRegisterStep1Model = new SocietyMaster.SocietyRegisterStep1Model();          
                    
        }

        ValidateStep1(societyRegisterStep1Model: SocietyMaster.SocietyRegisterStep1Model): void {
            this.errors = [];
            if (societyRegisterStep1Model.Name.trim() == '') {
                this.errors.push("Name is required");                
            }
            //todo: Add other validations -- Do we need the local variable errors?? can directly use societyRegisterStep1Model.Errors??
            
            societyRegisterStep1Model.Errors = this.errors;
            societyRegisterStep1Model.IsValid = (this.errors.length == 0);     
        }

        step2(): void {
           //ToDo:Handle Falure and also change the signature for Failure to may be optional...
           
            //todo: For testing only
           
          //  this.$location.path('/society/register/step2');
           // console.log(this.$location.path());
            alert(this.societyRegisterStep1Model.Name);
            this.ValidateStep1(this.societyRegisterStep1Model);
            this.viewModelHelper.modelIsValid = this.societyRegisterStep1Model.IsValid;
            this.viewModelHelper.modelErrors = this.societyRegisterStep1Model.Errors;
            alert(this.viewModelHelper.modelErrors);
            if (this.viewModelHelper.modelIsValid) {
                this.viewModelHelper.apiPost('api/society/register/validate1', this.societyRegisterStep1Model,
                    (result) => {
                        this.societyRegisterStep1Model.Initialized = true;
                        alert("afte serve trip"+this.societyRegisterStep1Model.Name)
                        this.$location.path('/society/register/step2');
                        //Todo: update the service -> step1 model 
                    }, (result) => { }, (result) => { });
            }           
        }        
    }
    angular.module('societyRegister')
        .controller('SocietyRegisterStep1ViewModel', SocietyRegisterStep1ViewModel);


    interface ISocietyRegisterStep2ViewModel {
        previous(): void;
        confirm(): void;
    }

    class SocietyRegisterStep2ViewModel extends SocietyRegisterViewModel implements ISocietyRegisterStep2ViewModel {

        static inject = ['$window', 'viewModelHelper', '$location']
        constructor(protected $window: ng.IWindowService, public viewModelHelper: SocietyMaster.IViewModelHelper,
            private $location: ng.ILocationService) {            
            super($window, viewModelHelper);
            var vm = this;
            this.societyRegisterStep2Model = new SocietyMaster.SocietyRegisterStep2Model();
           // alert(this.societyRegisterStep1Model.Name);
            //ToDO: Like in step1 - assgn the service -> step2
        }

        previous(): void {
             //alert("Back");
            //this.$window.history.back();
            //console.log(this.$location.path());
            super.previous();
        }
        confirm(): void {
            alert("confirm");
            //ToDo:Handle Falure and also change the signature for Failure to may be optional...
            //this.viewModelHelper.apiPost('api/society/register/validate2', this.societyRegisterStep2Model,
            //    (result) => {
            //        alert("Success");
            //        this.societyRegisterStep2Model.Initialized = true;
            //        this.$location.path('society/register/confirm');
            //    }, (result) => { alert("Failure"); }, (result) => { alert("Always")});

        }
    }
    angular.module('societyRegister')
        .controller('SocietyRegisterStep2ViewModel', SocietyRegisterStep2ViewModel);
         

    interface ISocietyRegisterConfirmViewModel {
        createSociety(): void;
    }

    class SocietyRegisterConfirmViewModel extends SocietyRegisterViewModel implements ISocietyRegisterConfirmViewModel {

        static inject = ['$window', 'viewModelHelper', '$location']
        constructor(protected $window: ng.IWindowService, public viewModelHelper: SocietyMaster.IViewModelHelper,
            private $location: ng.ILocationService) {
            super($window, viewModelHelper);
        }
        createSociety(): void {
        }
    }
    angular.module('societyRegister')
        .controller('SocietyRegisterConfirmViewModel', SocietyRegisterConfirmViewModel);
}