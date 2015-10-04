
(function (sm) {
    var SocietyRegisterModeStep1 = function () {
        var self = this;
        self.Name = '';
        self.Description = '';
        self.Address = '';
        self.Locality = '';
        self.City = '';
        self.State = '';
        self.ZipCode = '';

        self.Initialized = false;
    }
    sm.SocietyRegisterModeStep1 = SocietyRegisterModeStep1;
}(window.SocietyMaster));


(function (sm) {
    var SocietyRegisterModeStep2 = function () {
        var self = this;
        //ToDO: Add the other properties

        //For testing 
        self.Name = '';
        self.Initialized = false;
    }
    sm.SocietyRegisterModeStep2 = SocietyRegisterModeStep2;
}(window.SocietyMaster));