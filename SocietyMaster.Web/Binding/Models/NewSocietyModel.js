
(function(sm){
    var NewSocietyModel = function () {

        var self = this;
        self.Name = '';
        self.Description = '';
        self.Address = '';
        self.Locality = '';
        self.City = '';
        self.State = '';
        self.Zipcode = '';
        self.initialized = false;
    }
    sm.NewSocietyModel = NewSocietyModel;
}(window.SocietyMaster));