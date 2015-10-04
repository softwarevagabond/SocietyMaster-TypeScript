var SocietyMaster;
(function (SocietyMaster) {
    var SocietyRegisterStep1Model = (function () {
        function SocietyRegisterStep1Model() {
            this.Name = '';
            this.Description = '';
            this.Address = '';
            this.Locality = '';
            this.City = '';
            this.State = '';
            this.ZipCode = '';
            this.Initialized = false;
            this.Errors = [];
            this.IsValid = true;
        }
        return SocietyRegisterStep1Model;
    })();
    SocietyMaster.SocietyRegisterStep1Model = SocietyRegisterStep1Model;
    var SocietyRegisterStep2Model = (function () {
        function SocietyRegisterStep2Model() {
            this.Name = '';
            this.Initialized = false;
        }
        return SocietyRegisterStep2Model;
    })();
    SocietyMaster.SocietyRegisterStep2Model = SocietyRegisterStep2Model;
})(SocietyMaster || (SocietyMaster = {}));
//# sourceMappingURL=SocietyRegisterModel.js.map