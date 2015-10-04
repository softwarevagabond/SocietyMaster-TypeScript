//ToDO: Get more of the functionality moved from the ViewModel to the service
var SocietyMaster;
(function (SocietyMaster) {
    var SocietyRegisterService = (function () {
        function SocietyRegisterService() {
            this.societyRegisterStep1Model = new SocietyMaster.SocietyRegisterStep1Model();
            this.societyRegisterStep2Model = new SocietyMaster.SocietyRegisterStep2Model();
        }
        SocietyRegisterService.prototype.setRegisterStep1Model = function (societyRegisterStep1Model) {
            this.societyRegisterStep1Model = societyRegisterStep1Model;
        };
        SocietyRegisterService.prototype.setRegisterStep2Model = function (societyRegisterStep2Model) {
            this.societyRegisterStep2Model = societyRegisterStep2Model;
        };
        SocietyRegisterService.prototype.getRegisterStep1Model = function () {
            return this.societyRegisterStep1Model;
        };
        SocietyRegisterService.prototype.getRegisterStep2Model = function () {
            return this.societyRegisterStep2Model;
        };
        return SocietyRegisterService;
    })();
    SocietyMaster.SocietyRegisterService = SocietyRegisterService;
    //Todo: May be ceate a new module if needed...
    angular.module('common').service('societyRegisterService', SocietyRegisterService);
})(SocietyMaster || (SocietyMaster = {}));
//# sourceMappingURL=SocietyRegisterService.js.map